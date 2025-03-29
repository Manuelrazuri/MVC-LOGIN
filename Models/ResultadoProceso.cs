namespace mvc.Models;

public class ResultadoProceso {
    public int codigoResultado { get; set; } //1: OK, 0: ERROR
    public string mensajeError { get; set; } //Si "codigoResultado == 0", entonces aqui se detalla el error ocurrido
    public object data { set; get; }
}