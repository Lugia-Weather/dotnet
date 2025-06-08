using lugiaweather_api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lugiaweather_api.Models;

[Table("TBL_LEITURA")]
public class Leitura
{
    [Key]
    [Column("ID_LEITURA")]
    public long IdLeitura { get; set; }

    [Required]
    [Column("ID_DISPOSITIVO")]
    public long IdDispositivo { get; set; }

    [Required]
    [Column("NIVEL_AGUA_CM", TypeName = "NUMERIC(8,3)")]
    public decimal NivelAguaCm { get; set; }

    [Required]
    [Column("STATUS_NIVEL")]
    public StatusNivelEnum StatusNivel { get; set; }

    [Required]
    [Column("DATA_CRIACAO")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime DataCriacao { get; set; }

    [Column("ID_ALERTA")]
    public long? IdAlerta { get; set; }

    // Relacionamentos
    [ForeignKey(nameof(IdDispositivo))]
    public DispositivoIot? Dispositivo { get; set; }

    [ForeignKey(nameof(IdAlerta))]
    public Alerta? Alerta { get; set; }
}
