$(document).ready(function () {
    if ($('#ContentPlaceHolder1_ddlInputField').find(':selected').data('multi') == 'False')
        $('#ContentPlaceHolder1_txtDataQuery').prop('disabled', true);

    $('#ContentPlaceHolder1_ddlInputField').change(function () {
        if ($(this).find(':selected').data('multi') == 'False') {
            $('#ContentPlaceHolder1_txtDataQuery').prop('disabled', true);
        } else {
            $('#ContentPlaceHolder1_txtDataQuery').prop('disabled', false);
        }
    });
});