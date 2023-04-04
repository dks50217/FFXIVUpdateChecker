const router = new VueRouter({
    routes: [
        {
            path: '/',
            name: 'index',
            component: httpVueLoader('./Component/test.vue')
        }
    ]
})