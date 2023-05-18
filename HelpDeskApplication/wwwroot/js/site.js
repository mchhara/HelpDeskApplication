
const RenderTicketComments = (comments, container) => {
    container.empty();

    for (const comment of comments) {

        const dateCreated = new Date(comment.dateCreated).toLocaleString();
        container.append(
            `<div class="card border-secondary mb-3" style="max-width: 90rem;">
          <div class="card-header">Created by: <strong> ${comment.userEmail} </strong> 
          <br> At: <strong> ${dateCreated } </strong> 
          
          </div>
          <div class="card-body">
            <h5 class="card-title">${comment.text}</h5> 
          </div>
        </div>`)
    }
}


const LoadTicketComments = () => {
    const container = $("#comments")
    const ticketEncodedName = container.data("encodedName");


    $.ajax({
        url: `/Ticket/${ticketEncodedName}/TicketComment`,
        type: 'get',
        success: function (data) {
            if (!data.length) {
                container.html("There are no comments for this ticket yet.")
            } else {
                RenderTicketComments(data, container)
            }
        },
        error: function () {
            toastr["error"]("Something went wrong")
        }
    })
}