$(function () {
    configureAddBill();
    configureCheckbox();
})

function configureCheckbox() {
    $('#datetimepickerMin').datetimepicker({
        locale: 'pl'
    });
    $('#datetimepickerMax').datetimepicker({
        locale: 'pl',
        useCurrent: false //Important! See issue #1075
    });
    $("#datetimepickerMin").on("dp.change", function (e) {
        $('#datetimepickerMax').data("DateTimePicker").minDate(e.date);
    });
    $("#datetimepickerMax").on("dp.change", function (e) {
        $('#datetimepickerMin').data("DateTimePicker").maxDate(e.date);
    });
};

function configureAddBill() {

    selectedBill();

    $('#buttonAddBill').on('click', function () {
        if ($('#addBill').is(':hidden')) {
            $('#addBill').show();
        }
        else {
            $('#addBill').hide();
        }
    });
}

function configureEditBill() {
    $('#datetimepickerEdit').datetimepicker({
        locale: 'pl'
    });
};

function refreshAddBill() {
    selectedBill();
    $('#addBill').hide();
}

function selectedBill() {
    $('#selectBill').change(function () {
        var value = $('#selectBill').val();

        if (value !== "") {
            var date = $('#' + value).val();
            date = date.split(' ');
            date = date[0].split('-');
            var correctDate = date[2] + "." + date[1] + "." + date[0];

            $('#datetimepicker').datetimepicker({
                locale: 'pl'
            });
            $('#datetimepicker').val('Data wpłaty');

            $('#requiredDate').val(correctDate);
        }
        else {
            $('#datetimepicker').val('Data wpłaty');
            $('#requiredDate').val('Termin zapłaty');
        }
    });
}

