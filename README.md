# 🌾 Cifcisinden

Welcome to the **Cifcisinden** project! This repository is dedicated to managing and handling data operations efficiently.

## 📚 Table of Contents
- [About](#about)
- [Technologies](#technologies)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)
- [Acknowledgements](#acknowledgements)

## 📖 About
The **Cifcisinden** project is designed to streamline data operations using modern software development practices. The main goal is to provide a robust and scalable framework for managing CRUD operations and transaction management efficiently.

This application allows farmers to create and manage advertisements for renting agricultural tools. Farmers can add, update, delete, and retrieve rental advertisements, making it easier to rent farming equipment.

## 🛠️ Technologies
The following technologies and libraries are used in this repository:

- **Programming Language**: C#
- **Framework**: .NET Core
- **ORM**: Entity Framework Core
- **Database**: SQL Server (configured via Entity Framework)
- **Design Patterns**:
  - Repository Pattern: For abstracting data access logic
  - UnitOfWork Pattern: For managing database transactions

### 📚 Libraries
- `Microsoft.EntityFrameworkCore`: For interacting with the database using Entity Framework Core
- `System.Linq`: For querying data collections
- `System.Threading.Tasks`: For asynchronous programming

## ✨ Features
### 🗃️ Repository Pattern
The repository pattern is implemented to provide a clean separation of concerns between the data access logic and the business logic. This ensures that the data access logic is isolated and can be easily tested.

### 🔄 UnitOfWork Pattern
The UnitOfWork pattern is used to manage database transactions. It ensures that a group of operations either succeed or fail as a whole, maintaining data integrity.

### 📝 CRUD Operations
The project supports basic Create, Read, Update, and Delete (CRUD) operations for managing data entities.

### 🚀 Asynchronous Programming
This project is coded using asynchronous programming to improve application performance and responsiveness.

### 🌾 Advertisement Management
The application provides functionality for farmers to create and manage advertisements for renting agricultural tools. This includes:
- Adding new rental advertisements with details such as title, description, category, crop, location, and contact information.
- Updating existing rental advertisements.
- Deleting rental advertisements.
- Retrieving single or multiple rental advertisements.

### 🧩 OOP and SOLID Principles
This project is coded using Object-Oriented Programming (OOP) and adheres to SOLID principles to ensure maintainability, scalability, and testability.

## 🛠️ Installation
To install and set up the project, follow these steps:

1. Clone the repository:
    ```bash
    git clone https://github.com/yilmazcinar/Cifcisinden.git
    ```
2. Navigate to the project directory:
    ```bash
    cd Cifcisinden
    ```
3. Install the necessary dependencies:
    ```bash
    dotnet restore
    ```
4. Update the database configuration in `appsettings.json` to match your SQL Server setup.

5. Apply database migrations:
    ```bash
    dotnet ef database update
    ```

## 🚀 Usage
To run the project, use the following command:
```bash
dotnet run
```
This will start the application and make it accessible at `https://localhost:5001`.

### Examples
Here are some examples of how to use the project:

#### Adding a New Entity
```csharp
var newEntity = new YourEntity
{
    // Set properties
};
await _unitOfWork.YourEntityRepository.Add(newEntity);
await _unitOfWork.SaveChangesAsync();
```

#### Fetching All Entities
```csharp
var entities = await _unitOfWork.YourEntityRepository.GetAll().ToListAsync();
```

#### Updating an Entity
```csharp
var entity = await _unitOfWork.YourEntityRepository.GetById(id);
if (entity != null)
{
    entity.Property = newValue;
    _unitOfWork.YourEntityRepository.Update(entity);
    await _unitOfWork.SaveChangesAsync();
}
```

#### Deleting an Entity
```csharp
await _unitOfWork.YourEntityRepository.Delete(id);
await _unitOfWork.SaveChangesAsync();
```

### Advertisement Management
#### Adding a New Rental Advertisement
```csharp
var newAdvert = new AddAdvertDto
{
    Title = "Tractor for Rent",
    Description = "A well-maintained tractor available for rent.",
    ServiceCategory = ServiceCategory.Rental,
    Crop = Crop.Wheat,
    City = City.Ankara,
    Town = Town.Cankaya,
    Adress = "123 Farming St",
    PhoneNumber = "555-1234",
    UserId = 1
};
var result = await _advertService.AddAdvert(newAdvert);
```

#### Fetching All Rental Advertisements
```csharp
var adverts = await _advertService.GetAllAdverts();
```

## 🤝 Contributing
We welcome contributions to the **Cifcisinden** project! To contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes and commit them (`git commit -m 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Create a new Pull Request.

## 📜 License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## 🌟 Acknowledgements
Special thanks to [contributors] for their contributions and support.

Feel free to reach out if you have any questions or need further assistance!

![GitHub Logo](https://avatars.githubusercontent.com/u/187036189?v=4)
