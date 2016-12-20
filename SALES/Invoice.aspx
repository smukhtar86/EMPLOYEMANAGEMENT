<%@ Page Title="" Language="C#" MasterPageFile="~/SALES/MasterPage.master" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="USER_Invoice" %>

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
        function multiply() {
            var textValue1 = document.getElementById('<%= txtQnty.ClientID %>').value;
            var textValue2 = document.getElementById('<%= txtPrice.ClientID %>').value;
            document.getElementById('<%= txtTotal.ClientID %>').value = textValue1 * textValue2;
        }
        function discount() {
            var textValue1 = document.getElementById('<%= txtTotal.ClientID %>').value;
             var textValue2 = document.getElementById('<%= txtDiscount.ClientID %>').value;
             document.getElementById('<%= txtTotalAmount.ClientID %>').value = textValue1 - textValue2;
         }
        function chkValue() {
            var textValue1 = document.getElementById('<%= txtQnty.ClientID %>').value;
            if (textValue1 < 0)
                document.getElementById('<%= txtQnty.ClientID %>').value = "";
            var textValue2 = document.getElementById('<%= txtPrice.ClientID %>').value;
            if (textValue2 < 0)
                document.getElementById('<%= txtPrice.ClientID %>').value = "";
            var textValue2 = document.getElementById('<%= txtBox.ClientID %>').value;
            if (textValue2 < 0)
                document.getElementById('<%= txtBox.ClientID %>').value = "";
        }
        function CheckDropdown() {
            var e = document.getElementById('<%= ddlPrdName.ClientID %>');
            var prd = e.options[e.selectedIndex].text.split("-");
            document.getElementById('<%=txtPrice.ClientID %>').value = prd[1];
            // alert(txtPrice.text);
        }
        function boxtoPCs() {
            var e = document.getElementById('<%= ddlPrdName.ClientID %>');
            var prd = e.options[e.selectedIndex].text.split("-");
            var textValue1 = document.getElementById('<%= txtBox.ClientID %>').value;
            document.getElementById('<%= txtQnty.ClientID %>').value = prd[2] * textValue1;
            multiply();
        }
    </script>
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
                                                <h3 class="timeline-header"><a href="#">Invoice</a></h3>
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label">Date</label>
                                                            <div class="col-sm-3">
                                                                <asp:TextBox runat="server" type="text" Text='<%= DateTime.Now.ToString("dd-MMM-yyyy") %>' Enabled="false" CssClass="form-control" ID="txtDate" placeholder="Date" required="true"></asp:TextBox>
                                                            </div>
                                                            <label for="inputName" class="col-sm-1 control-label">Name</label>
                                                            <div class="col-sm-5">
                                                                <asp:DropDownList runat="server" type="text" CssClass="form-control" ID="ddlVendorName" required="true" OnSelectedIndexChanged="ddlVendorName_SelectedIndexChanged"></asp:DropDownList>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                        <!-- timeline item -->
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
                                                                            <asp:DropDownList runat="server" type="text" CssClass="form-control" style="width:250px;" ID="ddlPrdName" required="true" onchange="CheckDropdown();"></asp:DropDownList></td>
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
                                                                            <asp:Button runat="server" ID="btnSave" type="submit" class="btn btn-success" Text="Add" OnClick="btnSave_Click" /></td>
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
                                                                        <th>Sl. No.</th>
                                                                        <th>Product</th>
                                                                        <th>Quantity</th>
                                                                        <th>Price</th>
                                                                        <th>Discount</th>
                                                                        <th>Amount</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody runat="server" id="tblDetails">
                                                                    <tr>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                </tbody>                                                               
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
                                                            <table id="example2" class="table table-bordered table-striped">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Amount</th>
                                                                        <th>VAT</th>
                                                                        <th>Discount</th>
                                                                        <th>Total Amount</th>

                                                                    </tr>
                                                                </thead>
                                                                <tbody runat="server" id="Tbody2">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="amount" Enabled="false" CssClass="form-control" ID="txtAmountFooter"></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="amount" Enabled="false" CssClass="form-control" ID="txtVatFooter"></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" type="amount" Enabled="false" CssClass="form-control" ID="txtDiscountFooter"></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" Enabled="false" type="text" CssClass="form-control" ID="txtTotalAmountFooter"></asp:TextBox></td>
                                                                        <td></td>

                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>

                                                        <div class="form-group">
                                                            <label for="inputEmail" class="col-sm-2 control-label">Remarks</label>
                                                            <div class="col-sm-9">
                                                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="txtRemark" placeholder="Remark"></asp:TextBox>
                                                            </div>
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
                                                                <asp:Button runat="server" class="btn btn-warning" ID="btnGenerate" Text="Generate Invoice" OnClick="btnGenerate_Click" />
                                                            </div>
                                                            <div class="col-sm-1">
                                                                <asp:Button runat="server" class="btn btn-danger" ID="btnCancel" Text="Cancel Invoice" OnClick="btnCancel_Click" />
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

