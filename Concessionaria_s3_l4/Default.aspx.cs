using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Concessionaria_s3_l4
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            accessori.Items.Clear();
            getAuto();

            getAccessori();


        }

        protected void getAuto()
        {
            string StringaDiConnessione = ConfigurationManager.ConnectionStrings["connectionStringDb"].ConnectionString;
            SqlConnection conn = new SqlConnection(StringaDiConnessione);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("VisualizzaAuto", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.addWithValue("mioPar");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int Id_Auto = reader.GetInt32(0);
                    string Modello = reader.GetString(1);
                    decimal Prezzo_Base = reader.GetDecimal(2);
                    string imgAuto = reader.GetString(3);



                    carDrop.Items.Add(new ListItem(Modello, Prezzo_Base.ToString()));
                }
            }
            catch (Exception ex)
            {
                Error.InnerHtml = ex.Message;
            }
            finally { conn.Close(); }
        }

        protected void getAccessori()
        {
            string StringaDiConnessione = ConfigurationManager.ConnectionStrings["connectionStringDb"].ConnectionString;
            SqlConnection conn = new SqlConnection(StringaDiConnessione);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("VisualizzaAccessori", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.addWithValue("mioPar");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int ID_Optional = reader.GetInt32(0);
                    string Nome = reader.GetString(1);
                    decimal Prezzo = reader.GetDecimal(2);



                    //accessori
                    accessori.Items.Add(new ListItem(Nome, Prezzo.ToString()));
                }
            }
            catch (Exception ex)
            {
                Error.InnerHtml = ex.Message;
            }
            finally { conn.Close(); }
        }

        protected void calcolaPrev_Click(object sender, EventArgs e)
        {
            int Garanzia = int.Parse(garanzia.Text) * 120;
            decimal pickedCar = decimal.Parse(carDrop.SelectedValue);
            decimal optional = 0;
            foreach (ListItem item in accessori.Items)
            {
                if (item.Selected)
                { optional += decimal.Parse(item.Value); }
            }
            Preventivo.InnerHtml = (Garanzia + pickedCar + optional).ToString();
        }
    }
}