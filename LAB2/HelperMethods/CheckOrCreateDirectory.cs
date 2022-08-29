

namespace HelperMethods
{
    public class CheckOrCreateDirectory
    {
        static public void CheckOrCreate(string Directory)
        {
            int index = Directory.LastIndexOf('/');
            DirectoryInfo dir = new DirectoryInfo(Directory.Remove(index));
            if (!dir.Exists)
                dir.Create();
        }
    }
}
