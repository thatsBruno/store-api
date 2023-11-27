# store-api

## In this project I utilize a number of different techniques and technologies to develop a backend system with .Net.
Below you can find a detail list of the methods used in the application, but in sum the application is developed based
on the repository pattern and the specification pattern together with type generics, providing the data in DTOs using AutoMapper.
Locally the project uses SQLite just for the simplefication purpose of the application, and it introduzes the identity for loging and registration.
Caching is introduced, together with Redis and a payment method ( Stripe ).

## The front end is developed in Angular, and in the repo we can see that many Angular techniques were used such as, lazy loading,
 routing, reactive forms, reusable componenet and async validation. The styling of the application is provided by th Bootstrap libaray.


.Net Core
C# Generics
Paging, Sorting, Searching and Filtering
ASP.NET Identity for login and registration
DbContext as context boundaries
Repository and Unit of Work Pattern
Specification Pattern
Caching
Automapper in ASP.NET Core
