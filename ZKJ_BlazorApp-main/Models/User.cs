namespace BlazorApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string AuthData { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public ShoppingCart shoppingCart { get; set; }
    }

    public enum Role
    {
        Manager,
        Developer,
        DelegeteEmployee,
        OfficeEmployee,
        CEO,
        Admin
    }
}