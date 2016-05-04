(function () {
    "use strict";
    app.controller("OrderController", OrderController);
    app.controller("CreateOrderController", CreateOrderController);
    app.controller("DetailOrderController", DetailOrderController);
    app.controller("EditOrderController", EditOrderController);
    app.controller("DeleteOrderController", DeleteOrderController);
    OrderController.$inject = ["$log", "$scope", "$location", "OrderService"];
    CreateOrderController.$inject = ["$log", "$scope", "$location", "OrderService", "UserService"];
    DetailOrderController.$inject = ["$log", "$scope", "$location", "$routeParams", "OrderService"];
    EditOrderController.$inject = ["$log", "$scope", "$location", "$routeParams", "OrderService", "UserService"];
    DeleteOrderController.$inject = ["$log", "$scope", "$location", "$routeParams", "OrderService"];

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
    function CreateOrderController($log, $scope, $location, orderService, userService) {
        $scope.result = {};
        $scope.userResult = {};
        userService.getAll().then(function (result) {
            $scope.userResult = result.data;
        });

        $scope.create = function () {
            orderService.post($scope.result.model).then(function (result) {
                if (result.data.didError) {
                    $scope.result = result.data;
                }
                else {
                    $location.path("/orders");
                }
            });
        }
        $scope.cancel = function () {
            $location.path("/orders");
        }
    }

    function DetailOrderController($log, $scope, $location, $routeParams, orderService) {
        $scope.result = {};
        var id = $routeParams.id;
        orderService.get(id).then(function (result) {
            $scope.result = result.data;
        });
        $scope.backlist = function () {
            $location.path("/orders");
        };
    }
    function EditOrderController($log, $scope, $location, $routeParams, orderService, userService) {
        $scope.result = {};
        $scope.userResult = {};
        var id = $routeParams.id;
        userService.getAll().then(function (result) {
            $scope.userResult = result.data;
        });
        orderService.get(id).then(function (result) {
            $scope.result = result.data;
        });
        $scope.update = function () {
            orderService.put(id, $scope.result.model).then(function (result) {
                $scope.result = result.data;
                console.log(result.data);
                $location.path("/orders");
            });
        };
    }
    function DeleteOrderController($log, $scope, $location, $routeParams, orderService) {
        $scope.result = {};
        var id = $routeParams.id;
        orderService.get(id).then(function (result) {
            $scope.result = result.data;
        });
        $scope.delete = function () {
            orderService.delete(id).then(function (result) {
                if (result.data.didError) {
                    $scope.result = result.data;
                }
                else {
                    $location.path("/orders");
                }
            });
        };
    }

})();