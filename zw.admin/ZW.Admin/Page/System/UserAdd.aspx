<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="ZW.Admin.Page.System.UserAdd" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card">
        <div class="card-header">
            <h2>用户 <span runat="server" id="UserAddOrModify"></span></h2>

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
                    <div class="form-group fg-float">
                        <div class="fg-line">
                            <label class="fg-label">用户帐号</label>
                     
                            <asp:TextBox runat="server" ID="UserName"  
                                class="form-control " ></asp:TextBox>
                        </div> 
                    </div>
                </div>
                <div class="col-sm-3 m-b-20">
                    <div class="form-group fg-float">
                        <div class="fg-line">
                            <label class="fg-label">用户密码</label>
                            <asp:TextBox runat="server" ID="UserPwd"  
                                class="form-control "></asp:TextBox>
                        </div> 
                    </div>
                </div>
                <div class="col-sm-3 m-b-20">
                    <div class="form-group fg-float">
                        <div class="fg-line">
                            <label class="fg-label">真实姓名</label>
                            <asp:TextBox runat="server" ID="RealUserName"  
                                class="form-control "></asp:TextBox>
                        </div> 
                    </div>
                </div>
                <asp:BulletedList ID="BulletedList1" runat="server"></asp:BulletedList>
                <div class="col-sm-3 m-b-20">
                    <div class="fg-line">
                        <div class="select">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <asp:LinkButton runat="server" ID="btn_save"
                CssClass="btn btn-primary btn-sm m-t-10 waves-effect"
                OnClick="btn_save_Click" OnClientClick="return addUserPage.add()">保存</asp:LinkButton>
            <asp:HiddenField runat="server" ID="h_id" Value="0" />
        </div>
       
    </div>
   
<%--    <asp:ValidationSummary ID="ValidationSummary" runat="server" EnableClientScript="true"
        ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator"  runat="server" ControlToValidate="UserName"
        ErrorMessage="请输入用户名称">
    </asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserPwd" 
        ErrorMessage="请输入用户密码"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RealUserName" 
        ErrorMessage="请输入用户真实姓名"></asp:RequiredFieldValidator>--%>




    <script>
        var addUserPage = {
            //add: function () {
              
            //    if ($.trim($("#MainContent_UserName").val()) == "") {
            //        swal("出错啦!", "请输入用户帐号", "error");
            //        return false;
            //    }
            //    if ($.trim($("#MainContent_UserPwd").val()) == "" || $.trim($("#MainContent_UserPwd").val()).length<6 ) {
            //        swal("出错啦!", "请输入用户密码;最少6位", "error");
            //        return false;
            //    }
            //    if ($.trim($("#MainContent_RealUserName").val()) == "") {
            //        swal("出错啦!", "请输入用户真实姓名", "error");
            //        return false;
            //    }
            //    if ($.trim($(".form-control option:selected").val()) == "--请分配用户角色--") {
            //        swal("出错啦!", "请分配用户角色", "error");
            //        return false;
            //    }
            //}

        }
    </script>

</asp:Content>

