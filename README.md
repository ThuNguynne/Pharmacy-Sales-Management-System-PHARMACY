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

> *(Add screenshots of Use Case diagram, Class diagram, and ERD here)*

---

## Academic Note

This repository is an academic OOAD course project developed for portfolio and internship review purposes. The system was designed and specified; implementation code is included where available.

**Course:** Object-Oriented Analysis & Design — University of Finance & Marketing (UFM)  
**Period:** April 2026  
**Contributor:** Nguyen Anh Thu
