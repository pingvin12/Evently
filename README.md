# MXC Fullstack

This is a fullstack application called evently.

## Summary

The backend is implemented using C# and Entity Framework, which provides an Object Relational Mapping (ORM) system for working with databases. The database schema is designed using the Code-First approach, where the database schema is generated based on the classes defined in the project.

The backend is organized using a layered architecture, where each layer has a specific responsibility. The layers include the data layer, service layer, and controller layer. The data layer handles all the data storage and retrieval operations using Entity Framework, while the service layer provides business logic and validation for the data. The controller layer handles incoming requests and sends responses back to the client.

The frontend of Evently, a web application for managing events, uses NextAuth.js for authorization. NextAuth.js is a flexible authentication library for Next.js applications that supports various authentication providers, such as Google, Facebook, GitHub, and more.

![image](https://user-images.githubusercontent.com/1901727/220222357-41db7672-1522-48d0-a5cb-db2e20cef862.png)



## ORM Structure

Postgres is used for database, you can configure using the connectionstring that can be found under program.cs

Default structure ->
                Database:mxchazi
                    Schema:core
                        Table:events
                            Columns: name(varchar)
                                    location(varchar)
                                    country(varchar)
                                    capacity(numeric)
                            
### Notes

Memory based storage will be needed for testing (TODO).
Somehow httppost and httpput both work on the backend and not with the frontend, 
even though both endpoints look they should work as expected.
