using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelsUser.User;

namespace ModelResidente.Residente;

public class Residente
{
    public Residente(String Nombre_residente, String Num_apartamento, String Num_telefono, User Usuario)
    {
        this.Nombre_residente = Nombre_residente;
        this.Num_apartamento = Num_apartamento;
        this.Num_telefono = Num_telefono;
        this.Usuario = Usuario;
    }

    [Key] //primarykey
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//autoincrementable
    private int Id_residente { set; get; }
    [Required]
    private String Nombre_residente { set; get; }
    [Required]
    private String Num_apartamento { get; set; }

    private String Num_telefono { get; set; }

    [ForeignKey("Id_User")]
    private User Usuario { set; get; }





}