$(document).ready(function () {


    LoadTicketComments()

    $("#createTicketCommentModal form").submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Created ticket comment")
                LoadTicketComments()
            },
            error: function () {
                toastr["error"]("Something went wrong")
            }
        })
    });
});