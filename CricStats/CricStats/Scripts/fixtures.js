function render(data) {
    let html = '<div class="comment-box"> \
  <div class="left-paneling">\
  <img src="image/avatar.png" alt="avatar" />\
  </div>\
  <div class="right-paneling">\
  <span>' + data.name + '</span>\
  <div class="date">' + data.date + ' \
  </div><p>' + data.body + '</p>\
  </div><div class="clear"></div>\
  </div>';
    document.getElementById("container").innerHTML += html
}

// scroll function for comment section so when user enter
// the comment it shows the current comment entered in the comment section.
function scrollToBottom() {
    element = document.getElementById("container");
    element.scrollTop = element.scrollHeight;
}

// Date and time function to put in a required format
function dateAndTime(){

    const date = document.getElementById("date");

    let currentDateTime = new Date();

    let today = currentDateTime.getDate();
    let month = currentDateTime.getMonth();
    let year = currentDateTime.getFullYear();
    let time = currentDateTime.toLocaleTimeString();

    //getting date in right format
    date.value = today + "-" + (month + 1) + "-" + year + " / " + time;
}

//add comment button function
function addComments() {

    //comment data array
    let comment = [];

    //local Storage
    if (!localStorage.commentData) {
        localStorage.commentData = [];
    } else {
        comment = JSON.parse(localStorage.commentData);
    }

    //
    for (let i = 0; i < comment.length; i++) {
        render(comment[i]);
    }

    //getting all the form field elemets
    const name = document.getElementById("name");
    const date = document.getElementById("date");
    const body = document.getElementById("bodyText");

    //Add comment button function to post comments
    document.getElementById("addComment").addEventListener("click", function() {

        let nameInput = document.getElementById("name").value;
        let commentInput = document.getElementById("bodyText").value;

        //checking if field are empty
        if (nameInput == "" || commentInput == "") {
            alert('required fields with *');

            //setting border color if the required field is empty (validation)
            if (nameInput == "" && commentInput == "") {
                document.getElementById("name").style.border = "1px solid red";
                document.getElementById("bodyText").style.border = "1px solid red";
            } else if (commentInput == "" && nameInput != "") {
                document.getElementById("bodyText").style.border = "1px solid red";
                document.getElementById("name").style.border = "1px solid grey";
            } else if (nameInput == "" && commentInput != "") {
                document.getElementById("name").style.border = "1px solid red";
                document.getElementById("bodyText").style.border = "1px solid grey";
            }


        } else {

            //adding objects to comment box for display
            let addObj = {
                "name": name.value,
                "date": date.value,
                "body": body.value
            }

            comment.push(addObj);
            render(addObj);
            localStorage.commentData = JSON.stringify(comment);
            scrollToBottom();// it will scroll to the latest post.

            //setting input fields to default for new comment
            document.getElementById("name").value = "";
            document.getElementById("bodyText").value = "";
            document.getElementById("name").style.border = "1px solid grey";
            document.getElementById("bodyText").style.border = "1px solid grey";
        }
    });
}
dateAndTime();

//function to append on load of a window
window.onload = function() {
    addComments();
    dateAndTime();
}



