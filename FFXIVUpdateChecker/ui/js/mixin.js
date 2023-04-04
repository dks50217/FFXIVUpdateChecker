const mixin = {
    data: function () {
        return {
            
        }
    },
    methods: {
        sleep(ms) {
            return new Promise(resolve => setTimeout(resolve, ms));
        },
        callAPI(oUrl, oData) {
            const request = axios({
                method: 'POST',
                url: oUrl,
                data: oData
            }).then(function (response) {
                return response.data;
            }).catch(function (error) {
                console.log(error)
            })
        
            return {
                load: request
            };
        }
    }
}