using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.IncidentService.Domain.Entities
{
    public interface IAuditable
    {
        string UsuarioInsercao { get; set; }
        DateTime DataHoraInsercao { get; set; }
        string UsuarioUltimaAtualizacao { get; set; }
        DateTime? DataHoraUltimaAtualizacao { get; set; }
    }
}
