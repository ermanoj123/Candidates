using Candidate.Models;
using FluentResults;

namespace Candidate.Services
{
    
        public interface ICandidateService
        {
            Task<Result<CandidateResponse>> AddOrUpdateCandidateAsync(CandidatesRequest candidateDto);
        }
    
}
