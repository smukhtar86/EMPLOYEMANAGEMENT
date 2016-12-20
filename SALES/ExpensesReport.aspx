<%@ Page Title="" Language="C#" MasterPageFile="~/SALES/MasterPage.master" AutoEventWireup="true" CodeFile="ExpensesReport.aspx.cs" Inherits="USER_ExpensesReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cphead" runat="Server">
    <!-- DataTables -->
    <link rel="stylesheet" href="../Template/plugins/datatables/dataTables.bootstrap.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Expenses Reoprt
        </h1>
        <ol class="breadcrumb">
            <li><a href="Default.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Expenses Report</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-aqua"><i class="ion ion-android-cart"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Total Expenses</span>
                        <span class="info-box-number" runat="server" id="sp_totalSale">0<small></small></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="table-responsive">
                        <div class="box-header">
                            <h3 class="box-title">Sales Report</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">

                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th>Sl. No.</th>
                                        <th>Date</th>
                                        <th>Name</th>
                                        <th>Purpose</th>
                                        <th>Amount</th>

                                    </tr>
                                </thead>
                                <tbody runat="server" id="Tbody1">
                                    <tr>
                                        <td>1</td>
                                        <td>1-Jan-2016</td>
                                        <td>Name</td>
                                        <td>Purpose</td>
                                        <td>10</td>
                                    </tr>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>Sl. No.</th>
                                        <th>Date</th>
                                        <th>Name</th>
                                        <th>Purpose</th>
                                        <th>Amount</th>
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

