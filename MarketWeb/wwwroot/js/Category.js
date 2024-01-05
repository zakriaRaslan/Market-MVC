$(document).ready(function () {
    $(".js-delete").on("click", function () {
    var btn = $(this);


        const swal = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-danger mx-3",
                cancelButton: "btn btn-light"
            },
            buttonsStyling: false
        });
        swal.fire({
            title: "Are you sure you want to delete this Category?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `categories/Delete/${btn.data("id")}`,
                    method: "DELETE",

                    success: function () {
                        swal.fire({
                            title: "Deleted!",
                            text: "Category has been deleted.",
                            icon: "success"
                        })

                        btn.parents("tr").fadeOut(500, function () {
                            this.remove();
                        });
                    },
                    error: function () {
                        swal.fire({
                            title: "Error!",
                            text: "Something Went Wrong..",
                            icon: "error"
                        })
                    }
                })
            }
        });



    })
})

