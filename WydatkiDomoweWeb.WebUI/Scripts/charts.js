$(function () {
    $("#selectBill").change(function () {
        reloadPartialView();
    });
})

function reloadPartialView() {
    var id = $("#selectBill").val();
    $.ajax({
        url: "Charts/GetMonthlyChartForIndividualBills",
        type: 'GET',
        dataType: "html",
        // we set cache: false because GET requests are often cached by browsers
        // IE is particularly aggressive in that respect
        cache: false,
        data: { id: id },
        success: function (data) {
            $("#individualBill").html(data);
        }
    });
}