using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShkollaA1.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Season { get; set; }
        public int Hours { get; set; }


        [ForeignKey("CurriculumId")]
        public int CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }
    }
}
