using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace WebColiber
{
    public partial class download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int id = 0;
            string id = Request.QueryString["s"] as string;
            //if(!Int32.TryParse(Request.QueryString["s"], out id)) Response.Redirect("Search.aspx");

            using (SqlConnection conn = new SqlConnection(Settings.ColiberConnectionString))
            {
                conn.Open();
                string query = "SELECT nazwa, plik FROM documents WHERE id = @id; ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlParameter par = new SqlParameter();
                    par.ParameterName = "@id";
                    par.SqlDbType = System.Data.SqlDbType.VarChar;
                    par.Value = id;

                    cmd.Parameters.Add(par);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string file = reader.GetValue("nazwa").ToString();
                            byte[] data = (byte[])reader.GetValue("plik");

                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Split('\\').Last());
                            Response.AddHeader("Content-Length", data.Length.ToString());
                            Response.ContentType = "application/" + file.Split('.').Last();
                            Response.BinaryWrite(data);
                            Response.Flush();
                            Response.End();
                            Response.Close();
                        }
                    }
                }
            }

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=");
            //Response.AddHeader("
        }
    }
}