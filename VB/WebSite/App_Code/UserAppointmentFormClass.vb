Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.Web.ASPxScheduler.Internal
Imports DevExpress.XtraScheduler

Public Class UserAppointmentFormTemplateContainer
	Inherits AppointmentFormTemplateContainer
	Public Sub New(ByVal control As ASPxScheduler)
		MyBase.New(control)
	End Sub

	Public ReadOnly Property Field1() As Nullable(Of Double)
		Get
			Dim val As Object = Appointment.CustomFields("Field1")

			If val Is Nothing OrElse val Is DBNull.Value Then
				Return Nothing
			Else
				Return Convert.ToDouble(val)
			End If
		End Get
	End Property
	Public ReadOnly Property Field2() As String
		Get
			Return Convert.ToString(Appointment.CustomFields("Field2"))
		End Get
	End Property
End Class

Public Class UserAppointmentFormController
	Inherits AppointmentFormController
	Public Sub New(ByVal control As ASPxScheduler, ByVal apt As Appointment)
		MyBase.New(control, apt)
	End Sub
	Public Property Field1() As Nullable(Of Double)
		Get
			Return CType(EditedAppointmentCopy.CustomFields("Field1"), Nullable(Of Double))
		End Get
		Set(ByVal value As Nullable(Of Double))
			EditedAppointmentCopy.CustomFields("Field1") = value
		End Set
	End Property

	Public Property Field2() As String
		Get
			Return CStr(EditedAppointmentCopy.CustomFields("Field2"))
		End Get
		Set(ByVal value As String)
			EditedAppointmentCopy.CustomFields("Field2") = value
		End Set
	End Property

	Private Property SourceField1() As Nullable(Of Double)
		Get
			Return CType(SourceAppointment.CustomFields("Field1"), Nullable(Of Double))
		End Get
		Set(ByVal value As Nullable(Of Double))
			SourceAppointment.CustomFields("Field1") = value
		End Set
	End Property

	Private Property SourceField2() As String
		Get
			Return CStr(SourceAppointment.CustomFields("Field2"))
		End Get
		Set(ByVal value As String)
			SourceAppointment.CustomFields("Field2") = value
		End Set
	End Property

	Protected Overrides Sub ApplyCustomFieldsValues()
		SourceField1 = Field1
		SourceField2 = Field2
	End Sub
End Class

Public Class UserAppointmentSaveCallbackCommand
	Inherits AppointmentFormSaveCallbackCommand
	Public Sub New(ByVal control As ASPxScheduler)
		MyBase.New(control)
	End Sub
	Protected Friend Shadows ReadOnly Property Controller() As UserAppointmentFormController
		Get
			Return CType(MyBase.Controller, UserAppointmentFormController)
		End Get
	End Property

	Protected Overrides Sub AssignControllerValues()
		Dim tbField1 As ASPxTextBox = CType(FindControlByID("tbField1"), ASPxTextBox)
		Dim memField2 As ASPxMemo = CType(FindControlByID("memField2"), ASPxMemo)

		If String.IsNullOrEmpty(tbField1.Text) Then
			Controller.Field1 = Nothing
		Else
			Controller.Field1 = Convert.ToDouble(tbField1.Text)
		End If

		Controller.Field2 = memField2.Text

		MyBase.AssignControllerValues()
	End Sub

	Protected Overrides Function CreateAppointmentFormController(ByVal apt As Appointment) As AppointmentFormController
		Return New UserAppointmentFormController(Control, apt)
	End Function
End Class