<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="ZW.Admin.Page.System.User" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card">
        <div class="card-header">
            <h2>角色管理</h2>
            <ul class="actions">
                <li>
                    <a data-toggle="collapse" href="#searchArea" aria-expanded="false" aria-controls="searchArea">
                        <i class="zmdi zmdi-search"></i>
                    </a>
                </li>
                <li>
                    <a href="UserAdd">
                        <i class="zmdi zmdi-plus"></i>
                    </a>
                </li>
                <li class="dropdown">
                    <a href="" data-toggle="dropdown">
                        <i class="zmdi zmdi-more-vert"></i>
                    </a>

                    <ul class="dropdown-menu dropdown-menu-right">
                        <li>
                            <asp:LinkButton runat="server" ID="btn_deleteList" Text="删除所选" OnClientClick="return confirm('数据删除不可恢复，确定删除?')" OnClick="btn_deleteList_Click"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="btn_export" Text="导出excel" OnClick="btn_export_Click"></asp:LinkButton>
                        </li>
                    </ul>
                </li>
            </ul>
            <div class="row collapse" id="searchArea" aria-expanded="false">
                <div class="col-sm-3">
                    <div class="input-group">
                        <div class="fg-line">
                            <asp:TextBox runat="server" ID="search_UserName" CssClass="form-control" placeholder="角色名称"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="input-group">
                        <div class="fg-line">
                            <asp:LinkButton runat="server" ID="btn_search" CssClass="btn btn-info waves-effect" Text="查询" OnClick="btn_search_Click"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card-body">
            <asp:Repeater ID="RptList" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table width="100%" class="table table-bordered table-striped table-hover">
                        <tr>
                            <th style="width: 5%">
                               <label class="checkbox checkbox-inline m-r-20">
                                    <input type="checkbox" value="option1" class="cb_checkAll">
                                    <i class="input-helper"></i>
                                </label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                            <th style="width: 10%">编号</th>
                            <th >登陆账号</th>
                            <th >用户名称</th>
                            <th >所属角色</th>
                            <th >用户状态</th>
                            <th style="width: 25%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <label class="checkbox checkbox-inline m-r-20">
                                <input type="checkbox" class="cb_checkitem" id="CheckBox" runat="server" value='<%# Eval("Id") %>'/>
                                <i class="input-helper"></i>
                            </label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td><%#DataBinder.Eval(Container.DataItem,"row")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem,"UserName")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem,"Name")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem,"RoleName")%></td>
<%--                        <td><%#DataBinder.Eval(Container.DataItem,"status").ToString()=="1"?"x":"asd"%></td>--%>
                        <td><%#status(Eval("status"))%></td>
                        <td>
                            <asp:LinkButton ID="delete" runat="server"  CssClass="btn btn-danger waves-effect"
                                 OnClientClick="return confirm('数据删除不可恢复，确定删除?')"
                                CommandName="delete" ItemEventArgs=<%# Eval("Id") %> CommandArgument=<%# Eval("Id") %>>
                                <i class="zmdi zmdi-delete"></i>
                            </asp:LinkButton>
                            <asp:LinkButton ID="edit" runat="server" CssClass="btn bgm-lightblue waves-effect" 
                                CommandName="edit" ItemEventArgs=<%# Eval("Id") %> CommandArgument=<%# Eval("Id") %>>
                                <i class="zmdi zmdi-edit"></i>
                            </asp:LinkButton>
                            <asp:LinkButton ID="detail" runat="server" CssClass="btn btn-info waves-effect" 
                                CommandName="detail" ItemEventArgs=<%# Eval("Id") %> CommandArgument=<%# Eval("Id") %>>
                                <i class="zmdi zmdi-search"></i>
                            </asp:LinkButton>
                            <asp:LinkButton ID="properties" runat="server" CssClass="btn bgm-orange waves-effect" 
                                CommandName="properties" ItemEventArgs=<%# Eval("Id") %> CommandArgument=<%# Eval("Id") %>>
                                <i class="zmdi zmdi-key"></i>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
       
                </FooterTemplate>
            </asp:Repeater>

            <div class="pull-right">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" Width="100%" UrlPaging="true" 
                    CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" 
                    PagingButtonSpacing="0" CurrentPageButtonClass="activePage" OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>

    </div>

  
</asp:Content>
