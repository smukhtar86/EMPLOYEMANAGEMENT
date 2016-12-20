<%@ Page Title="" Language="C#" MasterPageFile="~/SALES/MasterPage.master" AutoEventWireup="true" CodeFile="VendorReport.aspx.cs" Inherits="USER_VendorReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cphead" runat="Server">
    <!-- DataTables -->
    <link rel="stylesheet" href="../Template/plugins/datatables/dataTables.bootstrap.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Sales History <small runat="server" id="divName"></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Payment History</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <div class="row">
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-aqua"><i class="ion ion-android-cart"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Total Sale</span>
                        <span class="info-box-number" runat="server" id="sp_totalSale">0<small></small></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-red"><i class="fa fa-credit-card"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Total Payment</span>
                        <a href="VendorPayment.aspx"><span class="info-box-number" runat="server" id="sp_totalPay">0</span></a>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-red"><i class="ion ion-arrow-graph-up-right"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Rest Amount</span>
                        <span class="info-box-number" runat="server" id="sp_total">0</span>
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
                            <h3 class="box-title">Total Sales</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th>Sl. No.</th>
                                        <th>Date</th>
                                        <th>Product</th>
                                        <th>Qnty</th>
                                        <th>Amount /Per</th>
                                        <th>Total Amount</th>
                                        <th>Remarks</th>
                                    </tr>
                                </thead>
                                <tbody runat="server" id="tblSaleReport">
                                    <tr>
                                        <td>1</td>
                                        <td>21-Jan-2016</td>
                                        <td>Name</td>
                                        <td>1</td>
                                        <td>10</td>
                                        <td>10</td>
                                    </tr>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>Sl. No.</th>
                                        <th>Date</th>
                                        <th>Product</th>
                                        <th>Qnty</th>
                                        <th>Amount /Per</th>
                                        <th>Total Amount</th>
                                        <th>Remarks</th>
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
        <div class="row">
            <div class="col-xs-12">
                <div class="box">
                    <div class="table-responsive">
                        <div class="box-header">
                            <h3 class="box-title">Total Payment Collected</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <table id="example2" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th>Sl. No.</th>
                                        <th>Date</th>
                                        <th>Amount</th>
                                    </tr>
                                </thead>
                                <tbody runat="server" id="tblPaymentReport">
                                    <tr>
                                        <td>1</td>
                                        <td>21-Jan-2016</td>
                                        <td>10</td>
                                    </tr>

                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>Sl. No.</th>
                                        <th>Date</th>
                                        <th>Total Amount</th>
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
                "autoWidth": false
            });
        });
    </script>
</asp:Content>

