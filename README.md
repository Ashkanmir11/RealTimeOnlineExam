# Online Exam System

## Introduction

An online system for **classroom management, exam creation and administration, student management, answer submission, and result evaluation**.

The project focuses on **Real-Time Exams, exam time management, answer persistence, automatic exam completion, and automatic and AI-assisted grading**.

The project is built using **Clean Architecture and CQRS** to provide a maintainable, scalable, and testable system.

## Technologies

* C#
* .NET / ASP.NET Core Web API
* Blazor WebAssembly
* Entity Framework Core
* SQL Server
* Clean Architecture
* CQRS
* MediatR
* Repository Pattern
* AutoMapper
* FluentValidation
* SignalR
* BackgroundService
* JWT & Refresh Token
* Cookies
* xUnit
* Moq
* Shouldly

## Features

* 👤 **User Management**

  * User and role management
  * Authentication and Authorization

* 🏫 **Classroom Management**

  * Create and manage classrooms
  * Manage teachers and students
  * View classrooms associated with each user

* 📝 **Exam Management**

  * Create and manage exams
  * Manage exam questions
  * Configure exam start time and duration
  * Configure allowed delay time
  * Manage individual student Attempts

* 🎯 **Online Exam**

  * Take exams online
  * Paginated question display
  * Real-time answer persistence
  * Randomized question order for each student

* ⏱️ **Real-Time Exam**

  * Real-time remaining exam time
  * Connection status management using SignalR
  * Reconnection support after connection loss

* 🛡️ **Exam Monitoring**

  * Log when a student leaves the exam page
  * Prevent Copy & Paste during the exam

* ⚡ **Automatic Exam Handling**

  * Automatically end timed-out exams
  * Process unfinished exams using Background Service

* ✅ **Automatic Grading**

  * Automatic grading for Multiple Choice questions
  * Automatic grading for True/False questions

* 🤖 **AI-Assisted Grading**

  * AI-assisted evaluation of descriptive questions
  * Teacher review and final approval of grades

* 🔐 **Security**

  * JWT Authentication
  * Refresh Token
  * Role-based and resource-based access control

* 🧪 **Testing**

  * Business Logic and Handler testing
  * Dependency mocking using Moq
  * Success and failure scenario testing

## Project Structure

