using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NBRepair
{
    public partial class StockOut : Form
    {
        public StockOut()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                string tablename = "ChuKu";
                SqlConnection mConn = new SqlConnection(Conlist.ConStr);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = mConn;


                cmd.CommandText = "select * from " + tablename + " where chukudate = '" + System.DateTime.Today.ToShortDateString() + "'";

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds, tablename);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.RowHeadersVisible = false;
                //dataGridView1.ColumnHeadersVisible = false;


                EXCELIO excel = new EXCELIO();
                string path = @"D:\出库材料";

                CodeSoft.MakePath(path);
                string filename = @"D:\出库材料\" + System.DateTime.Today.ToShortDateString().Replace("/", "-") + "的材料出库" + ".xlsx";
                bool ok = excel.ExportExcel(System.DateTime.Today.ToShortDateString().Replace("/", "-") + "材料出库明细", ds.Tables[0], filename);
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

                string tablename = "ChuKu";
                SqlConnection mConn = new SqlConnection(Conlist.ConStr);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = mConn;

                // MessageBox.Show(dateTimePicker1.Value.Date.ToShortDateString());
                cmd.CommandText = "select * from " + tablename + " where chukudate between '" + dateTimePicker1.Value.Date + "' and '" + dateTimePicker2.Value.Date + "'";
                //  cmd.CommandText = "select NBSerial,NewNBSerial, Model ,ShipDate,Status from " + tablename + " where ShipDate = '" + dateTimePicker1.Value.Date +"'";

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds, tablename);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.RowHeadersVisible = false;
                EXCELIO excel = new EXCELIO();
                string path = @"D:\出库材料";

                CodeSoft.MakePath(path);
                string filename = dateTimePicker1.Value.Date.ToShortDateString().Replace("/", "-") + "到" + dateTimePicker2.Value.Date.ToShortDateString().Replace("/", "-") + "出库明细" + ".xlsx";
                bool ok = excel.ExportExcel(dateTimePicker1.Value.Date.ToShortDateString() + "到" + dateTimePicker2.Value.Date.ToShortDateString() + "出库明细", ds.Tables[0], @"D:\出库材料\" + filename);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.countfile.Text != "" && this.countfile.Text != "" && this.countfile.Text != "" && this.countfile.Text != "" && this.countfile.Text != "")
            {
                SqlConnection conn = new SqlConnection(Conlist.ConStr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    string tableName = "ChuKu";
                    //SqlDataReader querySdr = cmd.ExecuteReader();
                    cmd.CommandText = "INSERT INTO " + tableName + " (countfile,partsno,qty,price,keyinman,chukudate)  VALUES('" +
                    this.countfile.Text.Trim() + "','" +
                    this.partsno.Text.Trim() + "','" +
                    this.qty.Text.Trim() + "','" +
                    this.price.Text.Trim().ToUpper() + "','" +
                    this.keyinman.Text.Trim().ToUpper() + "','" +
                     System.DateTime.Today.ToShortDateString() +
                     "')";
                    //querySdr.Close();
                    cmd.ExecuteNonQuery();


                    //update 料号数量
                    cmd.CommandText = "select number from materialhouse where materialNo='" + this.partsno.Text.Trim() + "'";
                    SqlDataReader querySdr = cmd.ExecuteReader();
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
                        int thistotal = totalLeft - Int32.Parse(this.qty.Text.Trim());

                        if (thistotal < 0)
                        {
                            conn.Close();
                            MessageBox.Show("数量不够，不能出库！");
                            return;
                        }
                        
                        cmd.CommandText = "update materialhouse set number = '" + thistotal + " where materialNo='" + this.partsno.Text.Trim() + "'";                     

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    MessageBox.Show("New Save OK");
                    Clear();
                    cmd.Dispose();
                }
                conn.Close();
                queryLastesttoday();
            }
        }
        public void Clear()
        {
            this.price.Text = ""; this.partsno.Text = ""; this.partsno.Text = ""; this.qty.Text = "";

        }
        public void queryLastesttoday()
        {
            try
            {
                SqlConnection mConn = new SqlConnection(Conlist.ConStr);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = mConn;
                string tableName = "ChuKu";
                cmd.CommandText = "select * from " + tableName + " where chukuDate = '" + System.DateTime.Today.ToString("yyyy-MM-dd") + "'";

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
    }
}
