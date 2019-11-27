"use strict";

const form_add = 0;
const form_edit = 1;
const form_view = 2;
const form_delete = 3;
const password_length = 8;
const lang = Vue.prototype.$lang;

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

Vue.prototype.$alertMessage = function (message, type, callback) {
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

Vue.prototype.$confirmDelete = function (url, param, responseCallback) {
    if (param == null)
        param = {};

    swal("Anda yakin untuk menghapus data ini?", {
        buttons: {
            cancel: "Batal",
            catch: {
                text: "Yakin",
                value: "submit",
            }
        },
    }).then((value) => {
        switch (value) {
            case "submit":
                axios.delete(url, {
                    params: param
                }).then(({ data }) => {
                    let status = data.status ? 1 : 0;
                    Vue.prototype.$alertMessage(data.message, status, responseCallback);
                }).catch((response) => {
                    Vue.prototype.$alertMessage(lang.ERROR0000, 0, responseCallback);
                });
                break;
        }
    });
}

axios.defaults.baseURL = 'https://localhost:5001/api/';

Vue.use(window.vuelidate.default);

