(function () {
	 'use strict';
	 angular
		  .module('product.service', [])
		  .factory('productService', productService);
	 function productService($http, config) {
	 	 var service = {
	 	 	 get: get,
	 	 	 post: post,
             find: find,
		 };
	 	 return service;
	 	 function get(opts) {
             const param = opts.param ? opts.param : '';
	 	 	 return $http.get(config.url + '/Product/' + param)
			   .then(function (res) {
			   	 return res.data;
			   }, function(err) {
			   	 console.log('err', err);
			   	 throw err;
			   });
	 	 }
	 	 function find(id) {
	 	      return get({ param: id });
	 	 }
	 	 function post(body) {
	 	      return $http.post(config.url + '/Product', body)
                    .then(function (res) {
                         return res.data;
                    }, function (err) {
                         console.log('err', err);
                         throw err;
                    });
	 	 }

	 }
})();