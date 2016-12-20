<%@ Page Title="" Language="C#" MasterPageFile="~/SALES/MasterPage.master" AutoEventWireup="true" CodeFile="Vendor.aspx.cs" EnableEventValidation="false" Inherits="SALES_Vendor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cphead" runat="Server">
    <!-- DataTables -->
    <link rel="stylesheet" href="../Template/plugins/datatables/dataTables.bootstrap.css" />
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
        <h1>Vendor</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Vendor</li>
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
                                <li class="active"><a href="#settings" data-toggle="tab">Add Vendor</a></li>
                            </ul>
                            <div class="tab-content">
                                <!-- /.tab-pane -->

                                <div class="active tab-pane" id="settings">
                                    <ul class="timeline timeline-inverse">
                                        <!-- timeline time label -->
                                        <li class="time-label" runat="server" id="divMsg" visible="false">
                                            <span class="bg-red"></span>

                                        </li>
                                        <!-- /.timeline-label -->
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-user bg-blue"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i></span>
                                                <h3 class="timeline-header"><a href="#">New Vendor</a></h3>
                                                <div class="timeline-body" id="divAddVendor">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label">Type</label>
                                                            <div class="col-sm-9">
                                                                <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" Width="100%" required="true">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label">Name</label>
                                                            <div class="col-sm-9">
                                                                <asp:TextBox ID="txtName" runat="server" type="text" CssClass="form-control" required="true" placeholder="Name"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="inputEmail" class="col-sm-2 control-label">Phone No.</label>
                                                            <div class="col-sm-9">
                                                                <asp:TextBox ID="txtPhone" type="number" runat="server" CssClass="form-control" placeholder="Phone No."></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <label for="inputEmail" class="col-sm-2 control-label">Address</label>
                                                            <div class="col-sm-9">
                                                                <asp:TextBox ID="txtAddress" runat="server" type="text" CssClass="form-control" placeholder="Address"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="inputEmail" class="col-sm-2 control-label">Email ID</label>
                                                            <div class="col-sm-9">
                                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Email ID"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                        </div>
                                                        <%-- <div class="form-group">
                                                            <label for="inputEmail" class="col-sm-2 control-label">Salary</label>
                                                            <div class="col-sm-9">
                                                                <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" TextMode="Number" placeholder="Salary"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="inputEmail" class="col-sm-2 control-label">Address</label>
                                                            <div class="col-sm-9">
                                                                <asp:FileUpload ID="fuImage" runat="server" />
                                                            </div>
                                                        </div>--%>

                                                        <div class="form-group">
                                                            <div class="col-sm-offset-2 col-sm-10">
                                                                <asp:Button ID="btnSubmit" runat="server" type="submit" Text="Submit" class="btn btn-danger" OnClick="btnSubmit_Click" />
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
    <script src="../Template/plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../Template/dist/js/demo.js"></script>
    <!-- page script -->
    <script>
        $(function () {
            $("#example1").DataTable();
            $('#example2').DataTable({
                "paging": true,
                "lengthChange": false,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": false
            });
        });
    </script>
</asp:Content>

