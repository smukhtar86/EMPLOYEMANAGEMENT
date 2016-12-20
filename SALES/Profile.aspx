<%@ Page Title="" Language="C#" MasterPageFile="~/SALES/MasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="USER_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cphead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>User Profile
          </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">User profile</li>
        </ol>
    </section>

    <!-- Main content -->
    <section class="content">

        <div class="row">
            <div class="col-md-3">

                <!-- Profile Image -->
                <div class="box box-primary">
                    <div class="box-body box-profile" runat="server" id="divProfile">
                        <img class="profile-user-img img-responsive img-circle" src="../../dist/img/user4-128x128.jpg" alt="User profile picture">
                        <h3 class="profile-username text-center">Nina Mcintire</h3>
                        <p class="text-muted text-center">Software Engineer</p>

                        <ul class="list-group list-group-unbordered">
                            <li class="list-group-item">
                                <b>Followers</b> <a class="pull-right">1,322</a>
                            </li>
                            <li class="list-group-item">
                                <b>Following</b> <a class="pull-right">543</a>
                            </li>
                            <li class="list-group-item">
                                <b>Friends</b> <a class="pull-right">13,287</a>
                            </li>
                        </ul>

                        <a href="#" class="btn btn-primary btn-block"><b>Follow</b></a>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->

                <!-- About Me Box -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">About Me</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <strong><i class="fa fa-book margin-r-5"></i>Education</strong>
                        <p class="text-muted">
                            B.S. in Computer Science from the University of Tennessee at Knoxville
                 
                        </p>
                        <hr>
                        <strong><i class="fa fa-map-marker margin-r-5"></i>Location</strong>
                        <p class="text-muted">Malibu, California</p>
                        <hr>
                        <strong><i class="fa fa-pencil margin-r-5"></i>Skills</strong>
                        <p>
                            <span class="label label-danger">UI Design</span>
                            <span class="label label-success">Coding</span>
                            <span class="label label-info">Javascript</span>
                            <span class="label label-warning">PHP</span>
                            <span class="label label-primary">Node.js</span>
                        </p>
                        <hr>
                        <strong><i class="fa fa-file-text-o margin-r-5"></i>Notes</strong>
                        <p>.</p>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
            <!-- /.col -->
            <div class="col-md-9">


                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>

                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#settings" data-toggle="tab">Settings</a></li>
                                <li><a href="#timeline" data-toggle="tab">Activity</a></li>
                            </ul>
                            <div class="tab-content">
                                <!-- /.tab-pane -->
                                <div class="tab-pane" id="timeline">
                                    <!-- The timeline -->
                                    <ul class="timeline timeline-inverse">
                                        <!-- timeline time label -->
                                        <li class="time-label">
                                            <span class="bg-red">10 Feb. 2014
                        </span>
                                        </li>
                                        <!-- /.timeline-label -->
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-envelope bg-blue"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>12:05</span>
                                                <h3 class="timeline-header"><a href="#">Support Team</a> sent you an email</h3>
                                                <div class="timeline-body">
                                                    Etsy doostang zoodles disqus groupon greplin oooj voxy zoodles,
                            weebly ning heekya handango imeem plugg dopplr jibjab, movity
                            jajah plickers sifteo edmodo ifttt zimbra. Babblely odeo kaboodle
                            quora plaxo ideeli hulu weebly balihoo...
                         
                                                </div>
                                                <div class="timeline-footer">
                                                    <a class="btn btn-primary btn-xs">Read more</a>
                                                    <a class="btn btn-danger btn-xs">Delete</a>
                                                </div>
                                            </div>
                                        </li>
                                        <!-- END timeline item -->
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-user bg-aqua"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>5 mins ago</span>
                                                <h3 class="timeline-header no-border"><a href="#">Sarah Young</a> accepted your friend request</h3>
                                            </div>
                                        </li>
                                        <!-- END timeline item -->
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-comments bg-yellow"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>27 mins ago</span>
                                                <h3 class="timeline-header"><a href="#">Jay White</a> commented on your post</h3>
                                                <div class="timeline-body">
                                                    Take me to your leader!
                            Switzerland is small and neutral!
                            We are more like Germany, ambitious and misunderstood!
                         
                                                </div>
                                                <div class="timeline-footer">
                                                    <a class="btn btn-warning btn-flat btn-xs">View comment</a>
                                                </div>
                                            </div>
                                        </li>
                                        <!-- END timeline item -->
                                        <!-- timeline time label -->
                                        <li class="time-label">
                                            <span class="bg-green">3 Jan. 2014
                        </span>
                                        </li>
                                        <!-- /.timeline-label -->
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-camera bg-purple"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>2 days ago</span>
                                                <h3 class="timeline-header"><a href="#">Mina Lee</a> uploaded new photos</h3>
                                                <div class="timeline-body">
                                                    <img src="../Template/dist/img/user4-128x128.jpg" alt="..." class="margin">
                                                    <img src="../Template/dist/img/user4-128x128.jpg" alt="..." class="margin">
                                                    <img src="../Template/dist/img/user4-128x128.jpg" alt="..." class="margin">
                                                    <img src="../Template/dist/img/user4-128x128.jpg" alt="..." class="margin">
                                                </div>
                                            </div>
                                        </li>
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-archive bg-purple"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>2 days ago</span>
                                                <h3 class="timeline-header"><a href="#">Mina Lee</a> uploaded new photos</h3>
                                                <div class="timeline-body">
                                                    <img src="../Template/dist/img/user4-128x128.jpg" alt="..." class="margin">
                                                    <img src="../Template/dist/img/user4-128x128.jpg" alt="..." class="margin">
                                                    <img src="../Template/dist/img/user4-128x128.jpg" alt="..." class="margin">
                                                    <img src="../Template/dist/img/user4-128x128.jpg" alt="..." class="margin">
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
                                            <i class="fa fa-user bg-blue"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>12:05</span>
                                                <h3 class="timeline-header"><a href="#">Personal Information</a></h3>
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label">Name</label>
                                                            <div class="col-sm-10">
                                                                <asp:TextBox runat="server" type="text" CssClass="form-control" ID="txtName" placeholder="Name"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="inputEmail" class="col-sm-2 control-label">Email</label>
                                                            <div class="col-sm-10">
                                                                <asp:TextBox runat="server" type="email" CssClass="form-control" ID="txtEmail" placeholder="Email"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label">Mobile No.</label>
                                                            <div class="col-sm-10">
                                                                <asp:TextBox runat="server" type="number" CssClass="form-control" ID="txtMobile" placeholder="Mobile"></asp:TextBox>
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
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-map-marker bg-red"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>5 mins ago</span>
                                                <h3 class="timeline-header no-border"><a href="#">Address</a></h3>
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <label for="inputExperience" class="col-sm-2 control-label">Address</label>
                                                            <div class="col-sm-10">
                                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtAddress" placeholder="Address"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="form-group">
                                                            <div class="col-sm-offset-2 col-sm-10">
                                                                <asp:Button runat="server" ID="btnSaveAddress" type="submit" class="btn btn-danger" Text="Save" OnClick="btnProfilePhoto_Click" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </li>
                                        <!-- END timeline item -->
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-calendar bg-red"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>5 mins ago</span>
                                                <h3 class="timeline-header no-border"><a href="#">Date of Birth</a></h3>
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label">DOB</label>
                                                            <div class="col-sm-10">
                                                                <asp:TextBox runat="server" type="date" class="form-control" ID="txtDOB" placeholder="Date of Birth"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-offset-2 col-sm-10">
                                                                <asp:Button runat="server" ID="btnSaveDOB" type="submit" class="btn btn-danger" Text="Save" OnClick="btnProfilePhoto_Click" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </li>
                                        <!-- END timeline item -->
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-book bg-blue"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>5 mins ago</span>
                                                <h3 class="timeline-header no-border"><a href="#">Education</a></h3>
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label">Education</label>
                                                            <div class="col-sm-10">
                                                                <asp:TextBox runat="server" type="text" class="form-control" ID="txtEducation" placeholder="Education"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-offset-2 col-sm-10">
                                                                <asp:Button runat="server" ID="Button2" type="submit" class="btn btn-danger" Text="Save" OnClick="btnProfilePhoto_Click" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </li>
                                        <!-- END timeline item -->
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-camera bg-aqua"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>5 mins ago</span>
                                                <h3 class="timeline-header no-border"><a href="#">Profile Photo</a> Upload</h3>
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label"></label>
                                                            <div class="col-sm-10">
                                                                <img src="DOCS/PHOTO/default.jpg" alt="..." class="margin">
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="inputEmail" class="col-sm-2 control-label"></label>
                                                            <div class="col-sm-10">
                                                                <asp:FileUpload runat="server" ID="fuProfile" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-offset-2 col-sm-10">
                                                                <asp:Button runat="server" ID="btnProfilePhoto" type="submit" class="btn btn-danger" Text="Save" OnClick="btnProfilePhoto_Click" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </li>
                                        <!-- END timeline item -->
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-camera bg-aqua"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>5 mins ago</span>
                                                <h3 class="timeline-header no-border"><a href="#">PANCARD</a> Upload</h3>
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label">PANCARD</label>
                                                            <div class="col-sm-10">
                                                                <input type="text" class="form-control" id="txtPancard" placeholder="Name">
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label"></label>
                                                            <div class="col-sm-10">
                                                                <img src="DOCS/PAN/default.jpg" alt="..." class="margin">
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="inputEmail" class="col-sm-2 control-label"></label>
                                                            <div class="col-sm-10">
                                                                <asp:FileUpload runat="server" ID="FileUpload1" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-offset-2 col-sm-10">
                                                                <asp:Button runat="server" ID="Button1" type="submit" class="btn btn-danger" Text="Save" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                        <!-- END timeline item -->
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-camera bg-aqua"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>5 mins ago</span>
                                                <h3 class="timeline-header no-border"><a href="#">Voter Id</a> Upload</h3>
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label">Voter ID</label>
                                                            <div class="col-sm-10">
                                                                <input type="text" class="form-control" id="txtVoterID" placeholder="Name">
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label"></label>
                                                            <div class="col-sm-10">
                                                                <img src="DOCS/VOTERID/default.jpg" alt="..." class="margin">
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="inputEmail" class="col-sm-2 control-label"></label>
                                                            <div class="col-sm-10">
                                                                <asp:FileUpload runat="server" ID="FileUpload2" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-offset-2 col-sm-10">
                                                                <asp:Button runat="server" ID="Button3" type="submit" class="btn btn-danger" Text="Save" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                        <!-- END timeline item -->
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-camera bg-aqua"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>5 mins ago</span>
                                                <h3 class="timeline-header no-border"><a href="#">Driving License</a> Upload</h3>
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label">DL</label>
                                                            <div class="col-sm-10">
                                                                <input type="text" class="form-control" id="txtDL" placeholder="Name">
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label"></label>
                                                            <div class="col-sm-10">
                                                                <img src="DOCS/DL/default.jpg" alt="..." class="margin">
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="inputEmail" class="col-sm-2 control-label"></label>
                                                            <div class="col-sm-10">
                                                                <asp:FileUpload runat="server" ID="FileUpload3" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-offset-2 col-sm-10">
                                                                <asp:Button runat="server" ID="Button4" type="submit" class="btn btn-danger" Text="Save" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                        <!-- END timeline item -->
                                        <!-- timeline item -->
                                        <li>
                                            <i class="fa fa-camera bg-aqua"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>5 mins ago</span>
                                                <h3 class="timeline-header no-border"><a href="#">AADHAR Card</a> Upload</h3>
                                                <div class="timeline-body">
                                                    <div class="form-horizontal">
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label">AADHAR CODE</label>
                                                            <div class="col-sm-10">
                                                                <input type="text" class="form-control" id="txtAADHAR" placeholder="Name">
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="inputName" class="col-sm-2 control-label"></label>
                                                            <div class="col-sm-10">
                                                                <img src="DOCS/AADHAR/default.jpg" alt="..." class="margin">
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="inputEmail" class="col-sm-2 control-label"></label>
                                                            <div class="col-sm-10">
                                                                <asp:FileUpload runat="server" ID="FileUpload4" />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-offset-2 col-sm-10">
                                                                <asp:Button runat="server" ID="Button5" type="submit" class="btn btn-danger" Text="Save" />
                                                            </div>
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
                        <asp:PostBackTrigger ControlID="btnProfilePhoto" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->

    </section>
    <!-- /.content -->

</asp:Content>

