namespace d04_ex02
{
    public class IdentityRole
    {
        public IdentityRole()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString() => $"{Name}, {Description}";
    }

}
