using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using NBRepair;

namespace SaledServices
{
    public partial class FaultMaterialOutForm : Form
    {
        private SqlConnection mConn;
        private DataSet ds;
        private SqlDataAdapter sda;
        private String tableName = "ng_out_house_table";

        public FaultMaterialOutForm()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (this.mpnTextBox.Text.Trim() == "" 
                || this.numberTextBox.Text.Trim() == ""
                || this.unitComboBox.Text.Trim() == ""             
                || this.declare_numberTextBox.Text.Trim() == ""
                || this.custom_request_numberTextBox.Text.Trim() == ""
                )
            {
                MessageBox.Show("需要输入的内容为空!");
                return;
            }

            try
            {
                SqlConnection conn = new SqlConnection(Conlist.ConStr);
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;

                    //不良品库, 需要更新库房对应储位的数量 减去 本次出库的数量
                    //根据mpn查对应的查询
                    cmd.CommandText = "select materialNo,number from materialNgHouse where materialNo='" + this.mpnTextBox.Text.Trim() + "'";
                    SqlDataReader querySdr = cmd.ExecuteReader();
                    string   number = "0";
                    while (querySdr.Read())
                    {                      
                        number = querySdr[0].ToString();
                    }
                    querySdr.Close();

                    int outNumber = Int32.Parse(this.numberTextBox.Text);
                    int stockNumber = Int32.Parse(number);
                    if(outNumber > stockNumber)
                    {
                        MessageBox.Show("出库的数量大于库存的数量！");
                        conn.Close();
                        return;
                    }

                    cmd.CommandText = "update materialNgHouse set number = '" + (stockNumber - outNumber) + "' where materialNo='" + this.mpnTextBox.Text.Trim() + "'";
                    cmd.ExecuteNonQuery();

                    //插入一条不良品出库记录
                    cmd.CommandText = "INSERT INTO ng_out_house_table VALUES('" +
                        this.mpnTextBox.Text.Trim() + "','" +
                        this.numberTextBox.Text.Trim() + "','" +
                        DateTime.Now.ToString("yyyy/MM/dd") + "','" +
                        this.unitComboBox.Text.Trim() + "','" +
                        this.declare_numberTextBox.Text.Trim() + "','" +
                        this.custom_request_numberTextBox.Text.Trim() +                         
                        "')";

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("SaledService is not opened");
                }

                conn.Close();
                MessageBox.Show("新增成功！");
                query_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void query_Click(object sender, EventArgs e)
        {
            try
            {
                mConn = new SqlConnection(Conlist.ConStr);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = mConn;
                cmd.CommandText = "select Id,mpn,in_number,declare_unit,declare_number,custom_request_number from  " + tableName;
                cmd.CommandType = CommandType.Text;

                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds, tableName);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            string[] hTxt = { "ID", "MPN","数量","单位","报关单号","申请单号" };
            for (int i = 0; i < hTxt.Length; i++)
            {
                dataGridView1.Columns[i].HeaderText = hTxt[i];
            }
            MessageBox.Show("查询完成！");
        }

        private void modify_Click(object sender, EventArgs e)
        {
            DataTable dt = ds.Tables[tableName];
            sda.FillSchema(dt, SchemaType.Mapped);
            DataRow dr = dt.Rows.Find(this.idTextBox.Text.Trim());
          
            dr["mpn"] = this.mpnTextBox.Text.Trim();
            dr["in_number"] = this.numberTextBox.Text.Trim();
            dr["declare_unit"] = this.unitComboBox.Text.Trim();
            dr["declare_number"] = this.declare_numberTextBox.Text.Trim();
            dr["custom_request_number"] = this.custom_request_numberTextBox.Text.Trim();

            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(sda);
            sda.Update(dt);
            MessageBox.Show("修改成功！");
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Conlist.ConStr);
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Delete from " + tableName + " where id = " + dataGridView1.SelectedCells[0].Value.ToString();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("SaledService is not opened");
                }

                conn.Close();
                MessageBox.Show("删除完毕!");
                query_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            this.idTextBox.Text = dataGridView1.SelectedCells[0].Value.ToString();
         
            this.mpnTextBox.Text = dataGridView1.SelectedCells[1].Value.ToString();
            this.numberTextBox.Text = dataGridView1.SelectedCells[2].Value.ToString();
            this.unitComboBox.Text = dataGridView1.SelectedCells[3].Value.ToString();
            this.declare_numberTextBox.Text = dataGridView1.SelectedCells[4].Value.ToString();
            this.custom_request_numberTextBox.Text = dataGridView1.SelectedCells[5].Value.ToString();          
        }

        private void mpnTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == System.Convert.ToChar(13))
            {
                if (this.mpnTextBox.Text == "")
                {
                    MessageBox.Show("MPN的内容不能为空！");
                    return;
                }

                try
                {
                    SqlConnection mConn = new SqlConnection(Conlist.ConStr);
                    mConn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = mConn;
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "select number,materialNo from materialNgHouse where materialNo like '%" + this.mpnTextBox.Text.Trim() + "%'";
                    SqlDataReader querySdr = cmd.ExecuteReader();
                    string number = "";
                    while (querySdr.Read())
                    {
                        number = querySdr[0].ToString();                       
                    }
                    querySdr.Close();

                    if (number == "")
                    {
                        MessageBox.Show("此料号不存在！");
                    }
                    
                    mConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
             }
        }        
    }
}
