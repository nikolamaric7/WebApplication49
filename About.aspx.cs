using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication49
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (SqlConnection Conn = new SqlConnection(Konekcija.Conn))
                {
                    try
                    {
                        Conn.Open();
                        string komanda = "SELECT MESTO FROM PONUDA";
                        using (SqlCommand cmd = new SqlCommand(komanda, Conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                DropDownList1.Items.Add(reader["Mesto"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                using (SqlConnection Con = new SqlConnection(Konekcija.Conn))
                {
                    try
                    {
                        Con.Open();
                        string komanda = "SELECT NAZIV FROM AGENCIJA";
                        using (SqlCommand Cmd = new SqlCommand(komanda, Con))
                        {
                            SqlDataReader reader = Cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                DropDownList2.Items.Add(reader["Naziv"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conn = new SqlConnection(Konekcija.Conn))
            {
                if (TextBox1.Text == string.Empty || TextBox2.Text == string.Empty || TextBox3.Text == string.Empty)
                {
                    Label2.Text = "Unesite sva polja.";
                }
                else
                {
                    try
                    {
                        Conn.Open();
                        string komanda = "SELECT * FROM Ponuda  WHERE Cena<=" + Convert.ToInt32(TextBox1.Text) + " AND Mesto='" + DropDownList1.SelectedItem.ToString() + "' AND ID_AGENCIJE=(SELECT ID_AGENCIJA FROM Agencija WHERE Naziv='" + DropDownList2.SelectedItem.ToString() + "')";
                        using (SqlCommand cmd = new SqlCommand(komanda, Conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            DataTable dt = new DataTable();
                            dt.Columns.Add("Id");
                            dt.Columns.Add("Cena");
                            dt.Columns.Add("DatumPolaska");
                            dt.Columns.Add("DatumDolaska");
                            dt.Columns.Add("IdAgencije");
                            dt.Columns.Add("Mesto");
                            while (reader.Read())
                            {
                                DataRow row = dt.NewRow();
                                row["Id"] = reader["ID_PONUDA"].ToString();
                                row["Cena"] = reader["Cena"].ToString();
                                row["DatumPolaska"] = reader["Datum_Polaska"].ToString();
                                row["DatumDolaska"] = reader["Datum_Dolaska"].ToString();
                                row["IdAgencije"] = reader["ID_AGENCIJE"].ToString();
                                row["Mesto"] = reader["Mesto"].ToString();
                                dt.Rows.Add(row);
                            }
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conn = new SqlConnection(Konekcija.Conn))
            {
                try
                {
                    Conn.Open();
                    string komanda = "INSERT INTO Zakazivanje Values(" + TextBox4.Text + "," + TextBox5.Text + ")";
                    using (SqlCommand cmd = new SqlCommand(komanda, Conn))
                    {
                        if (cmd.ExecuteNonQuery() > 0)
                            Label1.Text = "Uspesan unos!";
                        else
                            Label1.Text = "Neuspesan unos!";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Label1.Text = ex.Message;
                }
            }
        }
    }
}