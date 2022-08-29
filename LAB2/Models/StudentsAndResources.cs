using Models.Interfaces;


namespace Models
{
    public class StudentsAndResources: IModel
    {
        public int Id { get; set; }
        public int StudentId  { get; set; }
        public int? ResourceId { get; set; }
        public override string ToString() => 
            $"Id = {Id}, StudentId: {StudentId}, ResourceId: {ResourceId}";
    }
}
