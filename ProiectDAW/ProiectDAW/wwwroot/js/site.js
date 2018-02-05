var app = angular.module('app', ['ngRoute']);

app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when("/home", {
            templateUrl: "js/Home/home.html",
            controller: "home",
            controllerAs: "vm"
        })
        .when("/login", {
            templateUrl: "js/Login/Login.html",
            controller: "LoginController",
            controllerAs: "vm"

        })
        .when("/about", {
            templateUrl: "js/About/about.html",
            controller: "about",
            controllerAs: "vm"

        })
        .when("/ranking", {
            templateUrl: "js/Rankings/ranking.html",
            controller: "RankingController",
            controllerAs: "vm"

        })
        .when("/edit", {
            templateUrl: "js/Edit/edit.html",
            controller: "edit",
            controllerAs: "vm"

        })
        .otherwise({ redirectTo: "/home" });
    //$locationProvider.html5Mode(true);
}); 


