const masterMenuRoleMap = new Vue({
    el: '#masterMenuRoleMap',
    data: {
        form: {
            menuMapList: []
        },
        showForm: false,
        formType: form_add,
        menuRoleList: {},
        roleList: {},
        menuList: {},
        searchTerm: null
    },
    created() {

    },
    mounted() {
        axios.all([this.getRole(), this.getMenu()]);
    },
    methods: {
        getRole() {
            axios.get('/role', {
                params: {
                    limit: 10
                }
            }).then(({ data }) => {
                var list = data.listData.items.filter(function (value, index) {
                    return value.status === true;
                });
                this.roleList = list;
                this.menuRoleList = list;
            });
        },
        getMenu() {
            axios.get('/menu', {
                params: {
                    limit: 50
                }
            }).then(({ data }) => {
                this.menuList = data.listData.items.filter(function (value, index) {
                    return value.status === true
                });
            });
        },
        formCancel() {
            this.showForm = false;
        },
        setForm(item) {
            const self = this;
            const { id } = item;

            self.form.roleId = id;

            axios.get(`/menu-role/${id}`).then(({ data }) => {
                self.menuList = self.menuList.map(function (menu) {
                    return {
                        id: menu.id,
                        title: menu.title,
                        checked: data.listData.items.filter(function (value) {
                            return value.menuId === menu.id
                        }).length > 0 ? true : false
                    }
                })
                self.showForm = true;
            });

        },
        createClick() {
            this.formType = form_add;
            this.showForm = true;
            this.formReset();
        },
        editClick(item) {
            this.formType = form_edit;
            this.setForm(item);
        },
        viewClick(item) {
            this.formType = form_view;
            this.setForm(item);
        },
        deleteClick({ id }) {
            let _this = this;
            let url = '/menu-role';
            let param = {
                id: id
            };
            const callback = function () {
                _this.getUserRole();
            }

            this.$confirmDelete(url, param, callback);
        },
        searchMenu() {
            axios.get('/menu-role', {
                params: {
                    term: this.searchTerm
                }
            }).then(({ data }) => {
                this.userRoleList = data.listData.items;
            });
        },
        submit() {
            if (this.formType === form_add || this.formType === form_edit) {
                var self = this;
                $.each(self.menuList, function (index, { checked, id }) {
                    self.form.menuMapList.push({ checked: checked, menuRoleMap: { menuId: id, roleId: self.form.roleId, id: 0 } });
                });

                axios({
                    method: 'post',
                    url: '/menu-role',
                    data: self.form.menuMapList
                }).then(({ data }) => {
                    let status = data.status ? 1 : 0;
                    this.$alertMessage(data.message, status, this.formCloseCallback(status));
                }).catch((response) => {
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
    }
})