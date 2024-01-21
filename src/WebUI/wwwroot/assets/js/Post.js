// Post.js
$(document).ready(function () {
    $("#commentDescription").on("keypress", function (event) {
        if (event.key === "Enter" || event.which === 13) {
            event.preventDefault();
            submitComment();
        }
    });
    
    $("#submitComment").on("click", function () {
        submitComment();
    });
    
    function submitComment() {
        var postId = "@Model.Id";
        var description = $("#commentDescription").val();

        $.ajax({
            type: "POST",
            url: "@Url.Action("AddComment", "Post")",
            data: { postId: postId, description: description },
            success: function (result) {
                if (result.success) {
                    alert(result.message);
                    $("#commentSection").load("/Post/Index?postId=" + postId + " #commentSection");
                } else {
                    alert(result.message);
                    window.location.href = '/login';
                }
            },
            error: function () {
                alert("Đã xảy ra lỗi khi gửi yêu cầu.");
            }
        });
    }
});
