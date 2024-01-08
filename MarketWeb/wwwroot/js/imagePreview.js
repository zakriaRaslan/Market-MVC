$(document).ready(function () {
    $(".img-input").on("change", function () {
        $(".img-preview").attr("src", window.URL.createObjectURL(this.files[0]))
    })
})