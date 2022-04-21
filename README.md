# Logo Yazılım & Patika.dev .Net Core Bootcamp Graduation Project

Apartment management system with .Net Core 5 MVC and payment system with .Net Core 5 web API.

## Technologies used in project

 - Security made with Microsoft Identity
 - Generic Repository Design Pattern and onion architecture used
 - MS SQL Server used for MVC database7
 - Entity Framework Core used as ORM
 - MongoDb used for payment API database
 - Exception middleware for logging exceptions in application
 - Automapper for converting models to DTOs
 - Fluent Validation for validating models in forms
 - DateTime extension for printing DateTime to desired string format
 
 ## Run project
 - Open package manager console and type update-database
 - Run the project

## Pages

### Login
- User or Admin can login from this page
- You get get error if you leave email or password empty
- If password and email do not match you will get error

![](https://i.hizliresim.com/5j4mtnr.jpg)
![](https://i.hizliresim.com/th4enm0.jpg)

### Admin Index

- Admin can click these 4 fileds to manage user, apartments, invoices and payments

![](https://i.hizliresim.com/8jbfyea.jpg)

### Users Page

- Admin can see the list of users in this page 
- Admin can create, delete, or update users

- Create User

![](https://i.hizliresim.com/92t3ix3.jpg)

- Update User

![](https://i.hizliresim.com/oah0upw.jpg)

- Delete User

![](https://i.hizliresim.com/tqccrzk.jpg)

### Apartments Page

- Admin can see the list of apartments and create, update or delete them

![resim](https://user-images.githubusercontent.com/78491395/164484603-d2081261-c596-43fe-988e-cc196088235d.png)

- Create apartment

![resim](https://user-images.githubusercontent.com/78491395/164484733-a08aab9a-a676-4ab4-aceb-5727df8887b1.png)

- Update apartment

![resim](https://user-images.githubusercontent.com/78491395/164484845-0c0eca2a-4472-4e0d-bc44-7b8d5616a28d.png)

- Delete apartment

![resim](https://user-images.githubusercontent.com/78491395/164484931-13665cc2-173a-4a78-8646-bd21e369dabd.png)

### Invoice Page

- Admin can see the list of invoices and create, update or delete them

![resim](https://user-images.githubusercontent.com/78491395/164485033-3ccc9a45-f067-4d93-b92d-ef295275c8df.png)

- Create Invoice 

![resim](https://user-images.githubusercontent.com/78491395/164485203-78b661fb-e3e2-4e3d-91c4-2dccc162871a.png)

- Update Invoice

![resim](https://user-images.githubusercontent.com/78491395/164485268-d4363e1b-f5ea-4613-a772-d52f4321a370.png)

- Delete Invoice

![resim](https://user-images.githubusercontent.com/78491395/164485324-d0a20ea7-fb65-4c60-bd7a-1ecbcb89755d.png)

- Assign invoice to user(s)

![resim](https://user-images.githubusercontent.com/78491395/164485432-8449d5b4-5def-484e-941c-13206d762450.png)

### Payments page

- Admin can see the payments and filter them to payment status and month

![resim](https://user-images.githubusercontent.com/78491395/164485579-a4949c3f-b2ff-4192-b79c-8da42bc3d35d.png)


## User Index Page

- User can go to his/her invoices or credit carddss from here

![resim](https://user-images.githubusercontent.com/78491395/164485998-8859a518-615b-41d1-81e4-f5e45a86911f.png)


### User Invoice Page

- User can see his/her bills and pay them by clicking the button

![resim](https://user-images.githubusercontent.com/78491395/164486218-3b6ff2b8-40c7-4fe4-b893-566ef296e52d.png)

### User credit card page 

- User can see his/her credit cards and add or delete them

![resim](https://user-images.githubusercontent.com/78491395/164486471-93ea99b4-663e-4d49-8e57-8a57d0f60b24.png)

### Payment page

- User can select his/her credit card and make payment from here

![resim](https://user-images.githubusercontent.com/78491395/164486933-955dc970-cd40-4f52-a177-b4cba4225cb4.png)


### Payment API

- When user creates or deletes credit card or makes payment mvc makes requests to this api endpoints

![resim](https://user-images.githubusercontent.com/78491395/164486640-560b371a-4083-4c01-bc5f-8f254a41c643.png)


