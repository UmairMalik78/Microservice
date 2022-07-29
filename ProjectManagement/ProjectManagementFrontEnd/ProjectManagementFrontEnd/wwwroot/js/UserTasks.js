completedTasksIdsList = [];
taskIdObj = {};


$(document).ready(function() {
    $.ajax({
        url: '/Developer/UserInfoVC',
        success: function(data) {
            alert(data);
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
})


function AddTaskId(taskId) {

    let index = SearchTaskIdInList(taskId);
    if (index == -1) {
        completedTasksIdsList.splice(index, 1);
        return;
    }
    taskIdObj["Id"] = taskId;
    completedTasksIdsList.push(taskIdObj);
    let inputElement = document.getElementById('completed-tasks-id-field');
    inputElement.value = JSON.stringify(completedTasksIdsList).toString();
    if (completedTasksIdsList.length > 0) {
        (document.getElementsByClassName("update-task-status-btn")[0]).style.display = "block";
    }
}

function SearchTaskIdInList(taskId) {
    for (let i = 0; i < completedTasksIdsList.length; i++) {
        if (completedTasksIdsList[i].Id == taskId) {
            return i;
        }
    }
    return -1;
}