using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using web.app.models;
using web.app.utilities.interfaces;

namespace web.app.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly IQuery query;

        public IndexModel(ILogger<IndexModel> logger, IQuery query)
        {
            this.logger = logger;
            this.query = query;
        }

        [BindProperty]
        public string SearchAddress { get; set; }

        public List<LocationData> SearchResults { get; set; }


        public void OnGet()
        {

        }

        public void OnPost()
        {
            // This is called when the form is submitted (POST request).
            // Implementing the address-based search here.
            if (!string.IsNullOrEmpty(SearchAddress))
            {
                SearchResults = query.SearchByAddress(SearchAddress);
            }
        }

        public IActionResult OnGetGetClosestLocations(double lat, double lon)
        {
            return new JsonResult(query.GetNearestLocations(lat,lon));
        }

    }
}