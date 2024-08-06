using bookApp.Models;

namespace bookApp.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books { get; set; }
        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book() {ID=1 ,Title = "olasılıksız" , Price = 324},
                new Book() {ID=2 ,Title ="1984" , Price = 312},
                new Book() {ID=3 ,Title = "Budala",Price = 122}
            };
            
        }
    }
}
