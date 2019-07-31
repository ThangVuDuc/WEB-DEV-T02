using MISA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL
{
    public class RefDL
    {
        private FresherTrainingContext db = new FresherTrainingContext();

        //Hàm thực hiện lấy danh sách phiếu thu
        //Người tạo VDThang 30/07/2019
        public IEnumerable<Ref> GetData()
        {
            return db.Refs;
        }

        //Hàm thực hiện thêm mới phiếu thu
        //Người tạo VDThang 30/07/2019
        public void AddRef(Ref _ref)
        {
            _ref.RefID = Guid.NewGuid();
            db.Refs.Add(_ref);
            db.SaveChanges();
        }

        //Hàm thực hiện lấy phiếu chi tiết tương ứng phiếu thu
        //Người tạo VDThang 31/07/2019
        public IEnumerable<RefDetail> GetRefDetailByRefID(Guid _refID)
        {
            var _refResult = db.RefDetails.Where(p => p.RefID == _refID).ToList();
            return _refResult;
        }
    }
}
