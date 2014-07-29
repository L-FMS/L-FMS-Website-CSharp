using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

public partial class _Default : System.Web.UI.Page
{
    protected string Test
    {
        get;
        private set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string ConnectionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=TOM-PC)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=lfms)));User Id=h1994st;Password=db123456";
        OracleConnection conn = new OracleConnection(ConnectionString);    //创建一个新连接
        Console.Write("abc");
        try
        {
            conn.Open();    //打开连接
            OracleCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select * from account";    //SQL语句
            OracleDataReader rs = cmd.ExecuteReader();

            while (rs.Read())    //读取数据，如果rs.Read()返回为false的话，就说明到记录集的尾部了
            {
                Test = rs.GetString(1);
            }

            rs.Close();
        }

        catch (Exception a)
        {
            //            MessageBox.Show(a.Message);
            Console.Write(a.Message);
        }
        finally
        {
            conn.Close();
        }

    }
}