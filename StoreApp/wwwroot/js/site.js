(function () {
    'use strict';

    angular
        .module('app')
        .controller('site', site);

    site.$inject = ['$location'];

    function site($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'site';

        activate();

        function activate() { }
    }
})();
