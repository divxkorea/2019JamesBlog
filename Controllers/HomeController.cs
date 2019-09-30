using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using JamesBlog.Models;

namespace JamesBlog.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }
        public IActionResult Index()
        {
            List<Member> member = new List<Member>();
            GetMemberList(out member);
            return View(member);
        }

        private int GetMemberList(out List<Member> objMemberList)
        {
            int intRetVal = 0;
            string strErrMsg = string.Empty;

            try
            {
                using (IDbConnection  conn = Connection)
                {
                    string sQuery = "SELECT userno, userid FROM TMemberMst";
                    conn.Open();

                    var result = conn.Query<Member>(sQuery);
                    objMemberList = result.ToList();

                    //var result = await conn.QueryAsync<Employee>(sQuery, new { DateOfBirth = dateOfBirth });
                    //return result.ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

            return intRetVal;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
    }
}