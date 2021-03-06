﻿$(document).ready(function () {
    LoadIndexItem();
    LoadSupplierCombo();
    $('#table').DataTable({
        "ajax": LoadIndexItem()
    });
});

function LoadIndexItem() {
    $.ajax({
        url: 'http://localhost:36902/api/Items',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (item) {
            var html = '';
            var i = 1;
            $.each(item, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Price + '</td>';
                html += '<td>' + val.Stock + '</td>';
                html += '<td>' + val.Suppliers.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function LoadSupplierCombo() {
    $.ajax({
        url: 'http://localhost:36902/api/Suppliers',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var supplier = $('#Suppliers');
            $.each(result, function (i, Supplier) {
                $("<option></option>").val(Supplier.Id).text(Supplier.Name).appendTo(supplier);
            });
        }
    });
}

function Save() {
    var item = new Object();
    item.Name = $('#Name').val();
    item.Price = $('#Price').val();
    item.Stock = $('#Stock').val();
    item.Suppliers_Id = $('#Suppliers').val();
    $.ajax({
        url: 'http://localhost:36902/api/Items',
        type: 'POST',
        dataType: 'json',
        data: item,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/Items/Index/';
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function Delete(Id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: "http://localhost:36902/api/Items/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Items/Index/';
                });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function GetById(Id) {
    $.ajax({
        url: 'http://localhost:36902/api/Items/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Price').val(result.Price);
            $('#Stock').val(result.Stock);
            $('#Suppliers').val(result.Suppliers_Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function GetByStock(Id) {
    $.ajax({
        url: 'http://localhost:36902/api/Items',
        type: 'GET',
        //async: false,
        data: {
            'name': $('#cmbName').val(),
            'price': $('#cmbPrice').val(),
            'stock': $('#cmbStock').val()
        },
        dataType: 'json',
        success: function (item) {
            var html = '';
            var i = 1;
            $.each(item, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Price + '</td>';
                html += '<td>' + val.Stock + '</td>';
                html += '<td>' + val.Suppliers.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        }
    });
}

function Edit() {
    var item = new Object();
    item.Id = $('#Id').val();
    item.Name = $('#Name').val();
    item.Price = $('#Price').val();
    item.Stock = $('#Stock').val();
    item.Suppliers_Id = $('#Suppliers').val();
    $.ajax({
        url: 'http://localhost:36902/api/Items/' + item.Id,
        type: 'PUT',
        data: item,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Items/Index/';
                $('#Id').val('');
                $('#Name').val('');
                $('#Price').val('');
                $('#Stock').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}