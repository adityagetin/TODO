using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {   
        string connectionString= "Data Source=ADITYA-PAL\\SQLEXPRESS;Initial Catalog=LGM;Integrated Security=True;";
        int ckeck = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void signin_Click(object sender, EventArgs e)
        {
            string email = mainInput.Text;
            string name = nameInput.Text;
            string password = passInput.Text;
            string confirmPassword = repassInput.Text;

            // Basic validation
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                signError.Text = "All fields are required.";
                ckeck++;
                return;
            }

            if (password != confirmPassword)
            {
                signError.Text = "Passwords do not match.";
                ckeck++;
                return;
            }

            if(ckeck == 0) 
            {
                using (SqlConnection con = new SqlConnection(connectionString)) {
                    string query = "INSERT INTO [USERS]([email],[uname],[pass]) VALUES(@email,@uname,@pass);";
                    try
                    {
                        con.Open();
                        using(SqlCommand cmd = new SqlCommand(query,con)) 
                        {
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@uname", name);
                            cmd.Parameters.AddWithValue("@pass", password);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            ckeck = 0;
                        }
                        
                        Session["mail"] = email;
                        Session["name"] = name;
                        Response.Redirect("todo.aspx");
                    }
                    catch(Exception ex) 
                    { 
                        string Text = ex.Message;
                        signError.Text = "Already exist";
                        ckeck++;
                    }
                }
            }
        }

        protected void log_Click(object sender, EventArgs e)
        {
            string loginEmail = mailin.Text.Trim();
            string loginPassword = passin.Text;

            // Basic validation
            if (string.IsNullOrEmpty(loginEmail) || string.IsNullOrEmpty(loginPassword))
            {
                logError.Text = "Both email and password are required.";
                return;
            }

            if (ckeck == 0)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT [email],[pass] FROM [USERS] WHERE [email]=@email AND [pass]=@pass;";
                    try
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@email", loginEmail);
                            cmd.Parameters.AddWithValue("@pass", loginPassword);
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                string em = reader.GetString(0);
                                string na = reader.GetString(1);
                                Session["mail"] = em;
                                Session["name"] = na;
                                Response.Redirect("todo.aspx");
                            }
                            else 
                            {
                                logError.Text = "Invalid Email or Password";
                            }

                            con.Close();

                        }

                    }
                    catch (Exception ex)
                    {
                        signError.Text = ex.Message;
                        ckeck++;
                    }
                }
            }

            logError.Text = "Login successful!";
        }
    }
}