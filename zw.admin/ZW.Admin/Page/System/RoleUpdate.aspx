<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoleUpdate.aspx.cs" Inherits="ZW.Admin.Page.System.RoleUpdate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card">
        <div class="card-header">
            <h2>角色 <span runat="server" id="addOrModify"></span></h2>

            <ul class="actions">
                <li>
                    <a href="Role">
                        <i class="zmdi zmdi-undo"></i>
                    </a>
                </li>
                <li class="dropdown">
                    <a href="" data-toggle="dropdown">
                        <i class="zmdi zmdi-more-vert"></i>
                    </a>

                    <ul class="dropdown-menu dropdown-menu-right">
                        <li>
                            <a href="">重置</a>
                        </li>
                    </ul>
                </li>
            </ul>
        </div>
        <div class="card-body card-padding">
            <div class="row">
                <div class="col-sm-3 m-b-20">
                    <div class="form-group fg-line">
                        <label>角色名称</label>
                        <asp:TextBox runat="server" ID="tb_roleName"  
                            class="form-control " placeholder="角色名称"></asp:TextBox>
                    </div>
                </div>

            </div>
            <asp:LinkButton runat="server" ID="btn_save"
                CssClass="btn btn-primary btn-sm m-t-10 waves-effect"
                OnClick="btn_save_Click">保存</asp:LinkButton>
            <asp:HiddenField runat="server" ID="h_id" Value="0" />
        </div>
    </div>
   
    <asp:ValidationSummary ID="ValidationSummary" runat="server" EnableClientScript="true"
        ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator"  runat="server" ControlToValidate="tb_roleName"
        ErrorMessage="请输入角色名称">
    </asp:RequiredFieldValidator>

</asp:Content>
