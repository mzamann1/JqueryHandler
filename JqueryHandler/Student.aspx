                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="JqueryHandler.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.3.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />


    <script type="text/javascript">
        var page;
        var results;
        function dataBind(data) {
            var bdy = $('table tbody');
            bdy.empty();
            
            $(data).each(function (index, std) {
                var view = '';
                if (std.guardians.length == 0) {
                    view = "<button id='addGuardian'  class='btn btn-success px-4' value=" + std.std_id + "  onclick='add_guardian(" + std.std_id + ");return false;' >Add Guardian</button>";
                }
                else {
                    var str=JSON.stringify(std.guardians);
                    view = "<button id='viewGuardian' class='btn btn-success px-4 ' value=" + std.std_id + "  onclick='view_guardian(" + str + ");return false;' >View Guardian</button>";
                }
                
                
                
                var dlt = "<button id='dltstd' class='btn btn-danger' value=" + std.std_id + "  onclick='delete_student(" + std.std_id + ");return false;' >Delete</button>";
                var upd = "<button id='updstd' class='btn btn-dark text-white' value=" + std.std_id + "  onclick='update_student(" + std.std_id + ");return false;' >Update</button>";
                bdy.append("<tr><td>" + std.std_id + "</td><td>" + std.std_Fname + "</td><td>" + std.std_Lname + "</td><td>" + std.std_class + "</td><td>" + view + "</td><td>" + dlt + "</td><td>" + upd + "</td></tr>");
                std.guardians = '';
            });
        }
        function searchUrl() {
               


            
                let searchParams = new URLSearchParams(window.location.search);
                if (searchParams.has('page') && searchParams.has('rpp')) {
                    var npage = searchParams.get('page');
                    page = parseInt(npage, 10)
                    var nrpp = searchParams.get('rpp');
                    results = parseInt(nrpp, 10)
                

            }
        }
        function form_valid() {
            var obj = {};

            obj.g_Fname = $('#txtFname').val();
            obj.g_Lname = $('#txtLname').val();
            obj.g_Address = $('#txtClass').val();
            obj.std_id = $('.modal-body input#ID').val;

           

            if ((obj.g_Fname != null || obj.g_Fname != '') && (obj.g_Lname != null || obj.g_Lname != '') && (obj.g_Address != null || obj.g_Address != '') && (obj.std_id != null || obj.std_id != '')) {
                if (obj.std_id == '' || obj.std_id == null) {
                    obj.std_id = 0;
                }
                var jsonData = JSON.stringify(obj);
                $.ajax({

                    url: 'Handler.ashx/AddGuardian',
                    method: 'post',
                    data: jsonData,
                    success: function (data) {
                        alert("Success");
                    },
                    error: function (e) {
                        alert("error :" + e);
                    }




                });


            }
        }
        function ajaxWork(page, results) {

            window.history.pushState('Page', 'Title', '/Student.aspx?page=' + page + '&rpp=' + results);
            $.ajax({
                method: "get",
                dataType: "json",
                url: "Handler.ashx/ViewStudents?",
                data: "page=" + page + "&rpp=" + results,
                success: function (data) {
                    dataBind(data);
                },
                error: function (err) {
                    alert("error" + err);
                }


            });

        }
        function add_guardian(data) {
            var body = $('.modal-content > .modal-body');
            body.empty();
            body.load('/AddStudent.aspx');
            $('.modal-content > .modal-header > .modal-title').text('Add Guardian Information');
            $(".modal-body > input[id='txtClass']").attr("placeholder", "Address");
            $('.modal-footer').empty();
            $('.modal-header input#ID').val(data);
            
            $('.modal-footer').append("<button type='button' class='btn btn-success' onclick='form_valid();return false;' >Add</button>");
               
            //var val= $(this).attr('value');
           // $('.modal-title').text('Add Guardian  ' + data);
            $('#myModal').modal('show');

        }
        function view_guardian(data) {
            var head = $('.modal-content > .modal-header  > .modal-title');
            head.text('Guardian Information');
            var body = $('.modal-content > .modal-body');
            body.empty();
            $(data).each(function (index, g) {

                
                var inp = "<table class='table table-bordered table-striped'><thead><tr><th>ID</th><th>First Name</th><th>Last Name</th><th>Address</th></tr></thead><tbody><tr><td>" + g.id + "</td><td>" + g.g_Fname + "</td><td>" + g.g_Lname + "</td><td>" + g.g_Address + "</td></tr></tbody></table>";

                body.append(inp);

                var foot = $(".modal-content > .modal-footer");
                foot.empty();

            });
            //$('.modal-title').text('View Guardian   ' + data + val);
            $('#myModal').modal('show');

        }
        function dataWork(id, key) {
            if (key == 1) {
                $.ajax({
                    method: 'get',
                    url: 'Handler.ashx/DeleteStd?',
                    data: 'id=' + id,
                    success: function () {
                        searchUrl();
                        ajaxWork(page, results);
                        },
                    error: function () {
                        alert('error');
                    }

                })
            }
            if (key == 2) {

            }
        }
        function delete_student(data) {

            var body = $('.modal-body');
            var footer = $('.modal-footer');
            footer.empty();
            body.text('Confirm Delete?');
            footer.append("<button class='btn btn-danger btn-pill' id='btnModalDlt' data-dismiss='modal' onclick='dataWork("+data+","+1+");return false;'>Delete</button>")

            
            $('#btnModalFooterYes').text("Delete");
            $('.modal-title').text('Delete');
            $('.modal-header input#ID').val(data);
            $('#myModal').modal('show');
            

        
           
        }

        function update_student(data) {
            var body = $('.modal-body');
            var footer = $('.modal-footer');
            footer.empty();
            $('#myModal').modal('show');
        }


            $(document).ready(function () {
                jQuery(function () {
                    var page, results;
                    let searchParams = new URLSearchParams(window.location.search);
                    if (searchParams.has('page') && searchParams.has('rpp')) {
                        var inp = searchParams.get('page');
                        var inp2 = searchParams.get('rpp');


                        if (inp != null && inp2 != null) {
                            inp = parseInt(inp, 10);
                            inp2 = parseInt(inp2, 10)
                            if ((Number.isInteger(inp)) && (Number.isInteger(inp2))) {
                                page = inp;
                                results = inp2;
                            }
                            else {
                                page = 1;
                                results = 10
                            }
                        }
                    }
                    else {
                        page = 1;
                        results = 10;
                    }

                    ajaxWork(page, results);


                });

            });


            jQuery(function () {
                
                var page;
                var results;


                function GetUrl() {
                    let searchParams = new URLSearchParams(window.location.search);
                    if (searchParams.has('page') && searchParams.has('rpp')) {
                        var npage = searchParams.get('page');
                        page = parseInt(npage, 10)
                        var nrpp = searchParams.get('rpp');
                        results = parseInt(nrpp, 10)
                    }

                }

                $('#drpdown').change(function () {
                    GetUrl();
                    results = $('#drpdown').find(':selected').val();
                    ajaxWork(page, results);
                });

                $("#btnNext").click(function () {
                    GetUrl();

                    page++;
                    ajaxWork(page, results);

                });

                $('#btnPrev').click(function () {

                    GetUrl();
                    if (page > 1) {
                        --page;
                    }

                    ajaxWork(page, results);
                })

                $('#btnFirst').click(function () {
                    page = 1;

                    ajaxWork(page, results);


                })

                $('#btnLast').click(function () {
                    page = 50;
                    ajaxWork(page, results);

                })

                $('#addstd').click(function () {

                    $('.modal-body').load('/AddStudent.aspx');
                    $('.modal-title').text('New Student');
                    $('#myModal').modal('show');



                })

                

                
            });





           


    </script>

