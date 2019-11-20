const masterMenu = new Vue({
    el: '#masterMenu',
    data: {
        formType: 0,
        form: {
            title: null,
            url: null,
            status: false,
            parent: null,
            id: 0,
            cbStatus: "0"
        },
        list: {

        },
        validate: {
            title: false,
            url: false
        },
        showForm: false,
        btnShowModal: null,
        formTitle: null,
        searchTerm: null
    },
    mounted() {
        this.getAll();
    },
    created() {

    },
    computed: {
        titleValidation: function () {
            if (this.form.title === null || this.form.title === '')
                return true;

            return false;
        },
        urlValidation: function () {
            if (this.form.url === null || this.form.url === '')
                return true;

            return false;
        }
    },
    methods: {
        createClick: function () {
            this.formType = 0;
            this.showForm = true;
            this.formTitle = 'Buat Menu';
            this.formReset();
        },
        editClick: function (item) {
            this.formType = 1;
            this.showForm = true;
            this.formTitle = 'Ubah Menu';
            this.form = item;
            this.form.cbStatus = item.status === false ? '0' : '1'
        },
        viewClick: function (item) {
            this.formType = 2;
            this.showForm = true;
            this.formTitle = 'Lihat Menu';
            this.form = item;
            this.form.cbStatus = item.status === false ? '0' : '1'
        },
        onSubmit: function () {
            this.form.status = this.form.cbStatus === '0' ? false : true;
            if (this.formType === 0) {
                ajax.post('/menuapi', this.form)
                    .then((response) => {
                        alertMessage(response.data.message, 1, this.formCloseCallback(1));
                        this.getAll();
                    }).catch((response) => {
                        alertMessage(ERROR_MESSAGE, 0, this.formCloseCallback(0));
                    });
            } else {
                ajax.put(`/menuapi/${this.form.id}`, this.form)
                    .then((response) => {
                        alertMessage(response.data.message, 1, this.formCloseCallback(1));
                        this.getAll();
                    }).catch((response) => {
                        alertMessage(ERROR_MESSAGE, 0, this.formCloseCallback(0));
                    });
            }

        },
        getAll: function () {
            ajax.get('/menuapi').then((response) => {
                this.list = response.data.listData.items;
            }).catch((response) => {

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
            this.form.title = '';
            this.form.url = '';
            this.form.parent = '';
            this.form.cbStatus = '0';
        },
        searchMenu: function () {

        }
    }
});