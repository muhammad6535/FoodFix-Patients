using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;



namespace FoodFix
{
    public partial class Patients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                // ---------------- Sql Connection ---------------
                string mainConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(mainConnection);    
                GetPatiensFromDB(sqlConnection);
                sqlConnection.Close();
            }
        }

        public void GetPatiensFromDB(SqlConnection sqlConnection)
        {
            //Get Patiens List From DB
            string sqlQuerry = "SELECT * FROM [dbo].[Patient]";
            SqlCommand sqlCommand = new SqlCommand(sqlQuerry, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            ShowPatientsInList(sqlConnection, dt);
        }

        // ---------------- Show Patiens in list ---------------
        public void ShowPatientsInList(SqlConnection sqlConnection, DataTable dt)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<tr>");

            //Handling Columns
            foreach (DataColumn dc in dt.Columns)
            {
                stringBuilder.Append("<th>");
                stringBuilder.Append(dc.ColumnName.ToUpper());
                stringBuilder.Append("</th>");
            }
            stringBuilder.Append("</tr>");

            //Handling Rows
            foreach (DataRow dr in dt.Rows)
            {
                stringBuilder.Append("<tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    stringBuilder.Append("<th>");

                    //To show only two digits after the dot in the number
                    if (dr[dc.ColumnName].GetType() == typeof(double))
                    {
                        stringBuilder.Append(double.Parse(dr[dc.ColumnName].ToString()).ToString("N2"));
                    }
                    else
                    {
                        stringBuilder.Append(dr[dc.ColumnName].ToString());
                    }
                    stringBuilder.Append("</th>");
                }
                stringBuilder.Append("</tr>");
            }
            Tr.Controls.Add(new Label { Text = stringBuilder.ToString() });
        }

    }
}