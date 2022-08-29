using Models.Interfaces;


namespace Models
{
    public class Department: IModel 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string NameAbbreviation { get; set; }
        public override string ToString() => $"Id ={Id}, NameAbbr = {NameAbbreviation}";
    }
}
