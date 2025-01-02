Architecture

Directory Structure

├── Controllers/
│   ├── CandidatesController.cs
├── Services/
│   ├── CandidateService.cs
│   ├── ICandidateService.cs
├── Repository/
│   ├── CandidateRepository.cs
│   ├── ICandidateRepository.cs
├── Models/
│   ├── CandidatesRequest.cs
│   ├── CandidateResponse.cs
│   ├── CandidateDto.cs
├── Entities/
│   ├── CandidateDto.cs
├── Context/
│   ├── CandidateDbContext.cs
├── AppSettings.json

Components

1. Controllers
CandidatesController.cs
Responsible for handling HTTP requests and exposing APIs to interact with the Candidate Management System.

API Endpoint: /api/candidates

Method:
POST AddOrUpdateCandidate
Route: api/candidates/AddOrUpdateCandidate
Request Body: CandidatesRequest

Response:
200 OK: Candidate information saved successfully.
400 Bad Request: Validation errors in the input model.
422 Unprocessable Entity: Errors while saving candidate information.

2. Services
CandidateService.cs
Contains the business logic for adding or updating candidate information.
Interface: ICandidateService

thods:
Task<Result<CandidateResponse>> AddOrUpdateCandidateAsync(CandidatesRequest candidateDto)
bool IsValidEmail(string email)

3. Repository
CandidateRepository.cs
Handles database interactions using Entity Framework Core. Implements the ICandidateRepository interface.
Interface: ICandidateRepository
Methods:
Task<CandidateDto> AddOrUpdateCandidateAsync(CandidateDto candidateDto)

4. Models
CandidatesRequest.cs
Defines the structure for candidate data received in the API request.
CandidateResponse.cs
Represents the response structure returned by the service layer.

CandidateDto.cs
Defines the structure for the candidate data persisted in the database.
Flow of Execution

1. API Request Handling
The CandidatesController receives an API request with candidate details. The request body is validated, and if valid, the controller calls the CandidateService.

2. Business Logic
The CandidateService processes the input data, validates the email format, and constructs a CandidateDto object. It then calls the CandidateRepository for database operations.

3. Database Operations
The CandidateRepository checks if a candidate with the provided email exists:
If Exists: Updates the existing record.
If Not: Adds a new candidate record.
The changes are saved to the database.

4. Logging
Serilog captures and logs important events, such as invalid email formats, successful updates, or errors during processing.

5. API Response
The service returns a result to the controller, which in turn sends the appropriate HTTP response back to the client.

Key Features
Validation:
Ensures valid email format using regular expressions.

Upsert Logic:
Handles both adding new candidates and updating existing ones.

Logging:
Tracks key events and errors using Serilog.

Logging and Monitoring
Serilog Configuration:
Logs are written to both the console and a file.
Monitors key application events and exceptions.

Future Enhancements
Pagination: Add support for paginated retrieval of candidate data.
Authentication: Secure APIs using JWT-based authentication.
Search Filters: Enable filtering candidates by name, email, or date range
