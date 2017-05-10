angular.module('app').controller("AddEmpController", ["$scope", "$location", "EmployeeService", function ($scope, $location, EmployeeService) {

    GetAllJobTitles();

    function GetAllJobTitles() {
        var getGetAllJobTitles = EmployeeService.getJobTitles();
        getGetAllJobTitles.then(function (jobTitle) {
            $scope.jobTitles = jobTitle.data;
        }, function () {
            alert('Data not found');
        });
    };

    $scope.addEmployee = function () {
        var addEmployee = EmployeeService.addEmployee(this.newEmployee);
        addEmployee.then(function (newEmp) {
            //debugger;
            $location.path("/ListEmp");
        },function () {
                alert('Data not found');
            });
    };

}]);
