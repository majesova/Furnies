using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Furnies.WebUI.Models.Pagination
{
    public abstract class PagedList<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalRows { get; set; }
        public int TotalPages { get; set; }

        protected PagedList()
        {
            Items = Enumerable.Empty<T>();
        }

        protected PagedList(IEnumerable<T> items, int totalRows = 0, int page = 1, int pageSize = 20)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalRows = totalRows;
        }

        public int FirstRow { get { return Math.Min(Math.Max(1, ((Page - 1) * PageSize) + 1), TotalRows); } }

        public int LastRow { get { return Math.Min(FirstRow + PageSize - 1, TotalRows); } }

        public string Range { get { return FirstRow.ToString(CultureInfo.InvariantCulture) + " - " + LastRow.ToString(CultureInfo.InvariantCulture); } }

        public bool HasPreviousPage { get { return Page > 1; } }
        }
        
    }