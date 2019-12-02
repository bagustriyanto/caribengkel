namespace CariBengkel.Website.Models {
    public class CredentialViewModel {
        public long Id { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string VerificationCode { get; set; }
        public bool PublicUser { get; set; }
    }
}