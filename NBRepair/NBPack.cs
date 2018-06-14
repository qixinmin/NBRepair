using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace NBRepair
{
    public partial class NBPack : Form
    {
        public NBPack()
        {           
            InitializeComponent();
        }

        private void NBSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.NBSerial.Text != "")
                {
                    this.NewAdapterSN.Focus();
                    // TPORT.bat  UUID MAC.bat  
                }
                else
                {
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
                }
            }

            return partsno;
        }

        private void NewAdapterSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.NewAdapterSN.Text != "")
                {
                    string partsno = GetPartsNo(this.NewAdapterSN.Text.ToUpper(), 7);
                    string topicitem = "AC ADAP";
                    if (CheckKeyPartsInBom(this.NBSerial.Text.Trim().Substring(2, 10).ToUpper(), topicitem, partsno, partsno) == true)// PWR CORD
                    {
                        this.NewPowerCodeSN.Focus();
                    }
                    else
                    {
                        MessageBox.Show("电源料号不对！"); this.NewAdapterSN.Focus(); this.NewAdapterSN.Text = "";
                    }
                }
                else
                {
                    this.NewAdapterSN.Focus();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.NewAdapterSN.Text != "" && this.NewPowerCodeSN.Text != "" && this.NBSerial.Text != "")
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
                    cmd.CommandText = "select *  from " + tableName + " where NBSerial = '" + this.NBSerial.Text.Trim() + "' or NBID = '" + this.NBSerial.Text.Trim() + "'or NewNBSerial = '" + this.NBSerial.Text.Trim() + "' ";
                    SqlDataReader querySdr = cmd.ExecuteReader();

                    string volat = "";
                    string current = "";
                    string model = "";
                    string V_UPC_TITLE = "1999999999", CCLABEL = "";
                    string V_UPC = "", V_UUID = "", V_STD_WEIGHT = "", V_SSN = "", V_SPB_COMPUTER = "", V_SPB_COMPANY = "", V_PO_QTY = "1", V_PO_NUMBER = "", V_PO_LINE = "";
                    string V_PN_LCFC = "", V_PALLET_TYPE = "P1", V_PALLET_NO = "", V_MTM_TBG = "", V_MODEL_DESC_TBG = "", V_MODEL_DESC_CECP = "", V_LOGO_ES = "", V_LOGO_CPU = "", V_LOGO_CECP = "",
                    V_KEYPARTS_WLAN_PAD = "", V_KEYPARTS_WLAN_MAC = "", V_KEYPARTS_SSHD = "", V_KEYPARTS_SSD = "", V_KEYPARTS_MSATA = "", V_KEYPARTS_MEMORY = "", V_KEYPARTS_LCD = "", V_KEYPARTS_LAN_MAC = "",
                    V_KEYPARTS_HDD = "", V_KEYPARTS_CPU = "", V_KEYPARTS_BT = "", V_IMEI = "", V_ICCID = "", V_DATE = "", V_COMPLAINCE_ID = "", V_ASSET = "",
                    V_ASSET_MTM1 = "", V_ASSET_MTM2 = "", V_ASSET_MTM3 = "", V_ASSET_MTM4 = "";

                    string NBID = "", customer = "", Model = "", NBSerial = "", vender = "";
                    bool findok = false;
                    while (querySdr.Read())
                    {
                        if (querySdr.HasRows == true)
                        {
                            findok = true;
                            V_MTM_TBG = querySdr["SKU"].ToString().Trim();
                            V_SSN = "TR" + querySdr["NBSN"].ToString().Trim().Substring(2, 6);
                            V_UUID = querySdr["UUID"].ToString().Trim();
                            //V_KEYPARTS_WLAN_MAC = querySdr["WLANMAC"].ToString().Trim();
                            //V_KEYPARTS_LAN_MAC = querySdr["MBMAC"].ToString().Trim();

                            NBID = querySdr["NBID"].ToString().Trim();
                            customer = querySdr["customer"].ToString().Trim();
                            Model = querySdr["Model"].ToString().Trim();
                            NBSerial = querySdr["NewNBSerial"].ToString().Trim();
                            vender = querySdr["vendor"].ToString().Trim();
                        }
                        else
                        {
                            MessageBox.Show("没有这个记录！！！"); this.NBSerial.Focus();
                        }
                    }

                    if (findok == true)
                    {
                        querySdr.Close();
                        tableName = "BOMCompare";
                        cmd.CommandText = "select *  from " + tableName + " where SKU_LNO = '" + V_MTM_TBG + "'  and INDICATOR_TYPE = '" + "M" + "' ";
                        querySdr = cmd.ExecuteReader();

                        //SqlConnection conn1 = new SqlConnection(Conlist.ConStr);
                        //conn1.Open();
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = conn1;
                        cmd1.CommandType = CommandType.Text;

                        string tableName1 = "Chuku";
                        cmd1.CommandText = "delete   from " + tableName1 + " where keyinman = '" + NBID + "'  ";
                        cmd1.ExecuteNonQuery();
                        string material = "";
                        while (querySdr.Read())
                        {
                            string lcfcpn = querySdr["LCFC_PN"].ToString();
                            string partsqty = querySdr["KP_QTY"].ToString();
                            material = lcfcpn + "," + partsqty + ":" + material;
                            string descri = querySdr["ITEM_DESCRIPTION"].ToString();
                            tableName = "ChuKu";
                            cmd1.CommandText = "INSERT INTO " + tableName + " (countfile,partsno, serial,qty,price ,keyinman,chukudate)  VALUES('" +
                                NBID + "','" +
                                lcfcpn + "','" +
                                descri + "','" +
                                partsqty + "','" +
                                0 + "','" +
                                NBID + "','" +
                                System.DateTime.Today.ToShortDateString() +
                              "')";
                            cmd1.ExecuteNonQuery();
                        }

                        cmd1.Clone();
                        querySdr.Close();


                        tableName = "NBShouLiao";
                        cmd.CommandText = "update " + tableName + " set NewAdapterSN = '" + this.NewAdapterSN.Text.Trim()
                                         + "',NewPowerCodeSN = '" + this.NewPowerCodeSN.Text.Trim() + " "
                                          + "',materials = '" + material  + " "
                                         + "',PackDate ='" + System.DateTime.Today.ToString("yyyy-MM-dd") + " "
                                         + "',Status = '待出"
                                         + "' where NewNBSerial = '" + this.NBSerial.Text.Trim() + "'or NBID = '" + this.NBSerial.Text.Trim() + "' ";
                        cmd.ExecuteNonQuery();

                        //  添加包材之类的到材料出库， 在包装段，先删除 keyinman  ID的记录
                        ////////////////////////////////////                       
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        tableName = "OUTNBRUKU";
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
                            cmd.CommandText = "INSERT INTO " + tableName + " (vender,customer,NBID,NBSerial,Model,qty,rukudate)  VALUES('" +
                                vender + "','" +
                                customer + "','" +
                                NBID + "','" +
                                NBSerial + "','" +
                                Model + "','" +
                                1 + "','" +
                                System.DateTime.Today.ToShortDateString() +
                                "')";
                            querySdr.Close();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("New  out    NBRUKU   Save OK");
                        }

                        //根据序列号查询Sku料号
                        cmd.CommandText = "select SKU from NBShouLiao where NBSerial='" + NBSerial + "'";
                        querySdr = cmd.ExecuteReader();
                        string relatedSku = "";                       
                        while (querySdr.Read())
                        {
                            relatedSku = querySdr[0].ToString();
                            break;
                        }
                        querySdr.Close();

                        //update 料号数量
                        cmd.CommandText = "select number from NBHouse where model='" + relatedSku + "'";
                        querySdr = cmd.ExecuteReader();
                        string number = "";
                        bool exist = false;
                        while (querySdr.Read())
                        {
                            exist = true;
                            number = querySdr[0].ToString();
                            break;
                        }
                        querySdr.Close();

                        if (number == null || number == "")
                        {
                            number = "0";
                        }

                        try
                        {
                            int totalLeft = Int32.Parse(number);
                            int thistotal = totalLeft + 1;

                            if (exist)
                            {
                                cmd.CommandText = "update NBHouse set number = '" + thistotal + "' where model='" + relatedSku + "'";
                            }
                            else
                            {
                                cmd.CommandText = "INSERT INTO NBHouse (number, model) VALUES('" + thistotal + "','" + relatedSku + "')";
                            }

                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        tableName = "RatingLabel";
                        cmd.CommandText = "select *  from " + tableName + " where 料号 = '" + V_MTM_TBG + "' ";
                        querySdr = cmd.ExecuteReader();
                        bool lihao = false;
                        while (querySdr.Read())
                        {
                            if (querySdr.HasRows == true)
                            {
                                lihao = true;
                                volat = querySdr["电压"].ToString().Trim();
                                current = querySdr["电流"].ToString().Trim();
                                V_MODEL_DESC_TBG = querySdr["机型"].ToString().Trim();
                                V_UPC_TITLE = querySdr["EAN"].ToString().Trim();
                                V_KEYPARTS_CPU = querySdr["CPU"].ToString().Trim();
                                V_KEYPARTS_MEMORY = querySdr["MEM"].ToString().Trim();
                                V_KEYPARTS_HDD = querySdr["HDD"].ToString().Trim();
                                V_KEYPARTS_SSD = querySdr["SSD"].ToString().Trim();
                                V_KEYPARTS_LCD = querySdr["LCD"].ToString().Trim();
                                V_STD_WEIGHT = querySdr["WEIGHT"].ToString().Trim();
                                CCLABEL = querySdr["CCLABEL"].ToString();
                                V_COMPLAINCE_ID = querySdr["CPMID"].ToString().Trim();//V_ICCID
                                V_ICCID = querySdr["CMIIT"].ToString().Trim();
                                V_KEYPARTS_MSATA = querySdr["MSATA"].ToString().Trim();

                                V_KEYPARTS_SSHD = querySdr["SSHD"].ToString().Trim();
                            }
                        }
                        querySdr.Close();

                        V_UPC = V_UPC_TITLE.Substring(0, V_UPC_TITLE.Length - 1);
                        V_DATE = System.DateTime.Today.ToString("yyyy-MM-dd");
                        V_PO_QTY = "1";
                        if (lihao == true)
                        {
                            CodeSoft.POD.Variables.FormVariables.Item("V_UPC_TITLE").Value = "UPC CODE:" + V_UPC_TITLE;
                            CodeSoft.POD.Variables.FormVariables.Item("V_UPC").Value = V_UPC;  // V_MODEL_DESC_TBG
                            CodeSoft.POD.Variables.FormVariables.Item("V_MTM_TBG").Value = V_MTM_TBG;//V_ASSET
                            CodeSoft.POD.Variables.FormVariables.Item("V_ASSET").Value = "";// V_ASSET  V_KEYPARTS_MSATA

                            CodeSoft.POD.Variables.FormVariables.Item("V_DATE").Value = V_DATE.Replace("-", "");

                            CodeSoft.POD.Variables.FormVariables.Item("V_KEYPARTS_MSATA").Value = V_KEYPARTS_MSATA; // V_KEYPARTS_SSHD
                            CodeSoft.POD.Variables.FormVariables.Item("V_KEYPARTS_SSHD").Value = V_KEYPARTS_SSHD;

                            CodeSoft.POD.Variables.FormVariables.Item("V_SSN").Value = V_SSN;
                            CodeSoft.POD.Variables.FormVariables.Item("V_UUID").Value = V_UUID.Replace(" ", "");
                            CodeSoft.POD.Variables.FormVariables.Item("V_KEYPARTS_WLAN_MAC").Value = V_KEYPARTS_WLAN_MAC;
                            CodeSoft.POD.Variables.FormVariables.Item("V_KEYPARTS_LAN_MAC").Value = V_KEYPARTS_LAN_MAC;
                            CodeSoft.POD.Variables.FormVariables.Item("V_KEYPARTS_CPU").Value = V_KEYPARTS_CPU;
                            CodeSoft.POD.Variables.FormVariables.Item("V_KEYPARTS_MEMORY").Value = V_KEYPARTS_MEMORY;
                            CodeSoft.POD.Variables.FormVariables.Item("V_KEYPARTS_HDD").Value = V_KEYPARTS_HDD;//   V_IMEI  V_KEYPARTS_BT
                            CodeSoft.POD.Variables.FormVariables.Item("V_IMEI").Value = "";//   V_IMEI  V_KEYPARTS_BT
                            CodeSoft.POD.Variables.FormVariables.Item("V_KEYPARTS_BT").Value = "--";//   V_IMEI  V_KEYPARTS_BT

                            CodeSoft.POD.Variables.FormVariables.Item("V_KEYPARTS_SSD").Value = V_KEYPARTS_SSD;
                            CodeSoft.POD.Variables.FormVariables.Item("V_KEYPARTS_LCD").Value = V_KEYPARTS_LCD;
                            CodeSoft.POD.Variables.FormVariables.Item("V_STD_WEIGHT").Value = V_STD_WEIGHT;
                            CodeSoft.POD.Variables.FormVariables.Item("V_COMPLAINCE_ID").Value = V_COMPLAINCE_ID;
                            CodeSoft.POD.Variables.FormVariables.Item("V_SPB_COMPUTER").Value = V_SPB_COMPUTER;
                            CodeSoft.POD.Variables.FormVariables.Item("V_SPB_COMPANY").Value = V_SPB_COMPANY;
                            CodeSoft.POD.Variables.FormVariables.Item("V_PO_QTY").Value = V_PO_QTY;

                            CodeSoft.POD.Variables.FormVariables.Item("V_PO_NUMBER").Value = V_PO_NUMBER;
                            CodeSoft.POD.Variables.FormVariables.Item("V_PO_LINE").Value = V_PO_LINE;
                            CodeSoft.POD.Variables.FormVariables.Item("V_PALLET_TYPE").Value = V_PALLET_TYPE;
                            CodeSoft.POD.Variables.FormVariables.Item("V_PALLET_NO").Value = V_PALLET_NO;
                            CodeSoft.POD.Variables.FormVariables.Item("V_MODEL_DESC_TBG").Value = V_MODEL_DESC_TBG;
                            CodeSoft.POD.Variables.FormVariables.Item("V_MODEL_DESC_CECP").Value = V_MODEL_DESC_CECP;
                            CodeSoft.POD.Variables.FormVariables.Item("V_LOGO_ES").Value = V_LOGO_ES;

                            CodeSoft.POD.Variables.FormVariables.Item("V_LOGO_CECP").Value = V_LOGO_CECP;
                            CodeSoft.POD.Variables.FormVariables.Item("V_LOGO_CPU").Value = V_LOGO_CPU;
                            CodeSoft.POD.Variables.FormVariables.Item("V_KEYPARTS_WLAN_PAD").Value = V_KEYPARTS_WLAN_PAD;

                            CodeSoft.POD.Variables.FormVariables.Item("V_ICCID").Value = V_ICCID;

                            CodeSoft.POD.Variables.FormVariables.Item("V_MODEL_DESC_CECP").Value = V_MODEL_DESC_CECP;
                            CodeSoft.POD.Variables.FormVariables.Item("V_LOGO_ES").Value = V_LOGO_ES;


                            CodeSoft.POD.Printer.SwitchTo("Catron");
                            CodeSoft.POD.PrintDocument(); //打印一次
                            CodeSoft.POD.FormFeed(); //结束打印

                        }
                        this.NewAdapterSN.Text = ""; this.NBSerial.Text = ""; this.NewPowerCodeSN.Text = "";
                        this.NBSerial.Focus();

                        querySdr.Close();
                        cmd.Dispose();
                    }
                }

                conn.Close();

                queryLastesttoday();
            }
            else
            {
                MessageBox.Show("资料不全");
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
                cmd.CommandText = "select NBSerial, Model ,NewAdapterSN,NewPowerCodeSN,PackDate,Status from " + tableName + " where PackDate = '" + System.DateTime.Today.ToString("yyyy-MM-dd") + "'";

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

        private void NBPack_Load(object sender, EventArgs e)
        {
            CodeSoft.initCodesoftModel(CodeSoft.CartonLabelModel);//CodeSoft.CartonLabelModel );  
            this.NBSerial.Focus();
            tableLayoutPanel1.GetType().
                GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).
                SetValue(tableLayoutPanel1, true, null);
            tableLayoutPanel2.GetType().
                GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).
                SetValue(tableLayoutPanel2, true, null);            
        }

        private void NBPack_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void NewPowerCodeSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.NewPowerCodeSN.Text != "")
                {
                    string partsno = GetPartsNo(this.NewPowerCodeSN.Text.ToUpper(), 7);
                    string topicitem = "PWR CORD";
                    if (CheckKeyPartsInBom(this.NBSerial.Text.Trim().Substring(2, 10).ToUpper(), topicitem, partsno, partsno) == true)// PWR CORD
                    {                        
                    }
                    else
                    {
                        MessageBox.Show("电源 线 料号不对！"); this.NewPowerCodeSN.Focus(); this.NewPowerCodeSN.Text = "";
                    }
                }
                else
                {
                    this.NewPowerCodeSN.Focus();
                }
            }
        }       
    }
}
