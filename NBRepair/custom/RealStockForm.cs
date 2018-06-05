using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaledServices.CustomsContentClass;
using System.Data.SqlClient;
using NBRepair;

namespace SaledServices.CustomsExport
{
    public partial class RealStockForm : Form
    {
        public RealStockForm()
        {
            InitializeComponent();
        }

        private void exportxmlbutton_Click(object sender, EventArgs e)
        {
            DateTime time1 = Convert.ToDateTime(this.dateTimePickerstart.Value.Date.ToString("yyyy/MM/dd"));
            DateTime time2 = Convert.ToDateTime(this.dateTimePickerend.Value.Date.ToString("yyyy/MM/dd"));

            if (DateTime.Compare(time1, time2) > 0) //判断日期大小
            {
                MessageBox.Show("开始日期大于结束");
                return;
            }

            string startTime = this.dateTimePickerstart.Value.ToString("yyyy/MM/dd");
            string endTime = this.dateTimePickerend.Value.ToString("yyyy/MM/dd");

            RealStockClass realstock = new RealStockClass();
            List<StoreAmount> storeAmountList = new List<StoreAmount>();

            string seq_no = DateTime.Now.ToString("yyyyMMdd") + "2006" + "02";//日期+类型+序号01代表维修， 02代表整机
            string boxtype = "2006";//代码
            string flowstateg = "";
            string trade_code = "";
            string ems_no = "";

            trade_code = "3401560011";
            ems_no = "H33138000002";

            string status = "A";
            try
            {
                SqlConnection mConn = new SqlConnection(Conlist.ConStr);
                mConn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = mConn;
                cmd.CommandType = CommandType.Text;

                //1 读取材料库房信息
                cmd.CommandText = "select materialNo,number from materialhouse where materialNo!='' and number !='0'";
                SqlDataReader querySdr = cmd.ExecuteReader();
                while (querySdr.Read())
                {
                    StoreAmount init1 = new StoreAmount();
                    init1.ems_no = ems_no;
                    init1.cop_g_no = querySdr[0].ToString();
                    init1.qty = querySdr[1].ToString();
                    init1.unit = "007";
                    init1.goods_nature = "I";//代码
                    init1.bom_version = "";
                    init1.stock_date = Untils.getCustomCurrentDate();
                    init1.date_type = "B";//代码
                    init1.whs_code = "";
                    init1.location_code = "";
                    init1.note = "";
                    storeAmountList.Add(init1);
                }
                querySdr.Close();

                //2 整机良品库
                cmd.CommandText = "select model,number from NBHouse where model!='' and number !='0'";
                querySdr = cmd.ExecuteReader();
                while (querySdr.Read())
                {
                    StoreAmount init1 = new StoreAmount();
                    init1.ems_no = ems_no;
                    init1.cop_g_no = querySdr[0].ToString();
                    init1.qty = querySdr[1].ToString();
                    init1.unit = "007";
                    init1.goods_nature = "I";//代码
                    init1.bom_version = "";
                    init1.stock_date = Untils.getCustomCurrentDate();
                    init1.date_type = "B";//代码
                    init1.whs_code = "";
                    init1.location_code = "";
                    init1.note = "";
                    storeAmountList.Add(init1);
                }
                querySdr.Close();

                //3 材料不良品库房
                cmd.CommandText = "select materialNo,number from materialNgHouse where materialNo!='' and number !='0'";
                querySdr = cmd.ExecuteReader();
                while (querySdr.Read())
                {
                    StoreAmount init1 = new StoreAmount();
                    init1.ems_no = ems_no;
                    init1.cop_g_no = querySdr[0].ToString();
                    init1.qty = querySdr[1].ToString();
                    init1.unit = "007";
                    init1.goods_nature = "I";//代码
                    init1.bom_version = "";
                    init1.stock_date = Untils.getCustomCurrentDate();
                    init1.date_type = "B";//代码
                    init1.whs_code = "";
                    init1.location_code = "";
                    init1.note = "";
                    storeAmountList.Add(init1);
                }
                querySdr.Close();

                mConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            realstock.seq_no = seq_no;
            realstock.boxtype = boxtype;
            realstock.flowstateg = flowstateg;
            realstock.trade_code = trade_code;
            realstock.ems_no = ems_no;
            realstock.status = status;

            realstock.storeAmountList = storeAmountList;
            if(storeAmountList.Count>0)
            {
                Untils.createRealStockXML(realstock, "D:\\STORE_AMOUNT"+seq_no+".xml");
                MessageBox.Show("海关实盘库存信息产生成功！");
            }
            else
            {
                MessageBox.Show("没有实盘库存信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
