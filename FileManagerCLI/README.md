# FileManagerCLI

A lightweight **console-based file manager** written in C#.  
This project is part of the learning roadmap, following *ConsoleDictionary*, and introduces real filesystem operations, SOLID principles, and clean architecture design.

---

## 🧭 Overview

**FileManagerCLI** is a simple yet structured CLI tool that allows you to:
- List directories and files  
- Create, delete, copy, and move files  
- Display file information  
- Extend functionality by adding new commands easily  

It demonstrates:
- **Command Pattern**  
- **SOLID principles (especially SRP, OCP, DIP)**
- **Layered architecture** with clear separation of concerns  

---

## 🏗️ Architecture
FileManagerCLI/
├── Core/ # Business logic: interfaces, services, commands
├── App/ # Console entry point and command executor
└── Tests/ # Unit and integration tests

### Core Layer
Contains interfaces and implementations:
- `ICommand` — represents a single command with `Execute()`  
- `IFileService` — abstracts file operations  
- `FileService` — implementation of file handling  
- Command classes (e.g., `ListCommand`, `CopyCommand`, `DeleteCommand`)  

### App Layer
Responsible for:
- Parsing user input  
- Executing the appropriate command  
- Displaying output to the console  

### Tests Layer
Covers:
- Unit tests for `FileService`  
- Integration tests for commands  

---

## ⚙️ Example Usage

list C:\Projects
create notes.txt
copy notes.txt D:\Backup
delete old.txt
info report.pdf
exit

## 🧩 Design Principles

- **SRP (Single Responsibility Principle):**  
  Each class has exactly one purpose.  
- **OCP (Open/Closed Principle):**  
  You can add new commands without modifying existing code.  
- **DIP (Dependency Inversion Principle):**  
  Commands depend on abstractions (`IFileService`), not implementations.  

---

## 🧠 Learning Goals

This project focuses on:
- Applying **Clean Architecture** concepts to a console app  
- Understanding and practicing **SOLID principles**  
- Building a structured and testable C# application  

---

## 🚀 Future Improvements

- Add directory management commands  
- Implement command history and shortcuts  
- Add logging and configuration support  
- Support async operations (in later learning stages)  

---

## 🧑‍💻 Author

Part of an educational series by **Eugeny**, guided by a structured roadmap to professional .NET development.  
Mentored practice focusing on clarity, architecture, and mastery of C#.
