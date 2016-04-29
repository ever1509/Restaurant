(function () {
    "use strict";

    app.controller("FoodMenuController", FoodMenuController);
    FoodMenuController.$inject = ["$log", "$scope", "$location", "FoodMenuService"];

    function FoodMenuController($log, $scope, $location, foodmenuService) {
        $scope.result = {};

        foodmenuService.getAll().then(function (result) {
            $scope.result = result.data;
        });

        $scope.create = function () {
            $location.path("/foodmenu-create/");
        };
        $scope.detail = function (item) {
            $location.path("/foodmenu-detail/"+item.foodMenuID);
        }
        $scope.edit = function (item) {
            $location.path("/foodmenu-edit/" + item.foodMenuID);
        };
        $scope.delete = function (item) {
            $location.path("/foodmenu-delete/" + item.foodMenuID);
        };
    };

})();