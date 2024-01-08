var dataTable;
$(document).ready(function () {
    loadTabelData();
    $(".js-delete").on("click", function () {

        

    })
})

function loadTabelData() {
    dataTable = $('#dtaTable').DataTable({
        "ajax": { url: '/admin/products/getall'} ,
            "columns": [
                { data: 'title' , "width":"15%" },
                { data: 'description', "width": "30%" },
                { data: 'price', "width": "10%" },
                { data: 'category.name', "width": "15%" },                       
                {
                    data: 'id',
                    "render" : function (data) {
                        return`<div class="w-75 btn-group" role="group">
                         <a href="/admin/products/upsert?id=${data}" class="btn btn-info me-3"><i class="fa-solid fa-pen"></i> Edit</a>
                         <a onClick=Delete('/admin/products/delete/${data}') class="btn btn-danger me-3 js-delete"><i class="fa-solid fa-trash"></i> Delete</a>
                        </div>
                        `
                    },"width":"30%"
                },
            ]
    });
}

function Delete(url) {
    swal.fire({
        title: "Are you sure you want to delete this Category?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes, delete it!",
        cancelButtonText: "No, cancel!",
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message)
                }
            })
        }
    })
}