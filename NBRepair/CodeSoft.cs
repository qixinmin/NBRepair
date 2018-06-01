using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace NBRepair
{
    class CodeSoft
    {
        public static string CodeSoftPath = "D:\\CodeSoftModel\\";
        public static string ReturnCodeSoftModel = "ReturnModel";
        
        public  static  LabelManager2.Document POD = null;// new LabelManager2.Document();
        public static string PODModel = "PODModel";
        
      
       // public static LabelManager2.Document CartonLabel = new LabelManager2.Document();
        public static string CartonLabelModel = "CartonLabelModel";




       public static LabelManager2.Application labApp = null;//new LabelManager2.Application();
        
      
        public static void initCodesoftModel(string codesoftmodelname)
        {
            if (labApp == null)
            {
                labApp = new LabelManager2.Application();
            }

            if (POD != null)
            {
                POD.Close();
            }

            string labFileName = CodeSoftPath + codesoftmodelname.Replace ("Model","") + ".Lab";
            try
            {
                if (!File.Exists(labFileName))
                {
                    MessageBox.Show("沒有找到標簽模板文件："+ codesoftmodelname.Replace ("Model","") + ".Lab     請聯系系統管理員", "溫馨提示");
                    return;
                }
               labApp.Documents.Open(labFileName, false);// 调用设计好的label文件
               POD = labApp.ActiveDocument;
            }
            catch
            {
            }
            finally
            {
            }
        }
        public static void MakePath(string path)
        {
            if (Directory.Exists(path))
            {
            }
            else
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
