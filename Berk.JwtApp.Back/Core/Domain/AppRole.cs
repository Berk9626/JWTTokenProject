namespace Berk.JwtApp.Back.Core.Domain
{
    public class AppRole
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public AppRole() //eğer bir rol geldiyse ctora bunu en kötü ihtimalle boş olarak örnekle null bırakma.
        {
            AppUsers = new List<AppUser>();
        }
    }
}
