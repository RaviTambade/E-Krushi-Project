## List of REST API for EKrushi 

- [UserRoleManagement](#userrolemanagement) 
- [Suppliers](#suppliers)
- [Stores](#stores)
- [Shopping Cart](#shopping-cart)
- [Shippers](#shippers)
- [Payments](#payments)
- [Orders](#orders)
- [Consulting](#consulting)

# UserRoleManagement 

### UserRoleController 

URL            
```console
/api/userroles/roles/{userId}
```
Method: ```GET```

Description    : Returns Role of User by giving userId.

Parameters      : userId = 3 

Body           : None
              
Response        :

```console
['Customer']
```

Token required : No

<hr>


URL 
  ```console
 /api/userroles/roles/userid/{role}
```         
 Method: ```GET```

Description    : Returns all user of given Role .

Parameters      : role ="Customer"

Body           : None
              
Response        :

```console
[
  "2,3,15,16,17,18,19,20,21,22,23,24,25,27"
]
```

Token required : Yes

<hr>


URL 
  ```console
 /api/userroles/roles 
```         

Method: ```POST```

Description    :  Add a user role .

Parameters      :None

Body           :
```console
{
  "userId": 1,
  "roleId": 1
}
```
              
Response        :

```console
true
```

Token required : Yes

<hr>

# Suppliers 

### SuppliersController 

URL            
```console
/api/suppliers/corporate/{supplierId} 
```

Method: ```GET```

Description    : Returns Corporate Id of Supplier .

Parameters      : supplierId = 1

Body           : None
              
Response       :

```console
13
```

Token required : Yes

<hr>


URL            
```console
/api/suppliers/id/{userId}
```

Method: ```GET```

Description    : Returns Supplier Id by giving userId. 

Parameters      : userId  = 13

Body           : None
              
Response        :

```console
1
```

Token required : Yes

<hr>


# Stores 

### StoresController 

URL            
```console
/api/stores/{storeId}/{orderStatus}
```

Method: ```GET```

Description    : Returns a list of orders based on  StoreId and Order status.

Parameters      : storeId  = 1, orderStatus="delivered"

Body           : None
              
Response        :

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

Token required : Yes

<hr>


URL            
```console
/api/stores/orderscount/{storeId} 
```

Method: ```GET```

Description    : Returns a number of orders by its status 

Parameters      : storeId = 1

Body           : None
              
Response        :

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

Token required : Yes

<hr>


URL            
```console
 /api/stores/nearby/{customerAddressId}
```

Method: ```GET```

Description    :   Returns a nearby storeId  by giving customer's AddressId.

Parameters      : customerAddressId=2

Body           : None
              
Response        :

```console
2
```

Token required : Yes

<hr>

URL            
```console
/api/stores/user/{storeId}
```

Method: ```GET```

Description    :  Returns a UserId of store by giving StoreId .

Parameters      : storeId = 2

Body           : None
              
Response        :

```console
22
```

Token required : Yes

<hr>


URL            
```console
/api/stores/storeid/{userId}
```

Method: ```GET```

Description    :  Returns a StoreId of store by giving UserId .

Parameters      : userId = 22

Body           : None
              
Response        :

```console
22
```

Token required : Yes

<hr>


URL            
```console
/api/stores/name/{storeId}
```

Method: ```GET```

Description    : Returns a Name of store by giving StoreId .

Parameters      : storeId = 2

Body           : None
              
Response        :

```console
{
"name":"Manchar Store"
}
```

Token required : Yes

<hr>


# Shopping Cart 

### CartsController 

URL            
```console
 /api/carts/customer/{customerId}
```

Method: ```GET```

Description    : Returns Cart of Customer by customerId.

Parameters      : customerId  = 16

Body           : None
              
Response        :

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

Token required : Yes

<hr>


URL            
```console
 /api/carts
```

Method: ```POST```

Description    : Add Item in Cart returns boolean.

Parameters      : None

Body           :
```console
{
  "customerId": 16,
  "productId": 12,
  "size": "M"
}
```
              
Response        :

```console
true
```

Token required : Yes

<hr>



URL            
```console
 /api/carts/product/present
```

Method: ```POST```

Description    : checks wheather product is already present in a cart returns boolean.

Parameters      : None

Body           :
```console
{
  "customerId": 16,
  "productId": 12,
  "size": "M"
}
```
              
Response        :

```console
true
```

Token required : Yes

<hr>


URL            
```console
 /api/carts/cartitem/{cartItemId}/quantity/{quantity}

```

Method: ```PUT```

Description    : Updates quantity of cartItem returns boolean.

Parameters      : cartItemId=22 , quantity=4

Body           : None
              
Response        :

```console
true
```

Token required : Yes

<hr>


URL            
```console
 /api/carts/remove/{cartItemId}

```

Method: ```DELETE```

Description    : Remove specific item from cart by its cartItemId returns boolean.

Parameters      : cartItemId=22 

Body           : None
              
Response        :

```console
true
```

Token required : Yes

<hr>

URL            
```console
 /api/carts/removeall/{customerId}

```

Method: ```DELETE```

Description    : Empty the cart of customer bt giving customerId returns boolean.

Parameters      : customerId=16

Body           : None
              
Response        :

```console
true
```

Token required : Yes

<hr>


# Shippers

### ShippersController 

URL            
```console
 /api/shippers/{shipperId}/{status}
```

Method: ```GET```

Description    : Returns a list of orders of Shipper  by shipperId and Order status.

Parameters      : shipperId  = 4 ,status="delivered

Body           : None
              
Response        :

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

Token required : Yes

<hr>



URL            
```console
 /api/shippers/orderscount/{shipperId}
```

Method: ```GET```

Description     : Returns a number of orders by its status of that Shipper.

Parameters      : shipperId  = 4 

Body           : None
              
Response        :

```console
{
  "readyToDispatch": 0,
  "picked": 0,
  "inProgress": 0,
  "delivered": 16,
  "cancelled": 0
}
```

Token required : Yes

<hr>


URL            
```console
 /api/shippers/nearby/{storeId}
```

Method: ```GET```

Description     : Returns a nearest Shipper's Id to a store by giving storeId.

Parameters      : storeId  = 1

Body           : None
              
Response        :

```console
4
```

Token required : Yes

<hr>

URL            
```console
 /api/shippers/shipperid/{userId}
```

Method: ```GET```

Description     : Returns a ShipperId by giving UserId.

Parameters      : userId  = 32

Body           : None
              
Response        :

```console
2
```

Token required : Yes

<hr>


# Payments

### PaymentsController 

URL            
```console
 /api/payments/{customerId}
```

Method: ```GET```

Description    : Returns a list of payments of customer by  CustomerId.

Parameters      : customerId  = 16

Body           : None
              
Response        :

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

Token required : Yes

<hr>

URL            
```console
 /api/payments/details/{orderId}
```

Method: ```GET```

Description    : Returns a  payment of a order by  orderId.

Parameters      : orderId  = 90

Body           : None
              
Response        :

```console
{
  "paymentId": 89,
  "date": "2023-10-01T17:47:24",
  "total": 3400,
  "status": "paid",
  "paymentMode": "net banking"
}
```

Token required : Yes

<hr>


URL            
```console
 /api/payments
```

Method: ```POST```

Description    : Add a Payment returns boolean.

Parameters      : None

Body           : 
```console
{
  "mode": "net banking",
  "paymentStatus": "paid",
  "transactionId": 23,
  "orderId": 12
}
```
              
Response        :

```console
true
```

Token required : Yes

<hr>


# Orders

### OrdersController 

URL            
```console
 /api/orders/customer/{customerId}
```

Method: ```GET```

Description    : Returns a list of Orders of customer by  CustomerId.

Parameters      : customerId  = 16

Body           : None
              
Response        :

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

Token required : Yes

<hr>


URL            
```console
 /api/orders/details/{orderId}
```

Method: ```GET```

Description    : Returns a list of Order Details of Order by  orderId.

Parameters      : orderId  = 3

Body           : None
              
Response        :

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

Token required : Yes

<hr>


URL            
```console
 /api/orders/amount/{orderId}
```

Method: ```GET```

Description    : Returns Amount of Order by  orderId.

Parameters      : orderId  = 3

Body           : None
              
Response        :

```console
2620
```

Token required : Yes

<hr>

URL            
```console
 /api/orders/address/{orderId}
```

Method: ```GET```

Description    :  Returns a Delivery Address Id of Order by  orderId.

Parameters      : orderId  = 3

Body           : None
              
Response        :

```console
3
```

Token required : Yes

<hr>


URL            
```console
 /api/orders
```

Method: ```POST```

Description    :  Creates an Order and return orderId,StoreId and Its Amount.

Parameters      : None

Body           : 
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
              
Response        :

```console
{
  "orderId": 95,
  "storeId": 1,
  "amount": 120
}
```

Token required : Yes

<hr>


URL            
```console
 /api/orders/{orderId}
```

Method: ```DELETE```

Description    :  Remove an Order by  orderId return boolean.

Parameters      : orderId  = 3

Body           : None
              
Response        :

```console
true
```

Token required : Yes

<hr>


URL            
```console
 /api/orders/status
```

Method: ```PATCH```

Description    :   Update an Order status return boolean.

Parameters      : None

Body           : 
```console
{
  "orderId": 3,
  "status": "delivered"
}
```
              
Response        :

```console
true
```

Token required : Yes

<hr>



# Consulting

### ConsultingController 

URL            
```console
/api/consulting
```

Method: ```GET```

Description    : It is used for get all questions.

Parameters      : None.

Body           : None
              
Response        :

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

Token required : No

<hr>


URL            
```console
/api/consulting/questioncatagories
```

Method: ```GET```

Description    : it is used for get all question categories.
Parameters      : None.

Body           : None
              
Response        :

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

Token required : No

<hr>


URL            
```console
/api/consulting/answers/{id}
```

Method: ```GET```

Description    : it is used for get answer of particular question.
Parameters      : id=2

Body           : None
              
Response        :

```console
[
    {
        "question": "What are the best practices for pest and weed control in organic farming?",
        "answers": "In organic farming, you can use methods like companion planting, beneficial insects, and organic pesticides to control pests and weeds without synthetic chemicals.",
        "category": "Crop Cultivation"
    }
]
```

Token required : No

<hr>


URL            
```console
/api/consulting/reletedquestions/{id}
```

Method: ```GET```

Description    : it used for get releted questions of given question.

Parameters      : id=2

Body           : None
              
Response        :

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

Token required : No

<hr>



URL            
```console
/api/consulting/question
```

Method: ```POST```

Description    : it is used for insert new question.

Parameters      : None

Body           : [
    {
        
        "description": " How can I improve soil fertility in my fields?",
        "categoryId": 1
    }
]
              
Response        :

```console
true/false
```

Token required : No

<hr>


URL            
```console
/api/consulting/Questions/Catagory/{categoryid}
```

Method: ```GET```

Description    : it is used for get categoriwise questions.


Parameters      :categoryid=1

Body           : None
              
Response        :

```console
[
    {
        "id": 1,
        "customerId": 0,
        "date": "0001-01-01T00:00:00",
        "description": " How can I improve soil fertility in my fields?",
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

Token required : No

<hr>



URL            
```console
/api/consulting/smequestions/{smeid}
```

Method: ```GET```

Description    : it is used for get solved questions of subject matter expert.


Parameters      :smeid=7

Body           : None
              
Response        :

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

Token required : No

<hr>


URL            
```console
/api/consulting/notansweredquestions/{smeid}
```

Method: ```GET```

Description    : it is used for notansweredquestions list of sme.

Parameters      :smeid=7

Body           : None
              
Response        :

```console
[]
```

Token required : No

<hr>


# BI Service

### BI 

URL            
```console
/api/bi/orderscount/{todaysDate}/{storeId}
```

Method: ```GET```

Description    : it returns OrderCountByStore.


Parameters      : todaysDate=2023-10-18,storeId  = 1.
Body           : None
              
Response        :

```console
{
    "todaysOrders": 1,
    "yesterdaysOrders": 1,
    "weekOrders": 7,
    "monthOrders": 17
}
```

Token required : Yes

<hr>


URL            
```console
/api/bi/topproducts/{todaysDate}/{mode}/{storeId}
```

Method: ```GET```

Description    : it returns TopFiveSellingProducts


Parameters      :todaysDate=2023-10-10 ,mode=week,storeId  = 1.
Body           : None
              
Response        :

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

Token required : Yes

<hr>



URL            
```console
/api/bi/MonthOrders/{year}/{storeId}
```

Method: ```GET```

Description    : it returns MonthsWithOrders.


Parameters      :year=2023,storeId  = 1.
Body           : None
              
Response        :

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

Token required : Yes

<hr>



URL            
```console
/api/bi/categorywiseproducts/{todaysDate}/{mode}/{storeId}
```

Method: ```GET```

Description    : it returns CategorywiseProductsCount



Parameters      :todaysDate=2023-10-10 ,mode=week,storeId  = 1.
Body           : None
              
Response        :

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

Token required : Yes

<hr>



URL            
```console
/api/bi/deliveredorders/{ year}/{shipperId};
```

Method: ```GET```

Description    : it returns DeliveredOrders



Parameters      :todaysDate=2023 ,shipperId  = 2.
Body           : None
              
Response        :

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

Token required : Yes

<hr>

