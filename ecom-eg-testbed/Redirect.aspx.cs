using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcomEgTestBed
{
    public partial class Redirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.StatusCode = (int)HttpStatusCode.MovedPermanently;
            Response.Redirect("https://cv-fde-site-qa-eastau-aucqdvgkg3akgmdd.a01.azurefd.net");

        }
    }
}