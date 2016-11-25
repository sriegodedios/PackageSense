app.controller("PackageController", function ($scope, PackageService) {
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }
    //display records
    getTableData();
    function getTableData()
    {
        PackageService.getData().then(function (d) {
            $scope.search = {}
            $scope.searchBy = '$'

            $scope.ResidentList = d.data;

           
            





        });
    }
    
    $scope.getResident = function (ResidentList) {
        debugger;
        var getData = PackageService.getResident(ResidentList.Id);
        getData.then(function (emp) {
            $scope.resident= emp.data;
            $scope.residentId = resident.Id;
            $scope.residentFirstName = resident.FirstName;
            $scope.residentLastName = resident.LastName;
            $scope.residentRoomNumber = resident.residentRoomNumber;
            $scope.Action = "Update";
            $scope.divEmployee = true;
        },
        function () {
           alert('Error in getting records');
        });
    }

    $scope.LoadResident = function (r)
    {
        $scope.FName = r.FirstName;
        $scope.LName = r.LastName;


    }


});


