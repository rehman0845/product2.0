//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
    $("#myProdDiv").hide();

    $("#AddProd").click(function () {
        $("#AddProd").hide();
        $("#btnUpdate").hide();
        $("#btnAdd").show();
        $("#myProdDiv").show();
    });
    $("#EditProd").click(function () {
        $("#AddProd").hide();
        $("#EditProd").hide();
        $("#AddProdTitle").hide();
        $("#EditProdTitle").show();
        $("#btnUpdate").show();
        $("#btnAdd").hide();
        $("#myProdDiv").show();
    });
    $("#btnAdd").click(function () {
        var res = validate();
        if (res == false) {
            return false;
        }
        var prodObj = {
            Id : 0,
            Name : $('#Name').val(),
            Description : $('#Description').val(),
            SKU : $('#SKU').val(),
            Price : $('#Price').val()
        };
        console.log(prodObj);

        $.ajax({
            url: "/Home/Create",
            data: JSON.stringify(prodObj),
            type: "POST",
            contentType: "application/json;",
            dataType: "json",
            success: function (result) {
                loadData();
                $("#myProdDiv").hide();
                $("#AddProd").show();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    });
    $("#btnUpdate").click(function () {
        var res = validate();
        if (res == false) {
            return false;
        }
        var prodObj = {
            Id: $('#ProdId').val(),
            Name: $('#Name').val(),
            Description: $('#Description').val(),
            SKU: $('#SKU').val(),
            Price: $('#Price').val(),
        };
        console.log(prodObj);
        $.ajax({
            url: "/Home/Edit",
            data: JSON.stringify(prodObj),
            type: "POST",
            contentType: "application/json;",
            dataType: "json",
            success: function (result) {

                $("#AddProd").show();
                $("#EditProd").hide();
                $("#AddProdTitle").hide();
                $("#EditProdTitle").hide();
                $("#btnUpdate").hide();
                $("#btnAdd").hide();
                $("#myProdDiv").hide();

                loadData();
                //$('#myProdDiv').attr('hide');
                $('#Id').val("");
                $('#Name').val("");
                $('#Description').val("");
                $('#SKU').val("");
                $('#Price').val("");
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    });
});

//Load Data function  
function loadData() {

    $.ajax({
        url: "/Home/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            console.log(result);
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.description + '</td>';
                html += '<td>' + item.sku + '</td>';
                html += '<td>' + item.price + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.id + ')">Edit</a> | <a href="#" onclick="Delele(' + item.id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
//function Add() {
//    var res = validate();
//    if (res == false) {
//        return false;
//    }
//    var prodObj = {
//        Name: $('#Name').val(),
//        Description: $('#Description').val(),
//        SKU: $('#SKU').val(),
//        Price: $('#Price').val()
//    };
//    $.ajax({
//        url: "/Product/Create",
//        data: JSON.stringify(prodObj),
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            loadData();
//            //$('#myModal').modal('hide');
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}

//Function for getting the Data Based upon Product ID  

function getbyID(ProdId) {

    $('#Name').css('border-color', 'lightgrey');
    $('#Description').css('border-color', 'lightgrey');
    $('#SKU').css('border-color', 'lightgrey');
    $('#Price').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/GetbyId/" + ProdId,
        typr: "GET",
        contentType: "application/json;",
        dataType: "json",
        success: function (result) {
            console.log(result);
            $('#ProdId').val(result.id);
            $('#Name').val(result.name);
            $('#Description').val(result.description);
            $('#SKU').val(result.sku);
            $('#Price').val(result.price);

            $("#AddProd").hide();
            $("#AddProdTitle").hide();
            $("#EditProdTitle").show();
            $("#btnUpdate").show();
            $("#btnAdd").hide();
            $("#myProdDiv").show();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
//function Update() {
//    var res = validate();
//    if (res == false) {
//        return false;
//    }
//    var prodObj = {
//        Id: $('#Id').val(),
//        Name: $('#Name').val(),
//        Description: $('#Description').val(),
//        SKU: $('#SKU').val(),
//        Price: $('#Price').val(),
//    };
//    $.ajax({
//        url: "/Product/Edit",
//        data: JSON.stringify(prodObj),
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            loadData();
//            $('#myProdDiv').attr('hide');
//            $('#Id').val("");
//            $('#Name').val("");
//            $('#Description').val("");
//            $('#SKU').val("");
//            $('#Price').val("");
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}

//function for deleting employee's record  

function Delele(Id) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Home/Delete/" + Id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#ProdId').val("");
    $('#Name').val("");
    $('#Description').val("");
    $('#SKU').val("");
    $('#Price').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Description').css('border-color', 'lightgrey');
    $('#SKU').css('border-color', 'lightgrey');
    $('#Price').css('border-color', 'lightgrey');
}

//Valdidation using jquery  
function validate() {
    //debugger;
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#Description').val().trim() == "") {
        $('#Description').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Description').css('border-color', 'lightgrey');
    }
    if ($('#SKU').val().trim() == "") {
        $('#SKU').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SKU').css('border-color', 'lightgrey');
    }
    if ($('#Price').val().trim() == "") {
        $('#Price').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Price').css('border-color', 'lightgrey');
    }
    return isValid;
}  