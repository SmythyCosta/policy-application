using Microsoft.AspNetCore.Mvc;
using PolicyApplication.Models;

namespace PolicyApplication.Controllers
{
    [ApiController]
    [Route("policy")]
    public class PolicyController : ControllerBase
    {
        // Armazenamento em memória para a policy
        private static Policy _policyInMemory = new Policy
        {
            PolicyNumber = "000222333",
            Value = 15000.50m,
            Insured = "João da Silva"
        };

        [HttpGet("{policyNumber}")]
        public ActionResult<Policy> GetPolicy(string policyNumber)
        {
            if (_policyInMemory != null && _policyInMemory.PolicyNumber == policyNumber)
            {
                return Ok(_policyInMemory);
            }
            return NotFound();
        }

        [HttpPost("change")]
        public ActionResult<Policy> ChangePolicy([FromBody] Policy updatedPolicy)
        {
            if (updatedPolicy == null || string.IsNullOrEmpty(updatedPolicy.PolicyNumber))
            {
                return BadRequest("Dados inválidos.");
            }
            _policyInMemory = updatedPolicy;
            return Ok(_policyInMemory);
        }
    }
}
