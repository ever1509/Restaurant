(function () {
    "use strict";
    app.controller("OrderController", OrderController);
    app.controller("CreateOrderController", CreateOrderController);
    OrderController.$inject = ["$log", "$scope", "$location", "OrderService"];
    CreateOrderController.$inject = ["$log", "$scope", "$location", "OrderService","UserService"];

    function OrderController($log, $scope, $location, orderService) {
        $scope.result = {};
        orderService.getAll().then(function (result) {
            $scope.result = result.data;
        });

        $scope.create = function () {
            $location.path("/order-create/");
        }
        $scope.edit = function (item) {
            $location.path("/order-edit/" + item.orderID);
        }
        $scope.detail = function (item) {
            $location.path("/order-detail/" + item.orderID);
        }
        $scope.delete = function (item) {
            $location.path("/order-delete/" + item.orderID);
        }
    }



})();