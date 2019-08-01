using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjectEntityFrameworkMVCStyle.Model;
using testProjectEntityFrameworkMVCStyle.Model.ViewModel;

namespace testProjectEntityFrameworkMVCStyle
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        UserManager userMgr = new UserManager();

        private void BindUserNames()
        {
            ddlUser.DataSource = userMgr.GetUserFirstName();
            ddlUser.DataTextField = "FirstName";
            ddlUser.DataValueField = "UserID";
            ddlUser.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindUserNames();
        }
       
        private void PopulateFields(int userID)
        {
            var result = userMgr.GetUserDetail(userID);
            if (result.Count() > 0)
            {
                var user = result.First();
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtPhone.Text = user.Phone;
            }
            else
            {
                //NO RECORDS FOUND.
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtPhone.Text = string.Empty;
            }
        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateFields(Convert.ToInt32(ddlUser.SelectedItem.Value));
        }

        private void ToggleButton(bool isEdit)
        {
            if (isEdit)
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
            }

            pnlUserDetail.Enabled = isEdit;
        }

        private void UpdateUserDetail(UserDetail userDetail)
        {
            userMgr.UpdateUser(userDetail);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ddlUser.SelectedItem.Value != "0")
            {
                ToggleButton(true);
                lblMessage.Text = string.Empty;
            }
            else
            {
                lblMessage.Text = "Please select name from the list first.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UserDetail userDetail = new UserDetail();
            userDetail.UserID = Convert.ToInt32(ddlUser.SelectedItem.Value);
            userDetail.FirstName = txtFirstName.Text.TrimEnd();
            userDetail.LastName = txtLastName.Text.TrimEnd();
            userDetail.Phone = txtPhone.Text.TrimEnd();

            UpdateUserDetail(userDetail);
            lblMessage.Text = "Update Successful!";
            ToggleButton(false);
            ddlUser.Items.Clear();
            ddlUser.Items.Insert(0, new ListItem("--Select--", "0"));
            BindUserNames();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ToggleButton(false);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (ddlUser.SelectedItem.Value != "0")
            {
                //Perform the Delete
                userMgr.DeleteUser(Convert.ToInt32(ddlUser.SelectedItem.Value));

                //Re-bind the DropDownList
                ddlUser.Items.Clear();
                ddlUser.Items.Insert(0, new ListItem("--Select--", "0"));
                BindUserNames();

                //Clear the form fields
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtPhone.Text = string.Empty;

                lblMessage.Text = "Delete Successful!";
            }
            else
            {
                lblMessage.Text = "Please select name from the list first.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}