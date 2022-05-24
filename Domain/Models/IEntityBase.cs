using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public interface IEntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}