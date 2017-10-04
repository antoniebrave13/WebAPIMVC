// JavaScript source code
(function () {
    var app = angular.module('app', ['ngSanitize']);
    app.controller('Controller', ['$scope', '$http', '$window', function ($scope, $http, $window) {
        $scope.employees = '';
        $http.get('http://localhost:30214/api/Employees/GetEmployee').success(function (data) {
            $scope.employees = data;


            console.log($scope.employees);


        });

        //$http.get("http://localhost:30214/api/Employees/GetEmployee",
        //    {

        //        transformResponse: function (cnv) {
        //            //var x2js = new X2JS();
        //            //var aftCnv = x2js.xml_str2json(cnv);
        //            //return aftCnv; 

        //            $scope.employees = $.parseJSON(cnv);

        //        }
        //    })
        //    .success(function (response) {
        //        console.log($scope.employees);
        //    });



        $(document).ready(function () {
            $('#Save').click(function () {
                var employee = {
                    "Name": $('#Name').val(),
                    "Address": $('#Address').val(),
                    "Age": $('#Age').val(),
                    "Salary": $('#Salary').val(),
                    "Allowance": $('#Salary').val() + $('#Allowance').val()
                };

                //$http.post("http://localhost:30214/api/Employees/AddEmployee", employee , { header: { 'Content-Type': 'application/json' } })
                //    .then(function (response) {
                //        console.log(employee);
                //        alert('Successfully Saved!');
                //    },
                //    function (error, status) {
                //        console.log(employee);
                //        alert('Error in saving');
                //    });

                $http.post("http://localhost:30214/api/Employees/AddEmployee/" + employee.Name + "/" + employee.Address + "/" + employee.Age + "/" + employee.Salary)
                    .then(function (response) {
                        console.log(employee);
                        alert('Successfully Saved!');
                        location.reload();
                    },
                    function (error, status) {
                        console.log(employee);
                        alert('Error in saving');
                    });
            })

            $('#Delete').click(function () {
                var id = $('#empid').val();

                $http.post("http://localhost:30214/api/Employees/DeleteEmployee/"+id)
                    .then(function (response) {
                        console.log(employee);
                        alert('Successfully Deleted!');
                        location.reload();
                    },
                    function (error, status) {
                        console.log(employee);
                        alert('Error in saving');
                    });
            })

            $('#Update').click(function () {
                var id = $('#eid').val();

                var allowance = $('#NewAllo').val();

                $http.post("http://localhost:30214/api/Employees/UpdateEmployee/" + allowance + "/" + id)
                    .then(function (response) {
                        console.log(employee);
                        alert('Successfully Updated!');
                        location.reload();
                    },
                    function (error, status) {
                        console.log(employee);
                        alert('Error in updating');
                    });
            })

        });

    }]);
})();



