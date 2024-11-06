// ngservices/loginservice.js
myApp.factory('loginService', ['$http', '$q', 'serviceBasePath', function ($http, $q, serviceBasePath) {

    var service = {};

    // Function to handle user login
    service.login = function (username, password) {
        var deferred = $q.defer();

        // Sending login request to the backend API
        $http.post(serviceBasePath + '/api/login', { username: username, password: password })
            .then(function (response) {
                // On successful login, return the JWT token
                if (response.data && response.data.token) {
                    localStorage.setItem('token', response.data.token); // Store token in localStorage for further requests
                    deferred.resolve(response.data.token);
                } else {
                    deferred.reject('Invalid login credentials');
                }
            }, function (error) {
                deferred.reject('Error during login');
            });

        return deferred.promise;
    };

    // Function to get the JWT token from localStorage (for authentication)
    service.getToken = function () {
        return localStorage.getItem('token');
    };

    // Function to remove token from localStorage (logout)
    service.logout = function () {
        localStorage.removeItem('token');
    };

    return service;
}]);
