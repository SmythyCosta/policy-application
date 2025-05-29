using Microsoft.AspNetCore.Mvc;
using PolicyApplication.Models;

namespace PolicyApplication.Controllers
{
    [ApiController]
    [Route("policy")]
    public class PolicyController : ControllerBase
    {
        [HttpGet("{policyNumber}")]
        public ActionResult<Policy> GetPolicy(string policyNumber)
        {
            // Dados mockados
            if (policyNumber == "000222333")
            {
                var policy = new Policy
                {
                    PolicyNumber = "000222333",
                    Value = 15000.50m,
                    Insured = "João da Silva"
                };
                return Ok(policy);
            }

            return NotFound();
        }
    }
}
