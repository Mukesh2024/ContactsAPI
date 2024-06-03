# Contacts-API
1. There is one solution folders ContactsAPI.
2. Contacts API has 4 methods to perform CRUD Operations
3. Contacts API has two projects ContactsAPI and ContactsAPITest
4. ContactsAPITest covers unit test case
5. User need to download both the folders ContactsAPITest and ContactsAPI
6. Technology- .net core

# Application Structure
  We have created two projects ContactsAPI and ContactsAPITest
  In ContactAPI we have written all our business logic and separated out in three layers
  1. Controller
  2. Services
  3. Repository
	
Code is decoupled using three layers and dependencies are registered in Program.cs,
To resolve the dependency in our classes we have used constructor dependency

Currently we are writing/reading our data in json file. Repository will help to increase the scope if in 
future we want to save this data in database.

# Global Exception Handling
We have created custom middleware(named ExceptionMiddleware) to handle the exception Globally
This custom middleware is registered in progam.cs. 

Exception thrown by exceptionmiddleware will be captured on UI where we have used Http interceptor
which will capture the exception message on UI Globally and will be displayed on UI	using snakbar.

# Current Design Scalability Features
1. Separation of Concerns:
a. Controller Layer: Handles HTTP requests and responses.
b. Service Layer: Implements business logic and acts as an intermediary between the controller and the repository.
c. Repository Layer: Manages data access, including reading and writing to a JSON file.
	
2. Repository Pattern:
The repository pattern abstracts data access, allowing easy replacement of the data storage mechanism. If the JSON file storage becomes insufficient, you can switch to a more robust database like SQL Server, MongoDB, or PostgreSQL without changing the business logic or controllers.
3. Dependency Injection:
Using dependency injection (DI) for services and repositories makes the application more modular and testable. DI allows easy swapping of implementations, which is crucial for scaling (e.g., replacing a repository that reads from a JSON file with one that accesses a distributed database).

# Potential Scalability Enhancements
1. Switch to a Database:
Problem: JSON file storage is not suitable for a large number of contacts due to performance and concurrency issues.
Solution: Use a relational database (like SQL Server or PostgreSQL) or a NoSQL database (like MongoDB) for better performance, indexing, and querying capabilities.
Implementation: Replace the JSON file operations in UserRepository with database operations using an ORM like Entity Framework.
2. Asynchronous Processing:
Problem: Synchronous operations can become bottlenecks as they wait for I/O operations to complete.
Solution: Continue using asynchronous methods (async/await) to improve the application's ability to handle many concurrent operations without blocking threads.
3. Caching:
Problem: Frequent reads from the database or JSON file can become a performance bottleneck.
Solution: Implement caching (e.g., using in-memory caching with MemoryCache or distributed caching with Redis) to reduce read load on the database.
4. Horizontal and Vertical Scaling:
Horizontal Scaling: Add more instances of the application server behind a load balancer to distribute the load.

Vertical Scaling: Increase the resources (CPU, memory) of the existing server to handle more load.

5. API Rate Limiting and Throttling:
Implement API rate limiting and throttling to control the number of requests a client can make within a specific time period