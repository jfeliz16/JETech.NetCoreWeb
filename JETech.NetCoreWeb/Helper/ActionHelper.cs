using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JETech.NetCoreWeb.Helper
{
    public class ActionHelper
    {
        public ActionPaginationResult<IQueryable<t>> GetPaginationResult<t>(ActionQueryArgs<t> queryArgs,IQueryable<t> data)
        {
            IQueryable<t> newData;
            if (queryArgs.PageArgs != null)
            {
                int skip = 0;
                int take = 0;

                if (queryArgs.PageArgs.Skip.HasValue)
                {
                    skip = (int)queryArgs.PageArgs.Skip;
                }
                if (queryArgs.PageArgs.Size.HasValue && queryArgs.PageArgs.Num.HasValue)
                {
                    take = (int)(queryArgs.PageArgs.Size * queryArgs.PageArgs.Num);
                }
                newData = data.Skip(skip).Take(take);
            }else
            {
                newData = data;
            }
            return new ActionPaginationResult<IQueryable<t>> { Data = newData };
        } 
    }
}
