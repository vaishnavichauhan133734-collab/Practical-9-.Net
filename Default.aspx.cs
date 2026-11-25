using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Practical9
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly string cs = ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSummary();
                LoadPlacements();
            }
        }

        private void LoadSummary()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Students", con);
                int total = Convert.ToInt32(cmd.ExecuteScalar());
                lblTotal.Text = total.ToString();

                cmd.CommandText = "SELECT COUNT(DISTINCT StudentId) FROM Students WHERE PlacementStatus = 'Placed'";
                int placed = Convert.ToInt32(cmd.ExecuteScalar());
                lblPlaced.Text = placed.ToString();

                int unplaced = total - placed;
                lblUnplaced.Text = unplaced.ToString();

                cmd.CommandText = "SELECT MAX(PackageLPA) FROM Students";
                object result = cmd.ExecuteScalar();
                decimal highest = result == null || result == DBNull.Value ? 0 : Convert.ToDecimal(result);
                lblHighestPackage.Text = highest.ToString("0.00");

                decimal percentage = total == 0 ? 0 : (decimal)placed * 100 / total;
                lblPercentage.Text = percentage.ToString("0.00") + "%";
            }
        }

        private void LoadPlacements()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT PlacementId, StudentId, CompanyName, JobRole, PackageLPA FROM Students WHERE PlacementStatus = 'Placed'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvPlacements.DataSource = dt;
                gvPlacements.DataBind();
            }
        }
    }
}
