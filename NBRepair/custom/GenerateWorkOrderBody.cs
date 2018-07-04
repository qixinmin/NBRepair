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

                Dictionary<string, string> bomDict = new Dictionary<string, string>();
                cmd.CommandText = "select distinct LNV_PN,LCFC_PN from BOMCompare";
                SqlDataReader querySdr = cmd.ExecuteReader();
                while (querySdr.Read())
                {
                    string key = querySdr[0].ToString().Trim();
                    if (key != "NULL" && key !="" && bomDict.ContainsKey(key) == false)
                    {
                        bomDict.Add(key, querySdr[1].ToString().Trim());
                    }
                }
                querySdr.Close();

                //使用PackDate日期而不是采用维修日期，因为pack的日期确定了全部的使用材料

                cmd.CommandText = "select NBID,COVERSN,BRZELSN,UPSN,LOWSN,KBSN,KBUPSN,BatterySN,BatterySN1,RADAPTER,OTHERSN,materials,RepairDate from NBShouLiao where PackDate between '" + startTime + "' and '" + endTime + "'";
                querySdr = cmd.ExecuteReader();

                while (querySdr.Read())
                {
                    if (querySdr[1].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();

                        string temp = querySdr[1].ToString().Trim();
                        temp = GetPartsNo(temp,10);

                        if(temp.Length !=11)
                        {
                            temp = bomDict[temp];
                        }

                        MaterialCustomRelationTemp.mpn = temp;
                        MaterialCustomRelationTemp.num = "-1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[12].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);          
                    }

                    if (querySdr[2].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        string temp = querySdr[2].ToString().Trim();
                        temp = GetPartsNo(temp, 10);

                        if (temp.Length != 11)
                        {
                            temp = bomDict[temp];
                        }

                        MaterialCustomRelationTemp.mpn = temp;
                        MaterialCustomRelationTemp.num = "-1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[12].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }

                    if (querySdr[3].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        string temp = querySdr[3].ToString().Trim();
                        temp = GetPartsNo(temp, 10);

                        if (temp.Length != 11)
                        {
                            temp = bomDict[temp];
                        }

                        MaterialCustomRelationTemp.mpn = temp;
                        MaterialCustomRelationTemp.num = "-1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[12].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }

                    if (querySdr[4].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        string temp = querySdr[4].ToString().Trim();
                        temp = GetPartsNo(temp, 10);

                        if (temp.Length != 11)
                        {
                            temp = bomDict[temp];
                        }

                        MaterialCustomRelationTemp.mpn = temp;
                        MaterialCustomRelationTemp.num = "-1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[12].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }

                    if (querySdr[5].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        string temp = querySdr[5].ToString().Trim();
                        temp = GetPartsNo(temp, 10);

                        if (temp.Length != 11)
                        {
                            temp = bomDict[temp];
                        }

                        MaterialCustomRelationTemp.mpn = temp;
                        MaterialCustomRelationTemp.num = "-1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[12].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }

                    if (querySdr[6].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        string temp = querySdr[6].ToString().Trim();
                        temp = GetPartsNo(temp, 10);

                        if (temp.Length != 11)
                        {
                            temp = bomDict[temp];
                        }

                        MaterialCustomRelationTemp.mpn = temp;
                        MaterialCustomRelationTemp.num = "-1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[12].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }

                    if (querySdr[7].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString(); 
                        string temp = querySdr[7].ToString().Trim();
                        temp = GetPartsNo(temp, 10);

                        if (temp.Length != 11)
                        {
                            temp = bomDict[temp];
                        }

                        MaterialCustomRelationTemp.mpn = temp;
                        MaterialCustomRelationTemp.num = "-1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[12].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }

                    if (querySdr[8].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        string temp = querySdr[8].ToString().Trim();
                        temp = GetPartsNo(temp, 10);

                        if (temp.Length != 11)
                        {
                            temp = bomDict[temp];
                        }

                        MaterialCustomRelationTemp.mpn = temp;
                        MaterialCustomRelationTemp.num = "-1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[12].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }

                    if (querySdr[9].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        string temp = querySdr[9].ToString().Trim();
                        temp = GetPartsNo(temp, 10);

                        if (temp.Length != 11)
                        {
                            temp = bomDict[temp];
                        }

                        MaterialCustomRelationTemp.mpn = temp;
                        MaterialCustomRelationTemp.num = "-1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[12].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }

                    if (querySdr[10].ToString().Trim() != "")
                    {
                        MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                        MaterialCustomRelationTemp.id = querySdr[0].ToString();
                        string temp = querySdr[10].ToString().Trim();
                        temp = GetPartsNo(temp, 10);

                        if (temp.Length != 11)
                        {
                            temp = bomDict[temp];
                        }

                        MaterialCustomRelationTemp.mpn = temp;
                        MaterialCustomRelationTemp.num = "-1";
                        MaterialCustomRelationTemp.declare_unit = "个";
                        MaterialCustomRelationTemp.date = querySdr[12].ToString();

                        MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                    }


                    if (querySdr[11].ToString().Trim() != "")
                    {
                        string content = querySdr[11].ToString().Trim();
                        string[] contentarray = content.Split(':');
                        Dictionary<string, string> material_num = new Dictionary<string,string>();
                        foreach(string temp in contentarray)
                        {
                            if(temp.Trim() != "")
                            {
                                material_num.Add(temp.Split(',')[0], temp.Split(',')[1]);
                            }
                        }
                       // HG12S000100,1:HG0SA000I00,1:HG0ZJ000U00,1:HG0SI000E00,1:HG0TX000X00,1:HG0TS000J00,1:HK0SI000600,1:HK0ZQ000100,1:HE12D000100,2:HE169000210,1:HK0TV000100,1:HA105000100,1:HE105000100,1:HB10A000100,1: 
                        foreach (string key in material_num.Keys)
                        {
                            MaterialCustomRelation MaterialCustomRelationTemp = new MaterialCustomRelation();
                            MaterialCustomRelationTemp.id = querySdr[0].ToString();
                            MaterialCustomRelationTemp.mpn = key;
                            MaterialCustomRelationTemp.num = "-"+material_num[key];
                            MaterialCustomRelationTemp.declare_unit = "个";
                            MaterialCustomRelationTemp.date = querySdr[12].ToString();

                            MaterialCustomRelationList.Add(MaterialCustomRelationTemp);
                        }                       
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

        public string GetPartsNo(string partsserial, int l)
        {
            string partsno = partsserial;
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
