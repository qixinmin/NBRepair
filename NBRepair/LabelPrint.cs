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
    public partial class LabelPrint : Form
    {

       
        public LabelPrint()
        {
            InitializeComponent();
        }

        private void NBSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.NBSerial.Text.Trim() != "")
                {
                    SqlConnection conn = new SqlConnection(Conlist.ConStr);
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        string tableName = "NBShouLiao";
                        cmd.CommandText = "select *  from " + tableName + " where NBSerial = '" + this.NBSerial.Text.Trim().ToUpper() + "' or NBID = '" + this.NBSerial.Text.Trim().ToUpper() + "' ";
                        SqlDataReader querySdr = cmd.ExecuteReader();
                        while (querySdr.Read())
                        // if (querySdr.HasRows == true)
                        {

                            // GetKeyPartsBOM("20JNA04TCD");
                            this.label1.Text = querySdr["Model"].ToString();

                        }
                        querySdr.Close();
                        cmd.Dispose();
                    }
                }

                this.NBSerial.SelectionStart = 0;
                this.NBSerial.SelectionLength = 0;
                this.NBSerial.SelectAll();
                this.NBSerial.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.NBSerial.Text != "")
            {
                SqlConnection conn = new SqlConnection(Conlist.ConStr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    string tableName = "NBShouLiao";
                    cmd.CommandText = "select *  from " + tableName + " where NBSerial = '" + this.NBSerial.Text.Trim() + "' or NBID = '" + this.NBSerial.Text.Trim() + "'or NewNBSerial = '" + this.NBSerial.Text.Trim() + "' ";
                    SqlDataReader querySdr = cmd.ExecuteReader();
                    string SKU = ""; 
                    string newnbserial = "";
                    while (querySdr.Read())
                    {
                        SKU = querySdr["SKU"].ToString();
                        newnbserial = querySdr["NewNBSerial"].ToString();
                    } 
                  //  MessageBox.Show(newnbserial);
                    querySdr.Close();
                    tableName = "RatingLabel";
                    cmd.CommandText = "select *  from " + tableName + " where 料号 = '" + SKU + "' ";
                    querySdr = cmd.ExecuteReader();
                    bool lihao = false;
                    
                    string volat = "";//
                    string current = "";
                    string model = "";
                   
                    string CMIIT = "";
                    while (querySdr.Read())
                    {
                        
                            lihao = true;
                            volat = querySdr["电压"].ToString();
                            current = querySdr["电流"].ToString();
                            model = querySdr["机型"].ToString();
                            CMIIT = querySdr["CMIIT"].ToString();
                        
                    }
                   // MessageBox.Show(volat +"      "+current);
                    if (lihao == true)
                    {
                        string date = System.DateTime.Now.Year.ToString().Substring(2, 2) + "/" + System.DateTime.Now.Month.ToString("00");

                        CodeSoft.POD.Variables.FormVariables.Item("SSN").Value = "TYPE " + SKU.Substring(0, 4) + "-" + SKU.Substring(4, 6) + "  S/N  TR" + newnbserial.Substring(14, 6) + "  " + date;
                        CodeSoft.POD.Variables.FormVariables.Item("BARCODE").Value = newnbserial;
                        CodeSoft.POD.Variables.FormVariables.Item("电压值").Value = volat;
                        CodeSoft.POD.Variables.FormVariables.Item("电流值").Value = current;
                        CodeSoft.POD.Variables.FormVariables.Item("型号").Value = model;
                        CodeSoft.POD.Variables.FormVariables.Item("CMIITID").Value = CMIIT;
                        //CodeSoft.POD.Variables.FormVariables.Item("Date").Value =System.DateTime.Now .Year .ToString ().Substring (2,2)+"/"+System.DateTime.Now 
                        CodeSoft.POD.Printer.SwitchTo("POD");
                        CodeSoft.POD.PrintDocument(); //打印一次
                        CodeSoft.POD.FormFeed(); //结束打印
                        
                    }
                    querySdr.Close();
                    conn.Close();
                }
            }
            else
            {

                MessageBox.Show(" NO  Serial!");

            }
            this.NBSerial.Text = ""; this.NBSerial.Focus();

        }

        private void LabelPrint_Load(object sender, EventArgs e)
        {
            CodeSoft.initCodesoftModel(CodeSoft.PODModel);
           // CodeSoft.initCodesoftModel(CodeSoft.T470P , CodeSoft.T470PModel );
           // CodeSoft.initCodesoftModel(CodeSoft.T470 , CodeSoft.T470Model );



        }

       

       
    }
}
