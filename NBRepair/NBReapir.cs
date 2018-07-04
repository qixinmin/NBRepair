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
    public partial class NBReapir : Form
    {
        public NBReapir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.NBSerial.Text.Trim() != "")
            {
                SqlConnection conn = new SqlConnection(Conlist.ConStr);
                conn.Open();
                SqlConnection conn1 = new SqlConnection(Conlist.ConStr);
                conn1.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    string tableName = "NBShouLiao";
                    cmd.CommandText = "select *  from " + tableName + " where NBSerial = '" + this.NBSerial.Text.Trim().ToUpper() + "'  or NBID = '" + this.NBSerial.Text.Trim().ToUpper() + "' ";
                    SqlDataReader querySdr = cmd.ExecuteReader();
                    bool ok = false;
                    string nbid = "";

                    while (querySdr.Read())
                    {
                        nbid = querySdr["NBID"].ToString();
                    }
                    querySdr.Close();

                    cmd.CommandText = "update " + tableName + " set BatterySN = '" + this.BatterySN.Text.Trim().ToUpper()

                            + "',BatterySN1 = '" + this.frontbattery.Text.Trim().ToUpper() + " "

                            + "',KBSN = '" + this.KBSN.Text.Trim().ToUpper() + " "
                            + "',OLDKBSN = '" + this.OLDKBSN.Text.Trim().ToUpper() + " "
                            + "',MBSN = '" + this.MBSN.Text.Trim().ToUpper() + " "
                             
                            + "',Memory1SN = '" + this.Memory1SN.Text.Trim().ToUpper() + " "
                            + "',Memory2SN = '" + this.Memory2SN.Text.Trim().ToUpper() + " "
                            + "',HDDSN = '" + this.HDDSN.Text.Trim().ToUpper() + " "
                            + "',SSDSN = '" + this.SSDSN.Text.Trim().ToUpper() + " "
                            + "',WLANSN = '" + this.WLANSN.Text.Trim().ToUpper() + " "
                             
                            + "',COVERSN = '" + this.COVERSN.Text.Trim().ToUpper() + " "

                            + "',OLDCOVERSN = '" + this.OLDCOVERSN.Text.Trim().ToUpper() + " "
                            + "',BRZELSN = '" + this.BRZELSN.Text.Trim().ToUpper() + " "

                            + "',OLDBRZELSN = '" + this.OLDBRZELSN.Text.Trim().ToUpper() + " "

                            + "',LOWSN = '" + this.LOWSN.Text.Trim().ToUpper() + " "
                            + "',OLDLOWSN = '" + this.OLDLOWSN.Text.Trim().ToUpper() + " "
                            + "',UPSN = '" + this.UPSN.Text.Trim().ToUpper() + " "

                            + "',OLDUPSN = '" + this.OLDUPSN.Text.Trim().ToUpper() + " "

                            + "',KBUPSN = '" + this.KBUPSN.Text.Trim().ToUpper() + " "

                            + "',OLDKBUPSN = '" + this.OLDKBUPSN.Text.Trim().ToUpper() + " "

                            + "',RADAPTER = '" + this.RADAPTER.Text.Trim().ToUpper() + " "
                            + "',OLDRADAPTER = '" + this.OLDRADAPTER.Text.Trim().ToUpper() + " "

                            + "',OTHERSN = '" + this.OTHERSN.Text.Trim().ToUpper() + " "

                            + "',OLDOTHERSN = '" + this.OLDOTHERSN.Text.Trim().ToUpper() + " "
                            + "',RepairDesc = '" + this.RepairDesc.Text.Trim().ToUpper() + " "
                            + "',RepairMan = '" + this.RepairMan.Text.Trim().ToUpper() + " "
                            + "',RepairDate ='" + System.DateTime.Today.ToString("yyyy-MM-dd") + " "
                            + "',Status = '待测 "

                            + "' where NBSerial = '" + this.NBSerial.Text.Trim().ToUpper()
                            + "' or NBID = '" + this.NBSerial.Text.Trim().ToUpper() + "'";


                    cmd.ExecuteNonQuery();

                    this.NBSerial.Focus();
                    ok = true;
                    if (ok == true)
                    {
                        tableName = "ChuKu";
                        cmd.CommandText = "delete   from " + tableName + " where  countfile = '" + nbid + "' ";
                        cmd.ExecuteNonQuery();
                        string[] str = { this.COVERSN.Text.ToUpper(), this.BRZELSN.Text.ToUpper(), this.UPSN.Text.ToUpper(), this.LOWSN.Text.ToUpper(), this.KBSN.Text.ToUpper(), this.KBUPSN.Text.ToUpper(), this.RADAPTER.Text.ToUpper(), this.BatterySN.Text.ToUpper(), this.frontbattery.Text.ToUpper(), this.OTHERSN.Text.ToUpper() };//BatterySN
                        for (int i = 0; i < str.Length; i = i + 1)
                        {
                            if (str[i] != "" && str[i].Length >= 11)
                            {
                                if (str[i].Length > 11)
                                {
                                    string partsno = "";
                                    if (i == 6 || i == 7 || i == 8)
                                    {
                                        SqlCommand cmd1 = new SqlCommand();
                                        cmd1.Connection = conn1;
                                        cmd1.CommandType = CommandType.Text;
                                        string tableName1 = "BOMCompare";

                                         string  lnvpn = str[i].Substring(2, 10);
                                         string mtm = label24.Text;
                                         cmd1.CommandText = "select  SKU_LNO,LCFC_PN,LNV_PN   from " + tableName1 + " where SKU_LNO = '" + mtm + "'  and LNV_PN = '" + lnvpn + "'   ";
                                        SqlDataReader querySdr1 = cmd1.ExecuteReader();
                                        while (querySdr1.Read())
                                        {
                                            partsno = querySdr1["LCFC_PN"].ToString().Trim() ;
                                        }
                                        querySdr1.Close();
                                        cmd1.Dispose();
                                    }
                                    else
                                    {
                                        partsno = str[i].Substring(0, 11);
                                    }

                                    cmd.CommandText = "INSERT INTO " + tableName + " (countfile,partsno,serial,qty,price,keyinman,chukudate)  VALUES('" +
                                       nbid + "','" +
                                      partsno + "','" +
                                       str[i] + "','" +
                                       1 + "','" +
                                       0.00 + "','" +
                                       this.RepairMan.Text + "','" +
                                       System.DateTime.Today.ToShortDateString() +
                                    "')";

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        // MessageBox.Show("New Save OK");
                        Clear();
                        cmd.Dispose();
                        cmd.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("没有这个记录！！！");
                        this.NBSerial.Focus();
                    }
                    MessageBox.Show("  Update Save OK");
                }

                conn.Close(); conn1.Close();

                queryLastesttoday();
                Clear();
            }
        }

        private void queryLastesttoday()
        {
            try
            {
                SqlConnection mConn = new SqlConnection(Conlist.ConStr);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = mConn;
                string tableName = "NBShouLiao";
                cmd.CommandText = "select NBSerial, Model ,BatterySN, KBSN ,MBSN, Memory1SN ,Memory2SN,HDDSN,SSDSN,WLANSN,COVERSN,BRZELSN,UPSN,LOWSN,OTHERSN,RepairDesc,Status from " + tableName + " where RepairDate = '" + System.DateTime.Today.ToString("yyyy-MM-dd") + "'";

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

        private void GetKeyPartsBOM(  string partsno)
        {
            try
            {
                SqlConnection mConn = new SqlConnection(Conlist.ConStr);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = mConn;
                string tableName = "BOMCompare";
                cmd.CommandText = "select SKU_LNO,SKU_NO,ITEM_DESCRIPTION,LCFC_PN,LNV_PN,KP_QTY,REMARK from " + tableName + " where (KEY_TOPIC =   'KEY PARTS' or KEY_TOPIC = 'ACCESSORY' ) and  SKU_LNO= '" + partsno + "'";

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds, tableName);
                dataGridView2.DataSource = ds.Tables[0];
                dataGridView2.RowHeadersVisible = false;
                mConn.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Clear()
        {
            this.NBSerial.Text = ""; this.BatterySN.Text = ""; this.KBSN.Text = ""; this.MBSN.Text = ""; this.Memory1SN.Text = ""; this.Memory2SN.Text = ""; this.HDDSN.Text = ""; this.SSDSN.Text = "";
            this.WLANSN.Text = ""; this.COVERSN.Text = ""; this.BRZELSN.Text = ""; this.UPSN.Text = ""; this.LOWSN.Text = ""; this.OTHERSN.Text = ""; this.RepairDesc.Text = "";

            this.OLDKBUPSN.Text = ""; this.RADAPTER.Text = ""; this.OLDRADAPTER.Text = ""; this.OLDUPSN.Text = ""; this.OLDLOWSN.Text = ""; this.OLDCOVERSN.Text = ""; this.OLDBRZELSN.Text = "";


            this.label24.Text = ""; this.frontbattery.Text = ""; this.OLDfrontbattery.Text = ""; this.OLDBatterySN.Text = "";
        }

        private void NBSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.NBSerial.Text != "")
                {
                    LoadData();
                    this.MBSN.Focus();
                }
                else
                {
                    this.NBSerial.Focus();
                }
            }
        }

        public bool CheckKeyPartsInBom(string MTM, string item, string partsno1, string partsno2)
        {
            bool ok = false;
            try
            {
                SqlConnection conn = new SqlConnection(Conlist.ConStr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    string tableName = "BOMCompare";

                    if (item == "")
                    {
                        cmd.CommandText = "select *  from " + tableName + " where SKU_LNO = '" + MTM + "' and      LNV_PN = '" + partsno2 + "' ";
                    }
                    else
                    {

                        cmd.CommandText = "select *  from " + tableName + " where SKU_LNO = '" + MTM + "' and   TOPIC_ITEM = '" + item + "'    and     LNV_PN = '" + partsno2 + "' ";
                    }

                    SqlDataReader querySdr = cmd.ExecuteReader();

                    if (querySdr.HasRows == true)
                    {
                        ok = true;
                    }
                    querySdr.Close();
                    cmd.Dispose();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return ok;
        }

        public bool KeyPartsInBom(string MTM)
        {
            bool ok = false;
            try
            {
                SqlConnection conn = new SqlConnection(Conlist.ConStr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    string tableName = "BOMCompare";
                    cmd.CommandText = "select *  from " + tableName + " where SKU_LNO = '" + MTM + "'  and    (TOPIC_ITEM = '" + "PWR CODE" + "' or TOPIC_ITEM = '" + "M/B" + "'  or TOPIC_ITEM = '" + "MEMORY" + "' or TOPIC_ITEM = '" + "SSD" + "' or TOPIC_ITEM = '" + "HDD" + "'   or TOPIC_ITEM = '" + "BATTERY" + "'or TOPIC_ITEM = '" + "AC ADAP" + "')";


                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    
                    DataSet ds = new DataSet();
                   
                    sda.Fill(ds, tableName);
                    dataGridView2.DataSource = ds.Tables[0];
                    dataGridView2.RowHeadersVisible = false;
                    sda.Dispose();
                    cmd.Dispose();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return ok;
        }

        private void LoadData()
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
                    cmd.CommandText = "select *  from " + tableName + " where NBSerial = '" + this.NBSerial.Text.Trim().ToUpper () + "' or NBID = '" + this.NBSerial.Text.Trim().ToUpper () + "' ";
                    SqlDataReader querySdr = cmd.ExecuteReader();
                    bool bomok = false;
                    while (querySdr.Read())
                   // if (querySdr.HasRows == true)
                    {
                        bomok = true;
                        this.label24.Text = querySdr["SKU"].ToString().Trim ().ToUpper ();
                        GetKeyPartsBOM(querySdr["SKU"].ToString().Trim ());
                       // GetKeyPartsBOM("20JNA04TCD");
                        this.BatterySN.Text = querySdr["BatterySN"].ToString().Trim();
                        this.frontbattery .Text = querySdr["BatterySN1"].ToString().Trim();

                        this.OLDBatterySN.Text = querySdr["OLDBatterySN"].ToString().Trim();
                        this.OLDfrontbattery.Text = querySdr["OLDBatterySN1"].ToString().Trim();

                        this.KBSN.Text = querySdr["KBSN"].ToString().Trim();
                        this.OLDKBSN.Text = querySdr["OLDKBSN"].ToString().Trim();
                        this.MBSN.Text = querySdr["MBSN"].ToString().Trim();
                      
                        this.Memory1SN.Text = querySdr["Memory1SN"].ToString().Trim();
                        this.Memory2SN.Text = querySdr["Memory2SN"].ToString().Trim();
                        this.HDDSN.Text = querySdr["HDDSN"].ToString().Trim();
                        this.SSDSN.Text = querySdr["SSDSN"].ToString().Trim();
                        this.WLANSN.Text = querySdr["WLANSN"].ToString().Trim();
                      
                        this.COVERSN.Text = querySdr["COVERSN"].ToString().Trim();
                        this.BRZELSN.Text = querySdr["BRZELSN"].ToString().Trim();
                        this.UPSN.Text = querySdr["UPSN"].ToString().Trim();
                        this.LOWSN.Text = querySdr["LOWSN"].ToString().Trim();

                        this.OLDCOVERSN.Text = querySdr["OLDCOVERSN"].ToString().Trim();
                        this.OLDBRZELSN.Text = querySdr["OLDBRZELSN"].ToString().Trim();
                        this.OLDUPSN.Text = querySdr["OLDUPSN"].ToString().Trim();
                        this.OLDLOWSN.Text = querySdr["OLDLOWSN"].ToString().Trim();

                        this.RADAPTER.Text = querySdr["RADAPTER"].ToString().Trim();
                        this.OLDRADAPTER.Text = querySdr["OLDRADAPTER"].ToString().Trim();
                        this.KBUPSN.Text = querySdr["KBUPSN"].ToString().Trim();
                        this.OLDKBUPSN.Text = querySdr["OLDKBUPSN"].ToString().Trim();

                        this.OTHERSN.Text = querySdr["OTHERSN"].ToString().Trim();
                        this.RepairDesc.Text = querySdr["RepairDesc"].ToString().Trim();
                        this.RepairMan.Text = querySdr["RepairMan"].ToString().Trim();
                    }
                    querySdr.Close();
                    cmd.Dispose();
                    if (bomok ==false )
                    {

                    }
                }
                conn.Close();

                queryLastesttoday();               
            }
        }

        public string GetPartsNo(string partsserial,int l)
        {
            string partsno = "";
            if (partsserial.Length >= l+2)
            {
                if (partsserial.Substring(0, 2).ToUpper() == "8S")
                {
                    partsno = partsserial.ToUpper().Substring(2, l);
                }
                else if (partsserial.Substring(0, 3).ToUpper() == "11S")
                {
                    partsno = partsserial.ToUpper().Substring(3, l);

                }
                else
                {
                    partsno = partsserial.ToUpper().Substring(0, 11);

                }
            }

            return partsno;
        }        

        private void MBSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.MBSN.Text != "")
                {
                   // if(  CheckKeyPartsInBom(this.label24 .Text ,"M/B",
                     this.Memory1SN.Focus();
                }
                else
                {
                    this.Memory1SN.Focus();
                }
            }
        }      

        private void Memory1SN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.Memory1SN.Text.Trim().ToUpper().Substring(0, 2) == "8S" || this.Memory1SN.Text.Trim().ToUpper().Substring(0, 3) == "NNN")
                {
                    if (this.Memory1SN.Text != "" && this.Memory1SN.Text != "NNN")
                    {
                        if (this.Memory1SN.Text.ToUpper() != "NNN")
                        {
                            string partsno = GetPartsNo(this.Memory1SN.Text.ToUpper(), 10);
                            string topicitem = "MEMORY";
                            if (CheckKeyPartsInBom(this.label24.Text, topicitem, partsno, partsno))
                            {
                                this.Memory2SN.Focus();
                            }
                            else
                            {
                                MessageBox.Show("内存料号不对");
                                this.Memory1SN.Text = "料号不对" + this.Memory1SN.Text;
                                this.Memory2SN.Focus();
                            }
                        }
                        else
                        {
                            this.Memory2SN.Focus();
                        }
                    }
                    else
                    {
                        this.Memory2SN.Focus();
                    }
                }
                else
                {
                    this.Memory1SN.Focus();
                }
            }
        }

        private void Memory2SN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.Memory2SN.Text.Trim().ToUpper().Substring(0, 2) == "8S" || this.Memory2SN.Text.Trim().ToUpper().Substring(0, 3) == "NNN")
                {
                    if (this.Memory2SN.Text != "" && this.Memory2SN.Text != "NNN")
                    {
                        if (this.Memory2SN.Text.ToUpper() != "NNN")
                        {
                            string partsno = GetPartsNo(this.Memory2SN.Text.ToUpper(), 10);
                            string topicitem = "MEMORY";
                            if (CheckKeyPartsInBom(this.label24.Text, topicitem, partsno, partsno))
                            {
                                this.SSDSN.Focus();
                            }
                            else
                            {
                                MessageBox.Show("内存料号不对");
                                this.Memory2SN.Text = "料号不对" + this.Memory2SN.Text;
                                this.Memory2SN.Focus();
                            }
                        }
                        else
                        {
                            this.SSDSN.Focus();
                        }
                    }
                    else
                    {
                        this.SSDSN.Focus();
                    }
                }
                else
                {
                    this.Memory2SN.Focus();
                }
            }
        }

        private void HDDSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.HDDSN.Text.Trim().ToUpper().Substring(0, 2) == "8S" || this.HDDSN.Text.Trim().ToUpper().Substring(0, 3) == "NNN")
                {
                    if (this.HDDSN.Text != "" && this.HDDSN.Text != "NNN")
                    {
                        if (this.HDDSN.Text.ToUpper() != "NNN")
                        {
                            string partsno = GetPartsNo(this.HDDSN.Text.ToUpper(), 10);
                            string topicitem = "HDD";
                            if (CheckKeyPartsInBom(this.label24.Text, topicitem, partsno, partsno))
                            {
                                this.WLANSN.Focus();
                            }
                            else
                            {
                                MessageBox.Show("HDD 料号不对");
                                this.HDDSN.Text = "料号不对" + this.HDDSN.Text;
                                this.HDDSN.Focus();
                            }
                        }
                        else
                        {
                            this.WLANSN.Focus();
                        }
                    }
                    else
                    {
                        this.WLANSN.Focus();
                    }
                }
                else
                {
                    this.HDDSN.Focus();
                }
            }
        }

        private void SSDSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.SSDSN.Text.Trim().ToUpper().Substring(0, 2) == "8S" || this.SSDSN.Text.Trim().ToUpper().Substring(0, 3) == "NNN")
                {
                    if (this.SSDSN.Text != "" && this.SSDSN.Text != "NNN")
                    {
                        if (this.SSDSN.Text.ToUpper() != "NNN")
                        {
                            string partsno = GetPartsNo(this.SSDSN.Text.ToUpper(), 10);
                            string topicitem = "SSD";
                            if (CheckKeyPartsInBom(this.label24.Text, topicitem, partsno, partsno))
                            {
                                this.HDDSN.Focus();
                            }
                            else
                            {
                                MessageBox.Show("SSD   料号不对");
                                this.SSDSN.Text = "料号不对" + this.SSDSN.Text;
                                this.SSDSN.Focus();
                            }
                        }
                        else
                        {
                            this.HDDSN.Focus();
                        }
                    }
                    else
                    {
                        this.HDDSN.Focus();
                    }
                }
                else
                {
                    this.SSDSN.Focus();
                }
            }
        }       

        private void WLANSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.WLANSN.Text.Trim().ToUpper().Substring(0, 2) == "8S" || this.WLANSN.Text.Trim().ToUpper().Substring(0, 3) == "NNN")
                {
                    if (this.WLANSN.Text != "" && this.WLANSN.Text != "NNN")
                    {
                        if (this.WLANSN.Text.ToUpper() != "NNN")
                        {
                            string partsno = GetPartsNo(this.WLANSN.Text.ToUpper(), 10);
                            string topicitem = "";
                            if (CheckKeyPartsInBom(this.label24.Text, topicitem, partsno, partsno))
                            {
                                this.RepairMan.Focus();
                            }
                            else
                            {
                                MessageBox.Show("WLAN 卡   料号不对");
                                this.WLANSN.Text = "";
                                this.WLANSN.Focus();
                            }
                        }
                    }
                }
                else
                {
                    this.WLANSN.Focus();
                }
            }
            else
            {
               this.WLANSN.Focus();
            }        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
        SqlConnection conn = new SqlConnection(Conlist.ConStr);
        conn.Open();
        if (conn.State == ConnectionState.Open)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
           //  string tableName = "NBShouLiao";
            //string tableName = "BOMCompare";

            string tableName = "ChuKu";

            cmd.CommandText = "delete   from " + tableName;

              
          
            tableName = "OUTNBCHUKU";

            cmd.CommandText = "delete   from " + tableName;

            cmd.ExecuteNonQuery();


            tableName = "NBShouLiao";
            cmd.CommandText = "delete   from " + tableName;

            cmd.ExecuteNonQuery();


            tableName = "RatingLabel";
            cmd.CommandText = "delete   from " + tableName;

            cmd.ExecuteNonQuery();



            tableName = "INNBRUKU";

            cmd.CommandText = "delete   from " + tableName;

            cmd.ExecuteNonQuery();

            tableName = "INNBCHUKU";

            cmd.CommandText = "delete   from " + tableName;

            cmd.ExecuteNonQuery();

            cmd.Dispose();
        }
        conn.Close();

        MessageBox.Show("delete  OK");
       */
        }

        private void COVERSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                OLDCOVERSN.Focus();

            }
        }

        private void BRZELSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BRZELSN.Focus();

            }
        }

        private void LOWSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                OLDLOWSN.Focus();

            }
        }

        private void UPSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                OLDUPSN.Focus();
            }
        }

        private void KBSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                OLDKBSN.Focus();
            }
        }

        private void KBUPSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                OLDKBUPSN.Focus();
            }
        }

        private void BatterySN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                OLDBatterySN.Focus();
            }
        }

        private void frontbattery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                OLDfrontbattery.Focus();
            }
        }

        private void RADAPTER_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                OLDRADAPTER.Focus();
            }
        }

        private void OTHERSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                OLDOTHERSN.Focus();
            }
        }

        private void NBReapir_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.GetType().
              GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).
              SetValue(tableLayoutPanel1, true, null);
            tableLayoutPanel2.GetType().
                GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).
                SetValue(tableLayoutPanel2, true, null);

            tableLayoutPanel3.GetType().
              GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).
              SetValue(tableLayoutPanel3, true, null);
            tableLayoutPanel4.GetType().
                GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).
                SetValue(tableLayoutPanel4, true, null);

            tableLayoutPanel5.GetType().
              GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).
              SetValue(tableLayoutPanel5, true, null);
            tableLayoutPanel6.GetType().
                GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).
                SetValue(tableLayoutPanel6, true, null);
        }

      
    }
}
