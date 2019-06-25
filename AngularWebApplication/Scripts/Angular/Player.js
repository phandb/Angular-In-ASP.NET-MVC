// <reference path="Player.js" />
var App = angular.module('MyApp', ['ngRoute']);//already disscused about ngRoute and angular.module
App.controller('PlayerController', function ($scope, PlayerService) {// controller with two parameters $scope and serive Which i have little bit discused about it in ever first angualrjs tutorial
    $scope.isFormValid = false;
    $scope.message = null;
    $scope.player = null;
    PlayerService.GetPlayerList().then(function (d) { //Call the GetPlayerList() function in service for getting all Player Records
        $scope.player = d.data;
    },
        function () {
            alert('Failed');
        });

    // employee Objects
    $scope.Player = {
        PlayerId: '',
        PlayerName: '',
        Club: '',
        Pisition: '',
        JoinedClubOn: ''
        
    };
    //check form validation
    $scope.$watch('CreateForm.$valid', function (newValue) { // form1 is our form name
        $scope.isFormValid = newValue;
    });

    //Add Player Record function
    $scope.PlayerRecord = function (data) {
        $scope.message = '';
        $scope.Player = data;
        if ($scope.isFormValid) {
            PlayerService.AddPlayer($scope.Player).then(function (d) { //Calling AddPlayer() from service
                alert(d);
                if (d == 'Success') {
                    //Clear Form
                    ClearForm();
                }
            });
        }
        else {
            $scope.message = 'Please fill the required fields';
        }
    };

    //Delete Player Record function
    $scope.DeletePlayer = function (player) {
        if (player.PlayerId != null) {
            if (window.confirm('Are you sure you want to delete this Id = ' + player.PlayerId + '?'))//Popup window will open to confirm
            {
                PlayerService.DeletePlayerData(player.PlayerId).then(function (player) { //Calling DelEmployeeData() from service with parameter
                    window.location.href = '/Player/Index';
                }, function () {
                    alert("Error in deleting record");
                });
            }
        }
        else {
            alert("this id is null");
        }
    };

    //Update Employee Data function
    $scope.UpdatePlayer = function () {
        var Player = {};
        Player["PlayerId"] = $scope.PlayerId;
        Player["PlayerName"] = $scope.PlayerName;
        Player["Club"] = $scope.PlayerClub;
        Player["PlayerPosition"] = $scope.PlayerPosition;
        Player["PlayerJoinedClubOn"] = $scope.PlayerJoinedClubOn;
        PlayerService.UpdatePlayerData(Player);
    }

    //Redrect index form to edit form with parameter
    $scope.RedirectToEdit = function (player) {
        window.location.href = '/Player/Edit/' + player.PlayerId;
    };

    //Redirect to Detail view from index view with parameter
    $scope.RedirectToDetails = function (player) {
        window.location.href = '/Player/Detail/' + player.PlayerId;
    };

    //Calling GetPlayerByID() from service. This function will fetch record from data base and then paste that record in edit form fields.
    PlayerService.GetPlayerByID().success(function (data) {
        $scope.player = data;
        $scope.PlayerId = data.PlayerId;
        $scope.PlayerName = data.PlayerName;
        $scope.PlayerClub = data.PlayerClub;
        $scope.PlayerPosition = data.PlayerPosition;
        $scope.PlayerJoinedClubOn = data.PlayerJoinedClubOn;
        
    });

    //Clear Form Funciton
    function ClearForm() {
        $scope.Player = {};
        $scope.CreateForm.$setPristine();
        $scope.UpdatePlayer = {};
        $scope.EditForm.$setPristine();
    }
});
App.factory('PlayerService', function ($http, $q, $window) {//I have disscussed little bit about service in 3rd tutorial of angularjs series. Declare with some dependencies.
    return {
        //Get all Player List 
        GetPlayerList: function () {
            return $http.get('/Player/GetAllPlayers');
        },

        GetPlayerId: function () {//this function will get the last value of current page url.
            var urlPath = $window.location.href;
            var result = String(urlPath).split("/"); //will split the url by forword slash
            if (result != null && result.length > 0) {
                var id = result[result.length - 1]; //will get the last value from url.
                return id;
            }
        },

        GetPlayerByID: function () { // this function will call the controller function GetPlayerByID to get record by ID.
            var currentPlayerID = this.GetPlayerId();//calling GetPlayerId to get the current page url's last value.
            if (currentPlayerID != null) {
                return $http.get('/Player/GetPlayerById', { params: { id: currentPLayerID } });
            }
        },

        //Add Player Data. This function will call the Controller's Create action to add a new player.
        AddPlayer: function (data) {
            var defer = $q.defer();
            $http({
                url: '/Player/Create',
                method: "POST",
                data: data
            }).success(function (d) {
                //Callback after success
                defer.resolve(d);
            }).error(function (e) {
                //callback after failed
                alert("Error");
                window.location.href = '/Player/Create';
                defer.reject(e);
            });
            return defer.promise;
        }, //End of Add Player Data

        //Delete Player Data. This function will call the controller's Delete action method to delete the player record.
        DeletePlayerData: function (playerId) {
            var defer = $q.defer(); // I have disscussed littel bit about $q and defer in 3rd tutorial of angualrjs. 
            $http({
                url: '/Player/Delete/' + playerId,
                method: 'POST'
            }).success(function (d) {
                alert("the player deleted successfully");
                defer.resolve(d);
            }).error(function (e) {
                alert("Error");
                defer.reject(e);
            });
            return defer.promise;

        },

        //Update Player Data. This function will call the controller's Update action method to Update the player record.
        UpdatePlayerData: function (player) {
            var defer = $q.defer();
            player.PlayerId = this.GetPlayerId();
            $http({
                url: '/Player/UpdatePlayer',
                method: 'POST',
                data: player
            }).success(function (d) {
                defer.resolve(d);
                window.location.href = '/Player/Index';
            }).error(function (e) {
                alert("Error");
                defer.reject(e);
            });
            return defer.promise;
        },
    }
});