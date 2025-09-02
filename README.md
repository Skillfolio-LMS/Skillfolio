# ✨ Skillfolio - Personal Skill Management System

---

## 📖 1. Project Overview

Skillfolio is a **personal skill management and tracking system** designed to help individuals:

* Organize and monitor their technical skills.
* Showcase mastered skills.
* Track ongoing learning.
* Plan future skills to acquire.

This ensures visibility into **personal growth** and readiness for **new opportunities**.

---

## 🎯 2. Core Concept

Skillfolio organizes skills into **three stages of development**:

### 🔹 A. Learned

Skills already acquired.

**Categories:** Programming, Frameworks/Libraries, Databases, DevOps/Tools
**Attributes:**

* Skill Name (e.g., JavaScript, PostgreSQL)
* Points (1–5) → proficiency measure

**Proficiency Scale:**

1. Awareness – Heard of the skill.
2. Beginner – Can follow tutorials, write small examples.
3. Practitioner – Applies in projects with guidance.
4. Proficient – Designs & troubleshoots independently.
5. Expert – Mentors others, applies advanced patterns.

---

### 🔹 B. Learning

Skills currently being developed.

**Categories:** Same as Learned
**Attributes:**

* Skill Name
* Progress (1–5)

**Learning Progress Scale:**

1. Getting Started – Basics, setup, docs.
2. Building Basics – Tutorials, first labs.
3. Active Practice – Consistent practice, small projects.
4. Applied Projects – Confident real-world use.
5. Near Mastery – Production-ready, externally validated.

---

### 🔹 C. Wish to Learn

Skills planned for future acquisition.

**Categories:** Same as Learned
**Attributes:**

* Skill Name
* Priority (High / Medium / Low)

**Priority Labels:**

* **High** → Critical, start in 1–3 months.
* **Medium** → Valuable, start in 3–6 months.
* **Low** → Nice-to-have, exploratory.

---

## 📂 3. Directory Structure

```bash
.
├── hooks
├── README.md
├── setup.sh
├── Skillfolio.sln
├── src
└── tests
    ├── IntegrationTests
    └── UnitTests
```

---

## ⚙️ 4. Project Setup

### 🛠️ Create Projects in `src`

```bash
cd src

dotnet new webapi -n Skillfolio.Api
dotnet new classlib -n Skillfolio.Application
dotnet new classlib -n Skillfolio.Infrastructure
dotnet new classlib -n Skillfolio.Domain

cd ..

dotnet sln Skillfolio.sln add src/Skillfolio.Api/Skillfolio.Api.csproj
dotnet sln Skillfolio.sln add src/Skillfolio.Application/Skillfolio.Application.csproj
dotnet sln Skillfolio.sln add src/Skillfolio.Infrastructure/Skillfolio.Infrastructure.csproj
dotnet sln Skillfolio.sln add src/Skillfolio.Domain/Skillfolio.Domain.csproj
```

### 🧪 Create Projects in `tests`

```bash
cd tests/IntegrationTests
dotnet new xunit -n Skillfolio.Api.Tests

cd ../UnitTests
dotnet new xunit -n Skillfolio.Application.Tests
dotnet new xunit -n Skillfolio.Domain.Tests
dotnet new xunit -n Skillfolio.Infrastructure.Tests

cd ../../

dotnet sln Skillfolio.sln add tests/IntegrationTests/Skillfolio.Api.Tests/Skillfolio.Api.Tests.csproj
dotnet sln Skillfolio.sln add tests/UnitTests/Skillfolio.Application.Tests/Skillfolio.Application.Tests.csproj
dotnet sln Skillfolio.sln add tests/UnitTests/Skillfolio.Domain.Tests/Skillfolio.Domain.Tests.csproj
dotnet sln Skillfolio.sln add tests/UnitTests/Skillfolio.Infrastructure.Tests/Skillfolio.Infrastructure.Tests.csproj
```

---

## 🔗 5. Project References

### Main Projects

```bash
dotnet add src/Skillfolio.Api/Skillfolio.Api.csproj reference src/Skillfolio.Application/Skillfolio.Application.csproj
dotnet add src/Skillfolio.Application/Skillfolio.Application.csproj reference src/Skillfolio.Domain/Skillfolio.Domain.csproj
dotnet add src/Skillfolio.Infrastructure/Skillfolio.Infrastructure.csproj reference src/Skillfolio.Application/Skillfolio.Application.csproj
dotnet add src/Skillfolio.Infrastructure/Skillfolio.Infrastructure.csproj reference src/Skillfolio.Domain/Skillfolio.Domain.csproj
```

### Test Projects

```bash
dotnet add tests/IntegrationTests/Skillfolio.Api.Tests/Skillfolio.Api.Tests.csproj reference src/Skillfolio.Api/Skillfolio.Api.csproj

dotnet add tests/UnitTests/Skillfolio.Application.Tests/Skillfolio.Application.Tests.csproj reference src/Skillfolio.Application/Skillfolio.Application.csproj
dotnet add tests/UnitTests/Skillfolio.Domain.Tests/Skillfolio.Domain.Tests.csproj reference src/Skillfolio.Domain/Skillfolio.Domain.csproj
dotnet add tests/UnitTests/Skillfolio.Infrastructure.Tests/Skillfolio.Infrastructure.Tests.csproj reference src/Skillfolio.Infrastructure/Skillfolio.Infrastructure.csproj
```

---

## 🧾 6. Running Tests

```bash
dotnet test
```
