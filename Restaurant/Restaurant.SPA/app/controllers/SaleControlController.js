(function () {
    "use strict";
    app.controller("SaleControlController", SaleControlController);
    app.controller("CreateSaleControlController", CreateSaleControlController);
    app.controller("DetailSaleControlController", DetailSaleControlController);
    app.controller("EditSaleControlController", EditSaleControlController);
    app.controller("DeleteSaleControlController", DeleteSaleControlController);
    SaleControlController.$inject = ["$log", "$scope", "$location", "SaleControlService"];
    CreateSaleControlController.$inject = ["$log", "$scope", "$location", "SaleControlService", "FoodMenuService", "OrderService"];
    DetailSaleControlController.$inject = ["$log", "$scope", "$location","$routeParams", "SaleControlService"];
    EditSaleControlController.$inject = ["$log", "$scope", "$location", "$routeParams", "SaleControlService", "FoodMenuService", "OrderService"];
    DeleteSaleControlController.$inject = ["$log", "$scope", "$location", "$routeParams", "SaleControlService"];

    function SaleControlController($log, $scope, $location, salecontrolService) {
        $scope.result = {};
        salecontrolService.getAll().then(function (result) {
            $scope.result = result.data;
        });
        $scope.create = function () {
            $location.path("/salecontrol-create/");
        };
        $scope.detail = function (item) {
            $location.path("/salecontrol-detail/" + item.saleControlID);
        };
        $scope.edit = function (item) {
            $location.path("/salecontrol-edit/" + item.saleControlID);
        };
        $scope.delete = function (item) {
            $location.path("/salecontrol-delete/" + item.saleControlID);
        }
    }
    function CreateSaleControlController($log, $scope, $location, salecontrolService,foodmenuService,orderService) {
        $scope.result = {};
        $scope.foodmenuResult = {};
        $scope.orderResult = {};
        foodmenuService.getAll().then(function (result) {
            $scope.foodmenuResult = result.data;
        });
        orderService.getAll().then(function (result) {
            $scope.orderResult = result.data;
        });

        $scope.create = function () {
            salecontrolService.post($scope.result.model).then(function (result) {
                if (result.data.didError) {
                    $scope.result = result.data;
                }
                else {
                    $location.path("/salecontrol");
                }
            });
        };
        $scope.cancel = function () {
            $location.path("/salecontrol");
        };
    }
    function DetailSaleControlController($log, $scope, $location, $routeParams, salecontrolService) {
        $scope.result = {};
        salecontrolService.get($routeParams.id).then(function (result) {
            $scope.result = result.data;
        });
        $scope.backlist = function () {
            $location.path("/salecontrol");
        };
    }
    function EditSaleControlController($log, $scope, $location, $routeParams, salecontrolService, foodmenuService, orderService) {
        $scope.result = {};
        $scope.foodmenuResult = {};
        $scope.orderResult = {};
        var id = $routeParams.id;

        foodmenuService.getAll().then(function (result) {
            $scope.foodmenuResult = result.data;
        });
        orderService.getAll().then(function (result) {
            $scope.orderResult = result.data;
        });
        salecontrolService.get(id).then(function (result) {
            $scope.result = result.data;
        });
        $scope.update = function () {
            salecontrolService.put(id, $scope.result.model).then(function (result) {
                $scope.result = result.data;
                $location.path("/salecontrol");
            });
        };
        $scope.cancel = function () {
            $location.path("/salecontrol");
        };
    }
    function DeleteSaleControlController($log, $scope, $location, $routeParams, salecontrolService) {
        $scope.result = {};
        var id = $routeParams.id;

        salecontrolService.get(id).then(function (result) {
            $scope.result = result.data;
        });

        $scope.delete = function () {
            salecontrolService.delete(id).then(function (result) {
                if (result.data.didError) {
                    $scope.result = result.data;
                }
                else {
                    $location.path("/salecontrol");
                }                
            });
        };
        $scope.cancel = function () {
            $location.path("/salecontrol");
        };
    }
})();