$(function () {
    configureCheckbox();
})

function configureCheckbox() {
    $("#datetimepickerMin").datetimepicker({
        locale: "pl",
        format: "DD.MM.YYYY"
    });
    $("#datetimepickerMax").datetimepicker({
        locale: "pl",
        format: "DD.MM.YYYY",
        useCurrent: false //Important! See issue #1075
    });
    $("#datetimepickerMin").on("dp.change", function (e) {
        $("#datetimepickerMax").data("DateTimePicker").minDate(e.date);
    });
    $("#datetimepickerMax").on("dp.change", function (e) {
        $("#datetimepickerMin").data("DateTimePicker").maxDate(e.date);
    });
};