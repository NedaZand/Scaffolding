
function AddFunction(url, type = 'Get', dataType = 'html') {
    $.ajax({
        url: url,
        type: type,
        dataType: dataType,
        success: function (data) {
            bootbox.dialog({
                message: data,
                size: "large"
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }

    });
}


function EditFunction(url, id, type = 'Get', dataType = 'html') {
    $.ajax({
        url: url,
        type: type,
        dataType: dataType,
        data: { id: id },
        success: function (data) {
            bootbox.dialog({
                message: data,
                size: "large"
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }

    });
}

function bootboxHideAll() {
    bootbox.hideAll();
}

function addCompanySuccess(data) {

    $("#CompanyId").select2('destroy');
    $.ajax({
        url: '/Company/GetAllCompany',
        type: "Get",
        dataType: "Json",
        success: function (data) {

            $("#CompanyId").html('');

            $.each(data, function (i, company) {

                $("#CompanyId").append('<option value="'

                    + company.Value + '">'

                    + company.Text + '</option>');

            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }

    });

    $("#CompanyId").select2();
    addSuccess(data);
}
function addSuccessScaffolding(data) {

    if (data.ResultType == 0) {
     
    
        //bootboxHideAll();
        //jQuery("span[id*='remove']").trigger("click");
        //jQuery(".qq-upload-list").empty();
        //jQuery(".qq-upload-size").empty();
        $(".alert-success").hide();
        $('.alert-success b').html();
        $('.alert-success b').html(data.Message);
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-success").fadeToggle(350);


        $("#result").html('');
        $.ajax({
            url: '/scaffolding/CreateForm',
            data: { scaffoldingId: data.EntityId },
            type: 'Post',

            dataType: "html",
            success: function (data) {
                //$('html,body').animate({
                //    scrollTop: ("#wrapper").offset().top
                //},'slow');
                $('a[href="#section-bar-2"]').click();
                $("#result").html(data).slideDown('slow');;

            }


        });



    }
    else if (data.ResultType == 1) {

   
        $('.alert-danger b').html();
        $('.alert-danger b').html(data.Message);
        $('.alert-success').hide();
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-danger").fadeToggle(350);



    }
    else {
        window.open(data.Message, '_blank');
        //window.location = data.Message;
    }
}
function addSuccessScaffoldType(data) {


    $("#ScaffoldTypeId").select2('destroy');
    $.ajax({
        url: '/ScaffoldType/GetAllScaffoldType',
        type: "Get",
        dataType: "Json",
        success: function (data) {

            $("#ScaffoldTypeId").html('');

            $.each(data, function (i, scaffoldType) {

                $("#ScaffoldTypeId").append('<option value="'

                    + scaffoldType.Value + '">'

                    + scaffoldType.Text + '</option>');

            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }

    });

    if (data.ResultType == 0) {

     
        $(".alert-success").hide();
        $('.alert-success b').html();
        $('.alert-success b').html(data.Message);
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-success").fadeToggle(350);
        $('.table-responsive table').DataTable().ajax.reload();




    }
    else if (data.ResultType == 1) {

        bootboxHideAll();
        //jQuery(".qq-upload-size").empty();
        $('.alert-danger b').html();
        $('.alert-danger b').html(data.Message);
        $('.alert-success').hide();
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-danger").fadeToggle(350);



    }


    //$("#ScaffoldTypeId").select2();
}

function addSuccessEarth(data) {


    $("#EarthId").select2('destroy');
    $.ajax({
        url: '/Earth/GetAllEarth',
        type: "Get",
        dataType: "Json",
        success: function (data) {

            $("#EarthId").html('');

            $.each(data, function (i, earth) {

                $("#EarthId").append('<option value="'

                    + earth.Value + '">'

                    + earth.Text + '</option>');

            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }

    });

    if (data.ResultType == 0) {

     
        $(".alert-success").hide();
        $('.alert-success b').html();
        $('.alert-success b').html(data.Message);
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-success").fadeToggle(350);
        $('.table-responsive table').DataTable().ajax.reload();




    }
    else if (data.ResultType == 1) {

        bootboxHideAll();
        //jQuery(".qq-upload-size").empty();
        $('.alert-danger b').html();
        $('.alert-danger b').html(data.Message);
        $('.alert-success').hide();
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-danger").fadeToggle(350);



    }

    //$("#EarthId").select2();
}

function addSuccessEmployeeType(data) {

    $("#EmployeeId").select2('destroy');
    $.ajax({
        url: '/EmployeeType/GetAllEmployeeType',
        type: "Get",
        dataType: "Json",
        success: function (data) {

            $("#EmployeeId").html('');

            $.each(data, function (i, building) {

                $("#EmployeeId").append('<option value="'

                    + building.Value + '">'

                    + building.Text + '</option>');

            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }

    });

    if (data.ResultType == 0) {


        $(".alert-success").hide();
        $('.alert-success b').html();
        $('.alert-success b').html(data.Message);
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-success").fadeToggle(350);
        $('.table-responsive table').DataTable().ajax.reload();




    }
    else if (data.ResultType == 1) {

        bootboxHideAll();
        //jQuery(".qq-upload-size").empty();
        $('.alert-danger b').html();
        $('.alert-danger b').html(data.Message);
        $('.alert-success').hide();
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-danger").fadeToggle(350);



    }
    $("#EmployeeId").select2();
}

function addSuccessPositionType(data) {

    $("#PositionId").select2('destroy');
    $.ajax({
        url: '/PositionType/GetAllPositionType',
        type: "Get",
        dataType: "Json",
        success: function (data) {

            $("#PositionId").html('');

            $.each(data, function (i, building) {

                $("#PositionId").append('<option value="'

                    + building.Value + '">'

                    + building.Text + '</option>');

            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }

    });

    if (data.ResultType == 0) {


        $(".alert-success").hide();
        $('.alert-success b').html();
        $('.alert-success b').html(data.Message);
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-success").fadeToggle(350);
        $('.table-responsive table').DataTable().ajax.reload();




    }
    else if (data.ResultType == 1) {

        bootboxHideAll();
        //jQuery(".qq-upload-size").empty();
        $('.alert-danger b').html();
        $('.alert-danger b').html(data.Message);
        $('.alert-success').hide();
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-danger").fadeToggle(350);



    }
    $("#PositionId").select2();
}

function addSuccessWorkgroup(data) {

    $("#WorkgroupId").select2('destroy');

    $.ajax({
        url: '/WorkingGroup/GetAllWorkingGroup',
        type: "Get",
        dataType: "Json",
        success: function (data) {

            $("#WorkgroupId").html('');

            $.each(data, function (i, building) {

                $("#WorkgroupId").append('<option value="'

                    + building.Value + '">'

                    + building.Text + '</option>');

            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }

    });

    if (data.ResultType == 0) {


        $(".alert-success").hide();
        $('.alert-success b').html();
        $('.alert-success b').html(data.Message);
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-success").fadeToggle(350);
        $('.table-responsive table').DataTable().ajax.reload();




    }
    else if (data.ResultType == 1) {

        bootboxHideAll();
        //jQuery(".qq-upload-size").empty();
        $('.alert-danger b').html();
        $('.alert-danger b').html(data.Message);
        $('.alert-success').hide();
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-danger").fadeToggle(350);



    }
    $("#WorkgroupId").select2();
}


function addSuccessBuilding(data) {

    $("#BuildingId").select2('destroy');

    $.ajax({
        url: '/Building/GetAllBuilding',
        type: "Get",
        dataType: "Json",
        success: function (data) {

            $("#BuildingId").html('');

            $.each(data, function (i, building) {

                $("#BuildingId").append('<option value="'

                    + building.Value + '">'

                    + building.Text + '</option>');

            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }

    });

    if (data.ResultType == 0) {

   
        $(".alert-success").hide();
        $('.alert-success b').html();
        $('.alert-success b').html(data.Message);
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-success").fadeToggle(350);
        $('.table-responsive table').DataTable().ajax.reload();




    }
    else if (data.ResultType == 1) {

        bootboxHideAll();
        //jQuery(".qq-upload-size").empty();
        $('.alert-danger b').html();
        $('.alert-danger b').html(data.Message);
        $('.alert-success').hide();
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-danger").fadeToggle(350);



    }

    //$("#BuildingId").select2();
}
function addSuccess(data) {
    //$("html, body").animate({ scrollTop: 0 }, "slow");
   
    if (data.ResultType == 0) {
      
        ResetForm();
        //bootboxHideAll();
        //jQuery("span[id*='remove']").trigger("click");
        //jQuery(".qq-upload-list").empty();
        //jQuery(".qq-upload-size").empty();
        $(".alert-success").hide();
        $('.alert-success b').html();
        $('.alert-success b').html(data.Message);
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-success").fadeToggle(350);
        $('.table-responsive table').DataTable().ajax.reload();

       
   

    }
    else if (data.ResultType == 1) {
       
        bootboxHideAll();
        //jQuery(".qq-upload-size").empty();
        $('.alert-danger b').html();
        $('.alert-danger b').html(data.Message);
        $('.alert-success').hide();
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-danger").fadeToggle(350);



    }
    else
    {
        window.location = data.Message;
    }
}

function editSuccess(data) {
    //$("html, body").animate({ scrollTop: 0 }, "slow");

    if (data.ResultType == 0) {
     
        bootboxHideAll();
        //jQuery("span[id*='remove']").trigger("click");
        //jQuery(".qq-upload-list").empty();
        //jQuery(".qq-upload-size").empty();
        $(".alert-success").hide();
        $('.alert-success b').html();
        $('.alert-success b').html(data.Message);
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $(".alert-success").fadeToggle(350);
        $('.table-responsive table').DataTable().ajax.reload();


    }
    else if (data.ResultType == 1) {

        //bootboxHideAll();
        //jQuery(".qq-upload-size").empty();
        $('.alert-danger b').html();
        $('.alert-danger b').html(data.Message);
        $('.alert-success').hide();
        $('.alert-warning').hide();
        $('.alert-danger').hide();
        $(".alert-danger").fadeToggle(350);



    }

}

function addSuccessWorkorder(data) {
    //$("html, body").animate({ scrollTop: 0 }, "slow");

    if (data.ResultType == 0) {

        
        bootboxHideAll();

        ResetForm();
        //jQuery("span[id*='remove']").trigger("click");
        //jQuery(".qq-upload-list").empty();
        //jQuery(".qq-upload-size").empty();
        $(".alert-success").hide();
        $('.alert-success b').html();
        $('.alert-success b').html(data.Message);
        $('.alert-danger').hide();
        $('.alert-warning').hide();
        $('.alert-success').hide();
        $(".alert-success").fadeToggle(350);
        $('.table-responsive table').DataTable().ajax.reload();


    }
    else if (data.ResultType == 1) {

        bootboxHideAll();
        //jQuery(".qq-upload-size").empty();
        $('.alert-danger b').html();
        $('.alert-danger b').html(data.Message);
        $('.alert-success').hide();
        $('.alert-warning').hide();
        $('.alert-danger').hide();
        $(".alert-danger").fadeToggle(350);



    }

}


function GetWorkorderDetailList(id) {

    $.ajax({
        url: '/WorkorderDetail/Index',
        data: { id: id },
        type: 'Get',
        dataType: "html",
      
            success: function (data) {
                jQuery("#showDetaileWorkorder").empty();
                jQuery("#showDetaileWorkorder").html(data);
                $('html, body').animate({
                    scrollTop: $("#scrolltoIn").offset().top
                }, 'slow');
            
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }


    })

}

function CreateWorkorderDetails(id) {

    $.ajax({
        url: '/WorkorderDetail/Create',
        data: { id: id },
        type: 'Get',
        dataType: "html",
        success: function (data) {
            bootbox.dialog({
                message: data,
                size: "large"
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }


    })

}

function ShowWorkorderByScaffoldId(id) {

    $.ajax({
        url: '/Scaffolding/GetWorkOrderByScaffoldId',
        data: { id: id },
        type: 'post',
        dataType: "html",
        success: function (data) {
            bootbox.dialog({
                message: data,
                size: "large"
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }


    })

}


function ShowSafetyTagByScaffoldId(id) {

    $.ajax({
        url: '/Scaffolding/GetSafetyTagByScaffoldId',
        data: { id: id },
        type: 'post',
        dataType: "html",
        success: function (data) {
            bootbox.dialog({
                message: data,
                size: "large"
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }


    })

}

function showProperties(id) {

    $.ajax({
        url: '/Equipment/GetPropertiesById',
        data: { id: id },
        type: 'post',
        dataType: "html",
        success: function (data) {
            bootbox.dialog({
                message: data,
                size: "large"
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }


    })

}
function ShowPerssonnelByScaffoldId(id) {

    $.ajax({
        url: '/Scaffolding/GetPersonnelByScaffoldId',
        data: { id: id },
        type: 'post',
        dataType: "html",
        success: function (data) {
            bootbox.dialog({
                message: data,
                size: "large"
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }


    })

}

function ShowEquipmentByScaffoldId(id) {

    $.ajax({
        url: '/Scaffolding/GetEquipmentByScaffoldId',
        data: { id: id },
        type: 'post',
        dataType: "html",
        success: function (data) {
            bootbox.dialog({
                message: data,
                size: "large"
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }


    })

}

function addNewCreateTask(id) {

    $.ajax({
        url: '/AssignedTask/CreateOrUpdatePartial',
        type: 'Get',
        dataType: "html",
        success: function (data) {
            $("#addNew").append(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal("بروز خطا ", msg, "error");
        }


    })

}
function PersonnelSearch() {

    var userNameFmaily = $("#UserNameFmaily").val();
    var nationalCode = $("#NationalCode").val();
    var personnelCode = $("#PersonnelCode").val();
  
    var birthDate = $("#BirthDate").val();
    var toBirthDate = $("#ToBirthDate").val();
    var dateEmployeement = $("#DateEmployeement").val();
    var toDateEmployeement = $("#ToDateEmployeement").val();

    var maritalStatus = $("#MaritalStatus  option:selected").attr('value');
    var positionId = $("#PositionId  option:selected").attr('value');
    var employeeId = $("#EmployeeId  option:selected").attr('value');
    var companyId = $("#CompanyId  option:selected").attr('value');
    
   
    $('#PersonnelGrid').DataTable().ajax.url("/Personnel/list?UserNameFmaily=" + userNameFmaily + "&NationalCode=" + nationalCode + "&PersonnelCode=" + personnelCode + "&BirthDate=" + birthDate + "&ToBirthDate=" + toBirthDate + "&DateEmployeement=" + dateEmployeement + "&ToDateEmployeement=" + toDateEmployeement + "&MaritalStatus=" + maritalStatus + "&PositionId=" + positionId + "&EmployeeId=" + employeeId + "&CompanyId=" + companyId+"").load();

    $('html, body').animate({
        scrollTop: $("#PersonnelGrid").offset().top
    }, 'slow');

}

function BuyMaterialSearch() {

    var price = $("#Price").val();
   
    var buyDate = $("#BuyDate").val();
    var toBuyDate = $("#ToBuyDate").val();
  
    var equipmentId = $("#EquipmentId  option:selected").attr('value');
    var companyStoreRoomId = $("#CompanyStoreRoomId  option:selected").attr('value');


    $('#BuyMaterialGrid').DataTable().ajax.url("/BuyMaterial/list?Price=" + price + "&BuyDate=" + buyDate + "&ToBuyDate=" + toBuyDate + "&EquipmentId=" + equipmentId + "&CompanyStoreRoomId=" + companyStoreRoomId  + "").load();

    $('html, body').animate({
        scrollTop: $("#BuyMaterialGrid").offset().top
    }, 'slow');

}

function AttendanceSearch() {
    
    var fromDate = $("#FromDate").val();
    var toDate= $("#ToDate").val();

    var status = $("#PresenceStatus  option:selected").attr('value');
    var personnelCode = $("#SinglePersonnelCode  option:selected").attr('value');

    $('#AttendanceGrid').DataTable().ajax.url("/Attendance/list?SinglePersonnelCode=" + personnelCode + "&FromDate=" + fromDate + "&ToDate=" + toDate + "&PresenceStatus=" + status + "").load();

    $('html, body').animate({
        scrollTop: $("#AttendanceGrid").offset().top
    }, 'slow');

}

function WorkorderSearch() {

    var title = $("#TitleSearch").val();
    var tag = $("#TagSearch").val();
    var description = $("#Description").val();

    var date = $("#FromDate").val();
    var toDate = $("#ToDate").val();
    var expireDate = $("#FromExpireDate").val();
    var toExpireDate = $("#ToExpireDate").val();

    var status = $("#Status  option:selected").attr('value');
    var priority = $("#PriorityId  option:selected").attr('value');
    var type = $("#TypeId  option:selected").attr('value');
    var companyId = $("#CompanyId  option:selected").attr('value');


    $('#WorkOrderGrid').DataTable().ajax.url("/WorkOrder/list?TitleSearch=" + title + "&TagSearch=" + tag + "&Description=" + description + "&FromDate=" + date + "&ToDate=" + toDate + "&FromExpireDate=" + expireDate + "&ToExpireDate=" + toExpireDate + "&Status=" + status + "&PriorityId=" + priority + "&TypeId=" + type + "&CompanyId=" + companyId + "").load();

    $('html, body').animate({
        scrollTop: $("#WorkOrderGrid").offset().top
    }, 'slow');

}
function RoutinTaskSearch() {

   
    var date = $("#FromDate").val();
    var toDate = $("#ToDate").val();

    var personnelCode = $("#PersonnelCode  option:selected").attr('value');
    var routinId = $("#RoutineId  option:selected").attr('value');
   

    $('#RoutineGrid').DataTable().ajax.url("/AssignedTask/RoutinList?RoutineId=" + routinId + "&PersonnelCode=" + personnelCode  + "&FromDate=" + date + "&ToDate=" + toDate + "").load();

    $('html, body').animate({
        scrollTop: $("#RoutineGrid").offset().top
    }, 'slow');

}
function ResetForm() {

    //document.getElementById("form").reset();
    $('input[type=hidden]').val(null);
    $('input[type=number]').val(0);
    $('input[type=number]').text(0);
    $('input[type=number]').html(0);
    $('input[type=text]').val(null);
    $('input[type=text]').text(null);
    $(".select2").select2("destroy");
    $(".select2").select2();
    $(".select2 > option").removeAttr("selected");
    $(".select2").trigger("change");
   
}
function Cancel() {
    document.getElementById("search").reset();
    $('input[type=hidden]').val(null);
    $(".select2 > option").removeAttr("selected");
    $(".select2").trigger("change");

}
$('.table-responsive').on('show.bs.dropdown', function () {
    $('.table-responsive').css("overflow", "inherit");
});

$('.table-responsive').on('hide.bs.dropdown', function () {
    $('.table-responsive').css("overflow", "auto");
});
$('input[type="number"]').keypress(function (e) {
    //if the letter is not digit then display error and don't type anything
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        //display error message

        return false;
    }
});
$('#NationalCode').keypress(function (e) {
    //if the letter is not digit then display error and don't type anything
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        //display error message

        return false;
    }
});
$('#PersonnelCode').keypress(function (e) {
    //if the letter is not digit then display error and don't type anything
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        //display error message

        return false;
    }
});
$('#Phone').keypress(function (e) {
    //if the letter is not digit then display error and don't type anything
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        //display error message

        return false;
    }
});


