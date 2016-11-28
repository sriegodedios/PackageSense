app.service("PackageService", function ($http) {
    this.getData = function ()
    {
        return $http.get("/Home/GetRecords");
    }

    this.getResident = function (residentID)
    {
        var response = $http({
            method: "post",
            url: "Home/GetResidentById",
            params: {
                id: JSON.stringify(residentID)
            }
        });

        return response;
    }

    this.addPackage = function (resident)
    {
        var resonse = $http({
            method: "post",
            url: "Home/AddPackage",
            params:{
                resident: JSON.stringify(resident)
            }

        });
    }

});