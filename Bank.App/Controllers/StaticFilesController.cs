using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.App.Controllers
{
    public class StaticFilesController : Controller
    {
        //[Authorize]
        public IActionResult JsTransactionsHandlers()
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(),
                "Scripts", "js", "AccountTransactionViewModelUIManagementAndValidation.js");

            return PhysicalFile(file, "transaction");
        }
    }
}