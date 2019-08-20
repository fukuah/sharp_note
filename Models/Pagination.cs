using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Models
{
    public class Pagination<T> where T : class
    {
        // How many objects are to view on a single page (Default value)
        private static int _defaultSize = 10;

        // Page number
        public int Number;
        // Count of objects
        public int Count;
        // How many objects are to view on a single page
        public int Size;
        // Objects to view
        public List<T> Content;

        public Pagination(int pageNumber, int count)
        {
            Content = new List<T>();
            Number = pageNumber;
            Count = count;
            Size = _defaultSize;
        }

        public Pagination(IEnumerable<T> content, int pageNumber, int count)
        {
            Content = new List<T>();
            Count = count;
            Content.AddRange(content);
            Number = pageNumber;
            Size = _defaultSize;
        }
    }
}
