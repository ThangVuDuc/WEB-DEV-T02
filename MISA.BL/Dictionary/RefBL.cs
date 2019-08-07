using MISA.DL;
using MISA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL
{
    public class RefBL
    {
        private RefDL _refDL = new RefDL();

        public IEnumerable<Ref> GetPagingData(int _pageIndex, int _pageSize)
        {
            var _employees = _refDL.GetRefData().OrderBy(p => p.RefNo)
                .Skip((_pageIndex - 1) * _pageSize)
                .Take(_pageSize);
            return _employees;
        }

        public IEnumerable<Ref> FilterData(int _searchType, string _searchValue)
        {
            var _refs = _refDL.GetRefData();
            switch (_searchType)
            {
                case 1:
                    break;
                case 2:
                    _refs = _refs.Where(p => p.RefNo.Contains(_searchValue));
                    break;
                case 3:
                    _refs = _refs.Where(p => p.RefType == _searchValue);
                    break;
                case 4:
                    _refs = _refs.Where(p => p.Reason == _searchValue);
                    break;
                case 5:
                    _refs = _refs.Where(p => p.Total == decimal.Parse(_searchValue));
                    break;
                case 6:
                    _refs = _refs.Where(p => p.ContactName == _searchValue);
                    break;

            }
            return _refs;
        }
    }
}
