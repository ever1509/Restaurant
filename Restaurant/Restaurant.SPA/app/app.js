var app = angular.module("restaurant-APP", [
    "ngRoute",
    "ngResource"
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
            controller:"DeleteUserTypeController"
        })
        .when("/users", {
            templateUrl: "/app/views/foodmenu/index.html",
            controller:"FoodMenuController"
        });
    });
})();