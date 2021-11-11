using System.ComponentModel;

namespace Challenge.Domain.Enums
{
    public enum StatusPedidoEnum
    {        
        [Description("CODIGO_PEDIDO_INVALIDO")]
        PedidoInvalido = 0,
      
        [Description("REPROVADO")]
        Reprovado = 1,
      
        [Description("APROVADO")]
        Aprovado = 2,
       
        [Description("APROVADO_VALOR_A_MENOR")]
        AprovadoValorMenor = 3,
        
        [Description("APROVADO_QTD_A_MENOR")]
        AprovadoQuantidadeMenor = 4,
       
        [Description("APROVADO_VALOR_A_MAIOR")]
        AprovadoValorMaior = 5,
       
        [Description("APROVADO_QTD_A_MAIOR")]
        AprovadoQuantidadeMaior = 6,

        [Description("PEDIDO_CADASTRADO_SUCESSO")]
        PedidoCadastradoComSucesso = 7,

        [Description("PEDIDO_JA_EXISTE")]
        PedidoJaExiste = 8,
    }
}
