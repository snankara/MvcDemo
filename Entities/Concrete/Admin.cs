using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Admin : IEntity
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminRole { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
