using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Helper
{
    public class PaginatedList<T> : List<T>
    {
            public int PageIndex { get; private set; }
            public int TotalPages { get; private set; }
            public int Start { get; set; }
            public int End { get; set; }
            public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
            {
                PageIndex = pageIndex;
                TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                
                this.AddRange(items);
            }
            public bool HasPreviousPage
            {
                get
                {
                    return (PageIndex > 1);
                }
            }
            public bool HasNextPage
            {
                get
                {
                    return (PageIndex < TotalPages);
                }
            }
            public static PaginatedList<T> Create(IList<T> source, int pageIndex, int pageSize)
            {
                var count = source.Count;
                var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                return new PaginatedList<T>(items, count, pageIndex, pageSize);
            }
            public static PaginatedList<T> CreateAsync(IList<T> source, int pageIndex, int pageSize)
            {
                var count = source.Count();
                var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                return new PaginatedList<T>(items, count, pageIndex, pageSize);
            }


    }
}
