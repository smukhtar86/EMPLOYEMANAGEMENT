<%@ Page Title="" Language="C#" MasterPageFile="~/SALES/MasterPage.master" AutoEventWireup="true" CodeFile="VendorPayment.aspx.cs" Inherits="USER_VendorPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cphead" runat="Server">
    <script type="text/javascript">
        function showHide(e) {
            var cc = document.getElementById(e).style.display;
            var c = document.getElementById(e);
            if (cc == 'none') {
                c.style.display = 'block';
            }
            else {
                c.style.display = 'none';
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Vendor Payment</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Payment</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <div class="row">

            <!-- /.col -->
            <div class="col-md-11">


                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>

                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#settings" data-toggle="tab">Payment</a></li>
                            </ul>
                            <div class="tab-content">
                                <!-- /.tab-pane -->

                                <div class="active tab-pane" id="settings">
                                    <ul class="timeline timeline-inverse">
                                        <!-- timeline time label -->
                                        <li class="time-label" visible="false" runat="server" id="liMsg">
                                            <span class="bg-red">10 Feb. 2014
                        </span>
                                        </li>
                                        <!-- /.timeline-label -->
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-user bg-blue"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i></span>
                                                <h3 class="timeline-header"><a href="#">Vendor Payment</a></h3>
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label">Date</label>
                                                            <div class="col-sm-9">
                                                                <asp:TextBox runat="server" type="date" CssClass="form-control" ID="txtDate" required="true" placeholder="Date"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                         <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label">Vendor Name</label>
                                                            <div class="col-sm-9">
                                                                <asp:DropDownList runat="server" type="text" required="true" CssClass="form-control" ID="ddlVendorName"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                       
                                                        <div class="form-group">
                                                            <label for="inputEmail" class="col-sm-2 control-label">Total Amount</label>
                                                            <div class="col-sm-9">
                                                                <asp:TextBox runat="server" required="true" type="text" CssClass="form-control" ID="txtTotal" placeholder="Total Amount"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-offset-2 col-sm-10">
                                                                <asp:Button runat="server" ID="btnSave" type="submit" class="btn btn-danger" Text="Save" OnClick="btnSave_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="timeline-footer" style="display: none;">
                                                    <a class="btn btn-primary btn-xs">Read more</a>
                                                    <a class="btn btn-danger btn-xs">Delete</a>
                                                </div>
                                            </div>
                                        </li>
                                        <!-- END timeline item -->

                                        <li>
                                            <i class="fa fa-clock-o bg-gray"></i>
                                        </li>
                                    </ul>

                                </div>
                                <!-- /.tab-pane -->
                            </div>
                            <!-- /.tab-content -->
                        </div>
                        <!-- /.nav-tabs-custom -->
                        </span></span>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->

    </section>
    <!-- /.content -->

</asp:Content>

