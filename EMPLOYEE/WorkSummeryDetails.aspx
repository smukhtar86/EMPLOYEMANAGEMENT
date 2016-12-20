<%@ Page Title="" Language="C#" MasterPageFile="~/EMPLOYEE/MasterPage.master" AutoEventWireup="true" CodeFile="WorkSummeryDetails.aspx.cs" Inherits="EMPLOYEE_WorkSummeryDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cphead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Work Summery</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Work Summery</li>
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
                                <li class="active"><a href="#settings" data-toggle="tab">Work Summery</a></li>
                            </ul>
                            <div class="tab-content">
                                <!-- /.tab-pane -->

                                <div class="active tab-pane" id="settings">
                                    <ul class="timeline timeline-inverse">
                                        <!-- timeline time label -->
                                        <li class="time-label" style="display: none;">
                                            <span class="bg-red">10 Feb. 2014
                                            </span>
                                        </li>
                                        <!-- /.timeline-label -->

                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-user bg-orange"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i></span>
                                                <h3 class="timeline-header"><a href="#">Work Summery</a></h3>
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">

                                                        <div class="row">
                                                            <div class="col-xs-12">
                                                                <div class="box">
                                                                    <div class="table-responsive">
                                                                        <!-- /.box-header -->
                                                                        <div class="box-body">
                                                                            <table id="example1" class="table table-bordered table-striped">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>Sl. No.</th>
                                                                                        <th>Date</th>
                                                                                        <th>Login</th>
                                                                                        <th>Logout</th>
                                                                                        <th>Duration</th>
                                                                                        <th></th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody runat="server" id="Tbody1">
                                                                                    <tr>
                                                                                        <th></th>
                                                                                        <th></th>
                                                                                        <th></th>
                                                                                        <th></th>
                                                                                        <th></th>
                                                                                        <th></th>
                                                                                    </tr>

                                                                                </tbody>
                                                                                <tfoot>
                                                                                    <tr>
                                                                                        <th>Sl. No.</th>
                                                                                        <th>Date</th>
                                                                                        <th>Login</th>
                                                                                        <th>Logout</th>
                                                                                        <th>Duration</th>
                                                                                        <th></th>
                                                                                    </tr>
                                                                                </tfoot>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                    <!-- /.box-body -->
                                                                </div>
                                                                <!-- /.box -->
                                                            </div>
                                                            <!-- /.col -->
                                                        </div>
                                                    </div>
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

