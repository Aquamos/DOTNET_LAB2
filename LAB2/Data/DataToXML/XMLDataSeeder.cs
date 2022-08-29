using Data.InitialData;
using Data;

namespace LAB2
{
    public class XMLDataSeeder
    {
        public Context _context { get; }
        public XMLDataSeeder(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Context cannot be null");
            XMLDataCreatorMethods dataCreator = new XMLDataCreatorMethods();

            dataCreator.SeedDepartments(_context.Departments, Paths.Departments);
            dataCreator.SeedRanks(_context.Ranks, Paths.Ranks);
            dataCreator.SeedGroups(_context.Groups, Paths.Groups);
            dataCreator.SeedResources(_context.Resources, Paths.Resources);
            dataCreator.SeedResourceTypes(_context.ResourceTypes, Paths.ResourceTypes);
            dataCreator.SeedPeople(_context.People, Paths.People);
            dataCreator.SeedStudentsAndResources(_context.StudentsAndResources, Paths.StudentsAndResources);
            dataCreator.SeedStudentsAndTeachers(_context.StudentsAndTeachers, Paths.StudentAndTeachers);
        }
    }
}
