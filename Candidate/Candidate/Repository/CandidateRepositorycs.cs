using Candidate.Context;
using Candidate.Entities;
using Candidate.Services;
using Microsoft.EntityFrameworkCore;

namespace Candidate.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly CandidateDbContext _dbContext;
        private readonly ILogger<CandidateService> _logger;
        public CandidateRepository(CandidateDbContext dbContext, ILogger<CandidateService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<CandidateDto> AddOrUpdateCandidateAsync(CandidateDto candidateDto)
        {
            // Retrieve the existing candidate by email
            var existingCandidate = await _dbContext.CandidateDtos
                .FirstOrDefaultAsync(c => c.Email == candidateDto.Email);

            if (existingCandidate != null)
            {
                existingCandidate.FirstName = candidateDto.FirstName;
                existingCandidate.LastName = candidateDto.LastName;
                existingCandidate.PhoneNumber = candidateDto.PhoneNumber;
                existingCandidate.PreferredCallTime = candidateDto.PreferredCallTime;
                existingCandidate.LinkedInProfileUrl = candidateDto.LinkedInProfileUrl;
                existingCandidate.GitHubProfileUrl = candidateDto.GitHubProfileUrl;
                existingCandidate.FreeTextComment = candidateDto.FreeTextComment;
                existingCandidate.UpdatedDate = candidateDto.CreatedDate;

                _dbContext.CandidateDtos.Update(existingCandidate);
                _logger.LogInformation("Candidate updated successfully: {@candidateDto}", candidateDto);
            }
            else
            {
                await _dbContext.CandidateDtos.AddAsync(candidateDto);
                _logger.LogInformation("Candidate created successfully: {@candidateDto}", candidateDto);
            }
            await _dbContext.SaveChangesAsync();
            return candidateDto;
        }
    }
}
