(function () {
    "use strict";
    app.controller("CategoryController", CategoryController);
    app.controller("CreateCategoryController", CreateCategoryController);
    app.controller("DetailCategoryController", DetailCategoryController);
    app.controller("EditCategoryController", EditCategoryController);
    app.controller("DeleteCategoryController", DeleteCategoryController);
    CategoryController.$inject = ["$log", "$scope", "$location", "CategoryService"];
    CreateCategoryController.$inject = ["$log", "$scope", "$location", "CategoryService"];
    DetailCategoryController.$inject = ["$log", "$scope", "$location", "$routeParams", "CategoryService"];
    EditCategoryController.$inject = ["$log", "$scope", "$location", "$routeParams", "CategoryService"];
    DeleteCategoryController.$inject = ["$log", "$scope", "$location", "$routeParams", "CategoryService"];
    function CategoryController($log, $scope, $location, categoryService) {
        $scope.result = {};
        categoryService.getAll().then(function (result) {
            $scope.result = result.data;
        });
        $scope.create = function () {
            $location.path("/category-create/");
        };
        $scope.detail = function (item) {
            $location.path("/category-detail/" + item.categoryID);
        };
        $scope.edit = function (item) {
            $location.path("/category-edit/" + item.categoryID)
        };
        $scope.delete = function (item) {
            $location.path("/category-delete/" + item.categoryID);
        };
    };
    function CreateCategoryController($log, $scope, $location, categoryService) {
        $scope.result = {};
        $scope.create = function () {
            categoryService.post($scope.result.model).then(function (result) {
                if (result.data.didError) {
                    $scope.result = result.data;
                } else {
                    $location.path("/categories");
                }
            });
        };
        $scope.cancel = function () {
            $location.path("/categories");
        };
    };
    function DetailCategoryController($log, $scope, $location, $routeParams, categoryService) {
        $scope.result = {};
        var id = $routeParams.id;
        categoryService.get(id).then(function (result) {
            $scope.result = result.data;
        });

        $scope.backlist = function () {
            $location.path("/categories");
        };
    };
    function EditCategoryController($log, $scope, $location, $routeParams, categoryService) {
        $scope.result = {};
        var id = $routeParams.id;

        categoryService.get(id).then(function (result) {
            $scope.result = result.data;
        });
        $scope.update = function () {
            categoryService.put(id, $scope.result.model).then(function (result) {
                $location.path("/categories");
            });
        };
        $scope.cancel = function () {
            $location.path("/categories");
        };
    };
    function DeleteCategoryController($log, $scope, $location, $routeParams, categoryService) {
        $scope.result = {};
        var id = $routeParams.id;
        categoryService.get(id).then(function (result) {
            $scope.result = result.data;
        });

        $scope.delete = function () {
            categoryService.delete(id).then(function (result) {
                $location.path("/categories");
            });
        };
        $scope.cancel = function () {
            $location.path("/categories");
        };
    };
})();