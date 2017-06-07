$(function () {
    var defaultAddBill;
    saveDefaultAddBill();
})

function configureAddBill() {
    $("#selectBill").change(function () {
        var value = $("#selectBill").val();

        if (value !== "") {
            var date = $("#" + value).val();
            date = date.split(" ");
            date = date[0].split("-");
            var correctDate = date[2] + "." + date[1] + "." + date[0];

            $("#paymentDate").datetimepicker({
                locale: "pl",
                format: "DD.MM.YYYY"
            });
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

function saveDefaultAddBill() {
    defaultAddBill = $("#addBill").html();
};

function undoToDefaultAddBill() {
    $("#addBill").html(defaultAddBill);
};

function setDefaultDateTimePicker(datetimepicker) {
    $("#" + datetimepicker).datetimepicker({
        locale: "pl",
        format: "DD.MM.YYYY"
    });
};
