const masterRole = new Vue({
    el: '#masterRole',
    data: {
        formType: 0,
        form: {
            name: null,
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
        searchTerm: null,
        paging: {
            page: 0,
            perPage: 0
        }
    },
    mounted() {
        axios.all([this.getAll()]);
    },
    created() {

    },
    computed: {
        nameValidation: function () {
            if (this.form.title === null || this.form.title === '')
                return true;

            return false;
        }
    },
    methods: {
        createClick: function () {
            this.formType = form_add;
            this.showForm = true;
            this.formReset();
        },
        editClick: function (item) {
            this.formType = form_edit;
            this.showForm = true;
            this.setForm(item);
            this.form.cbStatus = item.status === false ? '0' : '1'
        },
        viewClick: function (item) {
            this.formType = form_view;
            this.showForm = true;
            this.setForm(item);
            this.form.cbStatus = item.status === false ? '0' : '1'
        },
        onSubmit: function () {
            this.form.status = this.form.cbStatus === '0' ? false : true;

            if (this.formType === 0) {
                axios.post('/role', this.form)
                    .then(({ data }) => {
                        let status = data.status ? 1 : 0;
                        alertMessage(data.message, status, this.formCloseCallback(status));
                        this.getAll();
                    }).catch((response) => {
                        alertMessage(this.$lang.ERROR0000, 0, this.formCloseCallback(0));
                    });
            } else {
                axios.put(`/role/${this.form.id}`, this.form)
                    .then(({ data }) => {
                        let status = data.status ? 1 : 0;
                        alertMessage(data.message, status, this.formCloseCallback(status));
                        this.getAll();
                    }).catch(() => {
                        alertMessage(this.$lang.ERROR0000, 0, this.formCloseCallback(0));
                    });
            }

        },
        getAll: function () {
            axios.get('/role').then(({ data }) => {
                this.list = data.listData.items;
            });
        },
        formCloseCallback: function (type) {
            if (type !== form_add) {
                this.formCancel();
                this.formReset();
            }
        },
        formCancel: function () {
            this.showForm = false;
        },
        formReset: function () {
            this.form.title = '';
            this.form.url = '';
            this.form.parent = '';
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
        setForm: function ({ id, name, status }) {
            this.form.id = id;
            this.form.name = name;
            this.form.cbStatus = status ? '1' : '0'
        }
    }
});