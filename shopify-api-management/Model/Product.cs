namespace shopify_api_management.Model
{
    public class Product
    {
        public Int64 id { get; set; } 
        public string title { get; set; }
        public string vendor { get; set; }
        public string product_type { get; set; }
        public string status { get; set; }
        public Image image { get; set; }
        public DateTime Created { get; set; }

    }

    public class Image
    {

        public long id { get; set; }
        public long product_id { get; set; }
        public int position { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object alt { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string src { get; set; }
        public List<object> variant_ids { get; set; }
        public string admin_graphql_api_id { get; set; }

    }
}
