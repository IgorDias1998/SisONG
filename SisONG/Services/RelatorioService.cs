using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;

namespace SisONG.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly SisONGContext _context;
        private readonly IMapper _mapper;

        public RelatorioService(SisONGContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Método para gerar relatório dinâmico
        public async Task<RelatorioReadDto> AddAsync(RelatorioRequestDto requestDto)
        {
            string conteudoGerado = await GerarConteudoRelatorioAsync(requestDto.Tipo, requestDto.DataInicio, requestDto.DataFim);

            var relatorio = new Relatorio
            {
                Tipo = requestDto.Tipo,
                DataGeracao = DateTime.Now,
                Conteudo = conteudoGerado
            };

            _context.Relatorios.Add(relatorio);
            await _context.SaveChangesAsync();

            return _mapper.Map<RelatorioReadDto>(relatorio);
        }

        // GET all
        public async Task<IEnumerable<RelatorioReadDto>> GetAllAsync()
        {
            var relatorios = await _context.Relatorios.ToListAsync();
            return _mapper.Map<IEnumerable<RelatorioReadDto>>(relatorios);
        }

        // GET by Id
        public async Task<RelatorioReadDto> GetByIdAsync(int id)
        {
            var relatorio = await _context.Relatorios.FindAsync(id);
            if (relatorio == null) return null;

            return _mapper.Map<RelatorioReadDto>(relatorio);
        }

        // UPDATE
        public async Task<RelatorioReadDto> UpdateAsync(int id, RelatorioUpdateDto updateDto)
        {
            var relatorio = await _context.Relatorios.FindAsync(id);
            if (relatorio == null) return null;

            _mapper.Map(updateDto, relatorio);

            await _context.SaveChangesAsync();

            return _mapper.Map<RelatorioReadDto>(relatorio);
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var relatorio = await _context.Relatorios.FindAsync(id);
            if (relatorio == null) return false;

            _context.Relatorios.Remove(relatorio);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<string> GerarConteudoRelatorioAsync(string tipo, DateTime? dataInicio, DateTime? dataFim)
        {
            var inicio = dataInicio ?? DateTime.MinValue;
            var fim = dataFim ?? DateTime.MaxValue;

            switch (tipo.ToLower())
            {
                case "financeiro":
                    var transacoes = await _context.TransacoesFinanceiras
                        .Where(t => t.Data >= inicio && t.Data <= fim)
                        .ToListAsync();

                    if (!transacoes.Any())
                        return "Nenhuma transação financeira encontrada nesse período.";

                    var totalFinanceiro = transacoes.Sum(t => t.Valor);
                    var relFinanceiro = "Relatório Financeiro\n";
                    relFinanceiro += $"Período: {inicio:dd/MM/yyyy} a {fim:dd/MM/yyyy}\n";
                    relFinanceiro += $"Total de transações: {transacoes.Count}\n";
                    relFinanceiro += $"Valor total: {totalFinanceiro:C}\n\n";
                    relFinanceiro += "Detalhes:\n";

                    foreach (var t in transacoes)
                    {
                        relFinanceiro += $"- {t.Data:dd/MM/yyyy} | {t.Origem} → {t.Destino} | {t.Valor:C} via {t.MetodoPagamento}\n";
                    }

                    return relFinanceiro;

                case "voluntariado":
                    var voluntarios = await _context.Voluntarios
                        .Where(v => v.DataCadastro >= inicio && v.DataCadastro <= fim)
                        .ToListAsync();

                    if (!voluntarios.Any())
                        return "Nenhum voluntário cadastrado nesse período.";

                    var relVoluntarios = "Relatório de Voluntariado\n";
                    relVoluntarios += $"Período: {inicio:dd/MM/yyyy} a {fim:dd/MM/yyyy}\n";
                    relVoluntarios += $"Total de voluntários cadastrados: {voluntarios.Count}\n\n";
                    relVoluntarios += "Nomes dos voluntários:\n";

                    foreach (var v in voluntarios)
                    {
                        relVoluntarios += $"- {v.Nome} (Cadastro: {v.DataCadastro:dd/MM/yyyy})\n";
                    }

                    return relVoluntarios;

                case "eventos":
                    var eventos = await _context.Eventos
                        .Where(e => e.DataHora >= inicio && e.DataHora <= fim)
                        .ToListAsync();

                    if (!eventos.Any())
                        return "Nenhum evento realizado nesse período.";

                    var relEventos = "Relatório de Eventos\n";
                    relEventos += $"Período: {inicio:dd/MM/yyyy} a {fim:dd/MM/yyyy}\n";
                    relEventos += $"Total de eventos realizados: {eventos.Count}\n\n";
                    relEventos += "Detalhes dos eventos:\n";

                    foreach (var e in eventos)
                    {
                        relEventos += $"- {e.Titulo} | {e.DataHora:dd/MM/yyyy HH:mm} | Local: {e.Local} | Status: {e.Status}\n";
                    }

                    return relEventos;

                default:
                    return "Tipo de relatório não suportado.";
            }
        }
    }
}
