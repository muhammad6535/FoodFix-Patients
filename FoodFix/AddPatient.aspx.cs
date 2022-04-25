using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace FoodFix
{
    public partial class AddPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void AddPatientToDb(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = Connect();
                var sqlQuerry = BiuldInsertQuerry();
                SqlCommand sqlCommand = new SqlCommand(sqlQuerry, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                sqlConnection.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Patient successfully added')", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error! the patient already exist')", true);
            }
        }

        //Build insert patient querry
        private string BiuldInsertQuerry()
        {
            string Id = Request.Form["ID"];
            string name = Request.Form["Name"];
            string surName = Request.Form["SurName"];
            double height = double.Parse(Request.Form["Height"]);
            double weight = double.Parse(Request.Form["Weight"]);
            double BMI = weight / Math.Pow(height / 100, 2);

            //Get Patiens List From DB
           return "INSERT INTO [dbo].[Patient] ([ID] ,[Name] ,[Surname] ,[Height] ,[Weight] ,[BMI]) " +
                "VALUES (" + Id + ",'" + name + "','" + surName + "'," + height + "," + weight + "," + BMI + ")";
        }

        //Connect Function
        private SqlConnection Connect()
        {
            // ---------------- Sql Connection ---------------
            string mainConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(mainConnection);
            sqlConnection.Open();

            return sqlConnection;
        }
    }


}