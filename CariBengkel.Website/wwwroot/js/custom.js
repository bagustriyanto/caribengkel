/**
 *
 * You can write your JS code here, DO NOT touch the default style file
 * because it will make it harder for you to update.
 * 
 */
var mainApp = new Vue({
    el: "#app-main",
    data: {
        jquery: $,
        title: "EveryDay",
        isMenuShow: false,
        toContainer: false
    },
    mounted() {

    },
    created() {

    },
    methods: {
        menuShow: function () {
            var _ = this;
            _.isMenuShow = true;
        },
        menuHide: function () {
            var _ = this;
            if (!_.toContainer)
                _.isMenuShow = false;
        },
        menuContainerOver: function () {
            var _ = this;
            _.toContainer = false;
        }
    }
});
