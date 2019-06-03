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
function CheckIfEmpty() {
    var userName = $('#txtUsername').val();
    var userPassword = $('#txtPassword').val();
    if (userName == "" || userPassword == "") {
        $('#lblValidationMsg').removeAttr('hidden');
        $('#lblValidationMsg').val("Username/Password cannot be empty!");
        return false;
    }
    return true;
}