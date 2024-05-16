namespace Applications.Commons
{
    public class ConnectionStrings
    {
        public string SQLServerDB { get; set; }
        public string DeployServerDB { get; set; }
    }
    public class JWTSection
    {
        public string SecretKey { get; set; }
        public int ExpiresInDays { get; set; }
    }
    public class VNPaySection
    {
        public string vnp_Version { get; set; }
        public string vnp_Command { get; set; }
        public string vnp_TmnCode { get; set; } // Replace with your actual merchant code
        public string vnp_CurrCode { get; set; }
        public string vnp_ReturnUrl { get; set; }
        public string vnp_ExpireDate { get; set; }
        public string vnp_Locale { get; set; }
        public string vnp_Url { get; set; }
        public string vnp_Api { get; set; }
        public string vnp_HashSecret { get; set; }
        public string vnp_SecureHash { get; set; } = "SHA256";
    }
    public class FirebaseConfig
    {
        public string ApiKey { get; set; } = default!;
        public string AuthDomain { get; set; } = default!;
        public string ProjectId { get; set; } = default!;
        public string StorageBucket { get; set; } = default!;
        public string MessagingSenderId { get; set; } = default!;
        public string AppId { get; set; } = default!;
        public string MeasurementId { get; set; } = default!;
    }
}
