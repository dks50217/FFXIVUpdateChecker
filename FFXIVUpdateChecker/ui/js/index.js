let vm = new Vue({
    mixins: [mixin],
    data() {
        return {
            form: {
                old_path: "",
                new_path: ""
            }
        }
    },
    components: {
       
    },
    created() {

    },
    computed: {

    },
    methods: {
        onSubmit(){
            vm.callAPI('../Check',this.form).load.then(function (response) {
                console.log('result', response);
            });            
        },
    },
    mounted() {
       
    },
    el: "#app"
})