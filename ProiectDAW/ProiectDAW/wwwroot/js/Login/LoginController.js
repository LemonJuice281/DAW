app.controller('LoginController', ['$scope','$location', 'OperationsService', function ($scope, $location, OperationsService) {
    vm = this;
    vm.about = "LoginController";

    vm.incorrect = false;

    vm.user = {
        UserName: "",
        FirstName: "",
        LastName: "",
        Password: "",
        Role: ""
    }

    vm.login = function () {

        console.log(vm.user);
        var $promise = OperationsService.login(vm.user);
        $promise.then(function (result) {
            var token = result.data;
            console.log(OperationsService.token);
            OperationsService.token = token;
            OperationsService.updateToken(token);
            OperationsService.isAuth = true;
            OperationsService.updateUser(token);
            $location.path("#!/about");
            var tokenel = document.getElementById('hidden');
            tokenel.innerHTML = token;
        },
            function (error) {
                vm.incorrect = true;
            });
    }

}]);
