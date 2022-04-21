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
 - Hangfire for running processes in the background
 
 ## Run project
 - Open package manager console and type update-database
 - Run the project

## Pages

- Web application consist of 18 pages

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

![resim](https://user-images.githubusercontent.com/78491395/164557121-52e547eb-f6f0-48ed-bf81-200c30acc2c6.png)

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

- User can go to his/her invoices or credit cards from here

![resim](https://user-images.githubusercontent.com/78491395/164555258-b8ad0273-bf0a-4908-870f-06a6a8cb801a.png)


### User Invoice Page

- User can see his/her bills, filter them by date or payment status and pay them by clicking the button

![resim](https://user-images.githubusercontent.com/78491395/164555400-599de00c-0ee6-4a8a-8c0a-7dc4b18d503e.png)

### User credit card page 

- User can see his/her credit cards and add new card or delete a credit card

![resim](https://user-images.githubusercontent.com/78491395/164555535-51ff9f88-966a-44cf-bd6b-19f5fb827089.png)

### Payment page

- User can select his/her credit card and make payment from here

![resim](https://user-images.githubusercontent.com/78491395/164555604-94c46f2c-eb83-442e-8d93-dc84a2d1ad8c.png)

### 500 Internal Server Error Page

![resim](https://user-images.githubusercontent.com/78491395/164557768-9da93759-6a53-4571-b971-59f8e8490107.png)

### 404 Not Found Page

![resim](https://user-images.githubusercontent.com/78491395/164557850-4365ba12-719c-4856-9e42-fb823b1f305c.png)

## Payment API

- When user creates or deletes credit card or makes payment mvc makes requests to this api endpoints

![resim](https://user-images.githubusercontent.com/78491395/164555652-e50136f9-e1fc-4536-9b74-ac0811a4a3e7.png)

### Hangfire Dashboard

![resim](https://user-images.githubusercontent.com/78491395/164560924-2592bd56-2009-4000-9495-ac663f6f0d6f.png)


### Database Diagrams

- MS SQL Server

![resim](https://user-images.githubusercontent.com/78491395/164556368-62768e3d-b042-4695-bcb8-6a322d3c9d89.png)

- MongoDB Users Table Object

![resim](https://user-images.githubusercontent.com/78491395/164556601-bb526e79-0862-4361-ae94-1d3d5e1fda50.png)
