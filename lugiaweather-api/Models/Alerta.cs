using lugiaweather_api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lugiaweather_api.Models;

[Table("TBL_ALERTA")]
public class Alerta
{
    [Key]
    [Column("ID_ALERTA")]
    public long IdAlerta { get; set; }

    [Required]
    [StringLength(50)]
    [Column("TIPO")]
    public TipoAlertaEnum Tipo { get; set; }

    [Required]
    [StringLength(500)]
    [Column("MENSAGEM")]
    public string Mensagem { get; set; } = string.Empty;

    [Required]
    [Column("DATA_CRIACAO")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime DataCriacao { get; set; }
}