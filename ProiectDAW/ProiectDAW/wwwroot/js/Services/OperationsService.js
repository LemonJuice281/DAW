app.service('OperationsService', function ($http, $location) {
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

    var url = $location.absUrl().split('/')[2]

    vm.getPlayers = function () {
        return $http.get('http://' + url + '/api/players/all');
    };

    vm.login = function (user) {
        vm.user = user;
        return $http.post('http://' + url +'/login/user', user);
    }

    vm.addTeam = function (team) {

        var tokenel = document.getElementById('hidden');
        token = tokenel.innerHTML;

        console.log(team);

        var req = {
            method: 'POST',
            url: 'http://' + url +  '/api/team/add',
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
            url: 'http://' + url + '/api/team/add/'+ teamName,
            headers: {
                'Authorization': "Bearer " + token
            }
        }

        return $http(req);
    }

    vm.updateUser = function (token) {
        $http.get('http://'+ url + '/api/user/' + vm.user.UserName, {
            headers: { 'Authorization': "Bearer " + token }
        }).then(function (data) {
            vm.user = data;
        });
    }

    vm.getTeamsByCountry = function (country) {

        var tokenel = document.getElementById('hidden');
        token = tokenel.innerHTML;

        return $http.get('http://' + url +'/api/team/' + country, {
            headers: { 'Authorization': "Bearer " + token }
        });
    }

    vm.updateToken = function (token) {
        vm.token = token;
    }
});