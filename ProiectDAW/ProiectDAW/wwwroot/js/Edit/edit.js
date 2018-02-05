app.controller('edit', ['$scope', '$location', 'OperationsService', function ($scope, $location, OperationsService) {
    vm = this;
    vm.about = "edit";

    vm.team = {
        teamName: "",
        country: "",
        championship: "",
        ranking: ""
    }
    vm.test = "asd";

    vm.teamName = "";

    activate();

    vm.addTeam = function () {

        OperationsService.addTeam(vm.team).then(function (data) {
            console.log("upated");
        });
    }

    vm.deleteTeam = function () {
        OperationsService.deleteTeam(vm.teamName).then(function (data) {
            console.log("deleted");
        });
    }

    function activate() {
        if (OperationsService.isAuth == false)
            $location.path("#!/home");
       
        $('#example').DataTable();
        $('.table').DataTable();
    }

}]);
