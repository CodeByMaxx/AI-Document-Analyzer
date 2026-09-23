# AI Document Analyzer

A full-stack document processing application for uploading, extracting, and analyzing PDF documents with configurable local and Azure-based AI services.

## Overview

**AI Document Analyzer** combines a React frontend with an ASP.NET Core backend to provide an end-to-end document processing pipeline.

The application supports:

* PDF document upload
* Document validation and storage
* PDF text extraction
* AI-powered document analysis
* Structured JSON analysis results
* Local development without cloud services
* Azure-based document processing
* Replaceable storage, extraction, and AI providers

The architecture is designed around interfaces and dependency injection so that infrastructure implementations can be exchanged without changing the core application logic.

## Application Preview

### Application Overview

![Application Overview](docs/images/application-overview.png)

### AI Analysis Result

![AI Analysis Result](docs/images/ai-result.png)

### Without AI Analysis

![Without AI Analysis Result](docs/images/without-ai-result.png)

---

## Features

### Document Upload

PDF documents can be uploaded through the frontend and processed by the backend.

The processing flow is:

```text
Upload
  |
  v
Processing
  |
  v
Analyzed
```

The document workflow includes:

* PDF upload
* Validation
* Storage
* Processing status tracking
* Text extraction
* Optional AI analysis

### PDF Text Extraction

PDF extraction is abstracted behind the `IPdfTextExtractor` interface.

This makes it possible to use different extraction implementations depending on the selected application mode.

#### Local extraction

The local implementation uses **iText PDF**.

Advantages:

* No external service required
* Suitable for local development
* Works without an Azure subscription

#### Azure extraction

The Azure implementation uses **Azure AI Document Intelligence**.

This provides cloud-based document processing and OCR capabilities.

---

## AI Document Analysis

After text extraction, the document content can be analyzed by an AI provider.

The result is returned as structured JSON.

Example:

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

Because the analysis result is stored as JSON, the application can support different document types and analysis structures without requiring a fixed database schema for every possible result.

Possible use cases include:

* CV analysis
* Cover-letter analysis
* Document classification
* Skill extraction
* Automated document processing

---

## Architecture

The application is divided into several layers:

* React frontend
* ASP.NET Core API
* Application services
* Storage services
* PDF extraction services
* AI analysis services
* External cloud providers

High-level architecture:

```text
                         User
                           |
                           v
                    React Frontend
                           |
                           v
                  ASP.NET Core API
                           |
         +-----------------+------------------+
         |                 |                  |
         v                 v                  v
  Storage Service    PDF Extraction    AI Analysis Service
         |                 |                  |
         v                 v                  v
  Local Storage      iText Extractor    Local AI Provider
         |
         | OR
         v
  Azure Blob Storage
                           |
                           v
                 Azure Document Intelligence
                           |
                           v
                      Azure OpenAI
```

---

## Application Flow

The complete document processing pipeline is:

```text
User uploads PDF
        |
        v
React Frontend
        |
        v
ASP.NET Core API
        |
        v
DocumentService
        |
        +-------------------+
        |                   |
        v                   v
Storage Service      PDF Extractor
                            |
                            v
                     Extracted Text
                            |
                            v
                 AI Analysis Service
                            |
                            v
                     JSON Result
                            |
                            v
                   Frontend Display
```

---

## Provider Architecture

The application uses interfaces to separate business logic from infrastructure.

### Storage

```text
IStorageService
        |
        +-----------------------------+
        |                             |
        v                             v
LocalStorageService        AzureBlobStorageService
```

### PDF Extraction

```text
IPdfTextExtractor
        |
        +-----------------------------+
        |                             |
        v                             v
PdfTextExtractorService    AzureDocumentIntelligenceService
```

### AI Analysis

```text
IDocumentAnalysisService
        |
        +-----------------------------+
        |                             |
        v                             v
LocalAiDocumentAnalysisService
AzureOpenAiDocumentAnalysisService
```

The concrete implementation is selected during application startup through dependency injection.

---

## Application Modes

The application supports two runtime modes:

* **Local**
* **Azure**

The selected mode is controlled through configuration.

### Local Mode

Local mode is intended for:

* Development
* Testing
* Offline usage
* Development without Azure resources

Typical components:

```text
React Frontend
       |
       v
ASP.NET Core API
       |
       +-------------------+
       |                   |
       v                   v
Local Storage       Local PDF Extraction
                           |
                           v
                    Local AI Provider
```

Example configuration:

```json
{
  "ApplicationMode": "Local"
}
```

Possible local components include:

* Local filesystem storage
* iText PDF extraction
* Ollama
* Local language models

### Azure Mode

Azure mode uses managed cloud services:

```text
React Frontend
       |
       v
ASP.NET Core API
       |
       +---------------------------+
       |                           |
       v                           v
Azure Blob Storage       Azure Document Intelligence
                                   |
                                   v
                              Azure OpenAI
                                   |
                                   v
                          AI Analysis Result
```

Example configuration:

```json
{
  "ApplicationMode": "Azure"
}
```

Azure services used by the application include:

* Azure Blob Storage
* Azure AI Document Intelligence
* Azure OpenAI

---

## Technology Stack

### Backend

* .NET 8
* ASP.NET Core Web API
* Dependency Injection
* Repository Pattern
* Swagger / OpenAPI

