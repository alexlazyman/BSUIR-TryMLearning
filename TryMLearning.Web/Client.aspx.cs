using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryMLearning.Web
{
    public partial class Client : System.Web.UI.Page
    {
        public string TryMLearningWebApiSrvUri { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            TryMLearningWebApiSrvUri = ConfigurationManager.AppSettings["TryMLearningWebApiSrvUri"];
        }
    }
}