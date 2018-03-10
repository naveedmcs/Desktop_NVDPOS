using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Project
{
    class DgvPaging
    {
        DataSet dataSet;
        SqlDataAdapter dataAdapter;
        int scrollStart;
        string TableName;
        int TotalTableRows1;
        int RowsPerPage1;
 public  DgvPaging (DataSet Obj1, SqlDataAdapter Obj2, string DataBaseTableName, int RowsPerPage, int TotalTableRows)
        {
            dataSet = Obj1;
            dataAdapter = Obj2;
            TableName= DataBaseTableName;
            TotalTableRows1= TotalTableRows;
            RowsPerPage1 = RowsPerPage;
        } 
    public    int ScrollPrev()
        {
           
           
            scrollStart = scrollStart - RowsPerPage1;
            if (scrollStart <= 0)
            {
                scrollStart = 0;
            }
            dataSet.Clear();
            dataAdapter.Fill(dataSet, scrollStart, RowsPerPage1, "Products");
           
            return scrollStart + 1;
        }
      public     int ScrollNext()
        {



            scrollStart = scrollStart + RowsPerPage1;
            if (scrollStart >(TotalTableRows1))
            {
                MessageBox.Show("testing:if (scrollStart >int.Parse(labelValue.Text)) then scrollStart = 10;");
                scrollStart = 10;
            }
            dataSet.Clear();
            dataAdapter.Fill(dataSet, scrollStart, RowsPerPage1, "Products");
            return scrollStart;
        }
        //private int getTotalPages()
        //{
        //    int value=get
        //    return;
        //}



    }
}
