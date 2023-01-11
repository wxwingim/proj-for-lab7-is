using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseEntities
{
    public abstract class BaseModel
    {
        [Column("id")]
        public int Id { get; set; }
    }
}