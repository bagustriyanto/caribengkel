"use strict";

const FORM_ADD = 0;
const FORM_EDIT = 1;
const FORM_VIEW = 2;
const FORM_DELETE = 3;
const ERROR_MESSAGE = "Terjadi Kesalahan.";

function checkboxCheckAll() {
    $("[data-checkboxes]").each(function () {
        var me = $(this),
            group = me.data('checkboxes'),
            role = me.data('checkbox-role');

        me.change(function () {
            var all = $('[data-checkboxes="' + group + '"]:not([data-checkbox-role="dad"])'),
                checked = $('[data-checkboxes="' + group + '"]:not([data-checkbox-role="dad"]):checked'),
                dad = $('[data-checkboxes="' + group + '"][data-checkbox-role="dad"]'),
                total = all.length,
                checked_length = checked.length;

            if (role == 'dad') {
                if (me.is(':checked')) {
                    all.prop('checked', true);
                } else {
                    all.prop('checked', false);
                }
            } else {
                if (checked_length >= total) {
                    dad.prop('checked', true);
                } else {
                    dad.prop('checked', false);
                }
            }
        });
    });
}

const alertMessage = function (message, type, callback) {
    let title = null;
    if (callback === null || callback === undefined)
        (callback) => { };

    switch (type) {
        case 0:
            title = 'Error';
            break;
        case 1:
            title = 'Success';
            break;
        case 2:
            title = 'Info';
            break;

    }

    swal({
        title: title,
        text: message,
        icon: title.toLowerCase(),
        buttons: false,
        dangerMode: false,
    }).then(callback);
}

const ajax = axios.create({
    baseURL: 'https://localhost:5001/',
});

