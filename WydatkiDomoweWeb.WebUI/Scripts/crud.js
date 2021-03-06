﻿$(function () {
    var defaultAddItem;
    saveDefaultAddItem();
})

function configureAddBill() {
    setDefaultDateTimePicker("paymentDate");

    $("#selectBill").change(function () {
        var value = $("#selectBill").val();

        if (value !== "") {
            var date = $("#" + value).val();
            date = date.split(" ");
            date = date[0].split("-");
            var correctDate = date[2] + "." + date[1] + "." + date[0];

            $("#paymentDate").attr("placeholder", "Data wpłaty");

            $("#requiredDate").val(correctDate);
        }
        else {
            $("#paymentDate").attr("placeholder", "Data wpłaty");
            $("#paymentDate").val("");

            $("#requiredDate").attr("placeholder", "Termin zapłaty");
            $("#requiredDate").val("");            
        }
    });
};

function saveDefaultAddItem() {
    defaultAddItem = $("#addItem").html();
};

function undoToDefaultAddItem() {
    $("#addItem").html(defaultAddItem);
};

function setDefaultDateTimePicker(datetimepicker) {
    $("#" + datetimepicker).datetimepicker({
        locale: "pl",
        format: "DD.MM.YYYY"
    });
};

function hideModal() {
    $("body").removeClass("modal-open");
    $(".modal-backdrop").remove();
};
