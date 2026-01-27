namespace WebApplication1.Models.Repository
{
    public static class ShirtsRepository
    {
        private static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt {ShirtId = 1, Brand = "My Band", Color = "Blue", Gender = "Male", Price = 30, Size = 10 },
            new Shirt {ShirtId = 2, Brand = "My Band", Color = "Black", Gender = "Male", Price = 35, Size = 12 },
            new Shirt {ShirtId = 3, Brand = "Your Band", Color = "Pink", Gender = "woMale", Price = 28, Size = 8 },
            new Shirt {ShirtId = 4, Brand = "Your Band", Color = "Yellow", Gender = "woMale", Price = 30, Size = 9 }
        };

        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }
    }
}
