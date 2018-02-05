app.controller('home', ['$scope', 'OperationsService', function ($scope, OperationsService) {
    vm = this;
    vm.home = "homeConroller";

    vm.players;
    vm.isVisible = false;
    vm.isAuth = false;
    activate();

    function activate() {
        vm.isAuth = OperationsService.isAuth;
        console.log("auth " + vm.isAuth);

        OperationsService.getPlayers().then(function (data) {
            var players = data.data;
            console.log(players);
            vm.players = data.data;
            vm.isVisible = true;
        });
        $('#example').DataTable();
        $('.table').DataTable();
    }
}]);
