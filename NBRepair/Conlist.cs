using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NBRepair
{
    class Conlist
    {
         // public static string ConStr = "server=192.168.1.122;database=NBREPAIER;uid=root;pwd=root";
        //public static string Con = "server=192.168.1.122;uid=admin;pwd=admin";
        public static string ConStr = "server=192.168.1.254;database=NBREPAIER;uid=admin;pwd=admin";
        public static void WriteStrBatFile(string path, string name, string content)
        {
            string ename = path + "\\" + name + ".bat";

            FileStream aa = new FileStream(ename, FileMode.Create  );
            StreamWriter bfile = new StreamWriter(aa, Encoding.Default);
            bfile.WriteLine(content);
            bfile.Close();
            aa.Close();
            bfile.Dispose();
            aa.Dispose();

            //StreamWriter sw = File.AppendText(@"D:/test.txt");sw.WriteLine("你的名字2");sw.Close();  
        }

        public static void WriteStrBatFileAppend(string path, string name, string content)
        {
            string ename = path + "\\" + name + ".bat";
            //FileStream aa = new FileStream(ename, FileMode.OpenOrCreate  );
            StreamWriter bfile = File.AppendText(ename);

            bfile.WriteLine(content);
            bfile.Close();
           // aa.Close();
            bfile.Dispose();
           // aa.Dispose();

            /*
            FileStream fs = File.Create(@"D:/test.txt"); 
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("你的名字");
            sw.Close(); fs.Close();
             * */

            //StreamWriter sw = File.AppendText(@"D:/test.txt");sw.WriteLine("你的名字2");sw.Close();  
        }

        public static void WriteStrBatFileS(string path, string name, string [] content)
        {
            string ename = path + "\\" + name + ".bat";
            FileStream aa = new FileStream(ename, FileMode.Open );
            StreamWriter bfile = new StreamWriter(aa, Encoding.Default);
            string temp = "";
            for (int i = 0; i < content.Length; i = i + 1)
            {
                temp += content[i] + "\n";
            }
            bfile.WriteLine(temp);
            bfile.Close();
            aa.Close();
            bfile.Dispose();
            aa.Dispose();
        }
    }
}
