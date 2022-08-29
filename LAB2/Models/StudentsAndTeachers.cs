using Models.Interfaces;


namespace Models
{
    public class StudentsAndTeachers : IModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public override string ToString() =>
            $"Id = {Id}, StudentId: {StudentId}, TeacherId: {TeacherId}";
    }
}
