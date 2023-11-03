using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using web.app.models;
using web.app.utilities.interfaces;

namespace web.app.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly IQuery query;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IQuery query)
        {
            this.logger = logger;
            this.query = query;
            GoogleMapsApiKey = configuration["GoogleMaps:ApiKey"];

        }

        [Required(ErrorMessage = "Search Address is required.")]
        [MaxLength(70, ErrorMessage = "Search Address must not exceed 70 characters.")]
        [BindProperty]
        public string SearchAddress { get; set; }
        public string GoogleMapsApiKey { get; set; }

        public List<LocationData> SearchResults { get; set; }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                    SearchResults = query.SearchByAddress(SearchAddress);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred in IndexModel: {ErrorMessage}", ex.Message);
                return RedirectToPage("Error");
            }
            return Page();
        }

        public IActionResult OnGetGetClosestLocations(double lat, double lon)
        {
            return new JsonResult(query.GetNearestLocations(lat, lon));
        }

    }
}