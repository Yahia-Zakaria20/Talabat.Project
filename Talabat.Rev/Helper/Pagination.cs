namespace Talabat.Rev.Helper
{
    public class Pagination<T>
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int Count { get; set; }

      public  IReadOnlyList<T> Data { get; set; }  

        public Pagination(int _pageSize , int _pageindex , int _count, IReadOnlyList<T> _items)
        {
            
            PageIndex = _pageindex;
            PageSize = _pageSize;
            Count = _count;
            Data= _items;
        }
    }
}
