namespace ProjectCompletionReport.Models
{
    /// <summary>
    /// Bảng hợp đồng (master) – FK → SAN_PHAM.
    /// </summary>
    public class HopDong
    {
        public string MA_HD { get; set; } = string.Empty;
        public string MA_SP { get; set; } = string.Empty;
        public string TEN_HD { get; set; } = string.Empty;
    }
}
