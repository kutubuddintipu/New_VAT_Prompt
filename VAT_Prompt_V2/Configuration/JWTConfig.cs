namespace VAT_Prompt_V2.Configuration
{
    public static class JWTConfig
    {
        public static string SecretKey = "e%_?csH+&=?xHt4B3qC7P#9ppD$5jTs_L&V69CJ?G54@Z#LdWK%3z+y%wPPfgL-?";
        public static string Issuer = "https://localhost:7179/";
        public static string Audience = "https://localhost:7179/";
        public static int Timeout = 120;
    }
}