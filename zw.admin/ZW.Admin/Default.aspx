<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ZW.Admin._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="block-header">
        <h2>主页</h2>

        <ul class="actions">
            <li>
                <a href="">
                    <i class="zmdi zmdi-trending-up"></i>
                </a>
            </li>
            <li>
                <a href="">
                    <i class="zmdi zmdi-check-all"></i>
                </a>
            </li>
            <li class="dropdown">
                <a href="" data-toggle="dropdown">
                    <i class="zmdi zmdi-more-vert"></i>
                </a>

                <ul class="dropdown-menu dropdown-menu-right">
                    <li>
                        <a href="">Refresh</a>
                    </li>
                    <li>
                        <a href="">Manage Widgets</a>
                    </li>
                    <li>
                        <a href="">Widgets Settings</a>
                    </li>
                </ul>
            </li>
        </ul>

    </div>

    <div class="card">
        <div class="card-header">
            <h2>Sales Statistics <small>Vestibulum purus quam scelerisque, mollis nonummy metus</small></h2>

            <ul class="actions">
                <li>
                    <a href="">
                        <i class="zmdi zmdi-refresh-alt"></i>
                    </a>
                </li>
                <li>
                    <a href="">
                        <i class="zmdi zmdi-download"></i>
                    </a>
                </li>
                <li class="dropdown">
                    <a href="" data-toggle="dropdown">
                        <i class="zmdi zmdi-more-vert"></i>
                    </a>

                    <ul class="dropdown-menu dropdown-menu-right">
                        <li>
                            <a href="">Change Date Range</a>
                        </li>
                        <li>
                            <a href="">Change Graph Type</a>
                        </li>
                        <li>
                            <a href="">Other Settings</a>
                        </li>
                    </ul>
                </li>
            </ul>
        </div>

        <div class="card-body">
            <div class="chart-edge">
                <div id="curved-line-chart" class="flot-chart "></div>
            </div>
        </div>
    </div>

    <div class="mini-charts">
        <div class="row">
            <div class="col-sm-6 col-md-3">
                <div class="mini-charts-item bgm-lightgreen">
                    <div class="clearfix">
                        <div class="chart stats-bar"></div>
                        <div class="count">
                            <small>Website Traffics</small>
                            <h2>987,459</h2>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-6 col-md-3">
                <div class="mini-charts-item bgm-purple">
                    <div class="clearfix">
                        <div class="chart stats-bar-2"></div>
                        <div class="count">
                            <small>Website Impressions</small>
                            <h2>356,785K</h2>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-6 col-md-3">
                <div class="mini-charts-item bgm-orange">
                    <div class="clearfix">
                        <div class="chart stats-line"></div>
                        <div class="count">
                            <small>Total Sales</small>
                            <h2>$ 458,778</h2>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-6 col-md-3">
                <div class="mini-charts-item bgm-bluegray">
                    <div class="clearfix">
                        <div class="chart stats-line-2"></div>
                        <div class="count">
                            <small>Support Tickets</small>
                            <h2>23,856</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
            Cookies.set("menu-id", '0');
    </script>
</asp:Content>
