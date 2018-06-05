using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaledServices.CustomsContentClass;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using NBRepair;

namespace SaledServices.CustomsExport
{
    public class GenerateWorkOrderBody
    {
        WorkListBodyClass workListBody = new WorkListBodyClass();
        List<WorkOrderList> workOrderList = new List<WorkOrderList>();

        string seq_no = "";//DateTime.Now.ToString("yyyyMMdd") + "4003" + "1";//日期+类型,后面需要加入序号信息
        string boxtype = "4003";//代码
        string flowstateg = "";
        string trade_code = "";
        string ems_no = "";

        string status = "A";
        string startTime;
        string endTime;
        //string today = DateTime.Now.ToString("yyyy/MM/dd");

        public GenerateWorkOrderBody(string tradeCode, string emsNo, DateTime currentday)
        {
            this.trade_code = tradeCode;
            this.ems_no = emsNo;
            this.startTime = currentday.ToString("yyyy/MM/dd");
            this.endTime = currentday.ToString("yyyy/MM/dd");
            seq_no = currentday.ToString("yyyyMMdd") + "4003" + "02";//01代表维修， 02代表整机
        }

        public void addWorkOrderList()
        {
            try
            {
                List<MaterialCustomRelation> MaterialCustomRelationList = new List<MaterialCustomRelation>();

                SqlConnection mConn = new SqlConnection(Conlist.ConStr);
                mConn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = mConn;
                cmd.CommandType = CommandType.Text;

                //使用PackDate日期而不是采用维修日期，因为pack的日期确定了全部的使用材料
                cmd.CommandText = "select NBSerial, COVERSN, BRZELSN,UPSN,LOWSN,OTHERSN,RepairDate from NBShouLiao where PackDate between '" + startTime + "' and '" + endTime + "'";
                SqlDataReader querySdr = cmd.ExecuteReader();

                while (querySdr.Read())
                {
                    if (querySdr[1].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        MaterialCustomRelationTemp.mpn = querySdr[1].ToString().Trim();
                        MaterialCustomRelationTemp.num = "1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[6].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);          
                    }

                    if (querySdr[2].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        MaterialCustomRelationTemp.mpn = querySdr[2].ToString().Trim();
                        MaterialCustomRelationTemp.num = "1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[6].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }

                    if (querySdr[3].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        MaterialCustomRelationTemp.mpn = querySdr[3].ToString().Trim();
                        MaterialCustomRelationTemp.num = "1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[6].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }

                    if (querySdr[4].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        MaterialCustomRelationTemp.mpn = querySdr[4].ToString().Trim();
                        MaterialCustomRelationTemp.num = "1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[6].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }

                    if (querySdr[5].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        MaterialCustomRelationTemp.mpn = querySdr[5].ToString().Trim();
                        MaterialCustomRelationTemp.num = "1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[6].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }                            
                }
                querySdr.Close();

                foreach (MaterialCustomRelation materialTemp in MaterialCustomRelationList)
                {
                    WorkOrderList init1 = new WorkOrderList();
                    init1.wo_no = materialTemp.id;
                    init1.take_date = Untils.getCustomDate(materialTemp.date);
                    init1.goods_nature = "I";
                    init1.cop_g_no = materialTemp.mpn;
                    init1.qty = materialTemp.num;
                    init1.unit =Untils.getCustomCode(materialTemp.declare_unit);
                    init1.emo_no = ems_no;

                    workOrderList.Add(init1);
                }
                
                mConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void doGenerate()
        {
            workListBody.seq_no = seq_no;
            workListBody.boxtype = boxtype;
            workListBody.flowstateg = flowstateg;
            workListBody.trade_code = trade_code;
            workListBody.ems_no = ems_no;
            workListBody.status = status;

            workListBody.workOrderList = workOrderList;

            if (workOrderList.Count > 0)
            {
                Untils.createWorkListBodyXML(workListBody, "D:\\WO_ITEM" + seq_no + ".xml");
                MessageBox.Show(startTime+"工单表体信息产生成功！");
            }
            else
            {
                MessageBox.Show(startTime+"工单表体信息不存在！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
