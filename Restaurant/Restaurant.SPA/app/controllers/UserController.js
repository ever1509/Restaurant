(function () {
    "use strict";

    app.controller("UserController", UserController);
    app.controller("CreateUserController", CreateUserController);
    app.controller("DetailUserController", DetailUserController);
    app.controller("EditUserController", EditUserController);
    app.controller("DeleteUserController", DeleteUserController);
    UserController.$inject = ["$log", "$scope", "$location", "UserService"];
    CreateUserController.$inject = ["$log", "$scope", "$location", "UserService", "UserTypeService"];
    DetailUserController.$inject = ["$log", "$scope", "$location", "$routeParams", "UserService", "UserTypeService"];
    EditUserController.$inject = ["$log", "$scope", "$location", "$routeParams", "UserService", "UserTypeService"];
    DeleteUserController.$inject = ["$log", "$scope", "$location", "$routeParams", "UserService"];
    function UserController($log, $scope, $location, userService) {
        $scope.result = {};

        userService.getAll().then(function (result) {
            $scope.result = result.data;
        });
        $scope.create = function () {
            $location.path("/user-create/");

        };
        $scope.detail = function (item) {
            $location.path("/user-detail/" + item.userID);
        };
        $scope.edit = function (item) {
            $location.path("/user-edit/" + item.userID);
        };
        $scope.delete = function (item) {
            $location.path("/user-delete/" + item.userID);
        };
    };
    function CreateUserController($log, $scope, $location, userService, usertypeService) {
        $scope.result = {};
        $scope.usertypeResult = {};

        usertypeService.getAll().then(function (result) {
            $scope.usertypeResult = result.data;
        });

        $scope.create = function () {
            userService.post($scope.result.model).then(function (result) {
                if (result.data.didError) {
                    console.log(result.data);
                    $scope.result = result.data;

                }
                else {
                    $location.path("/users");
                }
            });
        };
        $scope.cancel = function () {
            $location.path("/users");
        };
    }
    function DetailUserController($log, $scope, $location, $routeParams, userService, usertypeService) {
        $scope.result = {};
        $scope.usertypeResult = {};
        var id = $routeParams.id;
        usertypeService.get(id).then(function (result) {
            $scope.usertypeResult = result.data;
        });

        userService.get(id).then(function (result) {
            $scope.result = result.data;
        });

        $scope.backlist = function () {

            $location.path("/users");
        };
    }
    function EditUserController($log, $scope, $location, $routeParams, userService, usertypeService) {
        $scope.result = {};
        $scope.usertypeResult = {};
        var id = $routeParams.id;
        usertypeService.getAll().then(function (result) {
            $scope.usertypeResult = result.data;
        });
        userService.get(id).then(function (result) {
            $scope.result = result.data;
        });

        $scope.update = function () {
            userService.put(id, $scope.result.model).then(function (result) {
                $scope.result = result.data;
                $location.path("/users");
            });
        }

        $scope.cancel = function () {
            $location.path("/users");
        }
    }
    function DeleteUserController($log, $scope, $location, $routeParams, userService) {
        $scope.result = {};
        $scope.usertypeResult = {};
        var id = $routeParams.id;
        userService.get(id).then(function (result) {
            $scope.result = result.data;
        });
        $scope.delete = function () {
            userService.delete(id).then(function (result) {
                if (result.data.didError) {
                    $scope.result = result.data;
                }
                else {
                    $location.path("/users");
                }
            });

        }
        $scope.cancel = function () {
            $location.path("/users");
        }
    }
})();