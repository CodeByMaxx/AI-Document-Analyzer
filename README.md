# AI Document Analyzer

An AI-powered document analysis application for extracting, processing, and understanding information from uploaded documents.

The project combines a modern web frontend with a .NET backend and AI-powered document processing services.

## Features

* Document upload and analysis
* AI-powered document understanding
* Azure Document Intelligence integration
* Azure OpenAI integration
* Optional local AI processing with Ollama
* Document text extraction
* Structured document analysis
* PDF processing
* Azure Blob Storage integration
* REST API
* Swagger API documentation
* Modern web interface

## Architecture

```text
Document
    │
    ▼
Web Frontend
    │
    ▼
.NET Backend
    │
    ├──► Azure Document Intelligence
    │
    ├──► Azure OpenAI
    │
    └──► Ollama
    │
    ▼
Document Analysis
    │
    ▼
Analysis Result
    │
    ▼
Web Interface
```

## Technology Stack

### Frontend

* React
* TypeScript
* Vite

### Backend

* ASP.NET Core
* .NET 8
* REST API
* Swagger

### AI & Document Processing

* Azure Document Intelligence
* Azure OpenAI
* Ollama
* iText

### Storage

* Azure Blob Storage

## Project Structure

```text
AI-Document-Analyzer/
├── docs/
│   └── images/
│       ├── ai-result.png
│       ├── without-ai-result.png
│       └── application-overview.png
├── frontend/
├── backend/
└── README.md
```

## Frontend

The frontend provides the user interface for uploading and analysing documents.

It is built with:

* React
* TypeScript
* Vite

The frontend communicates with the backend through the REST API.

## Backend

The backend is implemented using ASP.NET Core and .NET 8.

It provides the API layer connecting the frontend with the document-processing and AI services.

## Document Processing

The application can use Azure Document Intelligence to extract structured information from supported documents.

The extracted information can then be passed to an AI model for additional analysis and interpretation.

```text
Document
   │
   ▼
Document Intelligence
   │
   ▼
Extracted Content
   │
   ▼
AI Analysis
   │
   ▼
Structured Result
```

## Azure OpenAI

Azure OpenAI can be used to process extracted document content and generate AI-based analysis.

This allows the application to combine document extraction with natural-language processing.

## Ollama

Ollama provides an option for local AI model execution.

This can be useful during development when testing AI functionality without relying exclusively on a cloud-based model.

## PDF Processing

The backend uses iText for PDF-related processing.

This allows PDF documents to be handled as part of the document-analysis workflow.

## Azure Blob Storage

Azure Blob Storage can be used for storing uploaded documents and related files.

```text
Upload
  │
  ▼
Backend
  │
  ▼
Azure Blob Storage
  │
  ▼
Document Processing
```

## API

The backend exposes a REST API for communication with the frontend.

Swagger can be used during development to inspect and interact with the available API endpoints.

## Results & Screenshots

The screenshots below show the actual application and the difference between document processing with and without AI analysis.

### Application Overview

![Application Overview](docs/images/application-overview.png)

### AI Result

![AI Result](docs/images/ai-result.png)

### Without AI

![Result Without AI](docs/images/without-ai-result.png)

## Development

### Frontend

Install the frontend dependencies and start the Vite development server using the project's frontend configuration.

### Backend

Restore the .NET dependencies and start the ASP.NET Core application using the project's backend configuration.

Once the backend is running, Swagger can be used to inspect the available API endpoints.

## Configuration

Cloud services and AI mode

