using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Abstraction.Collections
{
    public class PagedList<T> : IPagedList<T>
    {
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int indexFrom, int? totalCount = null)
        {
            if (indexFrom > pageIndex)
            {
                throw new Exception(
                    $"IndexFrom: {indexFrom} > PageIndex: {pageIndex}, must indexFrom <= pageIndex");
            }

            if (source is IQueryable<T> querable)
            {
                PageIndex = pageIndex;
                PageSize = pageSize;
                IndexFrom = indexFrom;
                TotalCount = totalCount ?? querable.Count();
                TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

                Items = querable.Skip((PageIndex - IndexFrom) * PageSize).Take(PageSize)
                    .ToList();
            }
            else
            {
                PageIndex = pageIndex;
                PageSize = pageSize;
                IndexFrom = indexFrom;
                TotalCount = totalCount ?? source.Count();
                TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

                Items = source.Skip((PageIndex - IndexFrom) * PageSize).Take(PageSize)
                    .ToList();
            }
        }
        public PagedList()
        {
            this.Items = Array.Empty<T>();
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int IndexFrom { get; set; }
        public IList<T> Items { get; set; }
        public bool HasPreviousPage => PageIndex - IndexFrom > 0;
        public bool HasNextPage => PageIndex - IndexFrom + 1 < TotalPages;

    }
}
