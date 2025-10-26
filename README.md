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

## 📄 License
© 2025 Ryan Francis Romano — All Rights Reserved.  
*(You can replace this with an open-source license like MIT or Apache 2.0 if you wish.)*

