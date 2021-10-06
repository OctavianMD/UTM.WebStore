namespace DataLayer.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BaseCategory BaseCategory { get; set; }
    }
}
