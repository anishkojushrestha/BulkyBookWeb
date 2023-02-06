var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        "ajax": {
            "url":"Product/GetAll"
        },
        "columns": [
            { "data": "image", "width": "15%" },
            { "data": "title", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "listPrice", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "price50", "width": "15%" },
            { "data": "price100", "width": "15%" },
            { "data": "category.name", "width":"15%" },
            { "data": "coverType.name", "width": "15%" },
            {
                "data": "id",
                "render": (data) => {
                    return `
                        <a href="#" class="btn btn-warning">Edit</a>
                          <a href="#" class="btn btn-danger">Delete</a>
`
                }
            },

            ]
        });
}