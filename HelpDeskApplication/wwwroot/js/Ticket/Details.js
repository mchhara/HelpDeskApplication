$(document).ready(function () {
    LoadTicketComments();

    $("#createTicketCommentModal form").submit(function (event) {
        event.preventDefault();

        var haveSolution = $("#HaveSolution").is(":checked");

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Created ticket comment");
                LoadTicketComments();

                if (haveSolution) {
                    location.reload();
                }
            },
            error: function () {
                toastr["error"]("Something went wrong");
            }
        });
    });

    $("#closeTicketButton").click(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('href'),
            type: $(this).attr('post'),
            data: $(this).serialize(),
            success: function (data) {
                window.location.href = '@Url.Action("Index", "Ticket")';
                toastr["success"]("Ticket closed");

            },
            error: function () {
                toastr["error"]("Something went wrong");
            }
        });
    });

});
