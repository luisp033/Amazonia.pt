using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazonia.DAL.Modelo
{
    public abstract class Entidade
    {

        //[Key] // desnecessario já que vamos optar pelo mecanismo de convenção
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }
    }
}
