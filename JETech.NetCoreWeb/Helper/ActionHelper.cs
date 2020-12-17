using JETech.NetCoreWeb.Types;
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
            IQueryable<t> newData = null;
            int totalCount = 0;

            try
            {
                if (queryArgs.PageArgs != null)
                {
                    int skip = 0;
                    int take = 0;

                    if (data != null)
                    {
                        totalCount = data.Count();

                        if (queryArgs.PageArgs.Size.HasValue)
                        {
                            take = (int)queryArgs.PageArgs.Size;
                        }

                        if (queryArgs.PageArgs.Skip.HasValue)
                        {
                            skip = (int)queryArgs.PageArgs.Skip;
                        }
                        else if (queryArgs.PageArgs.Num.HasValue)
                        {
                            skip = (int)(take * queryArgs.PageArgs.Num);
                        }
                        newData = data.Skip(skip).Take(take);
                    }
                }
                else
                {
                    newData = data;
                }
                return new ActionPaginationResult<IQueryable<t>> { Data = newData, TotalCount = totalCount };
            }
            catch (Exception ex)
            {
                throw;
            }
        } 
    }
}
