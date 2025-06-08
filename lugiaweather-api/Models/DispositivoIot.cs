using lugiaweather_api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lugiaweather_api.Models;

[Table("TBL_DISPOSITIVO_IOT")]
public class DispositivoIot
{
    [Key]
    [Column("ID_DISPOSITIVO")]
    public long IdDispositivo { get; set; }

    [Required]
    [StringLength(100)]
    [Column("ID_MODULO")]
    public string IdModulo { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    [Column("MAC_ENDERECO")]
    public string MacEndereco { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    [Column("PROJETO")]
    public string Projeto { get; set; } = string.Empty;

    [Required]
    [Column("STATUS")]
    public StatusDispositivoIotEnum Status { get; set; } = StatusDispositivoIotEnum.Ativo;

    [Required]
    [Column("ID_ENDERECO")]
    public long IdEndereco { get; set; }

    [Required]
    [Column("DATA_CRIACAO")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime DataCriacao { get; set; }

    [Column("DATA_ATUALIZACAO")]
    public DateTime? DataAtualizacao { get; set; }

    [ForeignKey(nameof(IdEndereco))]
    public Endereco? Endereco { get; set; }
}