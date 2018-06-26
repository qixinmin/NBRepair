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
    public partial class RatingLabel : Form
    {
        public RatingLabel()
        {
            InitializeComponent();
        }

        private void 确定_Click(object sender, EventArgs e)
        {
            if (this.料号.Text.Trim() != "" && this.机型.Text != "" && this.电压.Text != "" && this.电流.Text != "" && this.EAN.Text != "" && this.CCLABEL.Text != "" 
                && this.CPMID.Text != "" && this.CPU.Text != "" && this.MEM.Text != "" && this.HDD.Text != "" && this.SSD.Text != "" && this.LCD.Text != "" && this.WEIGHT.Text != "")
            {
                SqlConnection conn = new SqlConnection(Conlist.ConStr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    string tableName = "RatingLabel";
                    cmd.CommandText = "select *  from " + tableName + " where 料号 = '" + this.料号.Text.Trim().ToUpper() + "'  ";
                    SqlDataReader querySdr = cmd.ExecuteReader();

                    if (querySdr.HasRows == true)
                    {
                        cmd.CommandText = "update " + tableName + " set 料号 = '" + this.料号.Text.Trim()
                                  + "',机型 = '" + this.机型.Text.Trim() + " "
                                  + "', 电压 = '" + this.电压.Text.Trim() + " "
                                  + "',电流 = '" + this.电流.Text.Trim().ToUpper () + " "
                                  + "',EAN = '" + this.EAN.Text.Trim().ToUpper () + " "
                                  + "',CPMID = '" + this.CPMID.Text.Trim() + " "
                                  + "',CPU = '" + this.CPU.Text.Trim() + " "
                                   + "',CMIIT = '" + this.CMIIT.Text.Trim() + " "
                                  + "',MEM = '" + this.MEM.Text.Trim().ToUpper () + " "
                                  + "',HDD = '" + this.HDD.Text.Trim().ToUpper() + " "
                                  + "',SSD = '" + this.SSD.Text.Trim().ToUpper() + " "
                                   + "',MSATA = '" + this.MSATA.Text.Trim().ToUpper() + " "
                                    + "',SSHD = '" + this.SSHD.Text.Trim().ToUpper() + " "


                                  + "',LCD = '" + this.LCD.Text.Trim() + " "
                                  + "',WEIGHT = '" + this.WEIGHT.Text.Trim() + " "
                                  + "',CCLABEL = '" + this.CCLABEL.Text.Trim() + " "
                                  + "' where 料号 = '" + this.料号.Text.Trim().ToUpper() + "'";
                        querySdr.Close();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("  Update Save OK");
                        this.料号.Focus();

                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO " + tableName + " (料号,机型,电压,电流,EAN,CPMID,CMIIT,CPU,MEM,HDD,SSD,SSHD,MSATA,LCD,WEIGHT,CCLABEL)  VALUES('" +
                         this.料号.Text.Trim().ToUpper () + "','" +
                         this.机型.Text.Trim() + "','" +
                         this.电压.Text.Trim() + "','" +
                         this.电流.Text.Trim().ToUpper() + "','" +
                         this.EAN.Text.Trim().ToUpper() + "','" +
                         this.CPMID.Text.Trim() + "','" +
                         this.CMIIT.Text.Trim() + "','" +
                         this.CPU.Text.Trim() + "','" +
                         this.MEM.Text.Trim() + "','" +


                         this.HDD.Text.Trim().ToUpper() + "','" +
                         this.SSD.Text.Trim().ToUpper() + "','" +
                           this.SSHD.Text.Trim().ToUpper() + "','" +
                             this.MSATA.Text.Trim().ToUpper() + "','" +

                         this.LCD.Text.Trim() + "','" +
                         this.WEIGHT.Text.Trim() + "','" +
                         this.CCLABEL.Text.Trim() + 
                         "')";
                        querySdr.Close();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("New Save OK");

                        Clear();
                        this.料号.Focus();

                    }
                    cmd.Dispose();
                }
                conn.Close();

                queryLastesttoday();
                Clear();
            }
        }

        private void Clear()
        {
            this.机型.Text = ""; this.料号.Text = ""; this.电压.Text = ""; this.电流.Text = ""; this.EAN.Text = "";
            this.CPMID.Text = ""; this.CPU.Text = ""; this.MEM.Text = ""; this.HDD.Text = ""; this.LCD.Text = "";
            this.WEIGHT.Text = ""; this.SSD.Text = ""; this.CCLABEL.Text = ""; this.CMIIT.Text = ""; this.SSHD.Text = ""; this.MSATA.Text = "";


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
                //dataGridView1.DataSource = ds.Tables[0];
               // dataGridView1.RowHeadersVisible = false;
                mConn.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 料号_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.料号.Text != "")
                {
                    LoadData();
                    this.机型.Focus();

                }
                else
                {
                    this.料号.Focus();
                }

            }
        }
        private void LoadData()
        {
            if (this.料号.Text.Trim() != "")
            {
                SqlConnection conn = new SqlConnection(Conlist.ConStr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    string tableName = "RatingLabel";
                    cmd.CommandText = "select *  from " + tableName + " where 料号 = '" + this.料号.Text.Trim() + "'  ";
                    SqlDataReader querySdr = cmd.ExecuteReader();
                    while (querySdr.Read())
                    // if (querySdr.HasRows == true)
                    {
                        this.机型.Text = querySdr["机型"].ToString().Trim ();
                        this.电压.Text = querySdr["电压"].ToString().Trim();
                        this.电流.Text = querySdr["电流"].ToString().Trim();
                        this.EAN.Text = querySdr["EAN"].ToString().Trim();

                        this.CMIIT.Text = querySdr["CMIIT"].ToString().Trim();
                        this.CPMID.Text = querySdr["CPMID"].ToString().Trim();
                        this.CPU.Text = querySdr["CPU"].ToString().Trim();
                        this.MEM.Text = querySdr["MEM"].ToString().Trim();


                        this.HDD.Text = querySdr["HDD"].ToString().Trim();
                        this.SSD.Text = querySdr["SSD"].ToString().Trim();

                        this.SSHD.Text = querySdr["SSHD"].ToString().Trim();
                        this.MSATA.Text = querySdr["MSATA"].ToString().Trim();


                        this.LCD.Text = querySdr["LCD"].ToString().Trim();
                        this.WEIGHT.Text = querySdr["WEIGHT"].ToString().Trim();

                        this.CCLABEL.Text = querySdr["CCLABEL"].ToString().Trim();
                        
                    }
                    //querySdr.Close();
                    cmd.Dispose();
                }
                conn.Close();

                queryLastesttoday();

            }

        }

        private void RatingLabel_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.GetType().
               GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).
               SetValue(tableLayoutPanel1, true, null);
            tableLayoutPanel2.GetType().
                GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).
                SetValue(tableLayoutPanel2, true, null);
        }
    }
}
