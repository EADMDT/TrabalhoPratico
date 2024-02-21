using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNet8VStudio.Model
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("first_name")]
        public string? FirstName { get; set; }
        [Column("last_name")]
        public string? LastName { get; set; }
        [Column("adress")]
        public string? Adress { get; set; }
        [Column("gender")]
        public string? Gender { get; set; }

    }
}
