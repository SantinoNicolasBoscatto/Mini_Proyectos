using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeraPaginaWeb
{
    public partial class About : Page
    {
        public string H3titulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "El Papu";
            H3titulo = "Holanda Papus Viva la Grasovich";
        }
    }
}