</head>



<body class="container">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col col-4 bg-white">
                <div class="row my-50 py-50">
                    <div class="col">
                        <label class="my-50 py-50">Select Results Per Page</label>
                        <select id="drpdown">
                            <option id="10" value="10">10</option>
                            <option id="20" value="20">20</option>
                            <option id="30" value="30">30</option>
                        </select>

                    </div>

                </div>
                <div class="row my-50 py-20">
                    <div class="col">


                        <button class="btn btn-success mt-50 pt-50" onclick="return false;" id="addstd">Add Student</button>

                    </div>
                </div>
            </div>



            <div class="col col-8">
                <table class="table table-bordered table-striped">
                    <thead class="badge-primary text-capitalize text-white">
                        <tr>
                            <th>Student ID</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Class</th>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>

                <p>
                    <asp:Button ID="btnFirst" runat="server" Text="First" OnClientClick="return false;" CssClass="btn btn-dark text-white" />
                    <asp:Button ID="btnPrev" runat="server" Text="Prev" OnClientClick="return false;" CssClass="btn btn-dark text-white" />
                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClientClick="return false;" CssClass="btn btn-dark text-white" />
                    <asp:Button ID="btnLast" runat="server" Text="Last" OnClientClick="return false;" CssClass="btn btn-dark text-white" />
                </p>
            </div>

        </div>



        <div class="col col-8">

            <div>
                <div class="modal fade" id="myModal">
                    <div class="modal-dialog">
                        <div class="modal-content">

                            <!-- Modal Header -->
                            <div class="modal-header">
                                <h4 class="modal-title">Modal Heading</h4>
                                <input type="hidden" id="ID"/>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>

                            <!-- Modal body -->
                            <div class="modal-body">
                            </div>

                            <!-- Modal footer -->
                            <div class="modal-footer">
                               
                                
                            </div>

                        </div>
                    </div>
                </div>
            </div>








        </div>
    </form>

</body>
</html>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              