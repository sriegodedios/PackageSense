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
});