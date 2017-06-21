<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="ZW.Admin.CustomController.Footer" %>
<footer id="footer">
            Copyright &copy; <% DateTime.Now.Year.ToString(); %> <asp:Label runat="server" ID="lbl_softName"></asp:Label>

            <ul class="f-menu">
                <li><a runat="server" target="_blank" id="contact" href="">联系我们:陕西中为科技有限公司</a></li>
            </ul>
        </footer>

       
        <script src="/Content/bs3/vendors/bower_components/jquery/dist/jquery.min.js"></script>
        <script src="/Content/bs3/vendors/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
        <script src="/Content/Cookies.js"></script>
        <!-- Javascript Libraries -->
        

        <script src="/Content/bs3/vendors/bower_components/flot/jquery.flot.js"></script>
        <script src="/Content/bs3/vendors/bower_components/flot/jquery.flot.resize.js"></script>
        <script src="/Content/bs3/vendors/bower_components/flot.curvedlines/curvedLines.js"></script>
        <script src="/Content/bs3/vendors/sparklines/jquery.sparkline.min.js"></script>
        <script src="/Content/bs3/vendors/bower_components/jquery.easy-pie-chart/dist/jquery.easypiechart.min.js"></script>

        <script src="/Content/bs3/vendors/bower_components/moment/min/moment.min.js"></script>
        <script src="/Content/bs3/vendors/bower_components/fullcalendar/dist/fullcalendar.min.js "></script>
        <%--<script src="Content/bs3/vendors/bower_components/simpleWeather/jquery.simpleWeather.min.js"></script>--%>
        <script src="/Content/bs3/vendors/bower_components/Waves/dist/waves.min.js"></script>
        <script src="/Content/bs3/vendors/bootstrap-growl/bootstrap-growl.min.js"></script>
        <script src="/Content/bs3/vendors/bower_components/sweetalert2/dist/sweetalert2.min.js"></script>
        <script src="/Content/bs3/vendors/bower_components/malihu-custom-scrollbar-plugin/jquery.mCustomScrollbar.concat.min.js"></script>
        <script src="/Content/jquery.validate.js"></script>
        <!-- Placeholder for IE9 -->
        <!--[if IE 9 ]>
            <script src="vendors/bower_components/jquery-placeholder/jquery.placeholder.min.js"></script>
        <![endif]-->

        <script src="/Content/bs3/js/app.js"></script>
        <script>
            $(function () {
                $('.menu-item').click(function () {
                    //$('.active').removeClass("active");
                    //$(this).parent('li').addClass("active");
                    Cookies.set("menu-id", $(this).attr("id"));
                });
                $('.active').removeClass("active");
                $('.toggled').removeClass("toggled");
                $('.sub-menu').children('ul').css('display', '');
                $("a[id=" + Cookies.get("menu-id") + "]").parent('li').addClass("active");
                $("a[id=" + Cookies.get("menu-id") + "]").parent('li').parent('ul').css('display', 'block');
                $("a[id=" + Cookies.get("menu-id") + "]").parent('li').parent('ul').parent('li').addClass('toggled');

                $('.activePage').parent('li').addClass('active');
            });

            $('.cb_checkAll').click(function () {
                $('.cb_checkitem').prop("checked", $('.cb_checkAll').prop("checked"));
            });

            var ConfirmDelete = function () {
                var result = false;
                swal({
                    title: "确定删除吗?",
                    text: "数据删除将不可恢复!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonText: "是的, 我要删除!",
                    cancelButtonText:"我再想想",
                }).then(function () {
                    swal("Deleted!", "Your imaginary file has been deleted.", "success");
                    result = true;
                });
            }
        </script>