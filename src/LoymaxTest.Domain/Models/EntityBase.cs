using System.ComponentModel.DataAnnotations.Schema;

namespace LoymaxTest.Domain.Models
{
    /// <summary>
    /// Базовые атрибуты сущности
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
    }
}
