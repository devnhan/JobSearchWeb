function candidateregister() {
    let email = $('#CandidatesEmail').val();
    let name = $('#CandidatesName').val();
    let password = $('#CandidatesPassword').val();

    var url = "/Candidate/Register"; // Điều chỉnh URL để phản ánh cấu trúc dự án của bạn
    var data = JSON.stringify({
        "CandidatesEmail": email,
        "CandidatesName": name,
        "CandidatesPassword": password
    });
    $.ajax({
        type: "POST",
        data: data,
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (result) {
            alert(result);
        },
        error: function (result) {
            alert(error);
        }
    });
}

// Gán hàm candidateregister() cho sự kiện click của nút Register
$(document).ready(function () {
    $('#btnRegister').click(function (e) {
        e.preventDefault();
        candidateregister();
    });
});