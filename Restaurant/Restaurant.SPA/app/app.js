var app = angular.module("restaurant-APP", [
    "ngRoute",
    "ngResource"
    //"ngCookies"
]);
(function () {
    "use strict";
    app.config(function ($routeProvider) {
        $routeProvider
        .when("/", {
            templateUrl: "app/views/home/index.html",
            controller: "HomeController"
        })
        .when("/categories", {
            templateUrl: "app/views/categories/index.html",
            controller: "CategoryController"
        })
        .when("/category-create/", {
            templateUrl: "app/views/categories/create.html",
            controller: "CreateCategoryController"
        })
        .when("/category-detail/:id", {
            templateUrl: "app/views/categories/detail.html",
            controller: "DetailCategoryController"
        })
        .when("/category-edit/:id", {
            templateUrl: "app/views/categories/edit.html",
            controller: "EditCategoryController"
        })
        .when("/category-delete/:id", {
            templateUrl: "app/views/categories/delete.html",
            controller: "DeleteCategoryController"
        })
        .when("/usertypes", {
            templateUrl: "/app/views/usertypes/index.html",
            controller: "UserTypeController"
        })
        .when("/usertype-create/", {
            templateUrl: "/app/views/usertypes/create.html",
            controller: "CreateUserTypeController"
        })
        .when("/usertype-detail/:id", {
            templateUrl: "app/views/usertypes/detail.html",
            controller: "DetailUserTypeController"
        })
        .when("/usertype-edit/:id", {
            templateUrl: "app/views/usertypes/edit.html",
            controller: "EditUserTypeController"
        })
        .when("/usertype-delete/:id", {
            templateUrl: "app/views/usertypes/delete.html",
            controller: "DeleteUserTypeController"
        })
        .when("/foodmenu", {
            templateUrl: "app/views/foodmenu/index.html",
            controller: "FoodMenuController"
        })
        .when("/foodmenu-create/", {
            templateUrl: "app/views/foodmenu/create.html",
            controller: "CreateFoodMenuController"
        })
        .when("/foodmenu-detail/:id", {
            templateUrl: "app/views/foodmenu/detail.html",
            controller: "DetailFoodMenuController"
        })
        .when("/foodmenu-edit/:id", {
            templateUrl: "app/views/foodmenu/edit.html",
            controller: "EditFoodMenuController"
        })
        .when("/foodmenu-delete/:id", {
            templateUrl: "app/views/foodmenu/delete.html",
            controller: "DeleteFoodMenuController"
        })
        .when("/users", {
            templateUrl: "app/views/users/index.html",
            controller: "UserController"
        })
        .when("/user-create/", {
            templateUrl: "app/views/users/create.html",
            controller: "CreateUserController"
        })
        .when("/user-detail/:id", {
            templateUrl: "app/views/users/detail.html",
            controller: "DetailUserController"
        })
        .when("/user-edit/:id", {
            templateUrl: "app/views/users/edit.html",
            controller: "EditUserController"
        })
        .when("/user-delete/:id", {
            templateUrl: "app/views/users/delete.html",
            controller: "DeleteUserController"
        })
        .when("/orders", {
            templateUrl: "app/views/orders/index.html",
            controller: "OrderController"
        })
        .when("/order-create/", {
            templateUrl: "app/views/orders/create.html",
            controller: "CreateOrderController"
        })
        .when("/order-detail/:id", {
            templateUrl: "app/views/orders/detail.html",
            controller: "DetailOrderController"
        })
        .when("/order-edit/:id",
        {
            templateUrl: "app/views/orders/edit.html",
            controller: "EditOrderController"
        })
        .when("/order-delete/:id",
        {
            templateUrl: "app/views/orders/delete.html",
            controller: "DeleteOrderController"
        })
        .when("/salecontrol", {
            templateUrl: "/app/views/salecontrol/index.html",
            controller: "SaleControlController"
        })
        .when("/salecontrol-create/", {
            templateUrl: "/app/views/salecontrol/create.html",
            controller: "CreateSaleControlController"
        })
        .when("/salecontrol-detail/:id",
        {
            templateUrl: "/app/views/salecontrol/detail.html",
            controller: "DetailSaleControlController"
        })
        .when("/salecontrol-edit/:id",
        {
            templateUrl: "/app/views/salecontrol/edit.html",
            controller: "EditSaleControlController"
        }
        )
        .when("/salecontrol-delete/:id", {
            templateUrl: "/app/views/salecontrol/delete.html",
            controller: "DeleteSaleControlController"
        });
    });
})();