app.controller("PackageController", function ($scope, PackageService) {
    
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

    $scope.PackageAddStatus = false;
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

    $scope.PackageForm = {};
   
    $scope.LoadResident = function (r)
    {
        $scope.PackageForm.FName = r.FirstName;
        $scope.PackageForm.LName = r.LastName;
        $scope.PackageForm.Description = "";
        $scope.PackageForm.Location =  ""

        
    }

   

    $scopeTakeResident = function (FName, LName) {
        $scope.FirstFieldName = {}
        if (FName != "") {
            $scope.FirstFieldName = FName;

        }
        if (LName != "") {
            $scope.FirstFieldName = FName;

        }

    }
    



    $scope.AddResident = function (PackageForm)
    {

        $scope.Error = "";

        $scope.firstName = PackageForm.FName;
        $scope.lastName = PackageForm.LName;
        $scope.location = PackageForm.Location;
        $scope.description = PackageForm.Description;



        if (firstName == "") {


        }





    }

    $scope.onSubmit = function ()
    {
        
            $scope.AddPackage($scope.PackageForm);
        




    }


    $scope.AddPackage = function(PackageForms)
    {
        
        var Resident = {
            FullName: PackageForms.FName + " " + PackageForms.LName,
            Location: PackageForms.Location,
            Description: PackageForms.Description,

        }

        PackageService.addPackage(Resident).then( function (emp) {



            if (emp.data == 0) {
                $scope.PackageAddStatus = false;
                console.log("False");

            } else{
                $scope.PackageAddStatus = true;
                console.log("True");
            }




        });


    }

    


});

app.controller("AddPackage", function ($scope, PackageService) {
   
  


});


