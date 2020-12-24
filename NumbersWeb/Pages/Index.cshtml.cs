using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NumbersWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
        }

        public async Task OnGet()
        {
            try
            {
                var httpClient = this.httpClientFactory.CreateClient();
                var response = await httpClient.GetAsync(this.configuration.GetValue<string>("NumbersAPI"));
                if (response.IsSuccessStatusCode)
                {
                    var number = await response.Content.ReadAsStringAsync();
                    ViewData["Number"] = number;

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Happend when accessing the Get method");
                ViewData["Number"] = "There is a error !!";
            }
            
        }
    }
}
