using System.ComponentModel.DataAnnotations;

namespace Challenge.Domain.Commands
{
    public class StatusCommand
    {
        [Required(ErrorMessage = "O campo status é obrigatório", AllowEmptyStrings = false)]
        public string status { get; set; }
        public int itensAprovados { get; set; }
        public decimal valorAprovado { get; set; }

        [Required(ErrorMessage = "O campo pedido é obrigatório", AllowEmptyStrings = false)]
        public string pedido { get; set; }
    }
}
