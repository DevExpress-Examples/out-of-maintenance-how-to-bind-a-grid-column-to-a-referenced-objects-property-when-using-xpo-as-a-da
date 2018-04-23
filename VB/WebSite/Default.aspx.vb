Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Xpo

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private fSession As Session
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		fSession = XpoHelper.GetNewSession()
		XpoDataSource1.Session = fSession
	End Sub
End Class
