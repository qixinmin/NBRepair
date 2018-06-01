﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace NBRepair
{
    class EXCELIO
    {
         private int _ReturnStatus;
     private string _ReturnMessage;
 
     /// <summary>
     /// 执行返回状态
     /// </summary>
     public int ReturnStatus
     {
         get{return _ReturnStatus;}
     }
 
     /// <summary>
     /// 执行返回信息
     /// </summary>
     public string ReturnMessage
     {
         get{return _ReturnMessage;}
     }
 
    
 
     /// <summary>
     /// 导入EXCEL到DataSet
     /// </summary>
     /// <param name="fileName">Excel全路径文件名</param>
     /// <returns>导入成功的DataSet</returns>
     public DataSet ImportExcel(string fileName)
     {
         //判断是否安装EXCEL
         Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();          
         if(xlApp==null)
         {
             _ReturnStatus = -1;
             _ReturnMessage = "无法创建Excel对象，可能您的计算机未安装Excel";
             return null;
         }      
 
         //判断文件是否被其他进程使用           
         Microsoft.Office.Interop.Excel.Workbook workbook;               
         try
         {
             workbook = xlApp.Workbooks.Open(fileName,0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, 1, 0);
         }
         catch
         {
             _ReturnStatus = -1;
             _ReturnMessage = "Excel文件处于打开状态，请保存关闭";
             return null;
         }      
         
         //获得所有Sheet名称
         int n = workbook.Worksheets.Count;
         string[] SheetSet = new string[n];
         System.Collections.ArrayList al = new System.Collections.ArrayList();
         for(int i=1; i<=n; i++)
         {
             SheetSet[i-1] = ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[i]).Name;
         }
         
         //释放Excel相关对象
         workbook.Close(null,null,null);        
         xlApp.Quit();
         if(workbook != null)
         {
             System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
             workbook = null;
         }
         if(xlApp != null)
         {
             System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
             xlApp = null;
         }  
         GC.Collect();
         
         //把EXCEL导入到DataSet
         DataSet ds = new DataSet();        
         string connStr = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = "+ fileName +";Extended Properties=Excel 8.0" ;
         using(OleDbConnection conn = new OleDbConnection (connStr))
         {
             conn.Open();
             OleDbDataAdapter da;
             for(int i=1; i<=n; i++)
             {
                 string sql = "select * from ["+ SheetSet[i-1] +"$] ";
                 da = new OleDbDataAdapter(sql,conn);
                 da.Fill(ds,SheetSet[i-1]); 
                 da.Dispose();
             }              
             conn.Close();
             conn.Dispose();
         }              
         return ds;
     }
 
     /// <summary>
     /// 把DataTable导出到EXCEL
     /// </summary>
     /// <param name="reportName">报表名称</param>
     /// <param name="dt">数据源表</param>
     /// <param name="saveFileName">Excel全路径文件名</param>
     /// <returns>导出是否成功</returns>
     public   bool ExportExcel(string reportName,DataTable dt,string saveFileName)
     {
         if(dt==null)
         {
             _ReturnStatus = -1;
             _ReturnMessage = "数据集为空！";
             return false;          
         }
 
         bool fileSaved=false;

       
         Microsoft.Office.Interop.Excel.Application xlApp= new Microsoft.Office.Interop.Excel.Application();  
         if(xlApp==null)
         {
             _ReturnStatus = -1;
             _ReturnMessage = "无法创建Excel对象，可能您的计算机未安装Excel";
             return false;
         }
 
         Microsoft.Office.Interop.Excel.Workbooks workbooks=xlApp.Workbooks;
         Microsoft.Office.Interop.Excel.Workbook workbook=workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
         Microsoft.Office.Interop.Excel.Worksheet worksheet=(Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
         worksheet.Cells.Font.Size = 10;
         Microsoft.Office.Interop.Excel.Range range;
 
         long totalCount=dt.Rows.Count;
         long rowRead=0;
         float percent=0;
 
         worksheet.Cells[1,1]=reportName;
         ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1,1]).Font.Size = 12;
         ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1,1]).Font.Bold = true;
 
         //写入字段
         for(int i=0;i<dt.Columns.Count;i++)
         {
             worksheet.Cells[2,i+1]=dt.Columns[i].ColumnName;
             range=(Microsoft.Office.Interop.Excel.Range)worksheet.Cells[2,i+1];
             range.Interior.ColorIndex = 15;
             range.Font.Bold = true;
 
         }
         //写入数值
         for(int r=0;r<dt.Rows.Count;r++)
         {
             for(int i=0;i<dt.Columns.Count;i++)
             {
                 worksheet.Cells[r+3,i+1]=dt.Rows[r][i].ToString();
             }
             rowRead++;
             percent=((float)(100*rowRead))/totalCount;
         }
         
         range = worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[dt.Rows.Count + 2, dt.Columns.Count]];

         range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin,Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,null);
         
         if( dt.Rows.Count > 0)
         {
             range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].ColorIndex = Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic;
             range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
             range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].Weight =Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
         }
         if(dt.Columns.Count>1)
         {
             range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].ColorIndex =Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic;
             range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
             range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
         }
          
 
         //保存文件
         if(saveFileName!="")
         {
             try
             {
                 workbook.Saved =true;
                 workbook.SaveCopyAs(saveFileName);
                 fileSaved=true;
             }
             catch(Exception ex)
             {
                 fileSaved=false;
                 _ReturnStatus = -1;
                 _ReturnMessage = "导出文件时出错,文件可能正被打开！\n"+ex.Message;
             }
         }
         else
         {
             fileSaved=false;
         }          
     
         //释放Excel对应的对象
         if(range != null)
         {
             System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
             range = null;
         }
         if(worksheet != null)
         {
             System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
             worksheet = null;
         }
         if(workbook != null)
         {
             System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
             workbook = null;
         }
         if(workbooks != null)
         {
             System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
             workbooks = null;
         }              
         xlApp.Application.Workbooks.Close();
         xlApp.Quit();
         if(xlApp != null)
         {
             System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
             xlApp = null;
         }
         GC.Collect();
         return fileSaved;
     }

    }
}
