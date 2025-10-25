using Microsoft.AspNetCore.Razor.TagHelpers;
using OrdemServicoApp.Models;

namespace OrdemServicoApp.TagHelpers
{
    [HtmlTargetElement("status-badge")]
    public class StatusBadgeTagHelper : TagHelper
    {
        public StatusOrdem Status { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            var (text, css) = Status switch
            {
                StatusOrdem.Aberta => ("Aberta", "badge bg-secondary"),
                StatusOrdem.EmAndamento => ("Em andamento", "badge bg-warning text-dark"),
                StatusOrdem.Concluida => ("Concluída", "badge bg-success"),
                StatusOrdem.Cancelada => ("Cancelada", "badge bg-danger"),
                _ => (Status.ToString(), "badge bg-secondary")
            };
            output.Attributes.SetAttribute("class", css);
            output.Content.SetContent(text);
        }
    }
}
