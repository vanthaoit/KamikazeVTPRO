(function () {
    'use strict';
    angular.module('kamikazeVTPRO.productCategories', ['kamikazeVTPRO.common'])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: '/product_categories',
            parent: 'base',
            templateUrl: '/App/Backend/ProductCategories/productCategoryListView.html',
            controller: 'ProductCategoryListCtrl'
        }).state('product_category_add', {
            url: '/product_category_add',
            parent: 'base',
            templateUrl: '/App/Backend/ProductCategories/productCategoryAddView.html',
            controller: 'ProductCategoryAddCtrl'
        }).state('product_category_update', {
            url: '/product_category_update/:id',
            parent: 'base',
            templateUrl: '/App/Backend/ProductCategories/productCategoryUpdateView.html',
            controller: 'ProductCategoryUpdateCtrl'
            });
        
    }
})();