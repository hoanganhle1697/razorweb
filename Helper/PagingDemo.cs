namespace Entity_Razor.Helper{
    public class PagingDemo{
        public int currentPage{ get; set; }
        public int totalPage{ get; set; }
        public Func<int?,string>generateUrl{ get; set; }
    }
}