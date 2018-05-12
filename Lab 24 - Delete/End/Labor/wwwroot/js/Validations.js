function IsFieldEmpty() {
    if ((document.getElementById("TxtFName").value == "")
        || (document.getElementById("TxtLName").value == "")
        || (document.getElementById("TxtSalary").value == "")) {
        return "Required field!";}
    return "";
}

function ContainsOnlyLetters() {
    var letters = /^[a-zA-Z]*$/;
    if ((document.getElementById("TxtFName").value.match(letters))
        && (document.getElementById("TxtLName").value.match(letters))) {
        return "";
    }
    return "Use only letters!";
}

function LengthIsValid() {
    if ((document.getElementById("TxtFName").value.length > 20)
        || (document.getElementById("TxtLName").value.length > 20)) {
        return "Length should be less than 20 characters!";
    }
    return "";
}

var minSalary = 500;
var maxSalary = 50000;
function IsSalaryInValid() {
    if ((isNaN(document.getElementById("TxtSalary").value))
        || ((document.getElementById("TxtSalary").value) < minSalary)
        || ((document.getElementById("TxtSalary").value) > maxSalary)) {
        return "Salary must be between " + minSalary + " and " + maxSalary + "!";
    } return "";
}

function IsValid() {
    var FieldEmptyEmptyMessage = IsFieldEmpty();
    var OnlyLettersMessage = ContainsOnlyLetters();
    var LengthIsValidMessage = LengthIsValid();
    var SalaryInvalidMessage = IsSalaryInValid();
    var FinalErrorMessage = "Errors:";

    if (FieldEmptyEmptyMessage != "")
        FinalErrorMessage += "\n" + FieldEmptyEmptyMessage;
    if (OnlyLettersMessage != "")
        FinalErrorMessage += "\n" + OnlyLettersMessage;
    if (LengthIsValidMessage != "")
        FinalErrorMessage += "\n" + LengthIsValidMessage;
    if (SalaryInvalidMessage != "")
        FinalErrorMessage += "\n" + SalaryInvalidMessage;
    if (FinalErrorMessage != "Errors:") {
        alert(FinalErrorMessage);
        return false;
    } else {
        return true;
    }
}