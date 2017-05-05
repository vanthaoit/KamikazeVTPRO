(function () {
    'use strict';
    angular.module('kamikazeVTPRO.products', ['kamikazeVTPRO.common'])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: '/products',
            parent:'base',
            templateUrl: "/App/Backend/Components/Products/productListView.html",
            controller:"ProductListCtrl"
        }).state('product_add', {
            url: '/product_add',
            parent: 'base',
            templateUrl: "/App/Backend/Components/Products/productAddView.html",
            controller: "ProductAddCtrl"
        }).state('product_update', {
            url: '/product_update/:id',
            parent:'base',
            templateUrl: "/App/Backend/Components/Products/productUpdateView.html",
            controller:"ProductUpdateCtrl"
            });
        

    }


})();