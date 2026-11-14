# DVLD-Project & mini Vehicle License Department System
A comprehensive desktop application designed to manage the operation of a driving and Vehicle License Department.
Built with C# (.NET Framework), windows forms, and SQL Server, following a clean 3-Tier Architecture to ensure separation of concerns, maintainability, and scalability.

---

## Project Architecture 

The solution is structured into 3 distinct layers alongside the database resources:
DVLD_Presentation: The User Interface (UI) layer built with Windows Forms, handling user interactions, input validation, and custom controls.
DVLD_BusinessLogicLayer: Contains the core business rules, entities, and logic acting as a bridge between the UI and Data Access layers.
DVLD_DataAccessLayer: Handles direct communication with the SQL Server database using ADO.NET and parameterized queries.
Database: Contains the full SQL Server database script (Schema + Initial Data) required to set up and run the system.

## Key Features

_ People & Users Management: Full CRUD operations for managing citizens' records, system users, and role-based permissions.
Driving License Applications:
Issue New Local Driving Licenses.
Issue International Driving Licenses.
Renew, Replace (Lost/Damaged), and Release Detained Licenses.

_ Test Appointments & Scheduling: Manage vision, written (theory), and practical street test appointments, track attempts, and record results.

_ Drivers & Licenses Tracking: View complete driver history, active/expired licenses, and detained license records.

_ Application Types & Test Fees: Configurable system settings for service fees and test types.

---

Technologies Used

_ Language: C#
_ Framework: .NET Framework (Windows Forms)
_ Database: Microsoft SQL Server Management (SSMS)
_ Data Access: ADO.NET
_ Architecture: 3-Tier Architecture (Presentation, Business Logic, Data Access)

