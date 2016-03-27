
mainApp = angular.module('mainApp', ['ngRoute', 'ngAnimate']);

mainApp.config([
    '$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            
            when('/home', {
                templateUrl: "home/home",
                controller: 'peopleController'
            }).
            when('/home/home', {
                templateUrl: "home/home",
                controller: 'peopleController'
            }).
             when('/home/people', {
                 templateUrl: "home/people",
                 controller: 'peopleController'
             }).
            when('/people', {
                templateUrl: "home/people",
                controller: 'peopleController'
            }).
            
            otherwise({
                redirectTo: '/home'
            });
    }
]);

