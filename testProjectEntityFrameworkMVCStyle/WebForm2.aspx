<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="testProjectEntityFrameworkMVCStyle.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h1>Search User</h1>
    <hr />
    <div class="container">
        <div class="input-group mb-3">
            <div class="input-group-prepend">
                <label class="input-group-text" for="inputGroupSelect01">Users</label>
            </div>
            <asp:DropDownList ID="ddlUser" class="custom-select"
                AppendDataBoundItems="true" AutoPostBack="true"
                OnSelectedIndexChanged="ddlUser_SelectedIndexChanged" runat="server">
                <asp:ListItem Value="0">--Select--</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:Panel ID="pnlUserDetail" runat="server" Enabled="false">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
                <asp:TextBox ID="txtFirstName" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
                <asp:TextBox ID="txtLastName" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Phone"></asp:Label>
                <asp:TextBox ID="txtPhone" class="form-control" runat="server"></asp:TextBox>
            </div>
        </asp:Panel>
        <asp:Button ID="btnEdit" class="btn btn-primary" runat="server" Text="Edit" OnClick="btnEdit_Click" />
        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnCancel" class="btn btn-primary" runat="server" Text="Cancel" Visible="false" OnClick="btnCancel_Click" />
        <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />

    </div>
</asp:Content>
