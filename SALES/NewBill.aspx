<%@ Page Title="" Language="C#" MasterPageFile="~/SALES/MasterPage.master" AutoEventWireup="true" CodeFile="NewBill.aspx.cs" Inherits="SALES_NewBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cphead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>Product Sale</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Sale</li>
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
                                <li class="active"><a href="#settings" data-toggle="tab">Sale</a></li>
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
                                                <h3 class="timeline-header"><a href="#">Bill</a></h3>
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label">Bill No.</label>
                                                            <div class="col-sm-3">
                                                                <asp:TextBox runat="server" type="text" Text="" Enabled="true" CssClass="form-control" ID="txtBillNo" placeholder="Date" required="true"></asp:TextBox>
                                                            </div>
                                                            <label for="inputName" class="col-sm-2 control-label">Project Name</label>
                                                            <div class="col-sm-3">
                                                                <asp:TextBox runat="server" type="text" Text="" Enabled="true" CssClass="form-control" ID="txtProject" placeholder="Date" required="true"></asp:TextBox>
                                                            </div>
                                                            <label for="inputName" class="col-sm-2 control-label">Date</label>
                                                            <div class="col-sm-3">
                                                                <asp:TextBox runat="server" type="text" Text="" Enabled="true" CssClass="form-control" ID="txtDate" placeholder="Date" required="true"></asp:TextBox>
                                                            </div>
                                                            <label for="inputName" class="col-sm-1 control-label">Client Name</label>
                                                            <div class="col-sm-5">
                                                                <asp:DropDownList runat="server" type="text" CssClass="form-control" ID="ddlVendorName" required="true"></asp:DropDownList>
                                                            </div>
                                                            <label for="inputName" class="col-sm-2 control-label">Address</label>
                                                            <div class="col-sm-3">
                                                                <asp:TextBox runat="server" type="text" Text="" Enabled="true" CssClass="form-control" ID="txtAddress" placeholder="Date" required="true"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                        <!-- timeline item -->
                                        <li style="display: none;">
                                            <i class="fa fa-user bg-blue"></i>
                                            <div class="timeline-item">
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="box-body">
                                                            <table id="example1" class="table table-bordered table-striped">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Product</th>
                                                                        <th>Box</th>
                                                                        <th>Quantity</th>
                                                                        <th>Price</th>
                                                                        <th>Discount</th>
                                                                        <th>Amount</th>
                                                                        <th>Total</th>
                                                                        <th></th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody runat="server" id="Tbody3">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DropDownList runat="server" type="text" CssClass="form-control" Style="width: 250px;" ID="ddlPrdName" required="true" onchange="CheckDropdown();"></asp:DropDownList></td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="number" CssClass="form-control" ID="txtBox" placeholder="Box" onkeyup="chkValue();boxtoPCs();"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="number" CssClass="form-control" ID="txtQnty" placeholder="Quantity" onkeyup="multiply();chkValue();" onchange="multiply();chkValue();" required="true"></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="amount" CssClass="form-control" ID="txtPrice" onkeyup="multiply();chkValue();" placeholder="Price" required="true"></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="amount" CssClass="form-control" ID="txtDiscount" onkeyup="discount();chkValue();" onchange="discount();chkValue();" placeholder="Disc." required="true"></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" Enabled="false" type="text" CssClass="form-control" ID="txtTotal" placeholder="Amount"></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" Enabled="false" type="text" CssClass="form-control" ID="txtTotalAmount" placeholder="Total"></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:Button runat="server" ID="btnSave" type="submit" class="btn btn-success" Text="Add" /></td>
                                                                    </tr>
                                                                </tbody>

                                                            </table>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                        <!-- END timeline item -->
                                        <li>
                                            <i class="fa fa-user bg-blue"></i>
                                            <div class="timeline-item">
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="box-body">
                                                            <table id="example1" class="table table-bordered table-striped">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Product</th>
                                                                        <th></th>
                                                                        <th>Amount</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody runat="server" id="tblDetails">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="text" Enabled="false" CssClass="form-control" ID="TextBox1"></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="text" Enabled="false" CssClass="form-control" ID="TextBox2"></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="amount" Enabled="false" CssClass="form-control" ID="TextBox3"></asp:TextBox></td>
                                                                        <td></td>

                                                                    </tr>
                                                                </tbody>
                                                                <tfoot>
                                                                    <tr>
                                                                        <th>Product</th>
                                                                        <th></th>
                                                                        <th>Amount</th>
                                                                    </tr>
                                                                    <tr>
                                                                        <th></th>
                                                                        <th>Total Amount</th>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="amount" Enabled="false" CssClass="form-control" ID="TextBox4"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>@%</th>
                                                                        <th>
                                                                            <asp:TextBox runat="server" type="amount" Enabled="false" CssClass="form-control" ID="TextBox6"></asp:TextBox></th>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="amount" Enabled="false" CssClass="form-control" ID="TextBox5"></asp:TextBox></td>
                                                                    </tr>
                                                                </tfoot>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <i class="fa fa-user bg-blue"></i>
                                            <div class="timeline-item">
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="box-body">
                                                            <table id="example1" class="table table-bordered table-striped">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Product</th>
                                                                        <th></th>
                                                                        <th>Amount</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody runat="server" id="Tbody1">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="text" Enabled="true" CssClass="form-control" ID="TextBox7"></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="text" Enabled="true" CssClass="form-control" ID="TextBox8"></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="amount" Enabled="true" CssClass="form-control" ID="TextBox9"></asp:TextBox></td>
                                                                        <td></td>

                                                                    </tr>
                                                                </tbody>
                                                                <tfoot>
                                                                    
                                                                    <tr>
                                                                        <th></th>
                                                                        <th>Total Amount</th>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="amount" Enabled="false" CssClass="form-control" ID="TextBox10"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>@%</th>
                                                                        <th>
                                                                            <asp:TextBox runat="server" type="amount" Enabled="true" CssClass="form-control" ID="TextBox11"></asp:TextBox></th>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="amount" Enabled="false" CssClass="form-control" ID="TextBox12"></asp:TextBox></td>
                                                                    </tr>
                                                                </tfoot>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                         <li>
                                            <i class="fa fa-user bg-blue"></i>
                                            <div class="timeline-item">
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="box-body">
                                                            <table id="example1" class="table table-bordered table-striped">
                                                                <thead>
                                                                    <tr>
                                                                        <th></th>
                                                                        <th>Service Tax@15%</th>                                                                        
                                                                        <th>
                                                                            <asp:TextBox ID="TextBox15" runat="server" CssClass="form-control" Enabled="true" type="amount"></asp:TextBox>
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody runat="server" id="Tbody2">
                                                                </tbody>
                                                                <tfoot>
                                                                    
                                                                    <tr>
                                                                        <th></th>
                                                                        <th>Total Amount</th>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="amount" Enabled="false" CssClass="form-control" ID="TextBox16"></asp:TextBox></td>
                                                                    </tr>                                                                    
                                                                </tfoot>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <i class="fa fa-user bg-blue"></i>
                                            <div class="timeline-item">
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <label for="inputEmail" class="col-sm-2 control-label"></label>
                                                            <div class="col-sm-2">
                                                                <asp:Button runat="server" class="btn btn-warning" ID="btnGenerate" Text="Generate Invoice" />
                                                            </div>
                                                            <div class="col-sm-1">
                                                                <asp:Button runat="server" class="btn btn-danger" ID="btnCancel" Text="Cancel Invoice" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
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

