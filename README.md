# Mini Project: Product Management with gRPC

This project demonstrates a gRPC-based application for managing products, offering a high-performance and scalable solution for communication between services.

## Features

1. **Product Management**:
   - CRUD operations for products:
     - Create: Add new products with attributes such as name, price, and category.
     - Read: Fetch product details individually or as a list.
     - Update: Modify product details.
     - Delete: Remove products from the system.

2. **gRPC Communication**:
   - Efficient and fast inter-service communication using Protocol Buffers.
   - Supports streaming and unary calls.

3. **Database Integration**:
   - Uses Entity Framework Core with SQL Server for persistent product storage.

4. **Error Handling**:
   - Implements detailed error messages and response codes for failed operations.

## Technologies Used

- **Backend**:
  - gRPC for communication.
  - ASP.NET Core with gRPC server implementation.
- **Database**:
  - SQL Server for product data storage.
- **Frontend (Optional)**:
  - gRPC client (CLI, .NET Console App, or other supported clients).
