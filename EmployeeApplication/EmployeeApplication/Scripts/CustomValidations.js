//$('#btnAddEmployee').click(function () {
    
//    $.post('../Home/AddEmployeeView');
//})
//$.get({
//    url: '../Home/GetSkillNames',
//    success: function (data) {
//        var locationList = $('#lstLocation');
//        locationList.empty();
//        debugger;
//        for (var i = 0; i < data.length; i++) {
//            locationList.append('<option>' + data[i] + '</option>');
//        }
//    }
//});

//$.get({
//    url: '../Home/GetLocationNames',
//    success: function (data) {
        
//    }
//});
function ValidateAddForm() {
    var errorMsg = "";
    if ($('#txtFirstName').val() == "" ||
        $('#txtLastName').val() == "" ||
        $('#numAge').val() == "" ||
        $('#numSalary').val() == "" ||
        $('#lstLocation').val() == "default" ||
        $('#lstSkill').val() == "default") {
        errorMsg += "All the fields are mandatory! Please enter the values...";
    }

    if ($('#numAge').val() <= 0 || $('#numAge').val() > 150) {
        errorMsg += "Invalid value entered in Age field! Please enter value between 1-150..."
    }
    if ($('#numSalary').val() <= 0) {
        errorMsg += "Salary cannot be less than or equal to 0! Please enter value more than 0..."
    }
    if (errorMsg != "") {
        $("#lblAddValidationMsg").removeAttr("hidden");
        $("#lblAddValidationMsg").text(errorMsg);
        return false;
    }
    return true;
}

function ValidateEditForm() {
    var errorMsg = "";
    if ($('#txtEditEmpFirstName').val() == "" ||
        $('#txtEditEmpLastName').val() == "" ||
        $('#numEditEmpAge').val() == "" ||
        $('#numEditEmpSalary').val() == "" ||
        $('#lstEditLocation').val() == "default" ||
        $('#lstEditSkill').val() == "default") {
        errorMsg += "All the fields are mandatory! Please enter the values...";
    }

    if ($('#numEditEmpAge').val() <= 0 || $('#numEditEmpAge').val() > 150) {
        errorMsg += "Invalid value entered in Age field! Please enter value between 1-150..."
    }
    if ($('#numEditEmpSalary').val() <= 0) {
        errorMsg += "Salary cannot be less than or equal to 0! Please enter value more than 0..."
    }
    if (errorMsg != "") {
        $("#lblEditValidationMsg").removeAttr("hidden");
        $("#lblEditValidationMsg").text(errorMsg);
        return false;
    }
    return true;
}