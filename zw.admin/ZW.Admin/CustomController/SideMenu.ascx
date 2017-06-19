<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideMenu.ascx.cs" Inherits="ZW.Admin.CustomController.SideMenu" %>
<aside id="sidebar" class="sidebar c-overflow">
    <div class="s-profile">
        <a href="" data-ma-action="profile-menu-toggle">
            <div class="sp-pic">
                <img src="/Content/bs3/img/demo/profile-pics/1.jpg" alt="">
            </div>

            <div class="sp-info">
                管理员
                 <i class="zmdi zmdi-caret-down"></i>
            </div>
        </a>

        <ul class="main-menu">
            
            <li>
                <a href=""><i class="zmdi zmdi-settings"></i>个人设置</a>
            </li>
            <li>
                <asp:LinkButton runat="server" ID="logout" OnClick="logout_Click"><i class="zmdi zmdi-time-restore"></i>注销</asp:LinkButton>
            </li>
        </ul>
    </div>

    <ul class="main-menu">
        <li class="active">
            <a id="0" href="/" class="menu-item"><i class="zmdi zmdi-home"></i>主页</a>
        </li>
        <li class="sub-menu">
            <a href="" data-ma-action="submenu-toggle"><i class="zmdi zmdi-chart"></i>系统设置</a>

            <ul>
                <li><a id="1" href="dashboards/analytics.html" class="menu-item">模块管理</a></li>
                <li><a id="2" href="/Page/System/Role" class="menu-item">角色管理</a></li>
                <li><a id="3" href="dashboards/analytics.html" class="menu-item">权限管理</a></li>
                <li><a id="4" href="dashboards/school.html" class="menu-item">人员管理</a></li>
            </ul>
        </li>
        
    </ul>
</aside>


