(function () {
    "use strict";

    app.controller("UserController", UserController);
    app.controller("CreateUserController", CreateUserController);
    UserController.$inject = ["$log", "$scope", "$location", "UserService"];
    CreateUserController.$inject = ["$log", "$scope", "$location", "UserService", "UserTypeService"];

    function UserController($log, $scope, $location, userService) {
        $scope.result = result.data;

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
    function CreateUserController($log,$scope,$location,userService,usertypeService){
        $scope.result = {};
        $scope.usertypeResult = {};

        usertypeService.getAll().then(function (result) {
            $scope.usertypeResult = result.data;
        });

        userService.post($scope.result.model).then(function (result) {
            if (result.data.didError) {
                $scope.result = result.data;
            }
            else {
                $location.path("/users");
            }
        });
    }
})();