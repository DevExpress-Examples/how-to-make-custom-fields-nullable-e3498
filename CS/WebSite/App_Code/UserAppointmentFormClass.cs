using System;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Internal;
using DevExpress.XtraScheduler;

public class UserAppointmentFormTemplateContainer : AppointmentFormTemplateContainer {
    public UserAppointmentFormTemplateContainer(ASPxScheduler control)
        : base(control) {
    }
    
    public double? Field1 {
        get {
            object val = Appointment.CustomFields["Field1"];

            if (val == null || val == DBNull.Value)
                return null;
            else
                return Convert.ToDouble(val);
        }
    }
    public string Field2 { get { return Convert.ToString(Appointment.CustomFields["Field2"]); } }
}

public class UserAppointmentFormController : AppointmentFormController {
    public UserAppointmentFormController(ASPxScheduler control, Appointment apt)
        : base(control, apt) {
    }
    public double? Field1 { 
        get { return (double?)EditedAppointmentCopy.CustomFields["Field1"]; } 
        set { EditedAppointmentCopy.CustomFields["Field1"] = value; } }

    public string Field2 { 
        get { return (string)EditedAppointmentCopy.CustomFields["Field2"]; } 
        set { EditedAppointmentCopy.CustomFields["Field2"] = value; } }

    double? SourceField1 { 
        get { return (double?)SourceAppointment.CustomFields["Field1"]; } 
        set { SourceAppointment.CustomFields["Field1"] = value; } }

    string SourceField2 { 
        get { return (string)SourceAppointment.CustomFields["Field2"]; } 
        set { SourceAppointment.CustomFields["Field2"] = value; } }

    protected override void ApplyCustomFieldsValues() {
        SourceField1 = Field1;
        SourceField2 = Field2;
    }
}

public class UserAppointmentSaveCallbackCommand : AppointmentFormSaveCallbackCommand {
    public UserAppointmentSaveCallbackCommand(ASPxScheduler control)
        : base(control) {
    }
    protected internal new UserAppointmentFormController Controller { 
        get { return (UserAppointmentFormController)base.Controller; } }

    protected override void AssignControllerValues() {
        ASPxTextBox tbField1 = (ASPxTextBox)FindControlByID("tbField1");
        ASPxMemo memField2 = (ASPxMemo)FindControlByID("memField2");

        if (string.IsNullOrEmpty(tbField1.Text))
            Controller.Field1 = null;
        else
            Controller.Field1 = Convert.ToDouble(tbField1.Text);

        Controller.Field2 = memField2.Text;

        base.AssignControllerValues();        
    }

    protected override AppointmentFormController CreateAppointmentFormController(Appointment apt) {
        return new UserAppointmentFormController(Control, apt);
    }
}