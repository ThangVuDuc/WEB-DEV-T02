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
using FresherTraining.Properties;
using MISA.DL;
using MISA.Entities;

namespace FresherTraining.Controllers
{
    public class RefDetailsController : ApiController
    {
        private RefDL _refDL = new RefDL();
        /// <summary>
        /// Service thực hiện lấy phiếu chi tiết tương ứng phiếu thu
        /// Người tạo VDThang
        /// Ngày tạo 31/07/2019
        /// </summary>
        /// <param name="refid"></param>
        /// <returns>Danh sách phiếu chi tiết tương ứng</returns>
        [Route("refdetails/{refid}")]
        [HttpGet]
        public AjaxResult GetRefDetailByRefID(Guid refid)
        {
            var _ajaxResult = new AjaxResult();
            try
            {
                _ajaxResult.Data = _refDL.GetRefDetailByRefID(refid);
            }catch(Exception ex)
            {
                _ajaxResult.Data = ex;
                _ajaxResult.Success = false;
                _ajaxResult.Message = Resources.errorVN;
            }
            return _ajaxResult;
        }
    }
}