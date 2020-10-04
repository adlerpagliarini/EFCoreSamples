using EFCoreSamples.Domain.Entity;
using System;
using System.Collections.Generic;

namespace EFCoreSamples.Domain.Paging
{
    public class PageList<TEntity, TId> : List<TEntity> where TEntity : Identity<TEntity, TId>
    {
        public PageList(IReadOnlyList<TEntity> items, int totalCount, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(totalCount/(double)pageSize);
            TotalCount = totalCount;
            AddRange(items);
        }

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPreviousPage => (PageIndex > 1);
        public bool HasNextPage => (PageIndex < TotalPages);
    }
}
