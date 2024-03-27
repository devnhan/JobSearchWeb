function recruiterlogin() {
    let email = $('#RecruiterEmail').val();
    let password = $('#RecruiterPassword').val();

    var url = "/Recruiter/Login";  // Điều chỉnh URL để phản ánh cấu trúc dự án của bạn
    var data = JSON.stringify({
        "RecruiterEmail": email,
        "RecruiterPassword": password
    });
    $.ajax({
        type: "POST",
        data: data,
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (result) {
            alert(result.Message);
        },
        error: function (result) {
            alert(result.responseJSON.Message);
        }
    });
}

// Gán hàm candidatelogin() cho sự kiện click của nút đăng nhập
$(document).ready(function () {
    $('#btnLogin').click(function (e) {
        e.preventDefault();
        recruiterlogin();
    });
});