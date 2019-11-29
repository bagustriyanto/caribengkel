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
                    window.location.replace(`${baseUrl}/system/master/user`);
                }
            })
        }
    }
})