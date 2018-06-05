using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using SaledServices.CustomsContentClass;
using System.Data.SqlClient;
using NBRepair;

namespace SaledServices.CustomsExport
{
    public partial class OpeningStockForm : Form
    {
        public OpeningStockForm()
        {
            InitializeComponent();
        }

        private void exportxmlbutton_Click(object sender, EventArgs e)
        {
            DateTime time1 = Convert.ToDateTime(this.dateTimePickerstart.Value.Date.ToString("yyyy/MM/dd"));
            DateTime time2 = Convert.ToDateTime(this.dateTimePickerend.Value.Date.ToString("yyyy/MM/dd"));   

            if (DateTime.Compare(time1,time2)>0) //判断日期大小
            {
                MessageBox.Show("开始日期大于结束");
                return;
            }

            string startTime = this.dateTimePickerstart.Value.ToString("yyyy/MM/dd");
            string endTime = this.dateTimePickerend.Value.ToString("yyyy/MM/dd");

            OpeningStockClass openingstock = new OpeningStockClass();
            List<StoreInit> storeInitList = new List<StoreInit>();

            string seq_no = DateTime.Now.ToString("yyyyMMdd") + "2005" + "02";//日期+类型+序号 01代表维修， 02代表整机

            string boxtype = "2005";//代码 
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
                    StoreInit init1 = new StoreInit();
                    init1.ems_no = ems_no;
                    init1.cop_g_no = querySdr[0].ToString();
                    init1.qty = querySdr[1].ToString();                    
                    init1.unit = "007";                    
                    init1.goods_nature = "I";//代码
                    init1.bom_version = "";
                    init1.check_date = Untils.getCustomCurrentDate();
                    init1.date_type = "C";//代码
                    init1.whs_code = "";
                    init1.location_code = "";
                    init1.note = "";
                    storeInitList.Add(init1);
                }
                querySdr.Close();

                //2 整机良品库
                cmd.CommandText = "select model,number from NBHouse where model!='' and number !='0'";
                querySdr = cmd.ExecuteReader();
                while (querySdr.Read())
                {
                    StoreInit init1 = new StoreInit();
                    init1.ems_no = ems_no;
                    init1.cop_g_no = querySdr[0].ToString();
                    init1.qty = querySdr[1].ToString();
                    init1.unit = "007";
                    init1.goods_nature = "I";//代码
                    init1.bom_version = "";
                    init1.check_date = Untils.getCustomCurrentDate();
                    init1.date_type = "C";//代码
                    init1.whs_code = "";
                    init1.location_code = "";
                    init1.note = "";
                    storeInitList.Add(init1);
                }
                querySdr.Close();
               
                //3 材料不良品库房
                cmd.CommandText = "select materialNo,number from materialNgHouse where materialNo!='' and number !='0'";
                querySdr = cmd.ExecuteReader();
                while (querySdr.Read())
                {
                    StoreInit init1 = new StoreInit();
                    init1.ems_no = ems_no;
                    init1.cop_g_no = querySdr[0].ToString();
                    init1.qty = querySdr[1].ToString();
                    init1.unit = "007";
                    init1.goods_nature = "I";//代码
                    init1.bom_version = "";
                    init1.check_date = Untils.getCustomCurrentDate();
                    init1.date_type = "C";//代码
                    init1.whs_code = "";
                    init1.location_code = "";
                    init1.note = "";
                    storeInitList.Add(init1);
                }
                querySdr.Close();

                mConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            openingstock.seq_no = seq_no;
            openingstock.boxtype = boxtype;
            openingstock.flowstateg = flowstateg;
            openingstock.trade_code = trade_code;
            openingstock.ems_no = ems_no;
            openingstock.status = status;

            openingstock.storeInitList = storeInitList;

            if (storeInitList.Count > 0)
            {
                Untils.createOpeningStockXML(openingstock, "D:\\STORE_INIT" + seq_no + ".xml");
                MessageBox.Show("海关期初库存信息产生成功！");
            }
            else
            {
                MessageBox.Show("没有期初库存信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
