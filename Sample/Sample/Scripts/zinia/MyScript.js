var app = angular.module("Myapp", []);
app.filter("dateFilter", function () {
    return function (item) {
        if (item != null) {
            return new Date(parseInt(item.substr(6)));
        } return "";
    };
});

app.controller("Bankctrl", function ($scope, BankService, dateFilter) {
    $scope.insertBank = function myfunction() {
        var ban = {
            BankId: $scope.bankid == null || $scope.bankid == undefined ? 0 : $scope.bankid,
            BankName: $scope.bankname,
            BankCode: $scope.bankcode,
        };
        var data = BankService.insertBank(ban);
        data.then(function (m) {
            alert(m.data);
            getData();
            $scope.clearBank();
        }, function () {
            alert('Error');
        });
    }

    $scope.clearBank = function () {
        $scope.bankid   = "";
        $scope.bankname ="";
        $scope.bankcode = "";
    }

    $scope.editBank = function (o) {
        $scope.bankid = o.BankId;
        $scope.bankname = o.BankName;
        $scope.bankcode = o.BankCode;
    }
    $scope.deleteBank = function myfunction(ban) {

        var data = BankService.deleteBank(ban);
        data.then(function (m) {
            alert(m.data);
            getdata();
            $scope.clearBank();
        }, function () {
            alert('Error');
        });
    }
    getData();
    function getData() {
        var data = BankService.getBank();
        data.then(function (m) {

            $scope.BankBind = m.data;
        }, function () {
            alert('Error');
        });
    }

});

app.controller("BranchCtrl", function ($scope, BranchService, dateFilter) {

    getBank(); //To Get All Records  
    function getBank() {

        var getData = BranchService.getBank();

        getData.then(function (msg) {
            $scope.BankBind = msg.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    getBranchdata();
    function getBranchdata() {
        var data = BranchService.getBranch();
        data.then(function (m) {

            $scope.BranchBind = m.data;
        }, function () {
            alert('Error');
        });
    }

    $scope.clearBranch = function () {
        $scope.BranchId = "";
         $scope.branchname = "";
         $scope.swiftcode = "";
         $scope.bankname = "";
    }


    $scope.insertBranch = function myfunction() {
        var bran = {
            BranchId: $scope.BranchId == null || $scope.BranchId == undefined ? 0 : $scope.BranchId,
            BranchName: $scope.branchname,
            SwiftCode: $scope.swiftcode,
            BankId: $scope.bankname
        };
        var data = BranchService.insertBranch(bran);
        data.then(function (m) {
            alert(m.data);
            getdata();
            $scope.clearBranch();
        }, function () {
            alert('Error');
        });
    }

    $scope.editBranch = function (o) {
        $scope.BranchId = o.BranchId;
        $scope.branchname = o.BranchName;
        $scope.swiftcode = o.SwiftCode;
        $scope.bankname = o.BankId;
    }

    $scope.deleteBranch = function myfunction(bran) {

        var data = BranchService.deleteBranch(bran);
        data.then(function (m) {
            alert(m.data);
            getdata();
            $scope.clearBranch();
        }, function () {
            alert('Error');
        });
    }

});

app.controller("Empctrl", function ($scope, Empservice, dateFilter) {

    getDesignation(); //To Get All Records  
    function getDesignation() {

        var getData = Empservice.getDesignation();

        getData.then(function (msg) {
            $scope.designBind = msg.data;
        }, function () {
            alert('Error in getting records');
        });
    }


    getdata();
    function getdata() {
        var data = Empservice.getEmployee();
        data.then(function (m) {

            $scope.Empbind = m.data;
        }, function () {
            alert('Error');
        });
    }
    $scope.insertEmp = function myfunction() {
        var emp = {
            Empid: $scope.empid == null || $scope.empid == undefined ? 0 : $scope.empid,
            Empname: $scope.name,
            Empaddress: $scope.address,
            Empsalary: $scope.salary,
            Empemail: $scope.email,
            Empdateofbirth: $scope.dob,
            DesignId : $scope.designation
        };
        var data = Empservice.insertEmployee(emp);
        data.then(function (m) {
            alert(m.data);
            getdata();
            $scope.clearEmp();
        }, function () {
            alert('Error');
        });
    }
    $scope.clearEmp = function () {
        $scope.empid = "";
        $scope.name = "";
        $scope.address = "";
        $scope.salary = "";
        $scope.email = "";
        $scope.dob = "";
        $scope.designation = "";
    }
    $scope.editEmp = function (o) {
        $scope.empid = o.Empid;
        $scope.name = o.Empname;
        $scope.address = o.Empaddress;
        $scope.salary = o.Empsalary;
        $scope.email = o.Empemail;
        $scope.dob = new Date(parseInt(o.Empdateofbirth.substr(6)));
        $scope.designation = o.DesignId;

    }

    $scope.deleteEmp = function myfunction(emp) {

        var data = Empservice.deleteEmployee(emp);
        data.then(function (m) {
            alert(m.data);
            getdata();
            $scope.clearEmp();
        }, function () {
            alert('Error');
        });
    }
});


app.service("BankService", function ($http) {

    this.insertBank = function (ban) {
        var response = $http({
            method: "post",
            url: "/My/insertBank",
            data: JSON.stringify(ban),
            dataType: "json"
        });

        return response;
    };

    this.deleteBank = function (ban) {
        var response = $http({
            method: "post",
            url: "/My/deleteBank",
            data: JSON.stringify(),
            dataType: "json",
            params: { id: ban }
        });

        return response;
    };
    this.getBank = function () {
        var response = $http({
            method: "post",
            url: "/My/getData",
            data: JSON.stringify(),
            dataType: "json"
        });

        return response;
    };

});


app.service("Empservice", function ($http) {

    this.getDesignation = function () {
        var response = $http({
            method: "post",
            url: "/My/getDesignation",
            data: JSON.stringify(),
            dataType: "json",

        });

        return response;
    }


    this.getEmployee = function () {
        var response = $http({
            method: "post",
            url: "/My/getdata",
            data: JSON.stringify(),
            dataType: "json"
        });

        return response;
    };
    this.insertEmployee = function (emp) {
        var response = $http({
            method: "post",
            url: "/My/InsertEmployee",
            data: JSON.stringify(emp),
            dataType: "json"
        });

        return response;
    };
    this.deleteEmployee = function (emp) {
        var response = $http({
            method: "post",
            url: "/My/DeleteEmployee",
            data: JSON.stringify(),
            dataType: "json",
            params: { id: emp }
        });

        return response;
    };

});


app.service("BranchService", function ($http) {

    this.getBank = function () {
        var response = $http({
            method: "post",
            url: "/My/getBank",
            data: JSON.stringify(),
            dataType: "json",

        });

        return response;
    }

    this.getBranch = function () {
        var response = $http({
            method: "post",
            url: "/My/getBranchdata",
            data: JSON.stringify(),
            dataType: "json"
        });

        return response;
    };

    this.insertBranch = function (bran) {
        var response = $http({
            method: "post",
            url: "/My/insertBranch",
            data: JSON.stringify(bran),
            dataType: "json"
        });

        return response;
    };

    this.deleteBranch = function (bran) {
        var response = $http({
            method: "post",
            url: "/My/deleteBranch",
            data: JSON.stringify(),
            dataType: "json",
            params: { id: bran }
        });

        return response;
    };

});
