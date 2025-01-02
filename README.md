Candidate Management API
The Candidate Management API is an ASP.NET Core 8 application for managing candidate information. It supports adding and updating candidate details with built-in validation, logging, and efficient database operations using Entity Framework Core.

Directory Structure

Controllers

File: CandidatesController.cs

Handles HTTP requests and exposes APIs for interacting with the Candidate Management System.

Endpoint: /api/candidates

Route: api/candidates/AddOrUpdateCandidate

Method: POST

Request Body: CandidatesRequest

Responses:

200 OK: Candidate information saved successfully.

400 Bad Request: Validation errors in the input model.

422 Unprocessable Entity: Errors while saving candidate information.

Services

File: CandidateService.cs

Contains business logic for managing candidate information.

Interface: ICandidateService

Methods:

Task<Result> AddOrUpdateCandidateAsync(CandidatesRequest candidateDto)

Adds or updates candidate details.

bool IsValidEmail(string email)

Validates email format using regular expressions.

Repository

File: CandidateRepository.cs

Handles database interactions using Entity Framework Core.

Interface: ICandidateRepository

Methods:

Task AddOrUpdateCandidateAsync(CandidateDto candidateDto)

Adds or updates a candidate in the database.

Models

CandidatesRequest.cs: Structure for candidate data in API requests.

CandidateResponse.cs: Structure for service-layer responses.

CandidateDto.cs: Represents database-stored candidate data.

Flow of Execution

API Request Handling

CandidatesController receives and validates an API request.

Calls CandidateService for business logic processing.

Business Logic

CandidateService validates email format and constructs a CandidateDto object.

Calls CandidateRepository for database operations.

Database Operations

CandidateRepository checks for existing candidates by email:

If exists: Updates the record.

If not: Adds a new record.

Saves changes to the database.

Logging

Serilog captures key events such as:

Invalid email formats.

Successful updates or additions.

Errors during processing.

API Response
The service returns a result to the controller.

Controller sends the appropriate HTTP response.

Key Features
Validation: Validates email format using regular expressions.

Upsert Logic: Efficiently adds or updates candidate data.

Logging: Tracks events and errors using Serilog.

Logging and Monitoring

Serilog Configuration:

Logs are written to both the console and a file.

Monitors application events and exceptions.

Future Enhancements

Pagination: Support paginated retrieval of candidate data.

Authentication: Secure APIs using JWT-based authentication.

Search Filters: Enable filtering candidates by name, email, or date range.

Getting Started

Prerequisites

ASP.NET Core 8

Entity Framework Core 8

SQL Server
Setup Instructions

Clone the repository:

git clone https://github.com/ermanoj123/Candidates/tree/main/Candidate

Navigate to the project directory:

cd candidate-management-api

Configure the appsettings.json file with your database and logging settings.

Apply migrations to set up the database:

dotnet ef database update

Run the project:
dotnet run
