$(function () {
    configureAddBill();
})

function configureAddBill() {

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
    $('#cancelEdit').on('click', function () {
        $('form').attr('action', 'Home/Index')
    });
};