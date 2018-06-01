using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NBRepair
{
    public partial class BOM : Form
    {

        public Microsoft.Office.Interop.Excel.Application app;
        public Microsoft.Office.Interop.Excel.Workbooks wbs;
        public Microsoft.Office.Interop.Excel.Workbook wb;
        public Microsoft.Office.Interop.Excel.Worksheets wss;
        public Microsoft.Office.Interop.Excel.Worksheet ws;
        public BOM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();

            string fileName = openFileDialog.FileName;
           

            if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx"))
            {
                filePath.Text = fileName;
                importButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("请输入正确的xls文件 并选择正确的import目标!");
            }
            string a = fileName.Split('\\')[fileName.Split('\\').Length-1].Split ('.')[0];
            MessageBox.Show(a);
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            string sheetName = "BOM";
            string tableName = "BOMCompare";

            string mtm = filePath.Text.Trim().Split('\\')[filePath.Text.Split('\\').Length - 1].Split('.')[0];
             SqlConnection conn = new SqlConnection(Conlist.ConStr);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete   from " + tableName + " where SKU_LNO = '" + mtm + "'";
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            importLCFC_MBBOMUsingADO(sheetName, tableName);
           
        }
       

        public void importLCFC_MBBOMUsingADO(string sheetName, string tableName)
        {
            DataSet ds = new DataSet();
            try
            {
                //获取全部数据
                string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath.Text + ";Extended Properties=Excel 12.0;";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                string strExcel = "";
                OleDbDataAdapter myCommand = null;
                strExcel = string.Format("select * from [{0}$]", sheetName);
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                myCommand.Fill(ds, sheetName);

                //用bcp导入数据
                using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(Conlist.ConStr))
                {
                    // bcp.SqlRowsCopied += new System.Data.SqlClient.SqlRowsCopiedEventHandler(bcp_SqlRowsCopied);
                    bcp.BatchSize = 100;//每次传输的行数
                    bcp.NotifyAfter = 100;//进度提示的行数
                    bcp.DestinationTableName = tableName;//目标表
                    //客户机器物料编号	机型	配置说明	类别	说明	厂商料号	客户料号	classcode	数据说明	数量	用途	厂商型号	硬盘数量	SSD数量	内存数量	机器颜色

                    bcp.ColumnMappings.Add("SKU_LNO", "SKU_LNO");
                    bcp.ColumnMappings.Add("SKU_NO", "SKU_NO");
                    bcp.ColumnMappings.Add("KEY_TOPIC", "KEY_TOPIC");
                    bcp.ColumnMappings.Add("TOPIC_ITEM", "TOPIC_ITEM");
                    bcp.ColumnMappings.Add("ITEM_DESCRIPTION", "ITEM_DESCRIPTION");

                    bcp.ColumnMappings.Add("LCFC_PN", "LCFC_PN");

                    bcp.ColumnMappings.Add("LNV_PN", "LNV_PN");

                    bcp.ColumnMappings.Add("KP_QTY", "KP_QTY");
                    bcp.ColumnMappings.Add("KP_REL", "KP_REL");

                    bcp.ColumnMappings.Add("REMARK", "REMARK");
                    bcp.ColumnMappings.Add("INDICATOR_TYPE", "INDICATOR_TYPE");
                    bcp.ColumnMappings.Add("PARENT_PN", "PARENT_PN");
                    bcp.ColumnMappings.Add("GRAND_PN", "GRAND_PN");
                    bcp.ColumnMappings.Add("ACTION_TYPE", "ACTION_TYPE");
                    bcp.ColumnMappings.Add("STEP_SEQUENCE", "STEP_SEQUENCE");
                  

                    bcp.WriteToServer(ds.Tables[0]);
                    bcp.Close();

                    conn.Close();
                    MessageBox.Show("导入完成");
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
