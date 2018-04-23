using System;
using System.Collections;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Internal;
using DevExpress.XtraScheduler;
using System.Collections.Generic;
using DevExpress.XtraScheduler.Localization;

public partial class AppointmentForm : SchedulerFormControl {
	public bool CanShowReminders {
		get {
			return ((AppointmentFormTemplateContainer)Parent).Control.Storage.EnableReminders;
		}
	}
    public bool ResourceSharing {
        get {
            return ((AppointmentFormTemplateContainer)Parent).Control.Storage.ResourceSharing;
        }
    }
    public IEnumerable ResourceDataSource {
        get {
            return ((AppointmentFormTemplateContainer)Parent).ResourceDataSource;
        }
    }
	protected void Page_Load(object sender, EventArgs e) {
		//PrepareChildControls();
		tbSubject.Focus();
	}
	public override void DataBind() {
		base.DataBind();

		AppointmentFormTemplateContainer container = (AppointmentFormTemplateContainer)Parent;
		Appointment apt = container.Appointment;
		edtLabel.SelectedIndex = apt.LabelId;
		edtStatus.SelectedIndex = apt.StatusId;

        PopulateResourceEditors(apt, container);

		AppointmentRecurrenceForm1.Visible = container.ShouldShowRecurrence;

		if (container.Appointment.HasReminder) {
			cbReminder.Value = container.Appointment.Reminder.TimeBeforeStart.ToString();
			chkReminder.Checked = true;
		}
		else {
			cbReminder.ClientEnabled = false;
		}

		btnOk.ClientSideEvents.Click = container.SaveHandler;
		btnCancel.ClientSideEvents.Click = container.CancelHandler;
		btnDelete.ClientSideEvents.Click = container.DeleteHandler;
		//btnDelete.Enabled = !container.IsNewAppointment;
	}

    private void PopulateResourceEditors(Appointment apt, AppointmentFormTemplateContainer container) {
        if (ResourceSharing) {
            ASPxListBox edtMultiResource = ddResource.FindControl("edtMultiResource") as ASPxListBox;
            if (edtMultiResource == null)
                return;
            SetListBoxSelectedValues(edtMultiResource, apt.ResourceIds);
            List<String> multiResourceString = GetListBoxSeletedItemsText(edtMultiResource);
            string stringResourceNone = SchedulerLocalizer.GetString(SchedulerStringId.Caption_ResourceNone);
            ddResource.Value = stringResourceNone;
            if (multiResourceString.Count > 0)
                ddResource.Value = String.Join(", ", multiResourceString.ToArray());
            ddResource.JSProperties.Add("cp_Caption_ResourceNone", stringResourceNone);
        }
        else {
            if (!Object.Equals(apt.ResourceId, Resource.Empty.Id))
                edtResource.Value = apt.ResourceId.ToString();
            else
                edtResource.Value = SchedulerIdHelper.EmptyResourceId;
        }
    }
    List<String> GetListBoxSeletedItemsText(ASPxListBox listBox) {
        List<String> result = new List<string>();
        foreach (ListEditItem editItem in listBox.Items) {
            if (editItem.Selected)
                result.Add(editItem.Text);
        }
        return result;
    }
    void SetListBoxSelectedValues(ASPxListBox listBox, IEnumerable values) {
        listBox.Value = null;
        foreach (object value in values) {
            ListEditItem item = listBox.Items.FindByValue(value.ToString());
            if (item != null)
                item.Selected = true;
        }
    } 

	protected override void PrepareChildControls() {
		AppointmentFormTemplateContainer container = (AppointmentFormTemplateContainer)Parent;
		ASPxScheduler control = container.Control;

		AppointmentRecurrenceForm1.EditorsInfo = new EditorsInfo(control, control.Styles.FormEditors, control.Images.FormEditors, control.Styles.Buttons);
		base.PrepareChildControls();
	}
	protected override ASPxEditBase[] GetChildEditors() {
		ASPxEditBase[] edits = new ASPxEditBase[] {
			lblSubject, tbSubject,
			lblLocation, tbLocation,
			lblLabel, edtLabel,
			lblStartDate, edtStartDate,
			lblEndDate, edtEndDate,
			lblStatus, edtStatus,
			lblAllDay, chkAllDay,
			lblResource, edtResource,
			tbDescription, cbReminder
		};
		return edits;
	}
	protected override ASPxButton[] GetChildButtons() {
		ASPxButton[] buttons = new ASPxButton[] {
			btnOk, btnCancel, btnDelete
		};
		return buttons;
	}
}
