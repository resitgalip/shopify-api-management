using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using shopify_api_management.Model;

namespace shopify_api_management.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private string _product_apiurl = "https://entegitest.myshopify.com/admin/api/2022-01/products.json?limit=50";
        public List<Product> _products;
         
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var _shopify_apikey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("shopify_api_key").Value;

            var client = new RestClient(_product_apiurl);
 
            var request = new RestRequest();
            request.AddHeader("X-Shopify-Access-Token", _shopify_apikey);
            request.AddHeader("Cookie", "_master_udr=eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaEpJaWsyT0RrMU9UUTBZeTB5WmpjNExUUTRORGd0WVRFMU15MWxaamhoWWpNNE1XVXpOR1lHT2daRlJnPT0iLCJleHAiOiIyMDI0LTEwLTAzVDAyOjI2OjI4LjE0N1oiLCJwdXIiOiJjb29raWUuX21hc3Rlcl91ZHIifX0%3D--4cfd98f08363525c3e6fa846c7556d6e00ffc83c; _secure_admin_session_id=84b42f5b2a2f8dd5cc5e4a13323d7fca; _secure_admin_session_id_csrf=84b42f5b2a2f8dd5cc5e4a13323d7fca; _shopify_y=9b8cdb13-e436-422b-a55b-36557b031d8c; _y=9b8cdb13-e436-422b-a55b-36557b031d8c; localization=TR; secure_customer_sig=");
            var response = client.Get(request);

            JObject product = JObject.Parse(response.Content);
            _products = JsonConvert.DeserializeObject<List<Product>>(product["products"].ToString());

        }
    }
}