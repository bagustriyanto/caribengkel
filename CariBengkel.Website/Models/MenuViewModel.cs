namespace CariBengkel.Website.Models {
    public class MenuViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Parent { get; set; }
        public bool Status { get; set; }
    }
}