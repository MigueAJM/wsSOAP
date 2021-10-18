using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using MySql.Data.MySqlClient;

namespace wsProduct
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet getData()
        {
            string sConnection;
            string query;
            sConnection = "server=localhost;uid=root;pwd=;database=prueba";
            MySqlConnection objConnection = new MySqlConnection(sConnection);
            objConnection.Open();
            DataSet dataSet = new DataSet("producto");
            query = "SELECT * FROM producto";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, objConnection);
            dataAdapter.FillSchema(dataSet, SchemaType.Source, "producto");
            dataAdapter.Fill(dataSet, "producto");
            return dataSet;
        }
    }
}
