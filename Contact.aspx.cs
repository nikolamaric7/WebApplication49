using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication49
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection Conn = new SqlConnection(Konekcija.Conn))
            {
                try
                {
                    Conn.Open();
                    string select = "SELECT k.Ime, k.Prezime, p.Datum_Dolaska, p.Datum_Polaska, p.Cena, p.Mesto, a.Naziv  FROM korisnik k, ponuda p, agencija a, zakazivanje z\r\nWHERE k.id_korisnik = z.id_korisnika AND z.id_ponuda = p.id_ponuda AND p.ID_AGENCIJE = a.ID_AGENCIJA ";
                    using (SqlCommand cmd = new SqlCommand(select, Conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("ime");
                        dt.Columns.Add("prezime");
                        dt.Columns.Add("Datum_Dolaska");
                        dt.Columns.Add("Datum_Polaska");
                        dt.Columns.Add("Cena");
                        dt.Columns.Add("Mesto");
                        dt.Columns.Add("Naziv");
                        while (reader.Read())
                        {
                            DataRow row = dt.NewRow();
                            row["ime"] = reader["Ime"].ToString();
                            row["prezime"] = reader["Prezime"].ToString();
                            row["Datum_Dolaska"] = reader["Datum_Dolaska"].ToString();
                            row["Datum_Polaska"] = reader["Datum_Polaska"].ToString();
                            row["Cena"] = reader["Cena"].ToString();
                            row["Mesto"] = reader["Mesto"].ToString();
                            row["Naziv"] = reader["Naziv"].ToString();
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
    }
