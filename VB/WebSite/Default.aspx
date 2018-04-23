﻿<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v9.3, Version=9.3.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.XtraScheduler.v9.3.Core, Version=9.3.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
	</div>
	<dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" Width="100%" AppointmentDataSourceID="SqlDataSourceAppointments"
		ResourceDataSourceID="SqlDataSourceResources" OnAppointmentFormShowing="ASPxScheduler1_AppointmentFormShowing"
		GroupType="Resource" ClientInstanceName="scheduler" OnAppointmentRowInserting="ASPxScheduler1_AppointmentRowInserting"
		OnAppointmentRowInserted="ASPxScheduler1_AppointmentRowInserted" OnBeforeExecuteCallbackCommand="ASPxScheduler1_BeforeExecuteCallbackCommand">
		<OptionsForms AppointmentFormTemplateUrl="~/MyForms/UserAppointmentForm.ascx" />
		<OptionsBehavior RemindersFormDefaultAction="Custom" ShowRemindersForm="False" />
		<Storage>
			<Appointments ResourceSharing="True">
				<Mappings 
				AppointmentId="ID" 
				AllDay="AllDay" 
				Description="Description" 
				End="EndTime"
				Label="Label" 
				Location="Location" 
				RecurrenceInfo="RecurrenceInfo" 
				ReminderInfo="ReminderInfo"
				ResourceId="CarId" 
				Start="StartTime" 
				Status="Status" 
				Subject="Subject" 
				Type="EventType" />
				<CustomFieldMappings>
					<dxwschs:ASPxAppointmentCustomFieldMapping Name="Field1" Member="Price" ValueType="Decimal" />
					<dxwschs:ASPxAppointmentCustomFieldMapping Name="Field2" Member="ContactInfo" ValueType="String" />
				</CustomFieldMappings>
			</Appointments>
			<Resources>
				<Mappings ResourceId="ID" Caption="Model" />
			</Resources>
		</Storage>
		<Views>
			<DayView ResourcesPerPage="3" />
		</Views>
	</dxwschs:ASPxScheduler>
	<asp:SqlDataSource ID="SqlDataSourceResources" runat="server" ConnectionString="<%$ ConnectionStrings:CarsXtraSchedulingConnectionString %>"
		SelectCommand="SELECT [ID], [Model] FROM [Cars]"></asp:SqlDataSource>
	<asp:SqlDataSource ID="SqlDataSourceAppointments" runat="server" ConnectionString="<%$ ConnectionStrings:CarsXtraSchedulingConnectionString %>"
		DeleteCommand="DELETE FROM [CarScheduling] WHERE [ID] = @ID" InsertCommand="INSERT INTO [CarScheduling] ([CarId], [UserId], [Status], [Subject], [Description], [Label], [StartTime], [EndTime], [Location], [AllDay], [EventType], [RecurrenceInfo], [ReminderInfo], [Price], [ContactInfo]) VALUES (@CarId, @UserId, @Status, @Subject, @Description, @Label, @StartTime, @EndTime, @Location, @AllDay, @EventType, @RecurrenceInfo, @ReminderInfo, @Price, @ContactInfo)"
		SelectCommand="SELECT * FROM [CarScheduling]" UpdateCommand="UPDATE [CarScheduling] SET [CarId] = @CarId, [UserId] = @UserId, [Status] = @Status, [Subject] = @Subject, [Description] = @Description, [Label] = @Label, [StartTime] = @StartTime, [EndTime] = @EndTime, [Location] = @Location, [AllDay] = @AllDay, [EventType] = @EventType, [RecurrenceInfo] = @RecurrenceInfo, [ReminderInfo] = @ReminderInfo, [Price] = @Price, [ContactInfo] = @ContactInfo WHERE [ID] = @ID"
		OnInserted="SqlDataSourceAppointments_Inserted">
		<DeleteParameters>
			<asp:Parameter Name="ID" Type="Int32" />
		</DeleteParameters>
		<UpdateParameters>
			<asp:Parameter Name="ID" Type="Int32" />
			<asp:Parameter Name="CarId" Type="String" />
			<asp:Parameter Name="UserId" Type="Int32" />
			<asp:Parameter Name="Status" Type="Int32" />
			<asp:Parameter Name="Subject" Type="String" />
			<asp:Parameter Name="Description" Type="String" />
			<asp:Parameter Name="Label" Type="Int32" />
			<asp:Parameter Name="StartTime" Type="DateTime" />
			<asp:Parameter Name="EndTime" Type="DateTime" />
			<asp:Parameter Name="Location" Type="String" />
			<asp:Parameter Name="AllDay" Type="Boolean" />
			<asp:Parameter Name="EventType" Type="Int32" />
			<asp:Parameter Name="RecurrenceInfo" Type="String" />
			<asp:Parameter Name="ReminderInfo" Type="String" />
			<asp:Parameter Name="Price" Type="Decimal" />
			<asp:Parameter Name="ContactInfo" Type="String" />
		</UpdateParameters>
		<InsertParameters>
			<asp:Parameter Name="CarId" Type="String" />
			<asp:Parameter Name="UserId" Type="Int32" />
			<asp:Parameter Name="Status" Type="Int32" />
			<asp:Parameter Name="Subject" Type="String" />
			<asp:Parameter Name="Description" Type="String" />
			<asp:Parameter Name="Label" Type="Int32" />
			<asp:Parameter Name="StartTime" Type="DateTime" />
			<asp:Parameter Name="EndTime" Type="DateTime" />
			<asp:Parameter Name="Location" Type="String" />
			<asp:Parameter Name="AllDay" Type="Boolean" />
			<asp:Parameter Name="EventType" Type="Int32" />
			<asp:Parameter Name="RecurrenceInfo" Type="String" />
			<asp:Parameter Name="ReminderInfo" Type="String" />
			<asp:Parameter Name="Price" Type="Decimal" />
			<asp:Parameter Name="ContactInfo" Type="String" />
		</InsertParameters>
	</asp:SqlDataSource>
	</form>
</body>
</html>