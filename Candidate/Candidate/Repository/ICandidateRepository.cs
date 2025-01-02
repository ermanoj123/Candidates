using Candidate.Entities;

namespace Candidate.Repository
{
    public interface ICandidateRepository
    {
        Task<CandidateDto> AddOrUpdateCandidateAsync(CandidateDto candidateDto);
    }
}
