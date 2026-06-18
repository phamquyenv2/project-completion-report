namespace ProjectCompletionReport.Models
{
    /// <summary>
    /// Bảng phân công task – FK → HOP_DONG, NHAN_VIEN.
    /// Chỉ lưu SL_TASK_HT và SL_TASK_CHT.
    /// SL_TASK, TY_LE_HT, TY_LE_CHT tính tự động trong VIEW.
    /// </summary>
    public class PhanCongTask
    {
        public int ID { get; set; }
        public string MA_HD { get; set; } = string.Empty;
        public string MA_NV { get; set; } = string.Empty;
        public int SL_TASK_HT { get; set; }
        public int SL_TASK_CHT { get; set; }
    }
}
