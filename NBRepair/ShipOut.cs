using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;

namespace NBRepair
{
    public partial class ShipOut : Form
    {
        public ShipOut()
        {
            InitializeComponent();
        }

        private void NewNBSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.NewNBSerial.Text != "")
                {
                    SqlConnection conn = new SqlConnection(Conlist.ConStr);
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        string tableName = "NBShouLiao";
                        string nbserial = this.NewNBSerial.Text.Trim();
                        cmd.CommandText = "select *  from " + tableName + " where NewNBSerial = '" + nbserial + "' or NBID = '" + nbserial + "' ";
                        SqlDataReader querySdr = cmd.ExecuteReader();
                        string vender = "", customer = "", NBID = "", Model = "", NBSerial = "";
                        bool findok = false;
                        while (querySdr.Read())
                        {
                            findok = true;
                            vender = querySdr["vendor"].ToString(); 
                            customer = querySdr["customer"].ToString(); 
                            NBID = querySdr["NBID"].ToString(); 
                            NBSerial = querySdr["NewNBSerial"].ToString();
                            Model = querySdr["Model"].ToString();
                        }
                        if (findok == true)
                        {
                            cmd.CommandText = "update " + tableName + " set ShipDate ='" + System.DateTime.Now.ToShortDateString()
                                               + "',Status = ' " + checkBox1.Text + ""
                                             + "' where NewNBSerial = '" + nbserial + "' or NBID = '" + nbserial + "' ";

                            querySdr.Close();
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("没有这个料号");
                            this.NewNBSerial.Focus();
                        }

                        if (findok == true)
                        {
                            tableName = "OUTNBCHUKU";
                            cmd.CommandText = "select *  from " + tableName + " where NBID = '" + NBID
                            + "' or NBSerial = '" + NBSerial + "'";
                            querySdr = cmd.ExecuteReader();
                            if (querySdr.HasRows == true)
                            {
                                cmd.CommandText = "update " + tableName + " set vender = '" + vender
                                          + "',customer = '" + customer + " "
                                          + "', NBID = '" + NBID + " "
                                          + "',NBSerial = '" + NBSerial + " "
                                          + "',Model = '" + Model + " "
                                          + "' where NBID = '" + NBID
                                          + "' or NBSerial = '" + NBSerial + "'";
                                querySdr.Close();
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                cmd.CommandText = "INSERT INTO " + tableName + " (vender,customer,NBID,NBSerial,Model,qty,chukudate)  VALUES('" +
                                    vender + "','" +
                                    customer + "','" +
                                    NBID + "','" +
                                    NBSerial + "','" +
                                    Model + "','" +
                                    1 + "','" +
                                    //System.DateTime.Today.ToShortDateString() +
                                    "1900/01/01" +//采用默认值，等更新海关资料的时候再更新时间
                                    "')";
                                querySdr.Close();
                                cmd.ExecuteNonQuery();

                                //此时对材料进行操作，因为之前的材料一直被更新，不能确定，所以放在出库来确定更新, 满足条件的是会产生不良品
                                cmd.CommandText = "select partsno from ChuKu where countfile ='" + NBID + "' and keyinman != countfile";
                                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                                List<string> usedPartsNo = new List<string>();
                                while (sqlDataReader.Read())
                                {
                                    usedPartsNo.Add(sqlDataReader[0].ToString().Trim());
                                }
                                sqlDataReader.Close();

                                foreach (string partsno in usedPartsNo)
                                {
                                    //更新料号数量
                                    //string partsno = str[i].Substring(0, 11);
                                    cmd.CommandText = "select number from materialhouse where materialNo='" + partsno + "'";
                                    querySdr = cmd.ExecuteReader();
                                    string left_number = "";
                                    while (querySdr.Read())
                                    {
                                        left_number = querySdr[0].ToString();
                                        break;
                                    }
                                    querySdr.Close();

                                    if (left_number == null || left_number == "")
                                    {
                                        conn.Close();
                                        MessageBox.Show("此料号没有库存！");
                                        return;
                                    }

                                    try
                                    {
                                        int totalLeft = Int32.Parse(left_number);
                                        int thistotal = totalLeft - 1;

                                        if (thistotal < 0)
                                        {
                                            conn.Close();
                                            MessageBox.Show("数量不够，不能出库！");
                                            return;
                                        }

                                        cmd.CommandText = "update materialhouse set number = '" + thistotal + "' where materialNo='" + partsno + "'";
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }

                                    //对应的材料入不良品库
                                    //入不良品库记录
                                    cmd.CommandText = "INSERT INTO materialNgHouseRecord (materialNo,number,input_date)  VALUES('" +
                                        partsno + "','" +
                                        1 + "','" +
                                        System.DateTime.Today.ToShortDateString() +
                                     "')";
                                    cmd.ExecuteNonQuery();

                                    //更新不良品库数量
                                    cmd.CommandText = "select number from materialNgHouse where materialNo='" + partsno + "'";
                                    querySdr = cmd.ExecuteReader();
                                    bool exist = false;
                                    left_number = "";
                                    while (querySdr.Read())
                                    {
                                        left_number = querySdr[0].ToString();
                                        exist = true;
                                        break;
                                    }
                                    querySdr.Close();

                                    if (left_number == null || left_number == "")
                                    {
                                        left_number = "0";
                                    }

                                    try
                                    {
                                        int totalLeft = Int32.Parse(left_number);
                                        int thistotal = totalLeft + 1;

                                        if (exist)
                                        {
                                            cmd.CommandText = "update materialNgHouse set number = '" + thistotal + "' where materialNo='" + partsno + "'";
                                        }
                                        else
                                        {
                                            cmd.CommandText = "INSERT INTO materialNgHouse(number, materialNo) VALUES('" + thistotal + "','" + partsno + "')";
                                        }

                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }
                                }

                                //在打包的时候，也注意耗材的产生
                                cmd.CommandText = "select partsno,qty from ChuKu where countfile ='" + NBID + "' and keyinman = countfile";
                                sqlDataReader = cmd.ExecuteReader();
                                Dictionary<string, string> material_num = new Dictionary<string, string>();
                                while (sqlDataReader.Read())
                                {
                                    material_num.Add(sqlDataReader[0].ToString().Trim(), sqlDataReader[1].ToString().Trim());
                                }
                                sqlDataReader.Close();

                                foreach (string partsno in material_num.Keys)
                                {
                                    //更新料号数量
                                    //string partsno = lcfcpn;
                                    cmd.CommandText = "select number from materialhouse where materialNo='" + partsno + "'";
                                    querySdr = cmd.ExecuteReader();
                                    string left_number = "";
                                    while (querySdr.Read())
                                    {
                                        left_number = querySdr[1].ToString();
                                        break;
                                    }
                                    querySdr.Close();

                                    if (left_number == null || left_number == "")
                                    {
                                        conn.Close();
                                        MessageBox.Show("此料号没有库存！");
                                        return;
                                    }

                                    try
                                    {
                                        int totalLeft = Int32.Parse(left_number);
                                        int thistotal = totalLeft - Int32.Parse(material_num[partsno]);

                                        if (thistotal < 0)
                                        {
                                            conn.Close();
                                            MessageBox.Show("数量不够，不能出库！");
                                            return;
                                        }

                                        cmd.CommandText = "update materialhouse set number = '" + thistotal + " where materialNo='" + partsno + "'";
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }
                                }
                            }
                            cmd.Dispose();
                        }
                    }
                    conn.Close();
                }
                this.NewNBSerial.SelectionStart = 0;
                this.NewNBSerial.SelectionLength = 0;
                this.NewNBSerial.SelectAll();
                this.NewNBSerial.Focus();
            }
            else
            {
                this.NewNBSerial.Focus();
            }
            queryLastesttoday();
        }
        private void queryLastesttoday()
        {
            try
            {
                SqlConnection mConn = new SqlConnection(Conlist.ConStr);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = mConn;
                string tableName = "NBShouLiao";
                cmd.CommandText = "select NBSerial, Model ,NewNBSerial,ShipDate,Status from " + tableName + " where ShipDate = '" + System.DateTime.Today.ToString("yyyy-MM-dd") + "'";

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds, tableName);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.RowHeadersVisible = false;
                mConn.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "不良品";

            }
            else
            {
                checkBox1.Text = "良品";
            }
        }

        public bool DataSetToExcel(DataSet dataSet, string fileName, bool isShowExcle)
        {
            DataTable dataTable = dataSet.Tables[0];
            DataRow dr = dataTable.NewRow();

            int columnNumber = dataTable.Columns.Count;

            string[] hTxt = { "原机序号", "新机器序号", "型号", "出货日期", "状态" };
         //  dr.ItemArray = hTxt;

            dataTable.Rows.InsertAt(dr, 1);

            int rowNumber = dataTable.Rows.Count;//不包括字段名

            int colIndex = 0;

            if (rowNumber == 0)
            {
                MessageBox.Show("没有任何数据可以导入到Excel文件！");
                return false;
            }

            //建立Excel对象 
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //excel.Application.Workbooks.Add(true);
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            excel.Visible = false;
            //Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range;

            //生成字段名称 
            foreach (DataColumn col in dataTable.Columns)
            {
                colIndex++;
                excel.Cells[1, colIndex] = hTxt[colIndex-1];
            }
            object[,] objData = new object[rowNumber, columnNumber];
            for (int r = 0; r < rowNumber; r++)
            {
                for (int c = 0; c < columnNumber; c++)
                {
                    objData[r, c] = dataTable.Rows[r][c];
                }
            }

            // 写入Excel 
           // MessageBox.Show(rowNumber.ToString() + "    " + columnNumber.ToString ());
            range = worksheet.Range[excel.Cells[2, 1], excel.Cells[rowNumber, columnNumber]];
            range.NumberFormat = "@";//设置单元格为文本格式
            range.Value2 = objData;
            range.EntireColumn.AutoFit();//自动调整列宽

            range = worksheet.Range[excel.Cells[1, 4], excel.Cells[rowNumber, 4]];
            range.NumberFormat = @"yyyy-mm-dd";//
            range = worksheet.Range[excel.Cells[2, 1], excel.Cells[rowNumber, columnNumber]];
            range.Value2 = objData;
            worksheet.Name = fileName;
            string path = @"D:\出货";

            CodeSoft.MakePath(path);
            string fileNameFinally = @"D:\出货\" + fileName  + ".xlsx";
            workbook.SaveAs(fileNameFinally, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            try
            {
                workbook.Saved = true;
                excel.UserControl = false;
                //excelapp.Quit();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                workbook.Close(Microsoft.Office.Interop.Excel.XlSaveAction.xlSaveChanges, Missing.Value, Missing.Value);
                excel.Quit();
            }

            if (isShowExcle)
            {
                System.Diagnostics.Process.Start(fileNameFinally);
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                string tablename = "NBShouLiao";
                SqlConnection mConn = new SqlConnection(Conlist.ConStr);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = mConn;


                cmd.CommandText = "select NBSerial,NewNBSerial, Model ,ShipDate,Status from " + tablename + " where ShipDate = '" + System.DateTime.Today.ToShortDateString() + "'";

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds, tablename);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.RowHeadersVisible = false;
                //dataGridView1.ColumnHeadersVisible = false;

                string[] hTxt = {"原机序号", "新机器序号","型号","出货日期",
                                "状态"};
                for (int i = 0; i < hTxt.Length; i++)
                {
                    dataGridView1.Columns[i].HeaderText = hTxt[i];
                    // dataGridView1.Columns[i].Name = hTxt[i];
                }
                EXCELIO excel = new EXCELIO();
                string filename = @"D:\出货\" + System.DateTime.Today.ToShortDateString().Replace("/", "-") + "的出货" + ".xlsx";
                bool ok = excel.ExportExcel(System.DateTime.Today.ToShortDateString().Replace("/", "-") + "出货明细", ds.Tables[0], filename);
                if (ok == true)
                {
                    MessageBox.Show("导出OK!!");
                }
                else
                {
                    MessageBox.Show("导出 Fail !!");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                string tablename = "NBShouLiao";
                SqlConnection mConn = new SqlConnection(Conlist.ConStr);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = mConn;

                // MessageBox.Show(dateTimePicker1.Value.Date.ToShortDateString());
                cmd.CommandText = "select NBSerial,NewNBSerial, Model ,ShipDate,Status from " + tablename + " where ShipDate between '" + dateTimePicker1.Value.Date + "' and '" + dateTimePicker2.Value.Date + "'";
                //  cmd.CommandText = "select NBSerial,NewNBSerial, Model ,ShipDate,Status from " + tablename + " where ShipDate = '" + dateTimePicker1.Value.Date +"'";

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds, tablename);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.RowHeadersVisible = false;

                string[] hTxt = {"原机序号", "新机器序号","型号","出货日期",
                                "状态"};
                for (int i = 0; i < hTxt.Length; i++)
                {
                    dataGridView1.Columns[i].HeaderText = hTxt[i];
                    // dataGridView1.Columns[i].Name = hTxt[i];
                }
                EXCELIO excel = new EXCELIO();
                string filename = dateTimePicker1.Value.Date.ToShortDateString().Replace ("/","-") + "到" + dateTimePicker2.Value.Date.ToShortDateString().Replace ("/","-") + "出货明细" + ".xlsx";
                bool ok = excel.ExportExcel(dateTimePicker1.Value.Date.ToShortDateString() + "到" + dateTimePicker2.Value.Date.ToShortDateString() + "出货明细", ds.Tables[0], @"D:\出货\" + filename);
                if (ok == true)
                {
                    MessageBox.Show("导出OK!!");
                }
                else
                {
                    MessageBox.Show("导出 Fail !!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
