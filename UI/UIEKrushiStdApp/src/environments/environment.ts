// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  cartServiceUrl:'http://localhost:5282/api/carts',
  bankingServiceUrl:'http://localhost:5053/api/accounts',
  catalogServiceProductUrl:'http://localhost:5288/api/products',
  catalogServiceCategoriesUrl:'http://localhost:5288/api/categories',
  consultingServiceUrl:'http://localhost:5279/api/consulting',
  ordersServiceUrl:'http://localhost:5059/api/orders',
  paymentsServiceUrl:'http://localhost:5015/api/payments',
  shippersServiceUrl:'http://localhost:5298/api/shippers',
  storesServiceUrl:'http://localhost:5226/api/stores',
  suppliersServiceUrl:'http://localhost:5072/api/suppliers',
  usersServiceUrl:'http://localhost:5102/api/users',
  userAddressServiceUrl:'http://localhost:5102/api/addresses',
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
