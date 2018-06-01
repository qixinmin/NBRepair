using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NBRepair
{
    public partial class NBShouLiao : Form
    {
        public NBShouLiao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.NBSerial.Text.Trim() != "" && this.NBID.Text.Trim() != "" && this.CheckMan .Text.Trim() != "" 
                && this.Model.Text.Trim()!="")
            {
                SqlConnection conn = new SqlConnection(Conlist.ConStr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    string tableName = "NBShouLiao";
                    cmd.CommandText = "select *  from " + tableName + " where NBID = '" + this.NBID.Text.Trim()
                     + "' or NBSerial = '" + this.NBSerial.Text.Trim() + "'";
                    SqlDataReader querySdr = cmd.ExecuteReader();
                   // MessageBox.Show (this.NBSerial.Text.Trim().Substring(12, 8).ToUpper());


                    if (querySdr.HasRows == true)
                    {
                        cmd.CommandText = "update " + tableName + " set vendor = '" + this.vendor.Text.Trim()
                                  + "',customer = '" + this.customer.Text.Trim() + " "
                                  + "', NBID = '" + this.NBID.Text.Trim() + " "
                                  + "',NBSerial = '" + this.NBSerial.Text.Trim().ToUpper () + " "

                                  + "',NewNBSerial='"+"1S"+  this.NBSerial.Text.Trim().Substring(2, 10).ToUpper()+"TR" + this.NBSerial.Text.Trim().Substring (14,6).ToUpper ()+" "

                                  + "',SKU = '" + this.NBSerial.Text.Trim().Substring (2,10).ToUpper () + " "
                                  + "',NBSN = '" + this.NBSerial.Text.Trim().Substring (12,8).ToUpper () + " "
                                  + "',Model = '" + this.Model.Text.Trim().ToUpper () + " "
                                  + "',UUID = '" + this.UUID.Text.Trim().ToUpper () + " "
                                  
                                  + "',AdapterSN = '" + this.AdapterSN.Text.Trim().ToUpper () + " "
                                  + "',PowerCodeSN = '" + this.PowerCodeSN.Text.Trim().ToUpper () + " "
                                  + "',FunctionOK = '" + this.FunctionOK.Text.Trim() + " "
                                  + "',ConfigDesc = '" + this.ConfigDesc.Text.Trim() + " "
                                  + "',CheckMan = '" + this.CheckMan.Text.Trim() + " "

                                  + "' where NBID = '" + this.NBID.Text.Trim().ToUpper ()
                                  + "' or NBSerial = '" + this.NBSerial.Text.Trim().ToUpper () + "'";
                        querySdr.Close();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("  Update Save OK");//1S20KNA002CDPF12D33Z
                          //  1S  20KNA002CD  PF12D33Z
                       
                        this.NBID.Focus();
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO " + tableName + " (vendor,customer,NBID,NBSerial,NewNBSerial,SKU,NBSN,Model,UUID,AdapterSN,PowerCodeSN,FunctionOK,ConfigDesc,CheckMan, Status, CheckDate)  VALUES('" +
                        this.vendor.Text.Trim() + "','" +
                        this.customer.Text.Trim() + "','" +
                        this.NBID.Text.Trim() + "','" +
                        this.NBSerial.Text.Trim().ToUpper () + "','" +

                        "1S"+  this.NBSerial.Text.Trim().Substring(2, 10).ToUpper()+"TR" + this.NBSerial.Text.Trim().Substring (14,6).ToUpper ()+ "','" +

                        this.NBSerial.Text.Trim().Substring (2,10).ToUpper () + "','" +
                        this.NBSerial.Text.Trim().Substring (12,8).ToUpper () + "','" +
                        this.Model.Text.Trim().ToUpper () + "','" +
                        this.UUID.Text.Trim() + "','" +
                        
                        this.AdapterSN.Text.Trim() + "','" +
                        this.PowerCodeSN.Text.Trim() + "','" +
                        this.FunctionOK.Text.Trim() + "','" +
                        this.ConfigDesc.Text.Trim() + "','" +
                        this.CheckMan.Text.Trim() + "','" +
                        "待修" + "','" +
                         System.DateTime.Today.ToShortDateString () +
                         "')";
                        querySdr.Close();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("New Save OK");

                       
                        this.NBID.Focus();
                    }

                    tableName = "INNBRUKU";
                    cmd.CommandText = "select *  from " + tableName + " where NBID = '" + this.NBID.Text.Trim()
                    + "' or NBSerial = '" + this.NBSerial.Text.Trim() + "'";
                    querySdr = cmd.ExecuteReader();
                    if (querySdr.HasRows == true)
                    {
                        cmd.CommandText = "update " + tableName + " set vender = '" + this.vendor.Text.Trim()
                                  + "',customer = '" + this.customer.Text.Trim() + " "
                                  + "', NBID = '" + this.NBID.Text.Trim() + " "
                                  + "',NBSerial = '" + this.NBSerial.Text.Trim().ToUpper() + " "
                                  + "',Model = '" + this.Model.Text.Trim() + " "
                                  + "' where NBID = '" + this.NBID.Text.Trim().ToUpper()
                                  + "' or NBSerial = '" + this.NBSerial.Text.Trim().ToUpper() + "'";
                        querySdr.Close();
                        cmd.ExecuteNonQuery();
                       // MessageBox.Show("  Update   INNBRUKU Save OK");//1S20KNA002CDPF12D33Z
                        //  1S  20KNA002CD  PF12D33Z
                      
                        this.NBID.Focus();
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO " + tableName + " (vender,customer,NBID,NBSerial,Model,qty,rukudate)  VALUES('" +
                        this.vendor.Text.Trim() + "','" +
                        this.customer.Text.Trim() + "','" +
                        this.NBID.Text.Trim() + "','" +
                        this.NBSerial.Text.Trim().ToUpper() + "','" +
                        this.Model.Text.Trim().ToUpper() + "','" +
                          1 + "','" +
                         System.DateTime.Today.ToShortDateString() +
                         "')";
                        querySdr.Close();
                        cmd.ExecuteNonQuery();
                     //   MessageBox.Show("New  INNBRUKU   Save OK");

                      
                        this.NBID.Focus();
                    }


                    tableName = "INNBCHUKU";
                    cmd.CommandText = "select *  from " + tableName + " where NBID = '" + this.NBID.Text.Trim()
                    + "' or NBSerial = '" + this.NBSerial.Text.Trim() + "'";
                    querySdr = cmd.ExecuteReader();
                    if (querySdr.HasRows == true)
                    {
                        cmd.CommandText = "update " + tableName + " set vender = '" + this.vendor.Text.Trim()
                                  + "',customer = '" + this.customer.Text.Trim() + " "
                                  + "', NBID = '" + this.NBID.Text.Trim() + " "
                                  + "',NBSerial = '" + this.NBSerial.Text.Trim().ToUpper() + " "
                                  + "',Model = '" + this.Model.Text.Trim() + " "
                                  + "' where NBID = '" + this.NBID.Text.Trim().ToUpper()
                                  + "' or NBSerial = '" + this.NBSerial.Text.Trim().ToUpper() + "'";
                        querySdr.Close();
                        cmd.ExecuteNonQuery();
                     //   MessageBox.Show("  Update   chu Save OK");//1S20KNA002CDPF12D33Z
                        //  1S  20KNA002CD  PF12D33Z

                        this.NBID.Focus();
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO " + tableName + " (vender,customer,NBID,NBSerial,Model,qty,chukudate)  VALUES('" +
                        this.vendor.Text.Trim() + "','" +
                        this.customer.Text.Trim() + "','" +
                        this.NBID.Text.Trim() + "','" +
                        this.NBSerial.Text.Trim().ToUpper() + "','" +
                        this.Model.Text.Trim().ToUpper() + "','" +
                          1 + "','" +
                         System.DateTime.Today.ToShortDateString() +
                         "')";
                        querySdr.Close();
                        cmd.ExecuteNonQuery();
                      //   MessageBox.Show("New  chu  Save OK");


                        this.NBID.Focus();
                    }


                    Clear();
                    cmd.Dispose();
                }
                conn.Close();

                queryLastesttoday();
            }
        }
       
        public  bool CheckKeyPartsInBom(string MTM, string item  , string  partsno1,string partsno2)
        {
            bool ok=false ;
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
                    cmd.CommandText = "select *  from " + tableName + " where SKU_LNO = '" + MTM + "' and   TOPIC_ITEM = '" + item + "'    and    (LCFC_PN = '" + partsno1 + "' or LNV_PN = '" + partsno2 + "')";
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
        private void queryLastesttoday()
        {
            try
            {
                SqlConnection mConn = new SqlConnection(Conlist.ConStr);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = mConn;
                string tableName = "NBShouLiao";
                   // cmd.CommandText = "select top 3 * from " + tableName + " order by id desc";

                cmd.CommandText = "select vendor,customer,NBID,NBSerial,SKU,NBSN, Model ,UUID,AdapterSN, PowerCodeSN ,FunctionOK, ConfigDesc ,CheckMan from " + tableName + " where Checkdate = '" + System.DateTime.Today.ToString("yyyy-MM-dd") + "'";
                
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

           // string[] hTxt = { "ID", "厂商","客户别","NBID","机器序号","型号","收货日期"};
           // for (int i = 0; i < hTxt.Length; i++)
            {
                //dataGridView1.Columns[i].HeaderText = hTxt[i];
            }
        }

        private void Clear()
        {
            this.NBID.Text = ""; this.NBSerial.Text = ""; this.Model.Text = ""; this.FunctionOK .Text = "";
            this.UUID.Text = ""; this.AdapterSN.Text = ""; this.PowerCodeSN.Text = ""; this.ConfigDesc .Text = "";

        }

        private void NBID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.NBID.Text != "")
                {
                    this.NBSerial.Focus();
                }
                else
                {
                    this.NBID.Focus();
                }

            }
        }

        private void NBSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.NBSerial.Text != "" && this.NBSerial.Text.Length == 20 && this.NBSerial.Text.Substring (0,2).ToUpper ()=="1S")
                {
                    KeyPartsInBom(this.NBSerial.Text.Trim().Substring(2, 10));
                    this.Model .Focus();
                }
                else
                {
                    this.NBSerial.SelectionStart = 0;
                    this.NBSerial.SelectionLength = 0;
                    this.NBSerial.SelectAll();
                    this.NBSerial.Focus();
                }

            }
        }
        public string GetPartsNo(string partsserial, int l)
        {
            string partsno = "";
            if (partsserial.Length >= l + 2)
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
        private void AdapterSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.AdapterSN.Text != "")
                {

                    string partsno = GetPartsNo(this.AdapterSN.Text.ToUpper(), 7);
                    string topicitem = "AC ADAP";

                    if (CheckKeyPartsInBom(this.NBSerial.Text.Trim().Substring(2, 10).ToUpper (), topicitem, partsno, partsno) == true)// PWR CORD
                    {
                        this.PowerCodeSN.Focus();
                    }
                    else
                    {
                       this. AdapterSN.Text = "FailOn" +this. AdapterSN.Text; this.PowerCodeSN.Focus();
                        MessageBox.Show("电源料号不对！");
                    }
                }
                else
                {
                    this.AdapterSN.Focus();
                }

            }
        }

        private void PowerCodeSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (PowerCodeSN.Text != "")
                {

                    string partsno = GetPartsNo(this.PowerCodeSN.Text.ToUpper(), 7);
                    string topicitem = "PWR CORD";

                    if (CheckKeyPartsInBom(this.NBSerial.Text.Trim().Substring(2, 10).ToUpper(), topicitem, partsno, partsno) == true)// PWR CORD
                    {
                        this.FunctionOK.Focus();
                    }
                    else
                    {
                        this.PowerCodeSN.Text = "FailOn" + this.AdapterSN.Text; this.PowerCodeSN.Focus();
                        MessageBox.Show("电源线   料号不对！");
                    }
                }
                this.FunctionOK.Focus();
            }
        }

        private void ConfigDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.ConfigDesc.Text != "")
                {
                    this.CheckMan .Focus();
                }
                else
                {
                    this.ConfigDesc.Focus();
                }

            }
        }

        private void FunctionOK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.FunctionOK.Text != "")
                {
                    this.ConfigDesc.Focus();
                }
                else
                {
                    this.FunctionOK.Focus();
                }

            }
        }

        private void Model_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.Model.Text != "")
                {
                    this.UUID.Focus();
                }
                else
                {
                    this.Model.Focus();
                }

            }
        }

        private void vendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.vendor.Text != "")
                {
                    this.customer.Focus();
                }
                else
                {
                    this.vendor.Focus();
                }

            }

        }

        private void customer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.customer.Text != "")
                {
                    this.NBID.Focus();
                }
                else
                {
                    this.customer.Focus();
                }

            }
        }

        private void UUID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.UUID.Text != "")
                {
                    this.AdapterSN.Focus();
                }
                else
                {
                    this.UUID.Focus();
                }

            }
        }

        private void NBShouLiao_Load(object sender, EventArgs e)
        {
            this.vendor.Text = "联宝";
            this.customer.Text = "联想";
        }
       
    }
}
