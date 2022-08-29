using Models.Interfaces;


namespace Models
{
    public class Rank: IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() => $"Id = {Id}, {Name}";
    }
}
