using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace easyui._ajax
{
    public partial class ajax_use :System.Web.UI.Page
    {
    /*    protected void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(ajax_use));
        }*/
        public void Page_Load(object sender, EventArgs e)
        {
            Ajax.Utility.GenerateMethodScripts(this);
        }
        [Ajax.AjaxMethod]
        public string getString(string str)
        {
            string strResult = "The string is " + str;
            return strResult;
        }
    }
}