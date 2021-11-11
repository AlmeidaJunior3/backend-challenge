using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Domain.Commands
{
    public class PedidoCommand
    {
        [Required(ErrorMessage = "O campo pedido é obrigatório")]
        public string pedido { get; set; }
        public List<Itens> itens { get; set; }
        public class Itens
        {
            [Required(ErrorMessage = "O campo descrição é obrigatório")]
            public string descricao { get; set; }

            [Range(1, double.MaxValue, ErrorMessage = "Campo precoUnitario é obrigatório e tem que ser maior que 0")]
            public decimal precoUnitario { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "Campo qtd é obrigatório e tem que ser maior que 0")]
            public int qtd { get; set; }
        }
    }
}
