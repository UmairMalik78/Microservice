$(document).ready(function() {
    $.ajax({
        url: '/Manager/UserInfoVC',
        success: function(data) {
            $("#user-info-div").html(data);

        },
        statusCode: {
            404: function(content) { alert('cannot find resource'); },
            500: function(content) { alert('internal server error'); }
        },
        error: function(req, status, errorObj) {
            // handle status === "timeout"
            // handle other errors
            alert("Some Error occured, try again later!");
        }
    });
    $.ajax({
        url: '/Manager/PMTasksVC',
        success: function(data) {
            $("#pm-tasks-div").html(data);

        },
        statusCode: {
            404: function(content) { alert('cannot find resource'); },
            500: function(content) { alert('internal server error'); }
        },
        error: function(req, status, errorObj) {
            // handle status === "timeout"
            // handle other errors
            alert("Some Error occured, try again later!");
        }
    });


    $("#add-task-form").submit(function(event) {
        event.preventDefault();
        AddNewTask();
    })
})

function showAddTaskDiv() {
    $("#add-task-form").show();
    $("#add-new-task-form").show();
}

function closeAddTaskDiv() {
    document.getElementById('add-new-task-form').style.display = "none";
}

function AddNewTask(event) {
    // var formData = $("#add-task-form").serialize();
    // debugger;
    var data = {};
    data.id = "-1";
    data.title = $(title).val();
    data.description = $(description).val();
    data.taskDeadline = $(taskDeadline).val();
    data.status = "false";
    data.assignedUserId = $(assignedUserId).val().toString();
    // { id: "6bb3c013-d4d1-4d02-9b93-7c0ea73e4392", title: "lanfing", description: "sdsad", taskDeadline: "21-02-2022", stats: "false", assignedUserid: "6bb3c013-d4d1-4d02-9b93-7c0ea73e4392" }
    $.ajax({
        url: '/Manager/AddNewTask/',
        type: "POST",
        data: (data),
        statusCode: {
            404: function(content) { alert('cannot find resource'); },
            500: function(content) { alert('internal server error'); }
        },
        success: function() {
            debugger;
            alert("success");
            $("#add-task-form").hide();
            $("#add-new-task-form").hide();
        },
        error: function(req, status, errorObj) {
            debugger;
            // handle status === "timeout"
            // handle other errors
            alert("Some Error occured, try again later!");
        }
    });

    return false;

}


function UpdatePMTask(taskId) {
    $.ajax({
        url: '/Manager/UpdateTaskVC/',
        type: "GET",
        data: { taskId: taskId },
        success: function(data) {
            $("#update-task-form").html(data);

        },
        statusCode: {
            404: function(content) { alert('cannot find resource'); },
            500: function(content) { alert('internal server error'); }
        },
        error: function(req, status, errorObj) {
            // handle status === "timeout"
            // handle other errors
            alert("Some Error occured, try again later!");
        }
    });

}