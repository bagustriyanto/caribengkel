const { required, minLength } = window.validators;

var login = new Vue({
    el: '#login',
    data: {
        form: {
            username: null,
            password: null
        },
        loginSuccess: false,
        formTriggered: false
    },
    validations: {
        form: {
            username: { required },
            password: { required, minLength: minLength(password_length) }
        }
    },
    methods: {
        submit: function () {
            axios({
                method: 'post',
                url: '/auth/login',
                data: this.form,
            }).then(({ data }) => {
                if (data.status) {
                    this.$cookies.set('token', data.token);
                    this.$cookies.set('username', this.form.username);

                    let windowSearch = decodeURIComponent(window.location.search).split('=');
                    let returnUrl = windowSearch[windowSearch.length - 1];
                    if (returnUrl == '')
                        window.location.replace(`${baseUrl}`);
                    else
                        window.location.replace(`${baseUrl}${returnUrl}`);
                }
            })
        }
    }
})