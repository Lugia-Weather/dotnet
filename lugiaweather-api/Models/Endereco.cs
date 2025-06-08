using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lugiaweather_api.Models;

[Table("TBL_ENDERECO")]
public class Endereco
{
    [Key]
    [Column("ID_ENDERECO")]
    public long IdEndereco { get; set; }

    [Required]
    [StringLength(100)]
    [Column("LOGRADOURO")]
    public string Logradouro { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    [Column("BAIRRO")]
    public string Bairro { get; set; } = string.Empty;

    [StringLength(100)]
    [Column("COMPLEMENTO")]
    public string? Complemento { get; set; }

    [Required]
    [StringLength(2)]
    [Column("UF", TypeName = "CHAR(2)")]
    public string Uf { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    [Column("LOCALIDADE")]
    public string Localidade { get; set; } = string.Empty;

    [Column("LATITUDE", TypeName = "NUMERIC(10,6)")]
    public decimal? Latitude { get; set; }

    [Column("LONGITUDE", TypeName = "NUMERIC(11,6)")]
    public decimal? Longitude { get; set; }

    [Required]
    [Column("DATA_CRIACAO")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime DataCriacao { get; set; }

    [Column("DATA_ATUALIZACAO")]
    public DateTime? DataAtualizacao { get; set; }
}