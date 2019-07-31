using FresherTraining.Properties;
using MISA.DL;
using MISA.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FresherTraining.Controllers
{
    public class Refs1Controller : ApiController
    {
        private RefDL _refDL = new RefDL();
        /// <summary>
        /// Thực hiện lấy dữ liệu từ bảng dữ liệu REF
        /// Người tạo VDThang 24/07/2019
        /// </summary>
        /// <returns>Danh sách các phiếu thu</returns>
        [Route("refs")]
        [HttpGet]
        public AjaxResult GetRefs()
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _ajaxResult.Data = _refDL.GetData(); 
            }catch(Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
                _ajaxResult.Data = ex;
            }
            return _ajaxResult;
        }

        /// <summary>
        /// Thực hiện thêm mới 1 phiếu thu
        /// Người tạo VDThang 24/07/2019
        /// </summary>
        /// <returns></returns>
        [Route("refs")]
        [HttpPost]
        public AjaxResult Post([FromBody] Ref _ref)
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _refDL.AddRef(_ref);
            }
            catch (Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
                _ajaxResult.Data = ex;
            }
            return _ajaxResult;
        }

        ///// <summary>
        ///// Thực hiện sửa 1 phiếu thu
        ///// Người tạo VDThang 24/07/2019
        ///// </summary>
        ///// <returns></returns>
        //[Route("refs")]
        //[HttpPut]
        //public void Put([FromBody]Ref refitem)
        //{
        //    var item = db.Refs.Where(p => p.refNo == refitem.refNo).FirstOrDefault();
        //    item.refDate = refitem.refDate;
        //    item.refNo = refitem.refNo;
        //    item.refType = refitem.refType;
        //    item.contactName = refitem.contactName;
        //    item.reason = refitem.reason;
        //    item.total = refitem.total;
        //    db.SaveChanges();
        //}

        ///// <summary>
        ///// Thực hiện xóa các phiếu thu lựa chọn
        ///// Người tạo VDThang 24/07/2019
        ///// </summary>
        ///// <returns></returns>
        //[Route("refs")]
        //[HttpDelete]
        //public void DeleteMultiple([FromBody]List<Guid> refids)
        //{
        //    foreach (var refid in refids)
        //    {
        //        var refitem = db.Refs.Where(p => p.refID == refid).FirstOrDefault();
        //        db.Refs.Remove(refitem);
        //    }
        //    db.SaveChanges();
        //}
    }
}