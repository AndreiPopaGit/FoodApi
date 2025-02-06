# FoodTrack

FoodTrack is a comprehensive .NET-based application designed to efficiently manage and track food-related data. The project follows a modular architecture, organized into several core components to ensure scalability, maintainability, and separation of concerns.

## Project Structure

- **FoodTrack.Core:** Contains the core business logic and domain models, defining the fundamental operations and entities of the application.
- **FoodTrack.DataAccess:** Manages data access operations, interacting with databases to perform CRUD operations and data retrieval.
- **FoodTrack.Database:** Includes database schemas, migrations, and scripts necessary for setting up and maintaining the database structure.
- **FoodTrack.Repository:** Implements the repository pattern, providing an abstraction layer over the data access logic to promote clean and testable code.
- **FoodTrack.Services:** Handles the application services, orchestrating business logic and coordinating between different modules to fulfill application requirements.
- **FoodTrack2:** Serves as the main application layer, integrating all modules and acting as the entry point for the application.
