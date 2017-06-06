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

function setDefaultDateTimePicker() {
    $("#datetimepicker").datetimepicker({
        locale: "pl",
        format: "DD.MM.YYYY"
    });
};