### Frontend

* React
* TypeScript
* Vite

### Document Processing

* iText PDF
* Azure AI Document Intelligence

### AI

* Local AI providers
* Ollama
* Azure OpenAI

### Cloud

* Microsoft Azure
* Azure Blob Storage

---

## Project Structure

```text
AI-Document-Analyzer
├── backend
│   └── AI.DocumentAnalyzer.Api
│       ├── Controllers
│       ├── Interfaces
│       ├── Models
│       ├── Middleware
│       ├── Repositories
│       ├── Services
│       ├── Storage
│       └── Program.cs
│
├── docs
│   └── images
│
├── frontend
│   └── ai-document-analyzer
│
├── LICENSE
└── README.md
```

---

## Configuration

The application uses `appsettings.json` for configuration.

Example:

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

For local development:

```json
{
  "ApplicationMode": "Local"
}
```

---

## Azure Setup

Azure mode requires the following services:

1. Azure Blob Storage
2. Azure AI Document Intelligence
3. Azure OpenAI

### Azure Blob Storage

Create a storage account and a container for uploaded documents.

Example:

```json
{
  "AzureBlobStorage": {
    "ConnectionString": "YOUR_CONNECTION_STRING",
    "ContainerName": "documents"
  }
}
```

### Azure AI Document Intelligence

Create an Azure AI Document Intelligence resource and configure its endpoint and API key.

```json
{
  "DocumentIntelligence": {
    "Endpoint": "YOUR_ENDPOINT",
    "ApiKey": "YOUR_KEY"
  }
}
```

### Azure OpenAI

Create an Azure OpenAI resource and deploy the model used for document analysis.

The application uses the **deployment name**, not the model name, in its configuration.

```json
{
  "AzureOpenAI": {
    "Endpoint": "YOUR_ENDPOINT",
    "ApiKey": "YOUR_KEY",
    "DeploymentName": "document-analyzer"
  }
}
```

---

## Security

Do **not** commit credentials or secrets to the repository.

Never commit:

* API keys
* Connection strings
* Azure credentials
* Access tokens
* Other secrets

For local development, use configuration files that are excluded from version control or environment variables.

Example environment variables:

```text
AzureOpenAI__ApiKey
AzureBlobStorage__ConnectionString
DocumentIntelligence__ApiKey
```

---

## Running the Backend

Requirements:

* .NET 8 SDK
* Node.js
* npm

Check the installed versions:

```bash
dotnet --version
node --version
npm --version
```

Navigate to the backend:

```bash
cd backend/AI.DocumentAnalyzer.Api
```

Restore dependencies:

```bash
dotnet restore
```

Build:

```bash
dotnet build
```

Run:

```bash
dotnet run
```

The API is available locally at:

```text
https://localhost:7001
```

---

## Swagger API

The backend provides Swagger / OpenAPI documentation.

When the backend is running, open:

```text
https://localhost:7001/swagger
```

Swagger can be used to inspect and test the available API endpoints.

Example endpoint:

```text
POST /api/documents/upload
```

---

## Running the Frontend

Navigate to the frontend directory:

```bash
cd frontend
```

Install dependencies:

```bash
npm install
```

Start the development server:

```bash
npm run dev
```

The frontend is then available locally through the Vite development server.

---

## Development Workflow

Run the backend in one terminal:

```bash
cd backend/AI.DocumentAnalyzer.Api
dotnet run
```

Run the frontend in another terminal:

```bash
cd frontend
npm install
npm run dev
```

The resulting application consists of:

```text
React Frontend
      |
      v
ASP.NET Core API
      |
      v
Document Processing
      |
      +-------------------+
      |                   |
      v                   v
Storage             Text Extraction
                          |
                          v
                    AI Analysis
                          |
                          v
                    JSON Result
```

---

## Error Handling

The API contains centralized exception handling through middleware.

The general flow is:

```text
Controller
    |
    v
Service Layer
    |
    v
ExceptionMiddleware
    |
    v
HTTP Response
```

Unhandled exceptions are converted into consistent API responses without exposing internal implementation details.

Example:

```json
{
  "message": "Interner Serverfehler"
}
```

---

## Repository Pattern

Persistence logic is separated from the application services through repositories.

```text
DocumentService
       |
       v
DocumentRepository
       |
       v
Database
```

This keeps the service layer focused on application logic and makes the persistence implementation replaceable.

---

## Service Responsibilities

### DocumentService

Responsible for:

* Receiving uploaded documents
* Starting document processing
* Triggering text extraction
* Triggering AI analysis
* Updating document state

### StorageService

Responsible for:

* Saving documents
* Retrieving documents
* Managing the storage location

### PdfTextExtractor

Responsible for:

* Reading PDF files
* Extracting text
* Returning document content

### DocumentAnalysisService

Responsible for:

* Sending extracted text to an AI provider
* Processing AI responses
* Returning structured analysis results

---

## Project Goals

The main goals of the project are:

* Demonstrate a complete document-processing pipeline
* Separate business logic from infrastructure
* Support both local and cloud-based execution
* Make external providers replaceable
* Combine modern web development with AI services
* Provide a practical foundation for automated document analysis

---

## License

This project is licensed under the MIT License.

