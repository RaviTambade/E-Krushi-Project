 ## REST API EndPoints for EKrushi 
- [UserRoleManagement](#userrolemanagement) 
- [Suppliers](#suppliers)
- [Stores](#stores)
- [Shopping Cart](#shopping-cart)
- [Shippers](#shippers)
- [Payments](#payments)
- [Orders](#orders)
- [Consulting](#consulting)

### UserRoleManagement 

- <b>URL</b> : /api/userroles/roles/{userId}
- <b>Method</b>: GET
- <b>Description</b>: Returns Role of User by giving userId.
- <b>Parameters</b>: userId = 3 
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Not required
- <b>Response</b>:
  ```console
  ['Customer']
  ```

- <b>URL</b> : /api/userroles/roles/userid/{role}
- <b>Method</b>: GET
- <b>Description</b>: Returns all user of given Role .
- <b>Parameters</b>: role ="Customer"
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  [
    "2,3,15,16,17,18,19,20,21,22,23,24,25,27"
  ]
  ```

- <b>URL</b> : /api/userroles/roles 
- <b>Method</b>: POST
- <b>Description</b>:  Add a user role .
- <b>Parameters</b>:Not requried
- <b>Body</b>:
  ```console
  {
    "userId": 1,
    "roleId": 1
  }
  ```
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  true
  ```

### Suppliers 

- <b>URL</b> : /api/suppliers/corporate/{supplierId} 
- <b>Method</b>: GET
- <b>Description</b>: Returns Corporate Id of Supplier .
- <b>Parameters</b>: supplierId = 1
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  13
  ```

- <b>URL</b> :/api/suppliers/id/{userId}
- <b>Method</b>: GET
- <b>Description</b>: Returns Supplier Id by giving userId. 
- <b>Parameters</b>: userId  = 13
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
    ```console
    1
    ```

### Stores 

- <b>URL</b> : /api/stores/{storeId}/{orderStatus}
- <b>Method</b>: GET
- <b>Description</b>: Returns a list of orders based on  StoreId and Order status.
- <b>Parameters</b>: storeId  = 1, orderStatus="delivered"
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  [
    {
      "id": 16,
      "orderDate": "2023-10-01T17:08:34",
      "shippedDate": "2023-10-02T17:08:34",
      "status": "delivered",
      "total": 5000
    },
    {
      "id": 17,
      "orderDate": "2023-10-02T17:09:23",
      "shippedDate": "2023-10-03T17:09:23",
      "status": "delivered",
      "total": 4000
    },
    {
      "id": 18,
      "orderDate": "2023-10-03T17:09:53",
      "shippedDate": "2023-10-04T17:09:53",
      "status": "delivered",
      "total": 4000
    }
  ]
  ```

- <b>URL</b> : /api/stores/orderscount/{storeId} 
- <b>Method</b>: GET
- <b>Description</b>: Returns a number of orders by its status 
- <b>Parameters</b>: storeId = 1
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  {
    "pending": 2,
    "approved": 0,
    "readyToDispatch": 0,
    "picked": 0,
    "inProgress": 0,
    "delivered": 16,
    "cancelled": 1
  }
  ```

- <b>URL</b> : /api/stores/nearby/{customerAddressId}
- <b>Method</b>: GET
- <b>Description</b>:   Returns a nearby storeId  by giving customer's AddressId.
- <b>Parameters</b>: customerAddressId=2
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  2
  ```

- <b>URL</b> :/api/stores/user/{storeId}
- <b>Method</b>: GET
- <b>Description</b>:  Returns a UserId of store by giving StoreId .
- <b>Parameters</b>: storeId = 2
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  22
  ```

- <b>URL</b> : /api/stores/storeid/{userId}
- <b>Method</b>: GET
- <b>Description</b>:  Returns a StoreId of store by giving UserId .
- <b>Parameters</b>: userId = 22
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  22
  ```
- <b>URL</b> :/api/stores/name/{storeId}
- <b>Method</b>: GET
- <b>Description</b>: Returns a Name of store by giving StoreId .
- <b>Parameters</b>: storeId = 2
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  {
  "name":"Manchar Store"
  }
  ```

### Shopping Cart 

- <b>URL</b> : /api/carts/customer/{customerId}
- <b>Method</b>: GET
- <b>Description</b>: Returns Cart of Customer by customerId.
- <b>Parameters</b>: customerId  = 16
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  [
    {
      "cartItemId": 96,
      "productId": 2,
      "title": "wheat seeds",
      "size": "10kg",
      "image": "/assets/wheat.jpg",
      "quantity": 2,
      "unitPrice": 300
    },
    {
      "cartItemId": 97,
      "productId": 3,
      "title": "corn seeds",
      "size": "1kg",
      "image": "/assets/corn.jfif",
      "quantity": 2,
      "unitPrice": 2500
    }
  ]
  ```

- <b>URL</b> : /api/carts
- <b>Method</b>: POST
- <b>Description</b>: Add Item in Cart returns boolean.
- <b>Parameters</b>: Not requried
- <b>Body</b>:
  ```console
  {
    "customerId": 16,
    "productId": 12,
    "size": "M"
  }
  ```
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  true
  ```

- <b>URL</b> : /api/carts/product/present
- <b>Method</b>: POST
- <b>Description</b>: checks wheather product is already present in a cart returns boolean.
- <b>Parameters</b>: Not requried
- <b>Body</b>:
  ```console
  {
    "customerId": 16,
    "productId": 12,
    "size": "M"
  }
  ```
- <b>JWT Token Header</b> : Yes

- <b>Response</b>:
  ```console
  true
  ```

- <b>URL</b> :/api/carts/cartitem/{cartItemId}/quantity/{quantity}
- <b>Method</b>: PUT
- <b>Description</b>: Updates quantity of cartItem returns boolean.
- <b>Parameters</b>: cartItemId=22 , quantity=4
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  true
  ```

- <b>URL</b> : /api/carts/remove/{cartItemId}
- <b>Method</b>: DELETE
- <b>Description</b>: Remove specific item from cart by its cartItemId returns boolean.
- <b>Parameters</b>: cartItemId=22 
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  true
  ```
- <b>URL</b> : /api/carts/removeall/{customerId}
- <b>Method</b>: DELETE
- <b>Description</b>: Empty the cart of customer bt giving customerId returns boolean.
- <b>Parameters</b>: customerId=16
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  true
  ```

### Shippers

- <b>URL</b> :/api/shippers/{shipperId}/{status}
- <b>Method</b>: GET
- <b>Description</b>: Returns a list of orders of Shipper  by shipperId and Order status.
- <b>Parameters</b>: shipperId  = 4 ,status="delivered
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  [
    {
      "orderId": 16,
      "fromAddressId": 1,
      "toAddressId": 8,
      "status": "delivered",
      "orderDate": "2023-10-01T17:08:34",
      "shippedDate": "2023-10-02T17:08:34"
    },
    {
      "orderId": 17,
      "fromAddressId": 1,
      "toAddressId": 8,
      "status": "delivered",
      "orderDate": "2023-10-02T17:09:23",
      "shippedDate": "2023-10-03T17:09:23"
    }
  ]
  ```
- <b>URL</b> : /api/shippers/orderscount/{shipperId}
- <b>Method</b>: GET
- <b>Description</b>     : Returns a number of orders by its status of that Shipper.
- <b>Parameters</b>: shipperId  = 4 
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  {
    "readyToDispatch": 0,
    "picked": 0,
    "inProgress": 0,
    "delivered": 16,
    "cancelled": 0
  }
  ```

- <b>URL</b> : /api/shippers/nearby/{storeId}
- <b>Method</b>: GET
- <b>Description</b>     : Returns a nearest Shipper's Id to a store by giving storeId.
- <b>Parameters</b>: storeId  = 1
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  4
  ```
 
- <b>URL</b> : /api/shippers/shipperid/{userId}
- <b>Method</b>: GET
- <b>Description</b>     : Returns a ShipperId by giving UserId.
- <b>Parameters</b>: userId  = 32
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  2
  ```

### Payments

- <b>URL</b> : /api/payments/{customerId}
- <b>Method</b>: GET
- <b>Description</b>: Returns a list of payments of customer by  CustomerId.
- <b>Parameters</b>: customerId  = 16
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  [
    {
      "paymentDate": "2023-07-19T17:08:34",
      "orderId": 16,
      "paymentStatus": "paid"
    },
    {
      "paymentDate": "2023-07-20T17:09:23",
      "orderId": 17,
      "paymentStatus": "paid"
    }
  ]
  ```

- <b>URL</b> : /api/payments/details/{orderId}
- <b>Method</b>: GET
- <b>Description</b>: Returns a  payment of a order by  orderId.
- <b>Parameters</b>: orderId  = 90
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  {
    "paymentId": 89,
    "date": "2023-10-01T17:47:24",
    "total": 3400,
    "status": "paid",
    "paymentMode": "net banking"
  }
  ```

- <b>URL</b> : /api/payments
- <b>Method</b>: POST
- <b>Description</b>: Add a Payment returns boolean.
- <b>Parameters</b>: Not requried
- <b>Body</b>: 
  ```console
  {
    "mode": "net banking",
    "paymentStatus": "paid",
    "transactionId": 23,
    "orderId": 12
  }
  ```
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  true
  ```

### Orders

- <b>URL</b> : /api/orders/customer/{customerId}
- <b>Method</b>: GET
- <b>Description</b>: Returns a list of Orders of customer by  CustomerId.
- <b>Parameters</b>: customerId  = 16
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  [
    {
      "id": 16,
      "orderDate": "2023-10-01T17:08:34",
      "shippedDate": "2023-10-02T17:08:34",
      "status": "delivered",
      "total": 5000
    },
    {
      "id": 17,
      "orderDate": "2023-10-02T17:09:23",
      "shippedDate": "2023-10-03T17:09:23",
      "status": "delivered",
      "total": 4000
    }
  ]
  ```

- <b>URL</b> : /api/orders/details/{orderId}
- <b>Method</b>: GET
- <b>Description</b>: Returns a list of Order Details of Order by  orderId.
- <b>Parameters</b>: orderId  = 3
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  [
    {
      "productId": 3,
      "title": "corn seeds",
      "image": "/assets/corn.jfif",
      "unitPrice": 2500,
      "size": "1kg",
      "quantity": 1,
      "total": 2500
    },
    {
      "productId": 9,
      "title": " Bajra Seeds",
      "image": "/assets/bajra-seeds.webp",
      "unitPrice": 120,
      "size": "1kg",
      "quantity": 1,
      "total": 120
    }
  ]
  ```

- <b>URL</b> : /api/orders/amount/{orderId}
- <b>Method</b>: GET
- <b>Description</b>: Returns Amount of Order by  orderId.
- <b>Parameters</b>: orderId  = 3
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  2620
  ```

- <b>URL</b> : /api/orders/address/{orderId}
- <b>Method</b>: GET
- <b>Description</b>:  Returns a Delivery Address Id of Order by  orderId.
- <b>Parameters</b>: orderId  = 3
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  3
  ```

- <b>URL</b> : /api/orders
- <b>Method</b>: POST
- <b>Description</b>:  Creates an Order and return orderId,StoreId and Its Amount.
- <b>Parameters</b>: Not requried
- <b>Body</b>: 
  ```console
  {
    "customerId": 16,
    "addressId": 8,
    "orderDetails": [
      {
        "productId": 9,
        "quantity": 1,
        "size": "1Kg"
      }
    ]
  }
  ```
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  {
    "orderId": 95,
    "storeId": 1,
    "amount": 120
  }
  ```

- <b>URL</b> : /api/orders/{orderId}
- <b>Method</b>: DELETE
- <b>Description</b>:  Remove an Order by  orderId return boolean.
- <b>Parameters</b>: orderId  = 3
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  true
  ```

- <b>URL</b> : /api/orders/status
- <b>Method</b>: PATCH
- <b>Description</b>:   Update an Order status return boolean.
- <b>Parameters</b>: Not requried
- <b>Body</b>: 
  ```console
  {
    "orderId": 3,
    "status": "delivered"
  }
  ```
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  true
  ```

### Consulting

- <b>URL</b> : /api/consulting
- <b>Method</b>: GET
- <b>Description</b>: It is used for get all questions.
- <b>Parameters</b>: Not requried.
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  [
      {
          "id": 1,
          "customerId": 2,
          "date": "2023-09-01T00:00:00",
          "description": " How can I improve soil fertility in my fields?",
          "categoryId": 0
      },
      {
          "id": 2,
          "customerId": 3,
          "date": "2023-09-01T00:00:00",
          "description": "What are the best practices for pest and weed control in organic farming?",
          "categoryId": 0
      }
  ]
  ```

- <b>URL</b> : /api/consulting/questioncatagories
- <b>Method</b>: GET
- <b>Response</b>
- <b>Description</b>: it is used for get all question categories.
- <b>Parameters</b>: Not requried.
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  [
      {
          "id": 1,
          "category": "Crop Cultivation"
      },
      {
          "id": 2,
          "category": "Livestock Farming"
      },
      {
          "id": 3,
          "category": "Farm Equipment and Technology"
      }
  ]
  ```

- <b>URL</b> : /api/consulting/answers/{id}
- <b>Method</b>: GET
- <b>Description</b>: it is used for get answers of particular question.
- <b>Parameters</b>: id=2
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  [
      {
          "question": "What are the best practices for pest and weed control in organic farming?",
          "answers": "In organic farming, you can use - <b>Method</b>s like companion planting, beneficial insects, and organic pesticides to control pests and weeds without synthetic chemicals.",
          "category": "Crop Cultivation"
      }
  ]
  ```
- <b>URL</b> : /api/consulting/reletedquestions/{id}
- <b>Method</b>: GET
- <b>Description</b>: it used for get releted questions of given question.
- <b>Parameters</b>: id=2
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  [
      {
          "id": 1,
          "customerId": 0,
          "date": "0001-01-01T00:00:00",
          "description": " How can I improve soil fertility in my fields?",
          "categoryId": 0
      },
      {
          "id": 3,
          "customerId": 0,
          "date": "0001-01-01T00:00:00",
          "description": "How can I conserve water in my irrigation practices?",
          "categoryId": 0
      },
      {
          "id": 4,
          "customerId": 0,
          "date": "0001-01-01T00:00:00",
          "description": "What should I consider when selecting crop varieties for my region?",
          "categoryId": 0
      }
  ]
  ```

- <b>URL</b> : /api/consulting/question
- <b>Method</b>: POST
- <b>Description</b>: it is used to insert new question.
- <b>Parameters</b>: Not requried
- <b>Body</b>: 
  ```console
    {
        "description": " How can I improve soil fertility in my fields?",
        "categoryId": 1
    }
  ```
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  true
  ```

- <b>URL</b> : /api/consulting/questions/catagory/{categoryId}
- <b>Method</b>: GET
- <b>Description</b>: it is used for get categoriwise questions.
- <b>Parameters</b>:categoryId=1
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  [
      {
          "id": 1,
          "customerId": 0,
          "date": "0001-01-01T00:00:00",
          "- <b>Description</b>": " How can I improve soil fertility in my fields?",
          "categoryId": 1
      },
      {
          "id": 2,
          "customerId": 0,
          "date": "0001-01-01T00:00:00",
          "description": "What are the best practices for pest and weed control in organic farming?",
          "categoryId": 1
      },
      {
          "id": 3,
          "customerId": 0,
          "date": "0001-01-01T00:00:00",
          "description": "How can I conserve water in my irrigation practices?",
          "categoryId": 1
      }
  ] 
  ```

- <b>URL</b> : /api/consulting/smequestions/{smeid}
- <b>Method</b>: GET
- <b>Description</b>: it is used for get solved questions of subject matter expert.
- <b>Parameters</b>:smeid=7
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Yes
- <b>Response</b>:
  ```console
  [
      {
          "question": "How can I improve soil fertility and structure on my farm over time?"
      },
      {
          "question": " What are effective strategies for reducing the environmental impact of my farm, especially in terms of water and nutrient runoff?"
      },
      {
          "question": " How can I address labor shortages on my farm, especially during peak seasons?"
      }
  ] 
  ```

- <b>URL</b> : /api/consulting/notansweredquestions/{smeid}
- <b>Method</b>: GET
- <b>Description</b>: it is used for notansweredquestions list of sme.
- <b>Parameters</b>:smeid=7
- <b>Body</b>: Not requried
- <b>JWT Token Header</b> : Not required


# BI Service
### BI 

- <b>URL</b>            
```console
/api/bi/orderscount/{todaysDate}/{storeId}
```
- <b>Method</b>: ```GET```
- <b>Description</b>: it returns OrderCountByStore.
- <b>Parameters</b>: todaysDate=2023-10-18,storeId  = 1.
- <b>Body</b>: None
- <b>JWT Token Header</b> : Yes            
- <b>Response</b>:

```console
{
    "todaysOrders": 1,
    "yesterdaysOrders": 1,
    "weekOrders": 7,
    "monthOrders": 17
}
```

<hr>


- <b>URL</b>           
```console
/api/bi/topproducts/{todaysDate}/{mode}/{storeId}
```
- <b>Method</b>: ```GET```
- <b>Description</b>: it returns TopFiveSellingProducts
- <b>Parameters </b>:todaysDate=2023-10-10 ,mode=week,storeId  = 1.
- <b>Body</b>           : None
- <b>JWT Token Header</b> : Yes            
- <b>Response</b>        :

```console
[
  {
    "productId": 12,
    "quantity": 5,
    "totalQuantity": 26,
    "percentage": 19.2308,
    "title": "Garden Scissors",
    "imageURL": "/assets/gardenscissors.webp"
  },
  {
    "productId": 18,
    "quantity": 2,
    "totalQuantity": 26,
    "percentage": 7.6923,
    "title": "Weeding Hook ",
    "imageURL": "/assets/weedinghook.jpg"
  },
  {
    "productId": 17,
    "quantity": 2,
    "totalQuantity": 26,
    "percentage": 7.6923,
    "title": "Pickaxe ",
    "imageURL": "/assets/pickaxe.jpg"
  }
]
```

<hr>



- <b>URL</b>            
```console
/api/bi/MonthOrders/{year}/{storeId}
```
- <b>Method</b>: ```GET```
- <b>Description</b>    : it returns MonthsWithOrders.
- <b>Parameters</b>      :year=2023,storeId  = 1.
- <b>Body</b>           : None
- <b>JWT Token Header</b> : Yes            
- <b>Response</b>        :

```console
[
  {
    "month": "January",
    "orderCount": 0
  },
  {
    "month": "February",
    "orderCount": 0
  },
  {
    "month": "March",
    "orderCount": 0
  },
  {
    "month": "April",
    "orderCount": 0
  },
  {
    "month": "May",
    "orderCount": 0
  },
  {
    "month": "June",
    "orderCount": 0
  },
  {
    "month": "July",
    "orderCount": 0
  },
  {
    "month": "August",
    "orderCount": 0
  },
  {
    "month": "September",
    "orderCount": 0
  },
  {
    "month": "October",
    "orderCount": 17
  },
  {
    "month": "November",
    "orderCount": 0
  },
  {
    "month": "December",
    "orderCount": 0
  }
]
```

<hr>



- <b>URL</b>            
```console
/api/bi/categorywiseproducts/{todaysDate}/{mode}/{storeId}
```
- <b>Method</b>: ```GET```
- <b>Description</b>    : it returns CategorywiseProductsCount
- <b>Parameters</b>      :todaysDate=2023-10-10 ,mode=week,storeId  = 1.
- <b>Body</b>           : None
- <b>JWT Token Header</b> : Yes          
- <b>Response</b>        :

```console
[
  {
    "title": "seeds",
    "quantity": 3
  },
  {
    "title": "Agriculture implements",
    "quantity": 12
  },
  {
    "title": "fertilizers",
    "quantity": 5
  },
  {
    "title": "pesticides",
    "quantity": 2
  },
  {
    "title": "cattel feed",
    "quantity": 4
  }
]
```

<hr>



- <b>URL</b>            
```console
/api/bi/deliveredorders/{ year}/{shipperId};
```
- <b>Method</b>: ```GET```
- <b>Description</b>    : it returns DeliveredOrders
- <b>Parameters</b>      :todaysDate=2023 ,shipperId  = 2.
- <b>Body</b>           : None
- <b>JWT Token Header</b> : Yes                 
- <b>Response</b>        :

```console
[
  {
    "month": "January",
    "ordersCount": 0
  },
  {
    "month": "February",
    "ordersCount": 0
  },
  {
    "month": "March",
    "ordersCount": 0
  },
  {
    "month": "April",
    "ordersCount": 0
  },
  {
    "month": "May",
    "ordersCount": 0
  },
  {
    "month": "June",
    "ordersCount": 0
  },
  {
    "month": "July",
    "ordersCount": 14
  },
  {
    "month": "August",
    "ordersCount": 0
  },
  {
    "month": "September",
    "ordersCount": 0
  },
  {
    "month": "October",
    "ordersCount": 0
  },
  {
    "month": "November",
    "ordersCount": 0
  },
  {
    "month": "December",
    "ordersCount": 0
  }
]
```

<hr>





- <b>Response</b>:
    ```console
    []
    ```
