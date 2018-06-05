using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaledServices.CustomsContentClass;
using System.Windows.Forms;
using NBRepair;

namespace SaledServices.CustomsExport
{
    public class GenerateWorkOrderHead
    {
        WorkListHeadClass workListHead = new WorkListHeadClass();
        List<WorkOrderHead> workOrderHeadList = new List<WorkOrderHead>();

        string trade_code;
        string ems_no;

        string seq_no ="";// DateTime.Now.ToString("yyyyMMdd") + "4002" + "1";//日期+类型,后面需要加入序号信息
        string boxtype = "4002";//代码
        string flowstateg = "";

        string status = "A";

        DateTime currentDay;
        public GenerateWorkOrderHead(string tradeCode, string emsNo,DateTime currentday)
        {
            this.trade_code = tradeCode;
            this.ems_no = emsNo;
            currentDay = currentday;
            seq_no = currentday.ToString("yyyyMMdd") + "4002" + "02";//01代表维修， 02代表整机
        }

        public void addWorkListHeads(List<TrackNoCustomRelation> TrackNoCustomRelationList)
        {
            foreach (TrackNoCustomRelation trackTemp in TrackNoCustomRelationList)
            {
                WorkOrderHead init1 = new WorkOrderHead();
                init1.wo_no = trackTemp.trackno;
                init1.wo_date = Untils.getCustomDate(trackTemp.date);
                init1.goods_nature = "E";
                init1.cop_g_no = trackTemp.custom_materialNo;                
                init1.qty = "1";
                init1.unit = Untils.getCustomCode(trackTemp.declare_unit);
                init1.emo_no = ems_no;

                workOrderHeadList.Add(init1);
            }
        }

        public void doGenerate()
        {
            workListHead.seq_no = seq_no;
            workListHead.boxtype = boxtype;
            workListHead.flowstateg = flowstateg;
            workListHead.trade_code = trade_code;
            workListHead.ems_no = ems_no;
            workListHead.status = status;

            workListHead.workOrderHeadList = workOrderHeadList;

            if (workOrderHeadList.Count > 0)
            {
                Untils.createWorkListHeadXML(workListHead, "D:\\WO_HEAD" + seq_no + ".xml");
                MessageBox.Show(currentDay.ToString("yyyyMMdd") + "工单表头信息产生成功！");
            }
            else
            {
                MessageBox.Show(currentDay.ToString("yyyyMMdd") + "没有工单表头信息产生！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
