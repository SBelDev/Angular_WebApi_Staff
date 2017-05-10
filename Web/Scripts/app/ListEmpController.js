
angular.module('app').controller("ListEmpController", function ($scope, EmployeeService) {

    GetAllEmployee();

    function GetAllEmployee() {
        var getAllEmployee = EmployeeService.getEmployee();
        getAllEmployee.then(function (emp) {
            $scope.employees = emp.data;
        }, function () {
            alert('Data not found');
        });
    };

    $scope.deleteEmployee = function (employee) {
        var deleteEmployee = EmployeeService.deleteEmployee(employee.Id);
        deleteEmployee.then(function (emp) {
            //debugger;
            for (var i = 0, len = $scope.employees.length; i < len; i++) {
                if($scope.employees[i].Id == employee.Id) {
                    $scope.employees.splice(i, 1);
                    break;
                }
            }

        }, function () {
            alert('Data not found');
        });
};

});


