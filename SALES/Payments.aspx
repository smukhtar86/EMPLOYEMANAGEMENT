<%@ Page Title="" Language="C#" MasterPageFile="~/SALES/MasterPage.master" AutoEventWireup="true" CodeFile="Payments.aspx.cs" Inherits="USER_Payments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cphead" runat="Server">
    <!-- DataTables -->
    <link rel="stylesheet" href="../Template/plugins/datatables/dataTables.bootstrap.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Payment History
          </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Payment History</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">
        <div class="row">
            <!-- /.col -->
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-purple"><i class="ion ion-ios-arrow-down"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text"><b>Total Collection</b></span>
                        <span class="info-box-number" runat="server" id="sp_COLLECTION_AMT">0</span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="table-responsive">
                        <div class="box-header">
                            <h3 class="box-title"></h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th>Sl. No.</th>
                                        <th>Date</th>
                                        <th>Name</th>
                                        <th>Amount</th>
                                    </tr>
                                </thead>
                                <tbody runat="server" id="tblData">
                                    <tr>
                                        <td>Other browsers</td>
                                        <td>All others</td>
                                        <td>-</td>
                                        <td></td>
                                    </tr>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>Sl. No.</th>
                                        <th>Date</th>
                                        <th>Name</th>
                                        <th>Amount</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
                <!-- /.box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </section>
    <!-- /.content -->
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
                "autoWidth": true
            });
        });
    </script>
</asp:Content>