```text
OnlineExam
├── OnlineExam.Api
├── OnlineExam.Application
├── OnlineExam.Domain
├── OnlineExam.Infrastructure
├── OnlineExam.Identity
├── OnlineExam.Ui

### Layers

* **OnlineExam.Api** — Web API entry point and HTTP request handling.
* **OnlineExam.Application** — Application logic, CQRS, Requests/Handlers, DTOs, and Validation.
* **OnlineExam.Domain** — Core domain entities and business rules.
* **OnlineExam.Infrastructure** — Repository implementations, database access, and infrastructure services.
* **OnlineExam.Identity** — Authentication, Authorization, and identity-related functionality.
* **OnlineExam.Ui** — Frontend application built with Blazor WebAssembly.
* **OnlineExam.Tests** — Project tests, including Unit Tests for Business Logic and Handlers.
# Online Exam System

## معرفی

یک سیستم آنلاین برای **مدیریت کلاس‌ها، ایجاد و برگزاری آزمون، مدیریت دانشجویان، ثبت پاسخ‌ها و ارزیابی نتایج**.

این پروژه با تمرکز بر **آزمون Real-Time، مدیریت زمان آزمون، ذخیره پاسخ‌ها، پایان خودکار آزمون و تصحیح خودکار و AI-Assisted** طراحی شده است.

ساختار پروژه نیز بر پایه **Clean Architecture و CQRS** پیاده‌سازی شده تا سیستم قابل توسعه و تست‌پذیر باشد.

## تکنولوژی‌ها

* C#
* .NET / ASP.NET Core Web API
* Blazor WebAssembly
* Entity Framework Core
* SQL Server
* Clean Architecture
* CQRS
* MediatR
* Repository Pattern
* AutoMapper
* FluentValidation
* SignalR
* BackgroundService
* JWT & Refresh Token
* Cookies
* xUnit
* Moq
* Shouldly

## قابلیت‌ها

* 👤 **مدیریت کاربران**

  * مدیریت کاربران و نقش‌های مختلف
  * Authentication و Authorization

* 🏫 **مدیریت کلاس‌ها**

  * ایجاد و مدیریت کلاس‌ها
  * مدیریت استاد و دانشجویان کلاس
  * مشاهده کلاس‌های مربوط به هر کاربر

* 📝 **مدیریت آزمون**

  * ایجاد و مدیریت آزمون‌ها
  * مدیریت سؤالات آزمون
  * تعیین زمان و مدت مجاز آزمون
  * تعیین میزان تأخیر مجاز
  * مدیریت Attempt هر دانشجو

* 🎯 **برگزاری آزمون آنلاین**

  * شرکت دانشجو در آزمون
  * نمایش سؤالات به صورت صفحه‌بندی‌شده
  * ذخیره پاسخ‌ها در لحظه
  * تصادفی‌سازی ترتیب سؤالات برای هر دانشجو

* ⏱️ **آزمون Real-Time**

  * نمایش زمان باقی‌مانده آزمون به صورت Real-Time
  * مدیریت وضعیت اتصال کاربر با SignalR
  * پشتیبانی از Reconnection در صورت قطع ارتباط

* 🛡️ **نظارت بر آزمون**

  * ثبت Log خروج دانشجو از صفحه آزمون
  * جلوگیری از Copy و Paste در محیط آزمون

* ⚡ **مدیریت خودکار آزمون**

  * پایان خودکار آزمون‌های Timeout شده
  * اجرای فرآیندهای مربوط به آزمون‌های بدون پایان دستی با Background Service

* ✅ **تصحیح خودکار**

  * تصحیح خودکار سؤالات تستی
  * تصحیح خودکار سؤالات صحیح/غلط

* 🤖 **تصحیح با کمک AI**

  * استفاده از AI برای ارزیابی سؤالات تشریحی
  * امکان بررسی و تأیید نهایی نمرات توسط استاد

* 🔐 **امنیت**

  * JWT Authentication
  * Refresh Token
  * کنترل دسترسی بر اساس نقش و مالکیت منابع

* 🧪 **تست**

  * تست Business Logic و Handlerها
  * Mock کردن Dependencyها با Moq
  * تست سناریوهای موفق و خطا

## ساختار پروژه

```text
OnlineExam
├── OnlineExam.Api
├── OnlineExam.Application
├── OnlineExam.Domain
├── OnlineExam.Infrastructure
├── OnlineExam.Identity
├── OnlineExam.Ui
└── OnlineExam.Tests
```

### لایه‌ها

* **OnlineExam.Api** — نقطه ورود Web API و مدیریت درخواست‌های HTTP.
* **OnlineExam.Application** — منطق برنامه، CQRS، Request/Handlerها، DTOها و Validation.
* **OnlineExam.Domain** — موجودیت‌ها و قوانین اصلی دامنه.
* **OnlineExam.Infrastructure** — پیاده‌سازی Repositoryها، دسترسی به Database و سرویس‌های زیرساختی.
* **OnlineExam.Identity** — مدیریت Authentication، Authorization و قابلیت‌های مرتبط با هویت کاربران.
* **OnlineExam.Ui** — رابط کاربری پروژه با استفاده از Blazor WebAssembly.
* **OnlineExam.Tests** — تست‌های پروژه، شامل Unit Testهای Business Logic و Handlerها.

## تصاویر محیط پروژه


## Screenshots

<img width="1920" height="959" alt="Capture_2026_09_01_13_14_22_683" src="https://github.com/user-attachments/assets/1ad0cf18-b40c-4d01-875e-1bcec969f214" />```
<img width="1920" height="959" alt="Capture_2026_09_01_13_16_31_973" src="https://github.com/user-attachments/assets/c77f54c4-0873-42dd-bf18-00db05c93565" />
<img width="1920" height="959" alt="Capture_2026_09_01_13_15_41_128" src="https://github.com/user-attachments/assets/024ad07e-b646-4690-9b18-c1908297013c" />
<img width="1920" height="959" alt="Capture_2026_09_01_13_37_10_596" src="https://github.com/user-attachments/assets/f3932f99-b259-4713-b80c-287a806d962d" />
<img width="1920" height="959" alt="Capture_2026_09_01_13_37_36_328" src="https://github.com/user-attachments/assets/f90c6415-488e-4068-b3c8-415eada1d9c6" />
<img width="1920" height="959" alt="Capture_2026_09_01_14_21_13_947" src="https://github.com/user-attachments/assets/83839ce8-5905-4103-8a99-5305b0ffe680" />
<img width="1920" height="959" alt="Capture_2026_09_01_14_21_19_224" src="https://github.com/user-attachments/assets/a4e988c2-10c3-49e4-8366-43f030be11db" />


