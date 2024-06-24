using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace clinicteo.Models.Base;

public class BaseEntity
{
    [Key]
    [Column( "id" )]
    [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
    public int Id { get; set; }
    [Column( name: "create-at" )]
    public DateOnly CreateAt { get; set; }
    [Column( name: "update-at" )]
    public DateOnly? UpdateAt { get; set; }
}
