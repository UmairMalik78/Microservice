function ShowSignUpDiv() {
    var signupDiv = document.getElementById('sign-up');
    var loginDiv = document.getElementById('login-div');
    signupDiv.style.display = "block";
    loginDiv.style.display = "none";
}

function ShowLoginDiv() {
    var signupDiv = document.getElementById('sign-up');
    var loginDiv = document.getElementById('login-div');
    signupDiv.style.display = "none";
    loginDiv.style.display = "block";
}