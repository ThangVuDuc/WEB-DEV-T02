using FresherTraining.Properties;
using MISA.BL;
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
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace FresherTraining.Controllers
{
    public class Refs1Controller : ApiController
    {
        private RefDL _refDL = new RefDL();
        private RefBL _refBL = new RefBL();
        /// <summary>
        /// Thực hiện lấy dữ liệu từ bảng dữ liệu REF
        /// Người tạo VDThang 24/07/2019
        /// </summary>
        /// <returns>Danh sách các phiếu thu</returns>
        [Route("refs/{pageIndex}/{pageSize}")]
        [HttpGet]
        public async Task<AjaxResult> GetRefs([FromUri]int pageIndex, int pageSize)
        {
            await Task.Delay(1000);
            var _ajaxResult = new AjaxResult();
            try
            {
                _ajaxResult.Data = _refBL.GetPagingData(pageIndex, pageSize); 
            }catch(Exception ex)
            {
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
                _ajaxResult.Data = ex;
            }
            return _ajaxResult;
        }

        [Route("refs/filtering/{searchType}/{searchValue}")]
        [HttpGet]
        public AjaxResult FilterRefs([FromUri] int searchType, string searchValue)
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _ajaxResult.Data = _refBL.FilterData(searchType, searchValue);
            }
            catch (Exception ex)
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