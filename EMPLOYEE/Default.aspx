<%@ Page Title="" Language="C#" MasterPageFile="~/EMPLOYEE/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="USER_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cphead" runat="Server">
    <script type="text/javascript">

        function myFunction() {
            var r = confirm("Sure to approve the Stock..");
            if (r == true) {
                return true;
            } else {
                return false;
            }
        }
        function ShowHide(e) {
            var x = document.getElementById(e);
            if (x.style.display == 'none') {
                x.style.display = '';
            }
            else {
                x.style.display = "none";
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Dashboard
           
            <small></small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active"></li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">
        <!-- Info boxes -->
        <div class="row">
            <!-- Profile Image -->
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="box box-primary">
                    <div class="box-body box-profile" runat="server" id="divProfile">
                        <img class="profile-user-img img-responsive img-circle" src="../../dist/img/user4-128x128.jpg" alt="User profile picture">
                        <h3 class="profile-username text-center">Name</h3>
                        <p class="text-muted text-center">Designaiton</p>

                        <ul class="list-group list-group-unbordered">
                            <li class="list-group-item">
                                <b>Email</b> <a class="pull-right">1,322</a>
                            </li>
                            <li class="list-group-item">
                                <b>Contact No</b> <a class="pull-right">543</a>
                            </li>
                            <li class="list-group-item">
                                <b>Login Time</b> <a class="pull-right">13,287</a>
                            </li>
                        </ul>

                        <a href="Profile.aspx" class="btn btn-primary btn-block"><b>Personal Profile</b></a>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
            <!-- /.box -->
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-red-active"><a onclick="ShowHide('ContentPlaceHolder1_sp_CREDIT1');ShowHide('credit_link1');"><i class="ion ion-ios-contact" style="color: white;"></i></a>
                        <br />
                        <a href="VendorPayment.aspx" id="credit_link1" style="display: none;"><i class="ion ion-ios-contact" style="color: red;"></i></a></span>
                    <div class="info-box-content">
                        <span class="info-box-text"><a href="Profile.aspx"><b>My Profile</b></a></span>
                        <span class="info-box-number" runat="server" id="sp_CREDIT"></span>
                        <span class="progress-description" runat="server" id="sp_CREDIT1" style="display: none;"><small></small></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>

            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-blue"><i class="fa fa-line-chart"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text"><a href="WorkSummery.aspx">Work Summery</a></span>
                        <span class="info-box-number" runat="server" id="sp_CurrentStock">Days <small>20</small></span>
                        <span class="info-box-number" runat="server" id="sp_CurrentStock1">Month : December 2016</span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- fix for small devices only -->
            <div class="clearfix visible-sm-block"></div>
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-orange-active"><a onclick="ShowHide('ContentPlaceHolder1_sp_TODAY_SALE_QNTY1'); ShowHide('today_sale_link1');ShowHide('today_sale_link2');"><i class="fa fa-money" style="color: white;"></i></a>
                        <br />
                        <a href="Sale.aspx" id="today_sale_link1" style="display: none;"><i class="fa fa-cart-plus" style="color: red;"></i></a>
                        <br />
                        <a href="Vendor.aspx" id="today_sale_link2" style="display: none;"><i class="ion ion-ios-contact" style="color: red;"></i></a></span>
                    <div class="info-box-content">
                        <span class="info-box-text"><a href="Salary.aspx"><b>Salary Details</b></a></span>
                        <span class="info-box-number" runat="server" id="sp_TODAY_SALE_QNTY">0</span>
                        <span class="progress-description" id="sp_TODAY_SALE_QNTY1" runat="server" style="display: none;"><small></small></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>

            <!-- /.col -->
            <div class="clearfix visible-sm-block"></div>
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-aqua-active"><a onclick="ShowHide('ContentPlaceHolder1_sp_PURCHASE_ORDER_QNTY1');ShowHide('purchaseorder_link1');"><i class="fa fa-book" style="color: white;"></i></a>
                        <br />
                        <a href="AddStock.aspx" id="purchaseorder_link1" style="display: none;"><i class="fa fa-truck" style="color: red;"></i></a></span>
                    <div class="info-box-content">
                        <span class="info-box-text"><a href="Bank.aspx"><b>Bank Details</b></a></span>
                        <span class="info-box-number" runat="server" id="sp_PURCHASE_ORDER_QNTY" style="color: red;">0</span>
                        <span class="progress-description" runat="server" id="sp_PURCHASE_ORDER_QNTY1" style="display: none;"><small></small></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>

            <!-- /.col -->
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-aqua"><a onclick="ShowHide('ContentPlaceHolder1_sp_SALE_QNTY1'); ShowHide('sale_link1');ShowHide('sale_link2');"><i class="ion ion-ios-cart-outline" style="color: white;"></i></a>
                        <br />
                        <a href="Sale.aspx" id="sale_link1" style="display: none;"><i class="fa fa-cart-plus" style="color: red;"></i></a>
                        <br />
                        <a href="Vendor.aspx" id="sale_link2" style="display: none;"><i class="ion ion-ios-contact" style="color: red;"></i></a></span>
                    <div class="info-box-content">
                        <span class="info-box-text"><a href="SaleReport.aspx"><b>Work Assignment</b></a></span>
                        <span class="info-box-number" runat="server" id="sp_SALE_QNTY">0</span>
                        <span class="progress-description" id="sp_SALE_QNTY1" runat="server" style="display: none;"><small></small></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>



            

            <!-- /.col -->
            <div class="col-md-4 col-sm-6 col-xs-12" style="display:none;">
                <div class="info-box">
                    <span class="info-box-icon  bg-aqua-active"><a onclick="ShowHide('ContentPlaceHolder1_sp_Intransit_Details');ShowHide('intransit_link1');"><i class="fa fa-truck" style="color: white;"></i></a>
                        <br />
                        <a href="AddStock.aspx" id="intransit_link1" style="display: none;"><i class="fa fa-truck" style="color: red;"></i></a></span>
                    <div class="info-box-content">
                        <span class="info-box-text"><a href="AddStock.aspx"><b>In Transit</b></a></span>
                        <span class="info-box-number" runat="server" id="sp_InTransit" style="color: green;">0</span>
                        <span class="progress-description" id="sp_Intransit_Details" runat="server" style="display: none;"><small></small></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->


            <!-- /.col -->
            <div class="col-md-4 col-sm-6 col-xs-12" style="display:none;">
                <div class="info-box">
                    <span class="info-box-icon bg-purple"><a onclick="ShowHide('ContentPlaceHolder1_sp_COLLECTION_AMT1');ShowHide('colletion_link1');"><i class="ion ion-ios-arrow-down" style="color: white;"></i></a>
                        <br />
                        <a href="VendorPayment.aspx" id="colletion_link1" style="display: none;"><i class="ion ion-ios-contact" style="color: red;"></i></a></span>
                    <div class="info-box-content">
                        <span class="info-box-text"><a href="Payments.aspx"><b>Total Collection</b></a></span>
                        <span class="info-box-number" runat="server" id="sp_COLLECTION_AMT">0</span>
                        <span class="progress-description" runat="server" id="sp_COLLECTION_AMT1" style="display: none;"><small></small></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->

            <div class="col-md-4 col-sm-6 col-xs-12" style="display:none;">
                <div class="info-box">
                    <span class="info-box-icon bg-yellow"><a onclick="ShowHide('ContentPlaceHolder1_sp_EXPENSES1');ShowHide('expenses_link1');"><i class="ion ion-ios-arrow-up" style="color: white;"></i>
                        <br />
                        <a href="Expenses.aspx" id="expenses_link1" style="display: none;"><i class="ion ion-ios-arrow-up" style="color: red;"></i></a></span>
                    <div class="info-box-content">
                        <span class="info-box-text"><a href="Expenses.aspx"><b>Expenses</b></a></span>
                        <span class="info-box-number" runat="server" id="sp_EXPENSES">0</span>
                        <span class="progress-description" runat="server" id="sp_EXPENSES1" style="display: none;"><small></small></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
            <div class="col-md-4 col-sm-6 col-xs-12" style="display:none;">
                <div class="info-box">
                    <span class="info-box-icon bg-red"><i class="ion ion-arrow-graph-up-right"></i></span>
                    <div class="info-box-content">
                        <a href="SupplierReport.aspx"><span class="info-box-text" runat="server" id="sp_total_Title">Rest Amount</span></a>
                        <span class="info-box-number" runat="server" id="sp_total">0</span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
            <div class="col-md-4 col-sm-6 col-xs-12" style="display:none;">
                <div class="info-box bg-orange">
                    <span class="info-box-icon"><a onclick="ShowHide('ContentPlaceHolder1_sp_CapitalAmount1');"><i class="glyphicon glyphicon-credit-card" style="color: white;"></i></a></span>
                    <div class="info-box-content">
                        <span class="info-box-text"><b>Capital Amount</b></span>
                        <span class="info-box-number" runat="server" id="sp_CapitalAmount">0</span>
                        <div class="progress">
                            <div class="progress-bar" style="width: 50%"></div>
                        </div>
                        <span class="progress-description" runat="server" id="sp_CapitalAmount1" style="display: none;"><small></small></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
            </div>
            <!-- /.col -->
            <div class="col-md-4 col-sm-6 col-xs-12" style="display:none;">
                <div class="info-box bg-maroon">
                    <span class="info-box-icon"><a onclick="ShowHide('ContentPlaceHolder1_Span2');"><i class="fa fa-money" style="color: white;"></i></a></span>
                    <div class="info-box-content">
                        <span class="info-box-text"><b>TOTAL ASSET</b></span>
                        <span class="info-box-number" runat="server" id="sp_asset">0</span>
                        <div class="progress">
                            <div class="progress-bar" style="width: 50%"></div>
                        </div>
                        <span class="progress-description" id="Span2" runat="server" style="display: none;"><small></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
            </div>
            <!-- /.col -->
            <div class="col-md-4 col-sm-6 col-xs-12" style="display:none;">
                <div class="info-box bg-green">
                    <span class="info-box-icon"><i class="ion ion-ios-pricetag-outline"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text"><b>Cash In Hand</b></span>
                        <span class="info-box-number" runat="server" id="sp_CASHINHANDAct">0</span>
                        <div class="progress">
                            <div class="progress-bar" style="width: 50%"></div>
                        </div>
                        <span class="progress-description"></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
            </div>
            <!-- /.col -->

            <div class="col-md-4 col-sm-6 col-xs-12" style="display: none;">
                <div class="info-box bg-green">
                    <span class="info-box-icon"><i class="ion ion-ios-pricetag-outline"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text"><b>Cash In Hand [Virtual]</b></span>
                        <span class="info-box-number" runat="server" id="sp_CASHINHAND">0</span>
                        <div class="progress">
                            <div class="progress-bar" style="width: 50%"></div>
                        </div>
                        <span class="progress-description"></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
            </div>
        </div>


        <div class="row" style="display: none;">
            <div class="col-md-12">
                <div class="box">
                    <div class="box-header with-border">
                        <h3 class="box-title">Monthly Recap Report</h3>
                        <div class="box-tools pull-right">
                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            <div class="btn-group">
                                <button class="btn btn-box-tool dropdown-toggle" data-toggle="dropdown"><i class="fa fa-wrench"></i></button>
                                <ul class="dropdown-menu" role="menu">
                                    <li><a href="#">Action</a></li>
                                    <li><a href="#">Another action</a></li>
                                    <li><a href="#">Something else here</a></li>
                                    <li class="divider"></li>
                                    <li><a href="#">Separated link</a></li>
                                </ul>
                            </div>
                            <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-8">
                                <p class="text-center">
                                    <strong>Sales: 1 Jan, 2014 - 30 Jul, 2014</strong>
                                </p>
                                <div class="chart">
                                    <!-- Sales Chart Canvas -->
                                    <canvas id="salesChart" style="height: 180px;"></canvas>
                                </div>
                                <!-- /.chart-responsive -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-4">
                                <p class="text-center">
                                    <strong>Goal Completion</strong>
                                </p>
                                <div class="progress-group">
                                    <span class="progress-text">Silver Club (Min. 5 Direct Referals)</span>
                                    <span class="progress-number"><b>0</b>/5</span>
                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-red" style="width: 0%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <div class="progress-group">
                                    <span class="progress-text">Gold Club</span>
                                    <span class="progress-number"><b>0</b>/25</span>
                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-yellow" style="width: 0%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <div class="progress-group">
                                    <span class="progress-text">Total Joinings</span>
                                    <span class="progress-number"><b>0</b>/100</span>
                                    <div class="progress sm">
                                        <div class="progress-bar progress-bar-green" style="width: 0%"></div>
                                    </div>
                                </div>
                                <!-- /.progress-group -->
                                <!--<div class="progress-group">
                        <span class="progress-text">Send Inquiries</span>
                        <span class="progress-number"><b>250</b>/500</span>
                        <div class="progress sm">
                          <div class="progress-bar progress-bar-yellow" style="width: 80%"></div>
                        </div>
                      </div> /.progress-group -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- ./box-body -->
                    <div class="box-footer">
                        <div class="row">
                            <div class="col-sm-3 col-xs-6">
                                <div class="description-block border-right">
                                    <span class="description-percentage text-green"><i class="fa fa-caret-up"></i>17%</span>
                                    <h5 class="description-header">$35,210.43</h5>
                                    <span class="description-text">TOTAL REVENUE</span>
                                </div>
                                <!-- /.description-block -->
                            </div>
                            <!-- /.col -->
                            <div class="col-sm-3 col-xs-6">
                                <div class="description-block border-right">
                                    <span class="description-percentage text-yellow"><i class="fa fa-caret-left"></i>0%</span>
                                    <h5 class="description-header">$10,390.90</h5>
                                    <span class="description-text">TOTAL COST</span>
                                </div>
                                <!-- /.description-block -->
                            </div>
                            <!-- /.col -->
                            <div class="col-sm-3 col-xs-6">
                                <div class="description-block border-right">
                                    <span class="description-percentage text-green"><i class="fa fa-caret-up"></i>20%</span>
                                    <h5 class="description-header">$24,813.53</h5>
                                    <span class="description-text">TOTAL PROFIT</span>
                                </div>
                                <!-- /.description-block -->
                            </div>
                            <!-- /.col -->
                            <div class="col-sm-3 col-xs-6">
                                <div class="description-block">
                                    <span class="description-percentage text-red"><i class="fa fa-caret-down"></i>18%</span>
                                    <h5 class="description-header">1200</h5>
                                    <span class="description-text">GOAL COMPLETIONS</span>
                                </div>
                                <!-- /.description-block -->
                            </div>
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-footer -->
                </div>
                <!-- /.box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->

        <!-- Main row -->
        <div class="row" style="display: none;">
            <!-- Left col -->
            <div class="col-md-8">
                <!-- TABLE: LATEST ORDERS -->
                <div class="box box-info collapsed-box">
                    <div class="box-header with-border">
                        <h3 class="box-title">Product Stock</h3>
                        <div class="box-tools pull-right">
                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="table-responsive">
                            <table class="table no-margin">
                                <thead>
                                    <tr>
                                        <th>Sl. No.</th>
                                        <th>Product Name</th>
                                        <th>Qnty</th>
                                        <th>Status</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody runat="server" id="tblProductStock">
                                    <tr>
                                        <td>1</td>
                                        <td>Item</td>
                                        <td>Qnty</td>
                                        <td><span class="label label-success">Low</span></td>
                                        <td><span class="label label-success"><a href="SaleReport.aspx?Typ=Prd&Cd="></a></span></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.box-body -->
                    <div class="box-footer clearfix" style="display: none;">
                        <a href="AddStock.aspx" class="btn btn-sm btn-info btn-flat pull-left">Place New Order</a>
                        <a href="javascript::;" class="btn btn-sm btn-default btn-flat pull-right">View All Orders</a>
                    </div>
                    <!-- /.box-footer -->
                </div>
                <!-- TABLE: LATEST ORDERS -->
                <div class="box box-info collapsed-box">
                    <div class="box-header with-border">
                        <h3 class="box-title">Latest Orders</h3>
                        <div class="box-tools pull-right">
                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="table-responsive">
                            <table class="table no-margin">
                                <thead>
                                    <tr>
                                        <th>Order ID</th>
                                        <th>Date</th>
                                        <th>Item</th>
                                        <th>Qnty</th>
                                        <th>Box</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tbody runat="server" id="tblPurchaseOrder">
                                    <tr>
                                        <td><a href="pages/examples/invoice.html">OR9842</a></td>
                                        <td>Date</td>
                                        <td>Item</td>
                                        <td>Qnty</td>
                                        <th>Box</th>
                                        <td><span class="label label-success">Shipped</span></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.box-body -->
                    <div class="box-footer clearfix" style="display: none;">
                        <a href="AddStock.aspx" class="btn btn-sm btn-info btn-flat pull-left">Place New Order</a>
                        <a href="javascript::;" class="btn btn-sm btn-default btn-flat pull-right">View All Orders</a>
                    </div>
                    <!-- /.box-footer -->
                </div>
                <!-- /.box -->
                <!-- TABLE: CAPITAL INVESTMENT -->
                <div class="box box-info collapsed-box">
                    <div class="box-header with-border">
                        <h3 class="box-title">Capital Amount</h3>
                        <div class="box-tools pull-right">
                            <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-plus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="table-responsive">
                            <table class="table no-margin">
                                <thead>
                                    <tr>
                                        <th>Sl No.</th>
                                        <th>Date</th>
                                        <th>Name</th>
                                        <th>Amount</th>
                                    </tr>
                                </thead>
                                <tbody runat="server" id="tbl_Capital">
                                    <tr>
                                        <td></td>
                                        <td>Date</td>
                                        <td>Name</td>
                                        <td>Amount</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.box-body -->
                    <div class="box-footer clearfix" style="display: none;">
                        <a href="AddStock.aspx" class="btn btn-sm btn-info btn-flat pull-left">Place New Order</a>
                        <a href="javascript::;" class="btn btn-sm btn-default btn-flat pull-right">View All Orders</a>
                    </div>
                    <!-- /.box-footer -->
                </div>
                <!-- /.box -->
            </div>
            <!-- /.col -->

            <div class="col-md-4">

                <!-- /.box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </section>
    <!-- /.content -->

</asp:Content>

