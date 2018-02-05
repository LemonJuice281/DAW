app.service('OperationsService', function ($http) {
    vm = this;
    vm.token = "";
    vm.isAuth = false;
    vm.role =
        vm.user = {
            UserName: "",
            FirstName: "",
            LastName: "",
            Password: "",
            Role: ""
        }

    vm.getPlayers = function () {
        return $http.get('http://localhost:61123/api/players/all');
    };

    vm.login = function (user) {
        vm.user = user;
        return $http.post('http://localhost:61123/login/user', user);
    }

    vm.addTeam = function (team) {

        var tokenel = document.getElementById('hidden');
        token = tokenel.innerHTML;

        console.log(team);

        var req = {
            method: 'POST',
            url: 'http://localhost:61123/api/team/add',
            headers: {
                'Authorization': "Bearer " + token
            },
            data: team
        }

        return $http(req);
    }

    vm.deleteTeam = function (teamName) {

        var tokenel = document.getElementById('hidden');
        token = tokenel.innerHTML;

        console.log(teamName);

        var req = {
            method: 'DELETE',
            url: 'http://localhost:61123/api/team/add/'+ teamName,
            headers: {
                'Authorization': "Bearer " + token
            }
        }

        return $http(req);
    }

    vm.updateUser = function (token) {
        $http.get('http://localhost:61123/api/user/' + vm.user.UserName, {
            headers: { 'Authorization': "Bearer " + token }
        }).then(function (data) {
            vm.user = data;
        });
    }

    vm.getTeamsByCountry = function (country) {

        var tokenel = document.getElementById('hidden');
        token = tokenel.innerHTML;

        return $http.get('http://localhost:61123/api/team/' + country, {
            headers: { 'Authorization': "Bearer " + token }
        });
    }

    vm.updateToken = function (token) {
        vm.token = token;
    }
});