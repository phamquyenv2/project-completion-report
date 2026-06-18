using SkiaSharp;

namespace ProjectCompletionReport.Helpers
{
    /// <summary>
    /// Bảng màu dùng chung cho toàn bộ chart.
    /// </summary>
    public static class ColorPalette
    {
        // ── Màu chính ──
        public static readonly SKColor Green = new(76, 175, 80);       // Hoàn thành
        public static readonly SKColor Red = new(244, 67, 54);         // Chưa hoàn thành
        public static readonly SKColor Blue = new(33, 150, 243);       // SL Task HT
        public static readonly SKColor Orange = new(255, 152, 0);      // SL Task CHT

        // ── Màu nền ──
        public static readonly SKColor DarkBg = new(15, 20, 40);
        public static readonly SKColor CardBg = new(25, 30, 55);

        // ── Text ──
        public static readonly SKColor TextPrimary = SKColors.White;
        public static readonly SKColor TextSecondary = new(180, 220, 255);
    }
}
