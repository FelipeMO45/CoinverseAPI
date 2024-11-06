namespace CoinverseSocialAPI.DTO
{
    public class PostDTO
    {
        public int PkPost { get; set; }
        public int? FkUser { get; set; }
        public int? FkTypePost { get; set; }
        public string? Text { get; set; }
        public int? IdPostShared { get; set; }
        public DateTime? Date { get; set; }
    }
}
