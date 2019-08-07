<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="JqueryHandler.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.3.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Content/bootstrap.min.css"/>
    <script type="text/javascript">
        $(document.body).ready(function () {
            $('#txtFname').focus();
            

        })

        jQuery(function () {
            

            $('#btnAdd').click(function () {
                var obj = {};
                obj.std_fname = $('#txtFname').val();
                obj.std_lname = $('#txtLname').val();
                obj.std_class = $('#txtClass').val();
                var jsonData = JSON.stringify(obj);

                if ((obj.std_fname != null || obj.std_fname != '') && (obj.std_lname != null || obj.std_lname != '') && (obj.std_sclass != null || obj.std_sclass != '')) {
                   
                    $.ajax({

                        url:'Handler.ashx/AddStudent',
                        method:'post',
                        data:jsonData,
                        success: function (data) {
                            var body = $('body');
                            $(data).each(function(index, std) {
                                body.append('<p>' + std.std_id + std.std_Fname + std.std_Lname + std.std_class + '</p');
                            })
                        },
                        error: function () {

                        }




                    });

                    
                }


            })

        })



    </script>
</head>
<body class="bg-light">
    <form id="form1" runat="server" class="my-100 text-center  align-self-center">
        <div class="row">
            <div class="col">
                <div class="row mt-50 my-20 py-20">
                    <div class="col px-20 my-20">
                                <input type="hidden" id="hidden"/>
                                <div class="form-group pt-10">
                                    <input type="text" class="form-control" placeholder="First Name" id="txtFname"/>
                                </div>
                                <div class="form-group">
                                    <input type="text" class="form-control" placeholder="Last Name" id="txtLname" />
                                </div>
                                <div class="form-group">
                                     <input type="text" class="form-control" placeholder="Class" id="txtClass"/>
                                </div>
                             <asp:Button id="btnAdd" runat="server" OnClientClick="return false;" CssClass="btn btn-success" Text="Add"/>
                   </div>
                 
               </div>
           </div>
      </div>
    </form>
</body>
</html>
