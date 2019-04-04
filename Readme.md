<!-- default file list -->
*Files to look at*:

* [UserAppointmentFormClass.cs](./CS/WebSite/App_Code/UserAppointmentFormClass.cs) (VB: [UserAppointmentFormClass.vb](./VB/WebSite/App_Code/UserAppointmentFormClass.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
* [UserAppointmentForm.ascx](./CS/WebSite/MyForms/UserAppointmentForm.ascx) (VB: [UserAppointmentForm.ascx](./VB/WebSite/MyForms/UserAppointmentForm.ascx))
* [UserAppointmentForm.ascx.cs](./CS/WebSite/MyForms/UserAppointmentForm.ascx.cs) (VB: [UserAppointmentForm.ascx.vb](./VB/WebSite/MyForms/UserAppointmentForm.ascx.vb))
<!-- default file list end -->
# How to make custom fields nullable


<p>This example illustrates how to make custom fields nullable. This will allow the end-user to skip specifying a custom field value so that it is stored as <strong>NULL</strong> in the underlying database. We will use the <a href="https://www.devexpress.com/Support/Center/p/E1074">How to modify the appointment editing form for working with custom fields - step by step guide</a> example as a starting point. The first thing we should do, is to define custom fields (we will use a "Field1" in this example to demonstrate this approach) of value types as nullable in the <strong>UserAppointmentFormTemplateContainer</strong> and <strong>UserAppointmentFormController</strong> classes. Then, we will modify the <strong>UserAppointmentSaveCallbackCommand.</strong><strong>AssignControllerValues() </strong>method so that it makes the <strong>null</strong> value assignment to the custom field if the source editor (ASPxTextBox in this example) does not have any value.</p><p><strong>See </strong><strong>A</strong><strong>lso:</strong><br />
<a href="http://msdn.microsoft.com/en-us/library/b3h38hb0(v=vs.80).aspx"><u>Nullable Generic Structure</u></a></p>

<br/>


