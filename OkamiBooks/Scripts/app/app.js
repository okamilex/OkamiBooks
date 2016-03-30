
mainApp = angular.module('mainApp', ['ngRoute', 'ngAnimate', 'ngCookies', 'ngResource']);



mainApp.config([
    '$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            
            when('/home', {
                templateUrl: "home/home",
                controller: 'homeController'
            }).
             
            when('/people', {
                templateUrl: "home/people",
                controller: 'peopleController'
            }).
            when('/userPage', {
                templateUrl: "user/userpage",
                controller: 'userPageController'
            }).
            
            otherwise({
                redirectTo: '/home'
            });
    },
   
    
]);


