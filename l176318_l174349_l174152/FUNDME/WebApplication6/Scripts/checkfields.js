function validEmail(email) {
    var re = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    return re.test(email);
};

function validPhoneno(phone) {
    var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
    return phoneno.test(phone);
};

function hasNumber(myString) {
    return /\d/.test(myString);
};

function getAge(birthDateString) {
    var today = new Date();
    var birthDate = new Date(birthDateString);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
};

function checkForFieldsSignUp() {
    var name = document.getElementById("nameField").value;
    var email = document.getElementById("EmailField").value;
    var password = document.getElementById("PasswordField").value;
    var phone = document.getElementById("phonenumField").value;
    var valuedate = document.getElementById("dobField").value;
    var cnic = document.getElementById("cnicField").value;

    if (email == "" || password == "" || name == "" || phone == "" || valuedate == ""|| cnic=="") {
        alert("Please Enter all fields");
        return false;
    }
    if (hasNumber(name))
    {
        alert("Name can not have number in it");
        return false;
    }
    var n = name.length;
    if (n < 3 || n >= 30) {
        alert("Incorrect Namelength");
        return false;
    }
    n = cnic.length;
    if (n != 13)
    {
        alert("CNIC has to be 13 characters only");
        return false;
    }

    if (getAge(valuedate) <= 18) {
        alert("You are not 18 or old ");
        return false;
    } 
    n = password.length;
    if (n < 8) {
        alert("Password can not be less than 8 characters");
        return false;
    }

    if (validEmail(email) == false) {
        alert("Invalid Email");
        return false;
    }
    n = email.length;
    if (n < 5) {
        alert("Email Length Too Short");
        return false;
    }
    
    if (validPhoneno(phone) == false) {
        alert("Invalid Phone Number");
        return false;
    }
    return true;

}

function checkForFieldsSignIn() {//length checks for all the fields are catered here
    var email = document.getElementById("EmailField").value;//obtaining email from the webpage
    var password = document.getElementById("PasswordField").value;//obtaing password from webpage

    if (email == "" || password == "") {//empty field checks
        alert("Please Enter all fields");
        return false;
    }

    var n = password.length;//getting the length of submitted password
    if (n < 8) {
        alert("Password can not be less than 8 characters");
        return false;
    }
    if (validEmail(email) == false) {//email validation check
        alert("Invalid Email");
        return false;
    }
    n = email.length;
    if (n < 5) {
        alert("Email Length Too Short");
        return false;
    }
    
    return true;

}

function checkaddCase() {

    var id = document.getElementById("idField").value;
    var nameField = document.getElementById("nameField").value;
    var targetField = document.getElementById("targetField").value;
    var linkField = document.getElementById("linkField").value;

    if (id == "" || nameField == "" ||  targetField == "" || linkField=="")
    {
        alert("Please Enter all fields");
        return false;
    }
    if (id < 1) {
        alert("ID can not be negative ");
        return false;
    }
    var n;
    n = nameField.length;
    if (n < 5)
    {
        alert("Name has to be more than 5 characters long.");
        return false;
    }
    if (targetField < 0)
    {
        alert("Target Amount can not be negative.");
        return false;
    }
    if (targetField == 0)
    {
        alert("Target Amount can not be zero.");
        return false;
    }
    if (targetField < 10000)
    {
        alert("Target Amount has to be a minimum of 10,000.");
        return false;
    }
    return true;
}


function checkaddEvent() {

    var id = document.getElementById("idField").value;
    var nameField = document.getElementById("nameField").value;
    var date = document.getElementById("dateField").value;
    var linkField = document.getElementById("linkField").value;

    if (id == "" || nameField == "" || date == "" || linkField == "") {
        alert("Please Enter all fields");
        return false;
    }
    if (id < 1) {
        alert("ID can not be negative ");
        return false;
    }
    var n;
    n = nameField.length;
    if (n < 5) {
        alert("Name has to be more than 5 characters long.");
        return false;
    }
    var date = new Date(date);
    var now = new Date();
    if (date < now) {
        alert("Date must be in the future");
        return false;
    }
    return true;
}



function checkaddadmin() {//length checks for all the fields are catered here
    var email = document.getElementById("EmailField").value;
    var password = document.getElementById("PasswordField").value;
    var cnic = document.getElementById("cnicField").value;

    if (email == "" || password == "" || cnic =="" ) {
        alert("Please Enter all fields");
        return false;
    }
    var n;
    n = cnic.length;
    if (n != 13) {
        alert("CNIC has to be 13 characters only");
        return false;
    }

    n = password.length;
    if (n < 8) {
        alert("Password can not be less than 8 characters");
        return false;
    }

    if (validEmail(email) == false) {
        alert("Invalid Email");
        return false;
    }
    n = email.length;
    if (n < 5) {
        alert("Email Length Too Short");
        return false;
    }
    return true;

}


function checkdonate() {
    var amount = document.getElementById("amountField").value;

    if (amount == "") {
        alert("Please enter an amount");
        return false;
    }
    if (amount < 500) {
        alert("Amount has to be 500/- or more");
        return false;
    }
    return true;
}

function checkdonorregister() {
    var accField = document.getElementById("accField").value;
    var VAField = document.getElementById("VAField").value;

    if (accField == "" || VAField == "") {
        alert("Enter all fields please");
        return false;
    }
    var n;
    n = accField.length;
    if (n < 14 || n > 15) {
        alert("Account number length is invalid");
        return false;
    }

    n = VAField.length;
    if (n < 10) {
        alert("Your address seems short");
        return false;
    }
    return true;
}
