namespace WebApiCoreTest.Models
{
    public class ModelApi
    {

        public class Rootobject
        {
            public bool success { get; set; }
            public string src_url { get; set; }
            public string title { get; set; }
            public string picture { get; set; }
            public List<Link> links { get; set; }
        }

        public class Link
        {
            public string quality { get; set; }
            public string link { get; set; }
        }

    }
}
