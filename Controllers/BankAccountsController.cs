using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PortalApi.Data;
using PortalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public BankAccountsController(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _context = dbContext;
            _configuration = configuration;
        }
        [HttpGet("GetAllBankAccounts")]
        public IEnumerable<BankAccount> GetHouseholds()
        {
            return _context.GetAllBankAccounts(_configuration);
        }
        
    }
}
