<div align="center">

# 🛍️ FakeStore API

### Clean Architecture Implementation in .NET 9

<p align="center">
    <img src="https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET" />
    <img src="https://img.shields.io/badge/C%23-11.0-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#" />
    <img src="https://img.shields.io/badge/ASP.NET-Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="ASP.NET Core" />
    <img src="https://img.shields.io/badge/License-MIT-blue?style=for-the-badge" alt="License" />
</p>

<p align="center">
  <b>A modern, clean, and maintainable implementation of a client for the FakeStore API</b><br>
  Built with Clean Architecture, SOLID principles, and Domain-Driven Design
</p>

</div>

<br>

## ⭐ Overview

This project showcases a professional implementation of a RESTful API client for the [FakeStore API](https://fakestoreapi.com/), demonstrating best practices in software architecture, design patterns, and modern .NET development. It serves as both a functional product management system and an educational resource for developers looking to implement Clean Architecture in real-world applications.

<br>

## 📋 Table of Contents

- [Features](#-features)
- [Architecture](#-architecture)
- [Key Design Decisions](#-key-design-decisions)
- [Technologies Used](#-technologies-used)
- [Getting Started](#-getting-started)
- [API Endpoints](#-api-endpoints)
- [Clean Architecture Principles](#-clean-architecture-principles)
- [Learning Resources](#-learning-resources)
- [Contributing](#-contributing)
- [License](#-license)

<br>

## ✨ Features

<table>
  <tr>
    <td width="50%">
      <h3>Core Features</h3>
      <ul>
        <li>Complete product CRUD operations</li>
        <li>RESTful API design</li>
        <li>Standardized response format</li>
        <li>Comprehensive error handling</li>
      </ul>
    </td>
    <td width="50%">
      <h3>Technical Features</h3>
      <ul>
        <li>Clean Architecture implementation</li>
        <li>Use Case pattern approach</li>
        <li>Input validation with FluentValidation</li>
        <li>Resilient HTTP communication</li>
      </ul>
    </td>
  </tr>
</table>

<br>

## 🏗️ Architecture

The solution follows Clean Architecture principles with distinct layers and clear separation of concerns:

```
FakeStore/
│
├── Core
│   ├── FakeStore.Domain/               # Core domain layer
│   │   ├── Entities/                   # Domain entities
│   │   ├── Exceptions/                 # Domain-specific exceptions
│   │   ├── ValueObjects/               # Value objects
│   │   └── Specifications/             # Domain business rules
│   │
│   └── FakeStore.Application/          # Application layer
│       ├── Common/                     # Shared components
│       ├── DTOs/                       # Data Transfer Objects
│       ├── Interfaces/                 # Interfaces for use cases
│       ├── UseCases/                   # Business logic use cases
│       └── DependencyInjection/        # IoC configuration
│
└── Infrastructure
    ├── FakeStore.Infrastructure/       # Infrastructure layer
    │   ├── ApiClient/                  # FakeStore API client
    │   ├── Services/                   # Infrastructure services
    │   └── DependencyInjection/        # IoC configuration
    │
    └── FakeStore.WebApi/               # Presentation layer
        ├── Controllers/                # API controllers
        ├── Middleware/                 # HTTP pipeline components
        └── Program.cs                  # Application entry point
```

<div align="center">
  <img src="https://raw.githubusercontent.com/jasontaylordev/CleanArchitecture/main/.github/clean-architecture.png" alt="Clean Architecture Diagram" width="500px" />
  <p><i>Visualization of Clean Architecture layers and dependencies</i></p>
</div>

<br>

## 🧪 Key Design Decisions

### Direct API Client Access

> Unlike traditional Clean Architecture implementations that use repositories, this project has use cases directly accessing the API client, eliminating an unnecessary abstraction layer.

### Use Case Pattern vs. Mediator Pattern

> Each business operation is encapsulated in its own use case with clear interfaces rather than using the popular MediatR library, making the flow of data and responsibilities more explicit.

### Standardized Error Handling

> A comprehensive exception handling system transforms all errors into consistent API responses with appropriate HTTP status codes, making the API more predictable and user-friendly.

### Typed Requests and Responses

> Each operation has dedicated request and response types, enabling strong typing throughout the application and making the API contracts explicit.

<br>

## 🔧 Technologies Used

<table>
  <tr>
    <td><b>.NET 9</b></td>
    <td>Latest version of the .NET platform</td>
  </tr>
  <tr>
    <td><b>ASP.NET Core</b></td>
    <td>Web API framework</td>
  </tr>
  <tr>
    <td><b>FluentValidation</b></td>
    <td>Elegant validation for request objects</td>
  </tr>
  <tr>
    <td><b>Polly</b></td>
    <td>Resilience and transient-fault-handling library</td>
  </tr>
  <tr>
    <td><b>Swagger/OpenAPI</b></td>
    <td>API documentation and testing</td>
  </tr>
</table>

<br>

## 🚀 Getting Started

### Prerequisites

- .NET 9 SDK
- IDE of your choice (Visual Studio, VS Code, Rider)

### Building and Running

1. Clone the repository
   ```bash
   git clone https://github.com/yourusername/fakestore-api.git
   cd fakestore-api
   ```

2. Build the solution
   ```bash
   dotnet build
   ```

3. Run the application
   ```bash
   dotnet run --project FakeStore.WebApi
   ```

4. Access the Swagger UI
   ```
   https://localhost:5001/swagger
   ```

<br>

## 📝 API Endpoints

| Method | Endpoint             | Description               |
|--------|---------------------|---------------------------|
| GET    | `/api/products`     | Get all products          |
| GET    | `/api/products/{id}` | Get product by ID         |
| POST   | `/api/products`     | Create a new product      |
| PUT    | `/api/products/{id}` | Update an existing product|
| DELETE | `/api/products/{id}` | Delete a product          |

<br>

## 🧠 Clean Architecture Principles

This project adheres to key Clean Architecture principles:

- **Dependency Rule**: Dependencies only point inward, with inner layers having no knowledge of outer layers
- **Separation of Concerns**: Each layer has distinct responsibilities
- **Boundary Crossing**: DTOs are used to transfer data between architectural boundaries
- **Dependency Inversion**: Core business logic depends on abstractions, not concrete implementations
- **Explicit Dependencies**: All components declare their dependencies explicitly
- **Testability**: All components can be easily tested in isolation

<br>

## 📚 Learning Resources

If you're new to Clean Architecture or want to learn more, check out these resources:

- [Clean Architecture by Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [SOLID Principles](https://en.wikipedia.org/wiki/SOLID)
- [Domain-Driven Design](https://martinfowler.com/bliki/DomainDrivenDesign.html)

<br>

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the project
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

Please ensure your code follows the project's coding standards and includes appropriate tests.

<br>

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

<div align="center">
  <p>Developed with ❤️ by <a href="https://github.com/yourusername">Your Name</a></p>
</div>


