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

<h3 align="center">Consulting</h3>

<h4>ConsultingController </h4>

URL            
```console
/api/consulting
```

Method: ```GET```

Description    : it is used for get all questions.

Parameterss      : none.

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
Parameterss      : none.

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
Parameterss      : id=2

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

Parameterss      : id=2

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

Method: ```Post```

Description    : it is used for insert new question.

Parameterss      : none

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

Method: ```Get```

Description    : it is used for get categoriwise questions.


Parameterss      :categoryid=1

Body           : none
              
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

Method: ```Get```

Description    : it is used for get solved questions of subject matter expert.


Parameterss      :smeid=7

Body           : none
              
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

Method: ```Get```

Description    : it is used for notansweredquestions list of sme.

Parameterss      :smeid=7

Body           : none
              
Response        :

```console
[]
```

Token required : No

<hr>


