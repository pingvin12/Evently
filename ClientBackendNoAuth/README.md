# Backend client

This is the backend for evently featuring only database management using a webapi.

## Summary

The backend is implemented using C# and Entity Framework, which provides an Object Relational Mapping (ORM) system for working with databases. The database schema is designed using the Code-First approach, where the database schema is generated based on the classes defined in the project.

The backend is organized using a layered architecture, where each layer has a specific responsibility. The layers include the data layer, service layer, and controller layer. The data layer handles all the data storage and retrieval operations using Entity Framework, while the service layer provides business logic and validation for the data. The controller layer handles incoming requests and sends responses back to the client.


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