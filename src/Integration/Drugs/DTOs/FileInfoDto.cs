

namespace Integration.Drugs.DTOs
{
    public class FileInfoDto
    {
        public string Name { get; set; }
        public bool Downloaded { get; set; }

        public FileInfoDto() { }

        public FileInfoDto(string name, bool downloaded)
        { 
            this.Name = name;
            this.Downloaded = downloaded;
        }
    }
}
