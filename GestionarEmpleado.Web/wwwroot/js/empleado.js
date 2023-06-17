$(document).ready(function () {

    $('#DataTableEmpleado').DataTable({
        processing: true,
        serverSide: true,
        ajax: {
            url: '/Empleados/list',
            type: 'GET'
        },
        //order: [[0, "desc"]],
        columns: [
            {
                name: 'nombre',
                data: 'nombre',
                title: "Nombre",
                sortable: true,
                searchable: true,
                className: 'text-nowrap',
            },
            {
                name: 'apellido',
                data: 'apellido',
                title: "Apellido",
                sortable: true,
                searchable: false
            },
            {
                name: 'puesto.nombre',
                data: 'puesto.nombre',
                title: "Puesto",
                sortable: true,
                searchable: false
            },
            {
                name: 'fechaContratacion',
                data: 'fechaContratacion',
                title: "Fecha de Contratación",
                sortable: true,
                searchable: false,
                render: function (data, type, row) {
                    return moment(data).format("DD/MM/YYYY");
                }
            },
            {
                name: 'estado.nombre',
                data: 'estado.nombre',
                title: "Estado",
                sortable: true,
                searchable: false
            },
            {
                name: 'id',
                data: 'id',
                title: "Acción",
                sortable: false,
                searchable: false,
                className: 'text-nowrap',
                render: function (data, type, row) {
                    var html = '<span class="files-more-link">' +
                        '<a href="/Empleados/Details/' + data + '" sil-action="Details" data-bind="' + data + '"><i class="zmdi zmdi-eye zmdi-hc-2x"></i></a>';

                    
                    html += '<a href="/Empleados/Edit/' + data + '" sil-action="edit" data-bind="' + data + '"><i class="zmdi zmdi-edit zmdi-hc-2x"></i></a>';
                                     html += '</span >';

                    return html;
                }
            }
        ]
    });
});
