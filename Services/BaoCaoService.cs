using ProjectCompletionReport.Models;
using ProjectCompletionReport.Repositories;

namespace ProjectCompletionReport.Services
{
    public class BaoCaoService
    {
        private readonly BaoCaoDuAnRepository _duAnRepo = new();
        private readonly BaoCaoNhanVienRepository _nvRepo = new();

        public List<BaoCaoTyLeHoanThanhDuAn> LayTatCaDuAn()
            => _duAnRepo.GetBaoCaoDuAn();

        public BaoCaoTyLeHoanThanhDuAn? LayDuAnTheoMaHD(string maHD)
            => _duAnRepo.GetByMaHD(maHD);

        public List<BaoCaoTyLeHoanThanhNhanVien> LayTatCaNhanVien()
            => _nvRepo.GetAll();

        public List<BaoCaoTyLeHoanThanhNhanVien> LayNhanVienTheoMaHD(string maHD)
            => _nvRepo.GetByMaHD(maHD);

        public List<string> LayDanhSachMaHD()
            => LayTatCaDuAn().Select(x => x.MA_HD).ToList();
    }
}
