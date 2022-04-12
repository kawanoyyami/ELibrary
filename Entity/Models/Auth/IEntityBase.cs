using System.ComponentModel.DataAnnotations;

namespace Entity.Models.Auth
{
    public interface IEntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}