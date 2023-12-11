using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication49
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using(SqlConnection konekcija=new SqlConnection(Konekcija.Conn))
            {
                try
                {
                    konekcija.Open();
                    string komanda = "INSERT INTO KORISNIK VALUES(" + TextBox1.Text + ",'" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')";
                    using(SqlCommand cmd=new SqlCommand(komanda,konekcija))
                    {
                       if(cmd.ExecuteNonQuery()>0)
                        {
                            Label1.Text = "Uspesna registracija!";
                        }
                    }
                    Response.Redirect("~/About.aspx");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}