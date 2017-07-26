$(function () {
    $("#selectBill").change(function () {
        var billNameId = $("#selectBill").val();

        $.ajax({
            url: "Charts/GetSeriesData",
            type: 'POST',
            dataType: "json",
            // we set cache: false because GET requests are often cached by browsers
            // IE is particularly aggressive in that respect
            cache: false,
            data: { billNameId: billNameId },
            success: function (data) {
                updateChart(data);
            }
        });
    });
})

function updateChart(data) {    
    var chart = $("#MonthlyChartForIndividualBills").highcharts();
    
    var billName = $("#selectBill option:selected").text();

    chart.setTitle({ text: "Wydatki miesięczne za " + "<b>" + billName + "</b>" });

    while (chart.series.length > 0)
        chart.series[0].remove();

    for (var i = 0; i < data.length; i++) {
        chart.addSeries({ name: data[i].Name, data: data[i].Data }, false);
    }

    chart.redraw();
}