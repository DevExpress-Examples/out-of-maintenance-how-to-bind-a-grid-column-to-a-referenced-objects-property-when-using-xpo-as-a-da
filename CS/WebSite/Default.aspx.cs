using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Xpo;

public partial class _Default : System.Web.UI.Page 
{
    Session fSession;
    protected void Page_Init(object sender, EventArgs e)
    {
        fSession = XpoHelper.GetNewSession();
        XpoDataSource1.Session = fSession;
    }
}
