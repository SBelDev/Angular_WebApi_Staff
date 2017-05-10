
angular.module('app', ['ngRoute', '720kb.datepicker']).config(function ($routeProvider) {
    $routeProvider.when('/ListEmp', {
        templateUrl: '/Scripts/app/ListEmployee.html',
        controller: 'ListEmpController'
    })
    $routeProvider.when('/newEmp', {
        templateUrl: '/Scripts/app/AddEmployee.html',
        controller: 'AddEmpController'
    })
    .otherwise({
        redirectTo: '/',
        templateUrl: '/Scripts/app/ListEmployee.html',
    });
});
