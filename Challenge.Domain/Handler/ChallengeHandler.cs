using Challenge.Domain.Commands;
using Challenge.Domain.Entities;
using Challenge.Domain.Enums;
using Challenge.Domain.Helpers;
using Challenge.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.Domain.Handler
{
    public class ChallengeHandler
    {
        private readonly IPedidoRepository _pedidoRepository;

        public ChallengeHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public StatusResult GravarPedido(PedidoCommand command)
        {
            var result = new StatusResult
            {
                pedido = command.pedido
            };

            var pedido = _pedidoRepository.Buscar(command.pedido);

            if (pedido is not null)
                result.status = new string[] { StatusPedidoEnum.PedidoJaExiste.LerDescricacaoEnum() };
            else
            {
                var objPedido = new PedidoEntity(command.pedido)
                {
                    Itens = new List<ItemPedidoEntity>()
                };

                command.itens.ForEach(item => objPedido.Itens.Add(new ItemPedidoEntity(objPedido.Pedido, item.descricao, item.precoUnitario, item.qtd)));

                _pedidoRepository.Salvar(objPedido);

                result.status = new string[] { StatusPedidoEnum.PedidoCadastradoComSucesso.LerDescricacaoEnum() };
            }
            return result;
        }

        public StatusResult MudarStatus(StatusCommand command)
        {
            var listaStatus = new List<string>();

            var result = new StatusResult
            {
                pedido = command.pedido
            };

            var pedido = _pedidoRepository.Buscar(command.pedido);

            if (pedido is null)
                listaStatus.Add(StatusPedidoEnum.PedidoInvalido.LerDescricacaoEnum());
            else
                RealizarValidacoesStatusPedido(ref listaStatus, command, pedido);

            result.status = listaStatus.ToArray();

            return result;
        }

        private void RealizarValidacoesStatusPedido(ref List<string> listaStatus, StatusCommand command, PedidoEntity pedido)
        {
            if (command.status == "REPROVADO")
                listaStatus.Add(StatusPedidoEnum.Reprovado.LerDescricacaoEnum());

            var qtdItemPedido = pedido.Itens.Sum(x => x.Qtd);
            decimal valorTotalPedido = 0;

            pedido.Itens.ToList().ForEach(item => valorTotalPedido += (item.Qtd * item.PrecoUnitario));

            if (command.status == "APROVADO" &&
                command.itensAprovados == qtdItemPedido &&
                command.valorAprovado == valorTotalPedido)
                listaStatus.Add(StatusPedidoEnum.Aprovado.LerDescricacaoEnum());

            if (command.status == "APROVADO" &&
                command.valorAprovado < valorTotalPedido)
                listaStatus.Add(StatusPedidoEnum.AprovadoValorMenor.LerDescricacaoEnum());

            if (command.status == "APROVADO" &&
                command.itensAprovados < qtdItemPedido)
                listaStatus.Add(StatusPedidoEnum.AprovadoQuantidadeMenor.LerDescricacaoEnum());

            if (command.status == "APROVADO" &&
                command.valorAprovado > valorTotalPedido)
                listaStatus.Add(StatusPedidoEnum.AprovadoValorMaior.LerDescricacaoEnum());

            if (command.status == "APROVADO" &&
                command.itensAprovados > qtdItemPedido)
                listaStatus.Add(StatusPedidoEnum.AprovadoQuantidadeMaior.LerDescricacaoEnum());
        }
    }
}
