const { required } = window.validators;
const masterUserRoleMap = new Vue({
    el: '#masterUserRoleMap',
    data: {
        form: {
            id: 0,
            roleId: null,
            credentialId: null
        },
        formType: form_add,
        userList: {},
        roleList: {},
        userRoleList: {},
        showForm: false,
        searchTerm: null
    },
    mounted() {
        axios.all([this.getUser(), this.getRole(), this.getUserRole()]);
    },
    created() {

    },
    validations: {
        form: {
            roleId: { required },
            credentialId: { required }
        }
    },
    methods: {
        getUser() {
            axios.get('/user', {
                params: {
                    limit: 50
                }
            }).then(({ data }) => {
                this.userList = data.listData.items;
            });
        },
        getRole() {
            axios.get('/role', {
                params: {
                    limit: 50
                }
            }).then(({ data }) => {
                this.roleList = data.listData.items;
            });
        },
        getUserRole() {
            axios.get('/user-role').then(({ data }) => {
                this.userRoleList = data.listData.items;
            });
        },
        formCancel() {
            this.showForm = false;
        },
        setForm(item) {
            const { credentialId, roleId, id } = item;

            this.form.id = id;
            this.form.credentialId = credentialId;
            this.form.roleId = roleId;

        },
        createClick() {
            this.formType = form_add;
            this.showForm = true;
            this.formReset();
        },
        editClick(item) {
            this.formType = form_edit;
            this.showForm = true;
            this.setForm(item);
        },
        viewClick(item) {
            this.formType = form_view;
            this.showForm = true;
            this.setForm(item);
        },
        deleteClick({ id }) {
            let _this = this;
            let url = '/user-role';
            let param = {
                id: id
            };
            const callback = function () {
                _this.getUserRole();
            }

            this.$confirmDelete(url, param, callback);
        },
        searchMenu() {
            axios.get('/user-role', {
                params: {
                    term: this.searchTerm
                }
            }).then(({ data }) => {
                this.userRoleList = data.listData.items;
            });
        },
        submit() {
            if (this.formType === form_add) {
                axios({
                    method: 'post',
                    url: '/user-role',
                    data: this.form
                }).then(({ data }) => {
                    let status = data.status ? 1 : 0;
                    this.$alertMessage(data.message, status, this.formCloseCallback(status));
                    if (status)
                        this.getUserRole();
                }).catch((response) => {
                    this.$alertMessage(this.$lang.ERROR0000, 0, this.formCloseCallback(0));
                });
            } else {
                axios({
                    method: 'put',
                    url: `/user-role/${this.form.id}`,
                    data: this.form
                }).then(({ data }) => {
                    let status = data.status ? 1 : 0;
                    this.$alertMessage(data.message, status, this.formCloseCallback(status));
                    if (status)
                        this.getUserRole();
                }).catch(({ data }) => {
                    this.$alertMessage(this.$lang.ERROR0000, 0, this.formCloseCallback(0));
                });
            }
        },
        formReset() {
            this.form.credentialId = null;
            this.form.roleId = null;
        },
        formCloseCallback: function (type) {
            if (type !== form_add) {
                this.formCancel();
                this.formReset();
            }
        }
    },
});