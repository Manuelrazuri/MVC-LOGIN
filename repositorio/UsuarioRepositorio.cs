using MySqlConnector;
using mvc.Models;

public class UsuarioRepositorio {
    const string KS_IPBBDD = "localhost";
    const int KI_PUERTOBBDD = 3306;
    const string KS_NOMBREBBDD = "Lima_Autos";
    const string KS_USUARIOBBDD = "root";
    const string KS_CLAVEUSUARIOBBDD = "tauro21LP*21";
    public MySqlConnection cn;

    public ResultadoProceso conectarBBDD() {
        ResultadoProceso resultado = new ResultadoProceso();

        cn = null;

        try {
            cn = new MySqlConnection();

            cn.ConnectionString = "Server=" + KS_IPBBDD + ";Port=" + KI_PUERTOBBDD
            + ";Database=" + KS_NOMBREBBDD + ";Uid=" + KS_USUARIOBBDD + ";Pwd=" + KS_CLAVEUSUARIOBBDD;
            
            cn.Open();
            resultado.codigoResultado = 1;
            resultado.mensajeError = "";
        } catch (Exception ex) {
            resultado.codigoResultado = 0;
            resultado.mensajeError = "Hubo un error al conectarse a la BBDD. Detalles: " + ex.Message;
        }

        return resultado;
    }
    
}