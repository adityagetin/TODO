using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class todo : System.Web.UI.Page
    {   
        static string date = DateTime.Now.ToString("dd-MM-yyyy");
        string connectionString = "Data Source=ADITYA-PAL\\SQLEXPRESS;Initial Catalog=LGM;Integrated Security=True;";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                BindPeding(date);
                BindComplete(date);
            }

        }

        protected void set_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.ParseExact(dateselect.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            date = dt.ToString("dd-MM-yyyy");
            BindPeding(date);
            BindComplete(date);


        }

        protected void table_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Done") 
            { 
                string wroks = e.CommandArgument.ToString();
                string email = Session["mail"].ToString();
                try
                { 
                    using(SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE [TODO] SET [STATUS]=1 WHERE([work]=\'"+ wroks + "\' AND [email]= \'" + email+"\')";
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        BindPeding(date);
                        BindComplete(date);
                    }
                }
                catch(Exception ex) 
                {
                    string msg = ex.Message;
                    Console.WriteLine(msg);
                }
            }
            if (e.CommandName == "Delete")
            {
                string wroks = e.CommandArgument.ToString();
                string email = Session["mail"].ToString();
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query ="UPDATE [TODO] SET [STATUS]=1 WHERE([work]=\'" + wroks + "\' AND [email]= \'" + email + "\')";
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        BindPeding(date);
                        BindComplete(date);
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    Console.WriteLine(msg);
                }
            }


        }

        protected void add_Click(object sender, EventArgs e)
        {
            try 
            {
                string t = task.Text;
                string email = Session["mail"].ToString();
                string dt = date;
                int st = 0;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO [TODO] (email, work, status, date) VALUES(\'" + email+ "\',\'"+t+"\',"+st+",\'"+dt+"\');";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    BindPeding(date);
                    BindComplete(date);

                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                Console.WriteLine(msg);
            }




        }

        protected void BindPeding(string date) 
        {

            string email = Session["mail"].ToString();
            string dt = date;
            int st = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT [work] FROM [TODO] WHERE ([email]=\'"+email+"\' AND [status] ="+st+" AND [date]=\'"+dt+"\');";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter datp = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                datp.Fill(data);
                pendings.DataSource = data;
                pendings.DataBind();
                con.Close();


            }
            
        }


        protected void BindComplete(string date)
        {
            string email = Session["mail"].ToString();
            string dt = date;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT [work] FROM [TODO] WHERE ([email]=\'" + email + "\' AND [status] = 1 AND [date]=\'" + dt + "\');";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter datp = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                datp.Fill(data);
                completed.DataSource = data;
                completed.DataBind();
                con.Close();


            }

        }

    }
}