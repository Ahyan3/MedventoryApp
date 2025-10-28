# 💊 MedventoryApp
**Medventory: Medicine Dispenser Inventory System**

---

## 🏥 System Overview
**Medventory** is a hospital-based system designed to manage and track the dispensing of medicines from the pharmacy.  
It streamlines the entire process — from **doctors issuing medicine requests**, to **pharmacists dispensing medicines**, to **administrators managing stock and monitoring transactions**.  

The system ensures **accuracy, accountability, and efficiency** in hospital pharmacy operations.

---

## 👥 User Roles and Access Levels

| **Role** | **Responsibilities & Access** |
|-----------|-------------------------------|
| **Super Admin** | - Approves or rejects user sign-ups (doctors, pharmacists, admins) <br> - Deletes user accounts <br> - Has full access to all system functions |
| **Admin** | - Approves medicine receipts issued by doctors <br> - Updates and manages medicine inventory <br> - Monitors all transactions and system logs |
| **Doctor** | - Creates and issues medicine receipts (requests) for patients <br> - Can view request history and status |
| **Pharmacist** | - Reviews and dispenses medicines based on approved receipts <br> - Updates inventory after dispensing <br> - Logs dispensing actions |

---

## ⚙️ System Features

### 🧾 Medicine Request & Approval Workflow
- **Create Medicine Receipts:** Doctors issue digital receipts for the medicines required by patients.  
- **Approve Receipts:** Admin verifies and approves medicine requests before dispensing.

### 📦 Inventory Management
- **Stock Updates:** Admin or pharmacist can add, edit, or update medicine stock levels.  
- **Automatic Deduction:** Stocks are automatically deducted when medicines are dispensed.

### 📊 Tracking & Monitoring
- **Real-Time Stock Monitoring:** Displays available, low-stock, and out-of-stock medicines.  
- **Log History:** Records all transactions (receipt creation, approval, dispensing, inventory changes) for auditing and accountability.

---

## 🧠 Future Enhancements
- 🔐 Role-based authentication with encrypted credentials  
- 📱 Mobile-friendly interface for doctors and pharmacists  
- 📈 Data analytics dashboard for stock usage and medicine trends  
- 📦 Automatic reordering notifications for low-stock medicines  

---

## 🧰 Tech Stack
- **Language:** VB.NET (Windows Forms)  
- **Database:** PostgreSQL / Supabase  
- **IDE:** Visual Studio 2022  
- **Version Control:** Git + GitHub  

---

## ⚙️ Installation Guide

Follow these steps to **set up and run the MedventoryApp** properly:

### 🧩 Prerequisites

Before starting, make sure you have the following installed:

* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (Community edition or higher)
* [.NET 8.0 SDK (or higher)](https://dotnet.microsoft.com/download/dotnet)
* [PostgreSQL](https://www.postgresql.org/download/) or [Supabase](https://supabase.com) account for cloud database
* [Npgsql library](https://www.npgsql.org/download.html) for PostgreSQL database connection

### 🚀 Step-by-Step Installation

1.  **Clone the Repository**
    ```
    git clone [https://github.com/Ahyan3/MedventoryApp.git](https://github.com/Ahyan3/MedventoryApp.git)
    ```

2.  **Open the Solution in Visual Studio**
    Navigate to the project folder:
    ```
    MedventoryApp/
    ```
    Open the solution file:
    ```
    MedventoryApp.sln
    ```

3.  **Restore Dependencies**
    Visual Studio will automatically restore NuGet packages on project load.
    If not, go to:
    `Tools` → `NuGet Package Manager` → `Manage NuGet Packages for Solution` → `Restore All`

4.  **Set Up the Database Connection**
    Open `DatabaseConnection.vb` located under:
    ```
    MedventoryApp/Modules/DatabaseConnection.vb
    ```
    Replace the placeholder credentials with your actual PostgreSQL or Supabase details:
    ```
    conn = New NpgsqlConnection("Host=your_host;Port=5432;Username=your_user;Password=your_password;Database=medventory")
    (for getting the Host, Username, and Password contact Ryan Francis Romano)
    ```

5.  **Import Database Schema**
    Locate the SQL file:
    ```
    MedventoryApp/Database/medventory_db.sql
    ```
    Open your PostgreSQL client (like pgAdmin) or Supabase SQL Editor.
    Run the SQL script to create the necessary tables and sample data.

6.  **Build the Project**
    In Visual Studio, go to the menu bar and click:
    `Build` → `Build Solution (Ctrl + Shift + B)`
    Wait until the build completes with no errors.

7.  **Run the Application**
    Press `F5` or click `Start Debugging`.
    The Login Form should appear.
    You can now log in using your seeded credentials (from your database).
      
---

## 📄 Copyright
© 2025 Ryan Francis Romano — All Rights Reserved.  

