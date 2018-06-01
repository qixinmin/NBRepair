using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NBRepair
{
    public partial class MakeDatabase : Form
    {
        public MakeDatabase()
        {
            InitializeComponent();
        }

        private void MakeDB_Click(object sender, EventArgs e)
        {
          //  CreateDatabase(Conlist.Con, "hbj");
            MessageBox.Show("ok");

        }

        private static bool CreateDatabase(string connStr, string _strDBName) 
        {   bool bSuccess = false; 
            try  {
                using (SqlConnection conMaster = new SqlConnection(connStr))
                {
                    conMaster.Open();
                    // Check if the Database has existed first    
                    string strExist = @"select * from dbo.sysdatabases where name='" + _strDBName + @"'";
                    SqlCommand cmdExist = new SqlCommand(strExist, conMaster);
                    SqlDataReader readerExist = cmdExist.ExecuteReader();
                    bool bExist = readerExist.HasRows;
                    readerExist.Close();
                    if (bExist)
                    {
                        string strDel = @"drop database " + _strDBName;
                        SqlCommand cmdDel = new SqlCommand(strDel, conMaster);
                        cmdDel.ExecuteNonQuery();
                    }       // Create the database now;     
                    string strDatabase = "Create Database [" + _strDBName + "]";
                    SqlCommand cmdCreate = new SqlCommand(strDatabase, conMaster);
                    cmdCreate.ExecuteNonQuery();
                    conMaster.Close();
                } 
                bSuccess = true;  
            } 
            catch (Exception e) 
            {  
                throw e; 
            }  
            return bSuccess;
        } 

    }
}
