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
    public partial class StockInOutForm : Form
    {
        public StockInOutForm()
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

            for (DateTime dt = time1; dt <= time2; dt = dt.AddDays(1))
            {
                //MessageBox.Show(dt.ToString("yyyy/MM/dd"));
                //生成每天的数据
                string startTime = dt.ToString("yyyy/MM/dd");
                string endTime = dt.ToString("yyyy/MM/dd");

                StockInOutClass stockinout = new StockInOutClass();
                List<StoreTrans> storeTransList = new List<StoreTrans>();

                GenerateWorkOrderHead generateWorkOrderHead = null;

                GenerateWorkOrderBody generateWorkOrderBody = null;

                string seq_no = dt.ToString("yyyyMMdd") + "4001" + "02";//日期+类型,后面需要加入序号信息01代表维修， 02代表整机
                string boxtype = "4001";//代码
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

                    generateWorkOrderHead = new GenerateWorkOrderHead(trade_code, ems_no, dt);
                    generateWorkOrderBody = new GenerateWorkOrderBody(trade_code, ems_no, dt);

                    Dictionary<string, string> nameDir = new Dictionary<string, string>();
                    cmd.CommandText = "select distinct SKU_LNO,SKU_NO from BOMCompare";
                    SqlDataReader querySdr = cmd.ExecuteReader();
                    while (querySdr.Read())
                    {
                        if (nameDir.ContainsKey(querySdr[0].ToString().Trim()) == false)
                        {
                            nameDir.Add(querySdr[0].ToString().Trim(), querySdr[1].ToString().Trim());
                        }
                    }
                    querySdr.Close();

                    //1 整机待维修入库
                    List<TrackNoCustomRelation> TrackNoCustomRelationList = new List<TrackNoCustomRelation>();
                    cmd.CommandText = "select NBID,SKU,declearNumber,receiveDate from NBShouLiao where receiveDate between '" + startTime + "' and '" + endTime + "'";
                    querySdr = cmd.ExecuteReader();
                    while (querySdr.Read())
                    {
                        TrackNoCustomRelation TrackNoCustomRelationTemp = new TrackNoCustomRelation();
                        TrackNoCustomRelationTemp.trackno = querySdr[0].ToString();
                        TrackNoCustomRelationTemp.custom_materialNo = nameDir[querySdr[1].ToString()];//正常使用客户料号
                        TrackNoCustomRelationTemp.declare_number = querySdr[2].ToString();
                        TrackNoCustomRelationTemp.date = querySdr[3].ToString();
                        TrackNoCustomRelationTemp.declare_unit = "台";
                        TrackNoCustomRelationList.Add(TrackNoCustomRelationTemp);
                    }
                    querySdr.Close();
                    if (TrackNoCustomRelationList.Count > 0)
                    {
                        //信息完全,生成信息
                        foreach (TrackNoCustomRelation trackTemp in TrackNoCustomRelationList)
                        {
                            StoreTrans init1 = new StoreTrans();
                            init1.ems_no = ems_no;
                            init1.io_no = trackTemp.trackno;
                            init1.goods_nature = "I";
                            init1.io_date = Untils.getCustomDate(trackTemp.date);
                            init1.cop_g_no = trackTemp.custom_materialNo;
                            init1.qty = "1";
                            init1.unit = Untils.getCustomCode(trackTemp.declare_unit);
                            init1.type = "I0002";
                            init1.chk_code = "";
                            init1.entry_id = trackTemp.declare_number;
                            init1.gatejob_no = "";
                            init1.whs_code = "";
                            init1.location_code = "";
                            init1.note = "";

                            storeTransList.Add(init1);
                        }
                    }

                    //2 整机待维修出库信息，复用上面的信息
                    if (TrackNoCustomRelationList.Count > 0)
                    {
                        //信息完全,生成信息
                        foreach (TrackNoCustomRelation trackTemp in TrackNoCustomRelationList)
                        {
                            StoreTrans init1 = new StoreTrans();
                            init1.ems_no = ems_no;
                            init1.io_no = trackTemp.trackno;
                            init1.goods_nature = "I";
                            init1.io_date = Untils.getCustomDate(trackTemp.date);
                            init1.cop_g_no = trackTemp.custom_materialNo;//正常使用客户料号
                            init1.qty = "-1";
                            init1.unit = Untils.getCustomCode(trackTemp.declare_unit);
                            init1.type = "E0003";//其他出库
                            init1.chk_code = "";
                            init1.entry_id = "";
                            init1.gatejob_no = "";
                            init1.whs_code = "";
                            init1.location_code = "";
                            init1.note = "";

                          //  storeTransList.Add(init1);
                        }
                    }

                    ////根据序列号查询Sku料号
                    //cmd.CommandText = "select SKU from NBShouLiao where NBSerial='" + NBSerial + "'";
                    //querySdr = cmd.ExecuteReader();
                    //string relatedSku = "";
                    //while (querySdr.Read())
                    //{
                    //    relatedSku = querySdr[0].ToString();
                    //    break;
                    //}
                    //querySdr.Close();

                    //3 整机良品入库信息
                    TrackNoCustomRelationList.Clear();
                    cmd.CommandText = "select NBID,NBSerial,rukudate from OUTNBRUKU where rukudate between '" + startTime + "' and '" + endTime + "'";
                    querySdr = cmd.ExecuteReader();
                    while (querySdr.Read())
                    {
                        TrackNoCustomRelation TrackNoCustomRelationTemp = new TrackNoCustomRelation();
                        TrackNoCustomRelationTemp.trackno = querySdr[0].ToString();                      

                        TrackNoCustomRelationTemp.custom_materialNo =nameDir[ querySdr[1].ToString().Substring(2,10)];//正常使用客户料号
                        TrackNoCustomRelationTemp.date = querySdr[2].ToString();
                        TrackNoCustomRelationTemp.declare_unit = "台";

                        TrackNoCustomRelationList.Add(TrackNoCustomRelationTemp);
                    }
                    querySdr.Close();

                    //转换从NBSerial转成SKU
                    foreach (TrackNoCustomRelation trackTemp in TrackNoCustomRelationList)
                    {
                        cmd.CommandText = "select SKU from NBShouLiao where NBSerial='" + trackTemp.trackno + "'";
                        querySdr = cmd.ExecuteReader();
                      
                        while (querySdr.Read())
                        {
                            trackTemp.custom_materialNo = nameDir[querySdr[0].ToString()];//转换为海关料号                   
                        }
                        querySdr.Close();
                    }

                    if (TrackNoCustomRelationList.Count > 0)
                    {
                        //信息完全,生成信息
                        foreach (TrackNoCustomRelation trackTemp in TrackNoCustomRelationList)
                        {
                            StoreTrans init1 = new StoreTrans();
                            init1.ems_no = ems_no;
                            init1.io_no = trackTemp.trackno;
                            init1.goods_nature = "E";//成品
                            init1.io_date = Untils.getCustomDate(trackTemp.date);
                            init1.cop_g_no = trackTemp.custom_materialNo;//正常使用客户料号
                            init1.qty = "1";
                            init1.unit = Untils.getCustomCode(trackTemp.declare_unit);
                            init1.type = "I0003";
                            init1.chk_code = "";
                            init1.entry_id = "";
                            init1.gatejob_no = "";
                            init1.whs_code = "";
                            init1.location_code = "";
                            init1.note = "";

                           // storeTransList.Add(init1);
                        }

                        generateWorkOrderHead.addWorkListHeads(TrackNoCustomRelationList);
                    }

                    //4. 整机良品出库，复用上面的信息，TODO 方案是采用excel上传的方式，比对条形码，料号，保证是今天上传的数据，然后读取上传的数据生成良品出库报文                                
                    TrackNoCustomRelationList.Clear();
                    cmd.CommandText = "select track_serial_no,custom_materialNo,declare_number,input_date from repaired_out_house_excel_table where input_date between '" + startTime + "' and '" + endTime + "'";
                    querySdr = cmd.ExecuteReader();
                    while (querySdr.Read())
                    {
                        TrackNoCustomRelation TrackNoCustomRelationTemp = new TrackNoCustomRelation();
                        TrackNoCustomRelationTemp.trackno = querySdr[0].ToString();

                        TrackNoCustomRelationTemp.custom_materialNo = nameDir[querySdr[1].ToString()]
                            ;//正常使用客户料号
                        TrackNoCustomRelationTemp.declare_number = querySdr[2].ToString();
                        TrackNoCustomRelationTemp.date = querySdr[3].ToString();
                        TrackNoCustomRelationTemp.declare_unit = "台";
                        TrackNoCustomRelationList.Add(TrackNoCustomRelationTemp);
                    }
                    querySdr.Close();
                    if (TrackNoCustomRelationList.Count > 0)
                    {
                        //信息完全,生成信息
                        foreach (TrackNoCustomRelation trackTemp in TrackNoCustomRelationList)
                        {
                            StoreTrans init1 = new StoreTrans();
                            init1.ems_no = ems_no;
                            init1.io_no = trackTemp.trackno;
                            init1.goods_nature = "E";
                            init1.io_date = Untils.getCustomDate(trackTemp.date);
                            init1.cop_g_no = trackTemp.custom_materialNo;//正常使用客户料号
                            init1.qty = "-1";
                            init1.unit = Untils.getCustomCode(trackTemp.declare_unit);
                            init1.type = "E0002";//报关出库
                            init1.chk_code = "";
                            init1.entry_id = trackTemp.declare_number;
                            init1.gatejob_no = "";
                            init1.whs_code = "";
                            init1.location_code = "";
                            init1.note = "";

                            storeTransList.Add(init1);
                        }
                    }

                    List<MaterialCustomRelation> MaterialCustomRelationList = new List<MaterialCustomRelation>();
                    //5 原材料入库 信息,todo 牵扯到区内流程的材料，只有申请单号，没有报关单号，todo, 也有报关单号的
                    cmd.CommandText = "select Id,partsno,qty,rukudate,delearNo from RuKu where rukudate between '" + startTime + "' and '" + endTime + "'";
                    querySdr = cmd.ExecuteReader();
                    while (querySdr.Read())
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        MaterialCustomRelationTemp.mpn = querySdr[1].ToString();                      
                        MaterialCustomRelationTemp.num = querySdr[2].ToString();
                        MaterialCustomRelationTemp.date = querySdr[3].ToString();
                        MaterialCustomRelationTemp.custom_request_number = querySdr[4].ToString();
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.type = "I0001";

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }
                    querySdr.Close();

                    if (MaterialCustomRelationList.Count > 0)
                    {

                        //信息完全,生成信息
                        foreach (MaterialCustomRelation materialTemp in MaterialCustomRelationList)
                        {
                            StoreTrans init1 = new StoreTrans();
                            init1.ems_no = ems_no;
                            init1.io_no = materialTemp.id;
                            init1.goods_nature = "I";
                            init1.io_date = Untils.getCustomDate(materialTemp.date);
                            init1.cop_g_no = materialTemp.mpn;//因为报关原因，需要改成71料号（联想料号）->上面已经修改
                            init1.qty = materialTemp.num;
                            init1.unit = Untils.getCustomCode(materialTemp.declare_unit);
                            init1.type = materialTemp.type;
                            init1.chk_code = "";
                            init1.entry_id = "";
                            init1.gatejob_no = materialTemp.custom_request_number;
                            init1.whs_code = "";
                            init1.location_code = "";
                            init1.note = "";

                            storeTransList.Add(init1);
                        }
                    }
                  
                    //6 原材料出库
                    MaterialCustomRelationList.Clear();
                    cmd.CommandText = "select Id,partsno,qty,chukudate from ChuKu where chukudate between '" + startTime + "' and '" + endTime + "'";
                    querySdr = cmd.ExecuteReader();
                    while (querySdr.Read())
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        MaterialCustomRelationTemp.mpn = querySdr[1].ToString();
                        MaterialCustomRelationTemp.num = querySdr[2].ToString();
                        MaterialCustomRelationTemp.date = querySdr[3].ToString();
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }
                    querySdr.Close();

                    if (MaterialCustomRelationList.Count > 0)
                    {
                        //信息完全,生成信息
                        foreach (MaterialCustomRelation materialTemp in MaterialCustomRelationList)
                        {
                            StoreTrans init1 = new StoreTrans();
                            init1.ems_no = ems_no;
                            init1.io_no = materialTemp.id;
                            init1.goods_nature = "I";
                            init1.io_date = Untils.getCustomDate(materialTemp.date);
                            init1.cop_g_no = materialTemp.mpn;
                            init1.qty = "-" + materialTemp.num;
                            init1.unit = Untils.getCustomCode(materialTemp.declare_unit);
                            init1.type = "E0003";
                            init1.chk_code = "";
                            init1.entry_id = "";
                            init1.gatejob_no = "";
                            init1.whs_code = "";
                            init1.location_code = "";
                            init1.note = "";

                         //   storeTransList.Add(init1);
                        }
                    }

                    //6 不良品材料入库
                    MaterialCustomRelationList.Clear();
                    cmd.CommandText = "select Id,materialNo,number,input_date from materialNgHouseRecord where input_date between '" + startTime + "' and '" + endTime + "'";
                    querySdr = cmd.ExecuteReader();
                    while (querySdr.Read())
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        MaterialCustomRelationTemp.mpn = querySdr[1].ToString();
                        MaterialCustomRelationTemp.num = querySdr[2].ToString();
                        MaterialCustomRelationTemp.date = querySdr[3].ToString();
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }
                    querySdr.Close();

                    if (MaterialCustomRelationList.Count > 0)
                    {
                        //信息完全,生成信息
                        foreach (MaterialCustomRelation materialTemp in MaterialCustomRelationList)
                        {
                            StoreTrans init1 = new StoreTrans();
                            init1.ems_no = ems_no;
                            init1.io_no = materialTemp.id;
                            init1.goods_nature = "I";
                            init1.io_date = Untils.getCustomDate(materialTemp.date);
                            init1.cop_g_no = materialTemp.mpn;
                            init1.qty = materialTemp.num;
                            init1.unit = Untils.getCustomCode(materialTemp.declare_unit);
                            init1.type = "I0003";
                            init1.chk_code = "";
                            init1.entry_id = "";
                            init1.gatejob_no = "";
                            init1.whs_code = "";
                            init1.location_code = "";
                            init1.note = "";

                          //  storeTransList.Add(init1);
                        }
                    }

                    //6 不良品材料报关出库
                    MaterialCustomRelationList.Clear();
                    cmd.CommandText = "select Id,mpn,in_number,input_date,declare_unit,declare_number,custom_request_number from ng_out_house_table where input_date between '" + startTime + "' and '" + endTime + "'";
                    querySdr = cmd.ExecuteReader();
                    while (querySdr.Read())
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        MaterialCustomRelationTemp.mpn = querySdr[1].ToString();
                        MaterialCustomRelationTemp.num = querySdr[2].ToString();
                        MaterialCustomRelationTemp.date = querySdr[3].ToString();
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.declare_number = querySdr[5].ToString();
                        MaterialCustomRelationTemp.custom_request_number = querySdr[6].ToString();
                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }
                    querySdr.Close();

                    if (MaterialCustomRelationList.Count > 0)
                    {
                        //信息完全,生成信息
                        foreach (MaterialCustomRelation materialTemp in MaterialCustomRelationList)
                        {
                            StoreTrans init1 = new StoreTrans();
                            init1.ems_no = ems_no;
                            init1.io_no = materialTemp.id;
                            init1.goods_nature = "I";
                            init1.io_date = Untils.getCustomDate(materialTemp.date);
                            init1.cop_g_no = materialTemp.mpn;
                            init1.qty = "-"+materialTemp.num;
                            init1.unit = Untils.getCustomCode(materialTemp.declare_unit);
                            init1.type = "E0002";
                            init1.chk_code = "";
                            init1.entry_id = materialTemp.declare_number;
                            init1.gatejob_no = materialTemp.custom_request_number;
                            init1.whs_code = "";
                            init1.location_code = "";
                            init1.note = "";

                            storeTransList.Add(init1);
                        }
                    }

                    mConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                stockinout.seq_no = seq_no;
                stockinout.boxtype = boxtype;
                stockinout.flowstateg = flowstateg;
                stockinout.trade_code = trade_code;
                stockinout.ems_no = ems_no;
                stockinout.status = status;

                stockinout.storeTransList = storeTransList;
                if (storeTransList.Count > 0)//没有数据就不产生文件
                {
                    Untils.createStockInOutXML(stockinout, "D:\\WO_HCHX" + seq_no + ".xml");
                    MessageBox.Show( dt.ToString("yyyyMMdd") + "海关出入库信息产生成功！");
                }
                else
                {
                    MessageBox.Show( dt.ToString("yyyyMMdd") + "没有出入库信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (generateWorkOrderHead != null)
                {
                    generateWorkOrderHead.doGenerate();
                }
                if (generateWorkOrderBody != null)
                {
                    generateWorkOrderBody.addWorkOrderList();
                    generateWorkOrderBody.doGenerate();
                }
            }
        }
    }
}
