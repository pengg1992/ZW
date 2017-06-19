<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZW.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title runat="server" id="title">Material Admin</title>

    <!-- Vendor CSS -->
    <link href="Content/bs3/vendors/bower_components/animate.css/animate.min.css" rel="stylesheet">
    <link href="Content/bs3/vendors/bower_components/material-design-iconic-font/dist/css/material-design-iconic-font.min.css" rel="stylesheet">
    <link href="Content/bs3/vendors/bower_components/sweetalert2/dist/sweetalert2.min.css" rel="stylesheet">
    <!-- CSS -->
    <link href="Content/bs3/css/app_1.min.css" rel="stylesheet">
    <link href="Content/bs3/css/app_2.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
         <div class="login-content">
            <!-- Login -->
            <div class="lc-block toggled" id="l-login">
                <div class="lcb-form">
                   
                    <div class="input-group m-b-20">
                        <span class="input-group-addon"><i class="zmdi zmdi-account"></i></span>
                        <div class="fg-line">
                            <asp:TextBox runat="server" ID="txt_login_userName"  class="form-control" placeholder="用户名"></asp:TextBox>
                        </div>
                    </div>

                    <div class="input-group m-b-20">
                        <span class="input-group-addon"><i class="zmdi zmdi-male"></i></span>
                        <div class="fg-line">
                            <asp:TextBox runat="server" ID="txt_login_pwd" TextMode="Password"  class="form-control" placeholder="密码"></asp:TextBox>
                        </div>
                    </div>
                    <div class="input-group m-b-10">
                        <span class="input-group-addon"><i class="zmdi zmdi-key"></i></span>
                        <div class="fg-line">
                            <asp:TextBox runat="server" ID="txt_login_confirmCode" class="form-control" placeholder="验证码" Width="50%"></asp:TextBox>
                            <img id="img_login_yzm" src="CustomController/yzm.aspx"  />
                        </div>
                    </div>

                    <div class="checkbox">
                        <label>
                            <input type="checkbox" id="ipt_isRemember" value="" />
                            <i class="input-helper"></i>
                            记住密码
                        </label>
                    </div>
                    <asp:LinkButton runat="server" ID="btn_login" 
                        class="btn btn-login btn-success btn-float"
                        OnClick="btn_login_Click" OnClientClick="return Login();"><i class="zmdi zmdi-arrow-forward"></i></asp:LinkButton>
                </div>
                <div class="lcb-navigation" >
                    <a runat="server" id="switch_register" href="" data-ma-action="login-switch" data-ma-block="#l-register"><i class="zmdi zmdi-plus"></i> <span>注册</span></a>
                </div>
            </div>

            <!-- Register -->
            <div class="lc-block" id="l-register">
                <div class="lcb-form">
                    <div class="input-group m-b-20">
                        <span class="input-group-addon"><i class="zmdi zmdi-account"></i></span>
                        <div class="fg-line">
                            <asp:TextBox runat="server" ID="txt_register_userName"  class="form-control" placeholder="注册用户名"></asp:TextBox>
                        </div>
                    </div>

                    <div class="input-group m-b-20">
                        <span class="input-group-addon"><i class="zmdi zmdi-male"></i></span>
                        <div class="fg-line">
                            <asp:TextBox runat="server" ID="txt_register_pwd" TextMode="Password"  class="form-control" placeholder="注册密码"></asp:TextBox>
                        </div>
                    </div>

                    <asp:LinkButton runat="server" ID="btn_register" class="btn btn-login btn-success btn-float" OnClick="btn_register_Click"><i class="zmdi zmdi-check"></i></asp:LinkButton>
                </div>

                <div class="lcb-navigation">
                    <a href="" data-ma-action="login-switch" data-ma-block="#l-login"><i class="zmdi zmdi-long-arrow-right"></i> <span>登陆</span></a>
                </div>
            </div>
        </div>


        <AtomController:IEWarning runat="server"></AtomController:IEWarning>

        <!-- Javascript Libraries -->
        <script src="Content/bs3/vendors/bower_components/jquery/dist/jquery.min.js"></script>
        <script src="Content/bs3/vendors/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>

        <script src="Content/bs3/vendors/bower_components/Waves/dist/waves.min.js"></script>
        <script src="Content/bs3/vendors/bower_components/sweetalert2/dist/sweetalert2.min.js"></script>

        <!-- Placeholder for IE9 -->
        <!--[if IE 9 ]>
            <script src="vendors/bower_components/jquery-placeholder/jquery.placeholder.min.js"></script>
        <![endif]-->

        <script src="Content/bs3/js/app.min.js"></script>
        <script src="Content/Cookies.js"></script>
    </form>
</body>
</html>
<script>
    $(function () {
        $('#txt_login_userName').val(Cookies.get('userName'));
        $('#txt_login_pwd').val(Cookies.get('pwd'));
        $("#ipt_isRemember").prop("checked", Cookies.get('isRemember'));
    })

    var Login = function () {
        SettleCookies();
       
        if ($('#txt_login_userName').val().trim() == '') {
            swal("出错啦!", "请输入用户名", "error");
            return false;
        }
        if ($('#txt_login_pwd').val().trim() == '') {   
            swal("出错啦!", "请输入密码", "error");
            return false;
        }
        if ($('#txt_login_confirmCode').val().trim() == '') {
            swal("出错啦!", "请输入验证码", "error");
            return false;
        }
    }

    var SettleCookies = function () {
        Cookies.set('userName', $('#txt_login_userName').val());
        if ($("#ipt_isRemember").prop("checked") == true) {
            Cookies.set('pwd', $('#txt_login_pwd').val());
            Cookies.set('isRemember', true);
        }
        else {
            Cookies.remove('pwd');
            Cookies.remove('isRemember');
        }
    }

    var a = 0;
    document.getElementById("img_login_yzm").onclick = function () {
        this.src = "CustomController/yzm.aspx?a=" + a;
        a++;
    }
    
</script>
