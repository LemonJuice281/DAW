app.controller('RankingController', ['$scope', '$location', 'OperationsService', function ($scope, $location, OperationsService) {
    vm = this;
    vm.about = "RankingController";

    vm.englandTeams = "";
    vm.turkeyTeams = "";
    vm.romaniaTeams = "";
    vm.englandIsVisible = false;
    vm.romaniaVisible = false;
    vm.turkeyVisible = false;

    activate();

    function activate() {
        if (OperationsService.isAuth == false)
            $location.path("#!/home");

        OperationsService.getTeamsByCountry("Romania").then(function (data) {
            vm.romaniaTeams = data.data;
            console.log(vm.romaniaTeams)
            vm.romaniaVisible = true;
        });

        OperationsService.getTeamsByCountry("England").then(function (data) {
            vm.englandTeams = data.data;
            console.log(vm.englandTeams)
            vm.englandIsVisible = true;
        });

        OperationsService.getTeamsByCountry("Turkey").then(function (data) {
            vm.turkeyTeams = data.data;
            console.log(vm.turkeyTeams);
            vm.turkeyVisible = true;
        });


        $('#example').DataTable();
        $('.table').DataTable();
    }

}]);
