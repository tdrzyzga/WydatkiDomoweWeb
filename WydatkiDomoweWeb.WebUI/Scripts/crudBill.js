﻿$(function () {
    configureCheckbox();
    var defaultAddBill;
    saveDefaultAddBill();
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

function configureEditBill() {
    $("#datetimepickerEdit").datetimepicker({
        locale: "pl",
        format: "DD.MM.YYYY"
    });
};

function configureAddBill() {
    $("#selectBill").change(function () {
        var value = $("#selectBill").val();

        if (value !== "") {
            var date = $("#" + value).val();
            date = date.split(" ");
            date = date[0].split("-");
            var correctDate = date[2] + "." + date[1] + "." + date[0];

            $("#datetimepicker").datetimepicker({
                locale: "pl",
                format: "DD.MM.YYYY"
            });
            $("#datetimepicker").val("Data wpłaty");

            $("#requiredDate").val(correctDate);
        }
        else {
            $("#datetimepicker").val("Data wpłaty");
            $("#requiredDate").val("Termin zapłaty");
        }
    });
};

function saveDefaultAddBill() {
    defaultAddBill = $("#addBill").html();
};

function undoToDefaultAddBill() {
    $("#addBill").html(defaultAddBill);
};

