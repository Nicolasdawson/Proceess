var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Tarea/GetAll"
        },
        "columns": [
            { "data": "nom_tarea", "width": "5%" },
            { "data": "des_tarea", "width": "5%" },
            { "data": "progreso_tarea", "width": "5%" },
            { "data": "aprobacion", "width": "5%" },
            { "data": "justificacion", "width": "5%" },
            { "data": "inicio_tarea", "width": "5%" },
            { "data": "fin_tarea", "width": "5%" },
            { "data": "comentarios", "width": "5%" },
            { "data": "retraso", "width": "5%" },
            { "data": "flujoTarea.nom_flujo", "width": "5%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Tarea/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Delete("/Admin/Tarea/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "40%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "¿Estás seguro de que quieres eliminar esta tarea?",
        text: "¡No vas a poder recuperar estos datos!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}