﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDeviceRepository _repository;

        public IndexModel(ILogger<IndexModel> logger, IDeviceRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        
        [BindProperty] public IReadOnlyList<Device> ConnectedDevices { get; set; }

        public IActionResult OnGet()
        {
            return Redirect("Dashboard/Devices");
//            ConnectedDevices = await _repository.GetListAsync();
//            return Page();
        }
    }
}