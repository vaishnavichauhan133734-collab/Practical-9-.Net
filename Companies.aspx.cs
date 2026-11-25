using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Practical9
{
    public partial class Companies : System.Web.UI.Page
    {
        private readonly string cs = ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCompanies();
            }
        }

        private void LoadCompanies()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT PlacementId, StudentId, CompanyName, JobRole, PackageLPA FROM Students WHERE PlacementStatus = 'Placed'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rptCompanies.DataSource = dt;
                rptCompanies.DataBind();
            }
        }
    }
}
