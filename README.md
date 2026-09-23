# AI Document Analyzer

A full-stack AI-powered document processing application for uploading PDF documents, extracting their content, and generating structured AI analysis results.

The project combines a **React/TypeScript frontend** with an **ASP.NET Core Web API** and supports both local and Microsoft Azure-based processing.

## Overview

The application provides an end-to-end document processing pipeline:

```text
PDF Upload
    │
    ▼
React Frontend
    │
    ▼
ASP.NET Core API
    │
    ├── Document Storage
    │
    ├── PDF Text Extraction
    │
    └── AI Document Analysis
             │
             ▼
       Structured JSON
             │
             ▼
       Frontend Display
```

The architecture separates application logic from infrastructure providers through interfaces and dependency injection. This allows storage, PDF extraction and AI providers to be exchanged without changing the main application workflow.

## Features

* PDF document upload
* Document validation and processing
* PDF text extraction
* AI-powered document analysis
* Structured JSON analysis results
* Local development mode
* Microsoft Azure integration
* Azure Blob Storage support
* Azure AI Document Intelligence support
* Azure OpenAI support
* Swagger / OpenAPI API documentation
* React and TypeScript frontend
* Provider abstraction through interfaces
* Dependency Injection

## Technology Stack

### Backend

* .NET 8
* ASP.NET Core Web API
* C#
* Dependency Injection
* Repository Pattern
* Swagger / OpenAPI

### Frontend

* React
* TypeScript
* Vite

### AI & Document Processing

* iText PDF
* Azure AI Document Intelligence
* Azure OpenAI
* Ollama / local language models

### Cloud

* Microsoft Azure
* Azure Blob Storage

These technologies and providers are documented by the current repository.

## Architecture

The application is divided into several replaceable components:

```text
                         User
                           │
                           ▼
                   React Frontend
                           │
                           ▼
                  ASP.NET Core API
                           │
            ┌──────────────┼──────────────┐
            │              │              │
            ▼              ▼              ▼
        Storage       PDF Extraction   AI Analysis
        Service          Service         Service
            │              │              │
       ┌────┴────┐    ┌────┴────┐    ┌────┴────┐
       │         │    │         │    │         │
       ▼         ▼    ▼         ▼    ▼         ▼
     Local     Azure  iText   Azure  Local    Azure
    Storage    Blob           Document  AI     OpenAI
                           Intelligence
```

Provider selection is performed during application startup based on the configured application mode.

## Application Modes

### Local Mode

Local mode is intended for development, testing and offline usage.

Possible components include:

* Local filesystem storage
* iText PDF extraction
* Ollama
* Local language models

Configuration:

```json
{
  "ApplicationMode": "Local"
}
```

### Azure Mode

Azure mode uses managed cloud services:

* Azure Blob Storage
* Azure AI Document Intelligence
* Azure OpenAI

Configuration:

```json
{
  "ApplicationMode": "Azure"
}
```

Both modes use the same application interfaces, allowing the infrastructure implementation to be changed without modifying the core processing workflow.

## Backend Structure

```text
backend/
└── AI.DocumentAnalyzer.Api/
    ├── Controllers/
    ├── Interfaces/
    ├── Models/
    ├── Middleware/
    ├── Repositories/
    ├── Services/
    ├── Storage/
    └── Program.cs
```

The backend implements the document processing API and coordinates storage, extraction and AI analysis.

## Frontend

The frontend is implemented with React, TypeScript and Vite.

```text
frontend/
└── ai-document-analyzer/
```

The frontend communicates with the ASP.NET Core API and displays document processing and AI analysis results.

## Getting Started

### Requirements

Install:

* .NET 8 SDK
* Node.js
* npm

Verify the installations:

```bash
dotnet --version
node --version
npm --version
```

### Start the Backend

```bash
cd backend/AI.DocumentAnalyzer.Api

dotnet restore
dotnet build
dotnet run
```

The API is configured to expose Swagger/OpenAPI documentation during development.

### Start the Frontend

From the frontend project:

```bash
cd frontend/ai-document-analyzer

npm install
npm run dev
```

The Vite development server then provides the frontend locally.

## Configuration

Application settings are stored in `appsettings.json`.

A typical Azure configuration contains:

```json
{
  "ApplicationMode": "Azure",

  "AzureBlobStorage": {
    "ConnectionString": "",
    "ContainerName": "documents"
  },

  "DocumentIntelligence": {
    "Endpoint": "",
    "ApiKey": ""
  },

  "AzureOpenAI": {
    "Endpoint": "",
    "ApiKey": "",
    "DeploymentName": ""
  }
}
```

**Never commit API keys, connection strings or other secrets to the repository.**

Environment variables can be used for sensitive configuration values.

## API

The backend exposes a REST API for document processing.

Swagger/OpenAPI can be used to inspect and test the available endpoints.

Example endpoint:

```text
POST /api/documents/upload
```

The upload workflow stores the document, extracts its text and makes the content available for further AI analysis.

## AI Analysis

After text extraction, the document content is passed to the configured AI analysis provider.

The result is returned as structured JSON, for example:

```json
{
  "documentType": "resume",
  "summary": "Senior Backend Engineer with experience in AI systems.",
  "skills": [
    "Python",
    "C++",
    "Azure"
  ],
  "experienceYears": 9.25
}
```

This structure can be used for use cases such as:

* CV analysis
* Cover-letter analysis
* Document classification
* Skill extraction
* Automated document processing

The repository currently documents both local AI processing and Azure OpenAI as supported analysis approaches.

## Security

Sensitive credentials should not be committed to Git.

Do not commit:

```text
API keys
Connection strings
Azure credentials
Secrets
```

Use development configuration files or environment variables instead.

## Project Structure

```text
AI-Document-Analyzer/
├── backend/
│   └── AI.DocumentAnalyzer.Api/
│
├── frontend/
│   └── ai-document-analyzer/
│
├── docs/
│   └── images/
│
├── .gitignore
├── LICENSE
└── README.md
```

The current repository contains the backend, frontend, documentation images, license and README at the project root.

## Screenshots

The repository contains documentation images under:

```text
docs/images/
```

These can be used here to showcase the application UI and AI analysis results.

## License

This project is licensed under the **MIT License**. A `LICENSE` file is present in the repository.

