namespace StoreApp.Models
{
    public class Pagination
    {
        public int Totalitems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrenPage { get; set; }


        public int TotlPage => (int)Math.Ceiling((decimal)Totalitems/ ItemsPerPage);

    }
}
