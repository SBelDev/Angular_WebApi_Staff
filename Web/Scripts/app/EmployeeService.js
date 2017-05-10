var url = '/api/Employees/';

angular.module('app').service("EmployeeService", function ($http) {

    this.getEmployee = function () {
        return $http.get(url + 'GetEmployees');
    };

    this.deleteEmployee = function (employee) {
        return $http.delete(url + 'DeleteEmployee/' + employee);
    };

    this.addEmployee = function (employee) {
        return $http.post(url + 'PostEmployee', employee);
    };
    
    this.getJobTitles = function () {
        return $http.get(url + 'GetEmployeesJobTitles');
    }
});

