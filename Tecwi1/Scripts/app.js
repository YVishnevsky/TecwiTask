$(document).ready(function () {
    $('#example').DataTable({
        "order": [[0, "desc"]],
        "processing": true,
        "serverSide": true,
        "lengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]],
        "ajax":
            {
                url: $('#example').data('listUrl'),
                accepts: {
                    json: "application/json"
                }
            },
        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }],  
        "columns": [
            { "data": "id", "name": "Id", "autoWidth": true },
            { "data": "name", "name": "Name" },
            { "data": "position", "name": "Position" },
            {
                "data": "startDate", "name": "StartDate",
                render: function (d) {
                    return moment(d).format("DD.MM.YYYY");
                }
            },
            { "data": "age", "name": "Age" },
            {
                "orderable": false,
                "render": function (data, type, full, meta) {
                    var url = $('#example').data('editUrl') + '/';
                    return '<a class="btn btn-info" href="'+ url + full.id + '">Edit</a>';
                }
            },
            {
                "orderable": false,
                "data": null,
                "render": function (data, type, row) {
                    return "<a href='#' class='btn btn-danger' onclick=DeleteEmployee('" + row.id + "'); >Delete</a>";
                }
            }
        ],
        select: true
    });
});

function DeleteEmployee(id) {
    if (confirm("Are you sure you want to delete ...?")) {
        Delete(id);
    }
    else {
        return false;
    }
}

function Delete(id) {
    var url = $('#example').data('listUrl') + '/' + id;
    $.ajax({ url,  type: "DELETE", success: function (result) {
            console.log("after delete");
            oTable = $('#example').DataTable();
            oTable.ajax.reload();
        }
    });
}  