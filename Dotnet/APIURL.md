<h3 align="center">UserRoleManagement </h3>

<h4>UserRoleController </h4>

URL            
```console
/api/userroles/roles/{userId}
```
 Method: ```GET```
Description    : Returns Role of User by giving userId.
Parameter      : userId  : int
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
Parameter      : role : string
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
Parameter      :None
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
Parameter      : supplierId  : int
Body           : None
              
Response        :

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
Parameter      : userId  : int
Body           : None
              
Response        :

```console
1
```

Token required : Yes

<hr>
