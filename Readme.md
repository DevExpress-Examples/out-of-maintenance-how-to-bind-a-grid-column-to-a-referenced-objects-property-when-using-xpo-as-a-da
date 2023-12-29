<!-- default file list -->
*Files to look at*:

* [Address.cs](./CS/WebSite/App_Code/Address.cs) (VB: [Address.vb](./VB/WebSite/App_Code/Address.vb))
* [Person.cs](./CS/WebSite/App_Code/Person.cs) (VB: [Person.vb](./VB/WebSite/App_Code/Person.vb))
* [XpoHelper.cs](./CS/WebSite/App_Code/XpoHelper.cs) (VB: [XpoHelper.vb](./VB/WebSite/App_Code/XpoHelper.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to bind a grid column to a referenced object's property when using XPO as a data source


<p>Let's assume that there are Person and Address persistent objects. The Person class has an Address property of type Address. The Address class has a City column. The grid is bound to XpoDataSource with persons. The task is to display the Address.City value in a grid column. The solution is to set the grid column's FieldName to "Address.City".</p><p><strong>See Also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E553">How to define a lookup column in the ASPxGridView bound to XpoDataSource</a></p>

<br/>


