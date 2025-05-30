using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SisONG.DTOs;
using SisONG.Models;

public class RelatorioPdfService
{
    public byte[] GerarPdf(RelatorioReadDto relatorio)
    {
        using var ms = new MemoryStream();
        var document = new Document(PageSize.A4);
        PdfWriter.GetInstance(document, ms);
        document.Open();

        // Título
        var nomeONG = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
        var nomeONGparagrafo = new Paragraph("SisONG")
        {
            Alignment = Element.ALIGN_CENTER,
            SpacingAfter = 20f
        };
        document.Add(nomeONGparagrafo);

        var tituloFonte = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
        var paragrafoTitulo = new Paragraph("Relatório - " + relatorio.Tipo, tituloFonte)
        {
            Alignment = Element.ALIGN_CENTER,
            SpacingAfter = 20f
        };
        document.Add(paragrafoTitulo);

        // Data
        var dataFonte = FontFactory.GetFont(FontFactory.HELVETICA, 12);
        document.Add(new Paragraph("Data de Geração: " + relatorio.DataGeracao.ToString("dd/MM/yyyy"), dataFonte));
        document.Add(new Paragraph(" ")); // espaço

        // Conteúdo
        var conteudoFonte = FontFactory.GetFont(FontFactory.HELVETICA, 12);
        var conteudo = new Paragraph(relatorio.Conteudo, conteudoFonte)
        {
            SpacingBefore = 10f
        };
        document.Add(conteudo);

        document.Close();
        return ms.ToArray();
    }
}
