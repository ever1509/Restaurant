(function () {
    "use strict";

    app.controller("FoodMenuController", FoodMenuController);
    app.controller("CreateFoodMenuController", CreateFoodMenuController);
    app.controller("DetailFoodMenuController", DetailFoodMenuController);
    app.controller("EditFoodMenuController", EditFoodMenuController);
    app.controller("DeleteFoodMenuController", DeleteFoodMenuController);
    FoodMenuController.$inject = ["$log", "$scope", "$location", "FoodMenuService"];
    CreateFoodMenuController.$inject = ["$log", "$scope", "$location", "FoodMenuService", "CategoryService"];
    DetailFoodMenuController.$inject = ["$log", "$scope", "$location", "$routeParams", "FoodMenuService", "CategoryService"];
    EditFoodMenuController.$inject = ["$log", "$scope", "$location", "$routeParams", "FoodMenuService", "CategoryService"];
    DeleteFoodMenuController.$inject = ["$log", "$scope", "$location", "$routeParams", "FoodMenuService"];


    function FoodMenuController($log, $scope, $location, foodmenuService) {
        $scope.result = {};
        foodmenuService.getAll().then(function (result) {
            $scope.result = result.data;
        });

        $scope.create = function () {
            $location.path("/foodmenu-create/");
        }
        $scope.detail = function (item) {
            $location.path("/foodmenu-detail/" + item.foodMenuID);
        }
        $scope.edit = function (item) {
            $location.path("/foodmenu-edit/" + item.foodMenuID);
        }
        $scope.delete = function (item) {
            $location.path("/foodmenu-delete/" + item.foodMenuID);
        }

    };

    function CreateFoodMenuController($log, $scope, $location, foodmenuService, categoryService) {
        $scope.result = {};
        $scope.categoryResult = {};

        categoryService.getAll().then(function (result) {
            $scope.categoryResult = result.data;
        });
        $scope.create = function () {
            foodmenuService.post($scope.result.model).then(function (result) {
                if (result.data.didError) {
                    console.log(result.data);
                    $scope.result = result.data;
                }
                else {
                    $location.path("/foodmenu");
                }
            });
        }
        $scope.cancel = function () {
            $location.path("/foodmenu");
        }
    }

    function DetailFoodMenuController($log, $scope, $location, $routeParams, foodmenuService, categoryService) {
        $scope.result = {};
        var id = $routeParams.id;
        foodmenuService.get(id).then(function (result) {
            $scope.result = result.data;
        });

        $scope.backlist = function () {
            $location.path("/foodmenu");
        }
    }

    function EditFoodMenuController($log, $scope, $location, $routeParams, foodmenuService, categoryService) {
        $scope.result = {};
        $scope.categoryResult = {};

        categoryService.getAll().then(function (result) {
            $scope.categoryResult = result.data;
        });
        var id = $routeParams.id;
        foodmenuService.get(id).then(function (result) {
            $scope.result = result.data;
        });

        $scope.update = function () {
            foodmenuService.put(id, $scope.result.model).then(function (result) {
                $scope.result = resul.data;
                $location.path("/foodmenu");
            });
        };
        $scope.cancel = function (result) {
            $location.path("/foodmenu");
        };
    }

    function DeleteFoodMenuController($log, $scope, $location, $routeParams, foodmenuService) {
        $scope.result = {};
        var id = $routeParams.id;
        foodmenuService.get(id).then(function (result) {
            $scope.result = result.data;
        });

        $scope.delete = function () {
            foodmenuService.delete(id).then(function (result) {
                $scope.result = result.data;
                $location.path("/foodmenu");
            });
        };
        $scope.cancel = function () {
            $location.path("/foodmenu");
        };
    }

})();