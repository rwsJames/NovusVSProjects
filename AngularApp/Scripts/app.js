var app = angular.module("Ex2App", []);
app.controller("Ex2Controller", function ($scope) {
    $scope.Ex2Val = "Welcome to Angular!";

    $scope.Ex2Func = function () {
        alert("Hello, friend.");
    }
    $scope.Ex2FuncParam = function (val) {
        alert("Param passed: " + val);
    }
});