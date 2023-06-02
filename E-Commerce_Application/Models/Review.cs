namespace E_Commerce_Application.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int ProductID { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CommentText { get; set; }
    }
}
