

# 🚀 eCommerce Platform with .NET Core 6 and Onion Architecture 🛍️

Welcome to my **eCommerce Platform**, a scalable web application built using **.NET Core 6** with **Onion Architecture** to ensure clean code separation, maintainability, and scalability.

## Highlights

### ✅ **Tech Stack & Key Features:**

- **ASP.NET Core 6.0**: The latest version of ASP.NET Core, providing a fast and secure web framework for building APIs and web applications.
- **Onion Architecture**: A layered architecture to separate core business logic from dependencies like the database and UI.
- **SQL Server**: A powerful, reliable database system used to store product data, user information, and transactions.
- **ASP.NET Core Identity**: Provides user authentication and authorization with role-based management.
- **JWT Authentication**: Secure token-based authentication with JSON Web Tokens (JWT), implemented for role management and session handling.
- **Entity Framework Core (EF Core)**: Object-relational mapper (ORM) for working with SQL Server and implementing database operations.
- **LINQ (Language Integrated Query)**: A query syntax for data querying and manipulation, used to interact with EF Core for complex queries.
- **Generic Repository & Unit of Work Pattern**: Implements a clean, maintainable data access layer.
- **AutoMapper**: Maps between domain models and DTOs (Data Transfer Objects) for more efficient data transfer between layers.
- **DTOs (Data Transfer Objects)**: Used to simplify data handling and communication between layers of the application.
- **Specification Pattern**: Implemented for dynamic querying and filtering within the repository layer.
- **Data Seeding**: Automatic population of the database with default users, roles, and products.
- **Redis**: Used for caching to improve performance and reduce the load on the database.
- **Stripe Payment Integration**: Fully integrated with Stripe for secure and reliable payment processing.
- **Global Error Handling**: Centralized error handling mechanism ensuring robustness and clean exception logging.

## 🌟 **Features:**

1. **User Registration & Login**: Complete authentication system with roles (admin, customer).
2. **JWT-Based Authentication**: Secure token generation, token refresh, and role-based authentication using JWT.
3. **Product Management**: CRUD operations for products, including category and price filters.
4. **Shopping Cart**: Add, update, or remove items from the cart.
5. **Order Management**: Create, view, and track orders. Integration with Stripe for secure payments.
6. **Data Caching**: Performance boost with Redis caching.
7. **Error Handling**: Robust error logging and handling to catch and resolve any issues.

## 🚀 **Getting Started:**

1. **Clone the repository**:
   ```bash
   git clone https://github.com/Yahia-Zakaria20/Talabat.Project
   ```

2. **Navigate to the solution directory**:
   ```bash
   cd Talabat.Project/src
   ```

3. **Setup Database (SQL Server)**:
   Update the connection string in the `appsettings.json` file.

4. **Run Migrations**:
   ```bash
   dotnet ef database update
   ```

5. **Seed Data**:
   ```bash
   dotnet run --seed
   ```

6. **Run the Application**:
   ```bash
   dotnet run
   ```

7. **Stripe Setup**:
   - Configure your Stripe keys in the `appsettings.json`.
   - Set up a webhook to handle payment notifications.

8. **Test the API**: Use Postman or Swagger UI to interact with the API.

## 📚 **How to Contribute:**

1. Fork the repository.
2. Create a new feature branch.
3. Commit your changes and submit a pull request.

## 🤝 **Contact & Support**:

Feel free to reach out via LinkedIn if you have any questions or would like to discuss the project further!

