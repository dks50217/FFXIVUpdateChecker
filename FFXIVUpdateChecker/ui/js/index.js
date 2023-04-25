let vm = new Vue({
    mixins: [mixin],
    data() {
        return {
            form: {
                old_path: "",
                new_path: "",
            },
            loading : false,
            tableColumns: [
                { label: 'FILE NAME', prop: 'FileName' },
                { label: 'ADD', prop: 'AddedItems', type: 'count' },
                { label: 'UPDATE', prop: 'UpdatedItems', type: 'count' },
                { label: 'REMOVE', prop: 'RemovedItems', type: 'count' },
            ],
            tableData: [],
            options: [
                { label: 'AddedItems', value: 'AddedItems' },
                { label: 'RemovedItems', value: 'RemovedItems' },
                { label: 'UpdatedItems', value: 'UpdatedItems' }
            ],
            actionType: "AddedItems"
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
            let _self = this;
            _self.loading = true;
            vm.callAPI('../Check', this.form).load.then(function (response) {
                console.log('result', response);
                _self.tableData = response;
                _self.loading = false;
            });
        },
        getCount(row, prop) {
            let _self = this;
            return row.CompareList.filter(c => c.ActionType == prop).length;
        }
    },
    mounted() {
       
    },
    el: "#app"
})