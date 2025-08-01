# 🏥 Simple_Clinic API

A complete backend system for managing a medical clinic, built using ASP.NET Core Web API, following the 3-Tier Architecture with support for DTOs, and Entity Framework Core.

---

## 📌 Features

- 🧑‍⚕️ Manage Patients & Doctors
- 📅 Handle Appointments
- 📁 Maintain Medical Records
- 💊 Generate Prescriptions
- 💰 Record Payments

- 🧱 Clean separation using 3-Tier Architecture

---

## 🧱 Architecture – 3 Tiers

### 1. **Presentation Layer** (`SimpleClilicAPI`)
- Contains Controllers only
- Receives HTTP requests
- Sends/returns DTOs

### 2. **Business Layer** (`SampleClilicAPIBusinessLayer`)
- Contains DTOs, Services, MappingProfile
- Implements business logic


---
### 3. **Data Access Layer** (`SampleClilicDataAccessLayer`)
- Contains Entity Framework models and `AppDbContext`
- Manages database communication

---
✅ Relational Endpoints:
- Get appointments/records for a patient
- Link medical records to appointments

✅ Clean Separation of Concerns  
✅ AutoMapper for object mapping  
✅ RESTful API principles  
✅ Integrated Swagger UI

---

## 🛠️ Technologies

- ASP.NET Core Web API (.NET 6+)
- Entity Framework Core (Code First)
- SQL Server (LocalDB or full instance)
- DTOs
- Swagger / Swashbuckle

---

## 🧪 API Testing

Swagger UI is integrated for testing and exploring the API.

- ✅ Base URL: `https://localhost:{PORT}/swagger`
- ✅ All endpoints organized by resource (Patient, Doctor, etc.)


## 📁 Folder Structure

SampleClilicAPI
│
├── SampleClilicAPI # Presentation Layer (Controllers)
├── SampleClilicAPIBusinessLayer # Business Logic Layer (Services, Interfaces)
└── SampleClilicDataAccessLayer # Data Access Layer (EF Models, Repositories, Interface ,Data)

yaml
نسخ
تحرير

---

## 📌 Notes

- No frontend/UI is included. This is a pure backend project.
- Designed for future integration with web or mobile apps.
- You must configure your `appsettings.json` for your SQL Server connection string.


