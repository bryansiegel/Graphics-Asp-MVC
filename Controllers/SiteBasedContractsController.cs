﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Graphics_Asp_MVC.Data;
using Graphics_Asp_MVC.Models;

namespace Graphics_Asp_MVC.Controllers
{
    public class SiteBasedContractsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiteBasedContractsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SiteBasedContracts
        public async Task<IActionResult> Index()
        {
            return View(await _context.SiteBasedContracts.ToListAsync());
        }

    }
}
