<h3 align="center">UserRoleManagement </h3>

<h4>UserRoleController </h4>

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
true/false
```

Token required : Yes

<hr>

<h3 align="center">Suppliers </h3>

<h4>SuppliersController </h4>

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


<h3 align="center">Suppliers </h3>

<h4>SuppliersController </h4>

URL            
```console
/api/suppliers/corporate/{supplierId} 
```

Method: ```GET```

Description    : Returns Corporate Id of Supplier .

Parameters      : supplierId  =1

Body           : None
              
Response        :

```console
13
```

Token required : Yes

<hr>


<h3 align="center">Stores </h3>

<h4>StoresController </h4>

URL            
```console
/api/stores/{storeId}/{orderStatus}
```

Method: ```GET```

Description    : Returns a list of orders based on  StoreId and Order status.

Parameterss      : storeId  = 1, orderStatus="delivered"

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
