(function () {
     'use strict';
     angular
          .module('product.controller', ['product.service'])
          .controller('productController', productController);
     function productController(productService) {
          var vm = this;
          vm.get = get;
          vm.find = find;
          vm.add = post;
          function get() {
               productService.get({})
                    .then(function (data) {
                         vm.products = data;
                         vm.showResult = true;
                    }, function (err) {
                         console.log(err);
                    });
          }
          function find(id) {
               productService.find(id)
                    .then(function (data) {
                         vm.products = data;
                    }, function (err) {
                         console.log(err);
                    });
          }
          function post() {
               productService.post(vm.productToAdd)
                    .then(function (data) {
                         vm.msg = 'Product Added';
                    }, function (err) {
                         vm.msg = 'Cant Add Your Product';
                    });
               vm.showMsg = true;
          }

     }

})();