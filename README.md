# Pharmacy Sales Management System (PHARMACY)

> **Academic course project** — Object-oriented analysis and design (OOAD) of a GPP-compliant point-of-sale system for a pharmacy business, covering requirements analysis, full UML artifact set, and database modeling.

---

## Business Problem

Pharmacy operations require strict compliance with Good Pharmacy Practice (GPP) standards, including First-Expired-First-Out (FEFO) inventory control, controlled prescription handling, and multi-role access permissions. This project models a structured POS solution addressing these requirements through systematic analysis and system specification.

---

## Functional Scope

| Module | Key Capabilities |
|---|---|
| Point of Sale | Drug sales, receipt generation, payment processing |
| Inventory Management | Stock control, FEFO enforcement, low-stock alerts |
| Prescription Handling | Doctor prescription validation, dispensing workflow |
| Supplier Management | Purchase orders, supplier records |
| Authentication | OTP-based login, RBAC permission control |
| Reporting | Sales and inventory summary reports |

---

## Analysis Artifacts

This project applies the Unified Process (UP) methodology with full UML documentation:

| Artifact | Details |
|---|---|
| Use Case Diagram | 4 actor roles, 20+ use cases |
| Use Case Specifications | Detailed main/alternative flows per UC |
| Activity Diagrams | Process flows per functional module |
| Sequence Diagrams | Object interaction for key scenarios (e.g. UC001: Sell Drug) |
| State Machine Diagram | Prescription lifecycle states |
| Class Diagram | Full class model with FEFO method, associations, multiplicities |
| ERD | Entity Relationship Diagram with entity-mapping tables |

> Full documentation available in [Google Drive](https://drive.google.com/drive/folders/13MfgmvtTG9k9pnG_eszWpCJFjK3f2_UZ)

---

## Key Business Rules Modeled

- **FEFO (First-Expired-First-Out)** — inventory consumption order enforced at the `DrugLot` class level via `applyFEFO()` method
- **OTP Authentication** — two-step login for pharmacist and admin roles
- **RBAC** — four actor roles with distinct access permissions: Pharmacist, Warehouse Staff, Doctor, Admin

---

## Technology Stack

| Layer | Technology |
|---|---|
| Modeling | Enterprise Architect (UML), Draw.io (ERD) |
| Documentation | Word, Google Docs |
| Database Design | SQL Server (schema only — design-phase project) |
| Architecture | 3-layer architecture (Presentation / Business Logic / Data Access) |

---

## Repository Structure

```
/docs           → Use Case specs, UML diagrams (exported)
/database       → ERD, entity-mapping tables, schema scripts
/screenshots    → Diagram screenshots for quick reference
README.md
```

---

## Screenshots
Use Case
<img width="440" height="390" alt="image" src="https://github.com/user-attachments/assets/9889d127-0582-44b3-b445-96f54e597ae0" />
Class
<img width="440" height="317" alt="image" src="https://github.com/user-attachments/assets/d7dda05c-7038-494d-97cc-5f0ff4a0b30b" />
Program
<img width="440" height="274" alt="image" src="https://github.com/user-attachments/assets/0bf74fdb-0e1f-46c3-aca2-a9746af1728e" />
<img width="440" height="279" alt="image" src="https://github.com/user-attachments/assets/67774ac8-dc4e-4be3-ad28-846bbf6e934f" />
<img width="328" height="137" alt="image" src="https://github.com/user-attachments/assets/ba86d4d8-800e-4ae6-ad00-7603b67aa79d" />
<img width="289" height="309" alt="image" src="https://github.com/user-attachments/assets/a3ee9c72-257d-4e6b-a044-9e99bd035a6f" />        <img width="178" height="229" alt="image" src="https://github.com/user-attachments/assets/4c21e467-5e02-4285-a75c-4709077e120c" />
<img width="357" height="213" alt="image" src="https://github.com/user-attachments/assets/4e184cb8-f761-411d-9b66-ed7608bc04a8" />
<img width="324" height="193" alt="image" src="https://github.com/user-attachments/assets/1a99c3dd-72b1-427f-ac50-43986f1c5dd0" />




---

## Academic Note

This repository is an academic OOAD course project developed for portfolio and internship review purposes. The system was designed and specified; implementation code is included where available.

**Course:** Object-Oriented Analysis & Design — University of Finance & Marketing (UFM)  
**Period:** April 2026  
**Contributor:** Nguyen Anh Thu
