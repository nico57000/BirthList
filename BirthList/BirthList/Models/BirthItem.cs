using System.ComponentModel.DataAnnotations;

namespace BirthList.Models
{
    public class BirthItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LinkTo{ get; set; }
        public string FilePath { get; set; }
        public bool isAvaillable { get; set; }
    }
}
