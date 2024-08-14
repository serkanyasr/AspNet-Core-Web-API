using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeature
{
    public abstract class RequestParameters
    {
		const int MaxPageSize = 50;
		// Auto-implemtetd proporty
        public int PageNumber { get; set; }

		// full proporty
		private int _pageSize;

		public int PageSize
		{
			get { return _pageSize; }
			set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
		}



	}
}
