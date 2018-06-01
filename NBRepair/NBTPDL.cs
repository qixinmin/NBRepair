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
    public partial class NBTPDL : Form
    {
        public NBTPDL()
        {
            InitializeComponent();
        }

        private void TNBSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.TNBSerial.Text != "")
                {
                    //this.TPORT.Focus();
                    // TPORT.bat  UUID MAC.bat  
                    SqlConnection conn = new SqlConnection(Conlist.ConStr);
                    conn.Open();
                    string NBSN = "", UUID = "", MBMAC = "", MBSN = "",MTM="";

                    if (conn.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        string tableName = "NBShouLiao";
                        cmd.CommandText = "select *  from " + tableName + " where NBSerial = '" + this.TNBSerial.Text.Trim().ToUpper() + "' or NBID = '" + this.TNBSerial.Text.Trim().ToUpper() + "'or NewNBSerial = '" + this.TNBSerial.Text.Trim().ToUpper() + "' ";
                        SqlDataReader querySdr = cmd.ExecuteReader();

                        while (querySdr.Read())
                        // if (querySdr.HasRows == true)
                        {
                            NBSN = querySdr["NBSN"].ToString();
                            UUID = querySdr["UUID"].ToString();
                            MBMAC = querySdr["MBMAC"].ToString();
                            MBSN = querySdr["MBSN"].ToString();

                            MTM = querySdr["SKU"].ToString();

                            //MessageBox.Show(NBSN + "    " + MBMAC);
                        }
                        querySdr.Close();
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        // querySdr = cmd.ExecuteReader();
                        string st = "TPDL";
                        cmd.CommandText = "update " + tableName + " set Status = '" + st
                                  + "' where NBID = '" + this.TNBSerial.Text.Trim().ToUpper()
                                  + "' or NBSerial = '" + this.TNBSerial.Text.Trim().ToUpper() + "'";

                        cmd.ExecuteNonQuery();
                        querySdr.Close();
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                       
                        string path = @"Z:\\MAC\\";
                        string str = "SET PORTID=" + this.TPORT.Text.Trim().ToUpper();
                        string MACNAME = "";
                        if (MBMAC != "")
                        {
                            MACNAME = MBMAC;
                        }
                        else if (UUID != "")
                        {
                            MACNAME = UUID;
                        }
                        else
                        {
                            MessageBox.Show("UUID and MAC 都是空的！！");
                            return;
                        }
                        Conlist.WriteStrBatFile(path, MACNAME, str);
                        path = @"Z:\\PORT\\" + this.TPORT.Text.Trim().ToUpper() + "\\";

                        tableName = "BOMCompare";

                      //  MTM = "20JNA04TCD";

                     
                        cmd.CommandText = "select *  from " + tableName + " where TOPIC_ITEM = 'M/B'  and SKU_LNO='" + MTM + "' ";
                        querySdr = cmd.ExecuteReader();

                        string SWIDNUM = "", MBPN = "";
                        while (querySdr.Read())
                        // if (querySdr.HasRows == true)
                        {
                            SWIDNUM = querySdr["SKU_NO"].ToString();
                            MBPN = querySdr["LCFC_PN"].ToString();
                        }
                       // MessageBox.Show(SWIDNUM);
                        querySdr.Close();
                        // SET RAMCOUNT=1  bom 
                        // SET HDDCOUNT=1    SET MBPN=45110301101

                        string totalStr = "SET DBMAC=" + MBMAC + "\r\n"
                                             + "SET MTM=" + MTM + "\r\n"
                                             + "SET UUID=" + UUID + "\r\n"
                                             + "SET SWIDNUM=" + SWIDNUM + "\r\n"
                                             + "SET MBPN=" + MBPN + "\r\n"
                                             + "SET SSN=" + "TR" + NBSN.Substring(2, 6) + "\r\n";
                        Conlist.WriteStrBatFile(path, "TPORT", totalStr);
                        MessageBox.Show(MACNAME + "   上架   " + this.TPORT.Text.Trim().ToUpper() + "    OK");
                        cmd.Dispose();

                        this.TNBSerial.Text = "";
                        this.TPORT.Text = "";
                        conn.Close();



                    }
                    else
                    {
                        this.TNBSerial.Focus();
                    }
                }
            }
        }

        private void TPORT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.TPORT.Text != "")
                {
                    this.TNBSerial.Focus();
                    // TPORT.bat  UUID MAC.bat  

                }
                else
                {
                    this.TPORT.Focus();
                }
            }
        }

        private void SNBSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.SPORT.Text != "")
                {
                    SqlConnection conn = new SqlConnection(Conlist.ConStr);
                    conn.Open();
                    string NBSN = "", UUID = "", MBMAC = "", MBSN = "", MTM = "";
                    if (conn.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        string tableName = "NBShouLiao";
                        cmd.CommandText = "select *  from " + tableName + " where NewNBSerial = '" + this.SNBSerial.Text.Trim().ToUpper() + "' or NBID = '" + this.SNBSerial.Text.Trim().ToUpper() + "' or NBSerial = '" + this.SNBSerial.Text.Trim().ToUpper() + "' ";
                        SqlDataReader querySdr = cmd.ExecuteReader();

                        while (querySdr.Read())
                        // if (querySdr.HasRows == true)
                        {
                            NBSN = querySdr["NBSN"].ToString();
                            UUID = querySdr["UUID"].ToString();
                            MBMAC = querySdr["MBMAC"].ToString();
                            MBSN = querySdr["MBSN"].ToString();
                            MTM = querySdr["SKU"].ToString();
                        }
                        querySdr.Close();
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        // querySdr = cmd.ExecuteReader();
                        string st = "SWDL";
                        cmd.CommandText = "update " + tableName + " set Status = '" + st
                                  + "' where NBID = '" + this.SNBSerial.Text.Trim().ToUpper()
                                  + "' or NBSerial = '" + this.SNBSerial.Text.Trim().ToUpper() + "'";

                        cmd.ExecuteNonQuery();
                        querySdr.Close();
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        
                        string path = @"Z:\\MAC\\";
                        string str = "SET PORTID=" + this.SPORT.Text.Trim().ToUpper();
                        string MACNAME = "";
                        if (MBMAC != "")
                        {
                            MACNAME = MBMAC;
                        }
                        else if (UUID != "")
                        {
                            MACNAME = UUID;
                        }
                        else
                        {
                            MessageBox.Show("UUID and MAC 都是空的！！");
                            return;
                        }
                        Conlist.WriteStrBatFile(path, MACNAME, str);
                        path = @"Z:\\PORT\\" + this.SPORT.Text.Trim().ToUpper() + "\\";


                        tableName = "BOMCompare";

                      //  MTM = "20JNA04TCD";
                        cmd.CommandText = "select *  from " + tableName + " where TOPIC_ITEM = 'M/B'  and SKU_LNO='" + MTM + "' ";
                        querySdr = cmd.ExecuteReader();

                        string SWIDNUM = "", MBPN = "";
                        while (querySdr.Read())
                        // if (querySdr.HasRows == true)
                        {
                            SWIDNUM = querySdr["SKU_NO"].ToString();
                            MBPN = querySdr["LCFC_PN"].ToString();
                        }
                       // MessageBox.Show(SWIDNUM);
                        querySdr.Close();
                       // SET RAMCOUNT=1  bom 
                        // SET HDDCOUNT=1    SET MBPN=45110301101

                        string totalStr = "SET DBMAC=" + MBMAC + "\r\n"
                                             + "SET MTM=" + MTM + "\r\n"
                                             + "SET UUID=" + UUID + "\r\n"
                                             + "SET SWIDNUM=" + SWIDNUM + "\r\n"  //  4t
                                             + "SET MBPN=" + MBPN + "\r\n"
                                             + "SET SSN=" + "TR" + NBSN.Substring(2, 6) + "\r\n";
                        Conlist.WriteStrBatFile(path, "SPORT", totalStr);
                        MessageBox.Show(MACNAME + "   上架   " + this.SPORT.Text.Trim().ToUpper() + "    OK");
                        this.SNBSerial.Text = "";
                        this.SPORT.Text = "";
                        cmd.Dispose();
                        conn.Close();

                    }
                    else
                    {
                        this.SPORT.Focus();
                    }
                }
            }
        }

        private void SPORT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.SPORT.Text != "")
                {
                    this.SNBSerial.Focus();
                }
                else
                {
                    this.SPORT.Focus();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "Z")
            {
                MessageBox.Show("begin Port 001--199   OK  !");
                string pp = this.textBox1.Text.Trim();

                string path = pp+":\\MAC\\";
                CodeSoft.MakePath(path);
                path =  pp + ":\\PORT\\";
                CodeSoft.MakePath(path);
                for (int i = 1; i < 200; i = i + 1)
                {
                    path =  pp + ":\\PORT\\" +"P"+ i.ToString("000") + "\\";

                    CodeSoft.MakePath(path);
                }
                MessageBox.Show("Make Port 001--199   OK  !");
            }
        }

        private void NBTPDL_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = "Z";
        }

      

        

      
    }
}
