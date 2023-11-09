using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage
{
    public class Pages
    {
        public int TotalItems { get;private set; }
        public int CurrentPage { get;private set; }
        public int PageSize { get; private set;}
        public int TotalPages { get; private set;}

        public int StartPage { get; private set;}
        public int EndPage { get; private set;}


        public Pages()
        {

        }

        public Pages(int totalItems, int page, int pageSize = 10)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page;
            int startPage = currentPage - 2;
            int endPage = currentPage + 2;

            if(startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if(endPage > totalPages)
            {
                endPage = totalPages;
                if(endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }
            TotalItems = totalItems;
            CurrentPage = currentPage;
            StartPage = startPage;
            EndPage = endPage;
            TotalPages = totalPages;
            PageSize = pageSize;
        }
    }
}
