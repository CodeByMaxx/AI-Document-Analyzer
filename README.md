# AI Document Analyzer

![Status](https://img.shields.io/badge/status-development-blue)
![Technology](https://img.shields.io/badge/.NET-9-purple)
![Frontend](https://img.shields.io/badge/Frontend-React%20%2B%20TypeScript-blue)
![Cloud](https://img.shields.io/badge/Cloud-Microsoft%20Azure-0078D4)

## Overview

**AI Document Analyzer** is a cloud-based application that allows users to upload PDF documents and automatically analyze their content using artificial intelligence.

The goal of this project is to demonstrate a modern cloud application architecture using Microsoft Azure services, AI integration, secure storage, and automated deployment practices.

The application extracts information from uploaded documents, generates summaries, and provides structured insights to help users understand large documents faster.

---

## Features

### Current Features

* Upload PDF documents
* Validate uploaded files
* Store documents
* REST API for document handling
* Swagger API documentation

### Planned Features

* AI-powered document text extraction
* Automatic document summarization
* Keyword and entity extraction
* Chat with documents (RAG)
* Document history
* User authentication
* Cloud deployment on Microsoft Azure
* CI/CD pipeline with GitHub Actions

---

## Architecture

The planned architecture:

```
                    User
                     |
                     v
              React Frontend
                     |
                     v
             ASP.NET Core API
                     |
        +------------+------------+
        |                         |
        v                         v
 Azure Blob Storage       Azure AI Services
        |
        v
 Azure SQL Database
```

---

## Technology Stack

### Frontend

* React
* TypeScript
* Vite
* Material UI
* Axios

### Backend

* ASP.NET Core 9 Web API
* C#
* Entity Framework Core
* Swagger / OpenAPI

### Microsoft Azure

Planned Azure services:

* Azure App Service
* Azure Blob Storage
* Azure SQL Database
* Azure AI Document Intelligence
* Azure OpenAI
* Application Insights
* Azure Key Vault

### DevOps

* GitHub
* GitHub Actions
* Infrastructure as Code (Bicep)

---

## Project Structure

```
AI-Document-Analyzer/

├── backend/
│   └── AI.DocumentAnalyzer.Api/
│       ├── Controllers/
│       ├── Models/
│       ├── Services/
│       ├── Storage/
│       └── Program.cs
│
├── frontend/
│   └── ai-document-analyzer/
│       ├── src/
│       │   ├── api/
│       │   ├── components/
│       │   ├── models/
│       │   └── pages/
│
├── infrastructure/
│   └── azure/
│
├── docs/
│
└── README.md
```

---

## Getting Started

## Requirements

Install the following tools:

* .NET 9 SDK
* Node.js LTS
* Git

---

## Backend Setup

Navigate to the backend folder:

```bash
cd backend/AI.DocumentAnalyzer.Api
```

Restore dependencies:

```bash
dotnet restore
```

Start the API:

```bash
dotnet run
```

The API will be available at:

```
http://localhost:5271
```

Swagger documentation:

```
http://localhost:5271/swagger
```

---

## Frontend Setup

Navigate to the frontend folder:

```bash
cd frontend/ai-document-analyzer
```

Install dependencies:

```bash
npm install
```

Start development server:

```bash
npm run dev
```

---

## API Endpoints

### Upload Document

```
POST /api/Documents/upload
```

Uploads a PDF document for processing.

Example response:

```json
{
  "fileName": "document.pdf",
  "fileSize": 123456,
  "message": "Upload successful"
}
```

---

## Development Roadmap

### Sprint 1 - Project Setup ✅

* Repository creation
* Backend setup
* Frontend setup
* Basic project structure

### Sprint 2 - Document Upload 🚧

* PDF upload API
* File validation
* Local storage

### Sprint 3 - Azure Storage

* Azure Blob Storage integration
* Secure document storage

### Sprint 4 - AI Integration

* Document Intelligence integration
* AI-generated summaries

### Sprint 5 - Cloud Deployment

* Azure App Service
* Database deployment
* Monitoring

### Sprint 6 - CI/CD

* GitHub Actions
* Automated deployment

---

## Security Considerations

The application will include:

* Secure file validation
* Restricted file types
* File size limits
* Secret management using Azure Key Vault
* Secure API communication

---

## Learning Goals

This project demonstrates knowledge of:

* Cloud application development
* Microsoft Azure services
* AI integration
* REST API design
* Frontend/backend communication
* DevOps practices
* Infrastructure as Code

---

## License

This project is licensed under the MIT License.

