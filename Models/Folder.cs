namespace CCA_BE.Models
{
    public class Folder
    {
        public string Name { get; set; }
        public List<string> FileNames { get; set; } = new List<string>();
    }
}
