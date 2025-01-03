﻿using Candidate.Models;
using Candidate.Services;
using Microsoft.AspNetCore.Mvc;

namespace Candidate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost("AddOrUpdateCandidate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddOrUpdateCandidate([FromBody] CandidatesRequest candidateDto)
        {
            var data = await _candidateService.AddOrUpdateCandidateAsync(candidateDto);
            return data.IsSuccess ? Ok("Candidate information saved successfully.") : Problem(data.Errors[0].Message, statusCode: StatusCodes.Status422UnprocessableEntity);
        }
    }
}

