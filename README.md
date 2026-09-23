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
             ┌─────────┼─────────┐
             ▼         ▼         ▼
       Azure Document Azure OpenAI Ollama
       Intelligence
             │         │         │
             └─────────┼─────────┘
                       ▼
                Document Analysis
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
├── frontend/
├── backend/
├── docs/
│   └── images/
└── README.md
```

The repository contains separate frontend and backend components together with documentation images used to demonstrate the application.

## Frontend

The frontend provides the user interface for uploading and analysing documents.

The application is built with:

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

A simplified storage workflow is:

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

Swagger can be used to inspect and interact with the available API endpoints during development.

## Results & Screenshots

The repository contains screenshots under:

```text
docs/images/
```

These images are part of the project documentation and demonstrate the application's user interface and workflow.

They should remain part of the README because they provide a visual representation of the finished application.

![AI Document Analyzer](docs/images/README.png)

## Development

### Frontend

Install the frontend dependencies and start the Vite development server using the project's frontend configuration.

### Backend

Restore the .NET dependencies and start the ASP.NET Core application using the project's backend configuration.

Once the backend is running, Swagger can be used to inspect the available API endpoints.

## Configuration

Cloud services and AI models require appropriate configuration values.

Credentials and API keys should not be committed to the repository.

Use environment variables or the configuration mechanisms provided by the development environment.

## AI Workflow

The complete document-analysis workflow can be summarized as:

```text
User Upload
    │
    ▼
Frontend
    │
    ▼
ASP.NET Core API
    │
    ▼
Document Extraction
    │
    ▼
AI Processing
    │
    ▼
Analysis Result
    │
    ▼
Frontend
```

## Possible Improvements

Possible future extensions include:

* Additional document formats
* More AI analysis workflows
* Improved document search
* Additional extraction models
* Authentication and user accounts
* More detailed result visualizations
* Automated integration tests
* Additional cloud deployment options

## Project Purpose

The project demonstrates how modern web technologies, document intelligence, and generative AI can be combined into a practical document-analysis application.

It connects a React frontend with an ASP.NET Core backend and external AI/document-processing services.

## Author

**Markus**

