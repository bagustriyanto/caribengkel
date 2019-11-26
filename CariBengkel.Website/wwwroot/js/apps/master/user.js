const { required, minLength, email } = window.validators;

const masterUser = new Vue({
    el: '#masterUser',
    data: {
        formType: 0,
        form: {
            credential: {
                username: null,
                password: null,
                email: null,
                id: 0
            },
            firstname: null,
            lastname: null,
            phone: null,
            status: false,
            id: 0,
            cbStatus: "0"
        },
        list: {
        },
        cbMenuList: {},
        showForm: false,
        btnShowModal: null,
        formTitle: null,
        formValid: false,
        searchTerm: null,
        paging: {
            page: 0,
            perPage: 0
        }
    },
    validations: {
        form: {
            firstname: {
                required
            },
            credential: {
                username: { required },
                email: {
                    required, email
                },
                password: { required, minLength: minLength(8) }
            }
        }
    },
    mounted() {
        axios.all([this.getAll()]);
    },
    created() {

    },
    computed: {
        submitDisabled: function () {
            if (this.formType === 0)
                return this.$v.$invalid
            else if (this.formType === 1) {
                let disabled = false;
                if (!this.$v.form.firstname.required || !this.$v.form.credential.username.required || !this.$v.form.credential.email.email || !this.$v.form.credential.email.required)
                    disabled = true;

                return disabled;
            }
        }
    },
    methods: {
        createClick: function () {
            this.formType = 0;
            this.showForm = true;
            this.formReset();
        },
        editClick: function (item) {
            this.formType = 1;
            this.showForm = true;
            this.setForm(item);
            this.form.cbStatus = item.idCredentialNavigation.status === false ? '0' : '1'
        },
        viewClick: function (item) {
            this.formType = 2;
            this.showForm = true;
            this.setForm(item);
            this.form.cbStatus = item.idCredentialNavigation.status === false ? '0' : '1'
        },
        onSubmit: function () {
            this.form.credential.status = this.form.cbStatus === '0' ? false : true;

            if (this.formType === 0) {
                axios({
                    method: 'post',
                    url: '/user',
                    data: this.form
                }).then(({ data }) => {
                    let status = data.status ? 1 : 0;
                    alertMessage(data.message, status, this.formCloseCallback(status));
                    this.getAll();
                }).catch((response) => {
                    alertMessage(this.$lang.ERROR0000, 0, this.formCloseCallback(0));
                });
            } else {
                axios({
                    method: 'put',
                    url: `/user/${this.form.id}`,
                    data: this.form
                }).then(({ data }) => {
                    let status = data.status ? 1 : 0;
                    alertMessage(data.message, status, this.formCloseCallback(status));
                    this.getAll();
                }).catch(() => {
                    alertMessage(this.$lang.ERROR0000, 0, this.formCloseCallback(0));
                });
            }

        },
        getAll: function () {
            axios.get('/user').then(({ data }) => {
                this.list = data.listData.items;
            });
        },
        formCloseCallback: function (type) {
            if (type !== 0) {
                this.formCancel();
                this.formReset();
            }
        },
        formCancel: function () {
            this.showForm = false;
        },
        formReset: function () {
            this.form.credential.username = '';
            this.form.credential.password = '';
            this.form.credential.status = false;
            this.form.credential.email = '';
            this.form.firstname = '';
            this.form.lastname = '';
            this.form.phone = '';
            this.form.cbStatus = '0';
        },
        searchMenu: function () {
            axios.get('/role', {
                params: {
                    title: this.searchTerm
                }
            }).then(({ data }) => {
                this.list = data.listData.items;
            });
        },
        setForm: function (item) {
            const { idCredentialNavigation, firstName, lastName, phone, id } = item;

            this.form.credential.username = idCredentialNavigation.username;
            this.form.credential.email = idCredentialNavigation.email;
            this.form.credential.id = idCredentialNavigation.id;
            this.form.id = id;
            this.form.firstname = firstName;
            this.form.lastname = lastName;
            this.form.phone = phone
            this.form.cbStatus = idCredentialNavigation.status ? '1' : '0';
        }
    }
});