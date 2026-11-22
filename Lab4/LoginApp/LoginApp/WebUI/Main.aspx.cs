using System;
using System.Web.UI;

namespace WEB
{
    public partial class Main : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer.aspx");
        }

        protected void btnProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx");
        }

        protected void btnSupplier_Click(object sender, EventArgs e)
        {
            Response.Redirect("Supplier.aspx");
        }
    }
}