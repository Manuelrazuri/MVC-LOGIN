using MySqlConnector;
using mvc.Models;

public class AutoRepositorio {
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

    public List<Auto> listarAutos() {
        List<Auto> lista = null;
        Auto auto = null;

        MySqlCommand cmd = null;
        MySqlDataReader dr = null;

        try {
            cmd = new MySqlCommand();
            cmd.Connection = this.cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from auto";

            dr = cmd.ExecuteReader();

            while (dr.Read()) {
                if (lista == null) {
                    lista = new List<Auto>();
                }

                auto = null;
                auto = new Auto();
                auto.codigo = dr.GetInt32("codigo");
                auto.marca = dr.GetString("marca");
                auto.modelo = dr.GetString("modelo");
                auto.cantidadVentanas = dr.GetInt16("cantidadVentanas");
                auto.cantidadLlantas = dr.GetInt16("cantidadLlantas");

                lista.Add(auto);
            }
        } catch (Exception ex) {
            throw ex;
        } finally {
            if (cmd != null) {
                cmd = null;
            }
        }

        return lista;
    }

    public bool agregarAuto(Auto autoINPUT) {
        MySqlCommand cmd = null;
        bool resultado = false;
        
        try {
            cmd = new MySqlCommand();
            cmd.Connection = this.cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into auto (marca, modelo, cantidadVentanas, cantidadLlantas) " +
                                "values ('" + autoINPUT.marca + "', '" + autoINPUT.modelo + "', " + autoINPUT.cantidadVentanas + ", " + autoINPUT.cantidadLlantas + ")";

            int cantidadFilasAfectadas = cmd.ExecuteNonQuery();

            if (cantidadFilasAfectadas >= 0) {
                resultado = true;
            } else {
                resultado = false;
            }
        } catch (Exception ex) {
            throw ex;
        } finally {
            if (cmd != null) {
                cmd = null;
            }
        }

        return resultado;
    }
    public bool editarAuto(Auto autoINPUT){
         MySqlCommand cmd = null;
         bool resultado = false;
        try{
             cmd = new MySqlCommand();
            cmd.Connection = this.cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE auto SET marca = '" + autoINPUT.marca + "', " +
                          "modelo = '" + autoINPUT.modelo + "', " +
                          "cantidadVentanas = " + autoINPUT.cantidadVentanas + ", " +
                          "cantidadLlantas = " + autoINPUT.cantidadLlantas + " " +
                          "WHERE codigo = " + autoINPUT.codigo;
         int cantidadFilasAfectadas = cmd.ExecuteNonQuery();

        resultado = cantidadFilasAfectadas > 0;
    } catch (Exception ex) {
        throw new Exception("Error al editar el auto: " + ex.Message);
    } finally {
        if (cmd != null) {
            cmd = null;
        }
    }

    return resultado;
    }

     public bool eliminarAuto(Auto autoINPUT){
         MySqlCommand cmd = null;
         bool resultado = false;
        try{
             cmd = new MySqlCommand();
            cmd.Connection = this.cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM auto WHERE codigo = " + autoINPUT.codigo;
         int cantidadFilasAfectadas = cmd.ExecuteNonQuery();

        resultado = cantidadFilasAfectadas > 0;
    } catch (Exception ex) {
        throw new Exception("Error al eliminar el auto: " + ex.Message);
    } finally {
        if (cmd != null) {
            cmd = null;
        }
    }

    return resultado;
    }
   
    // public bool buscarAuto(Auto autoINPUT){
    //      MySqlCommand cmd = null;
    //      bool resultado = false;
    //     try{
    //          cmd = new MySqlCommand();
    //         cmd.Connection = this.cn;
    //         cmd.CommandType = System.Data.CommandType.Text;
    //         cmd.CommandText = "Select codigo, marca, modelo, cantidadVentanas, cantidadLlantas" +
    //                            "From auto" +
    //                            "where codigo Like" + autoINPUT.codigo +
    //                            "OR marca Like" + autoINPUT.marca +
    //                            "OR modelo Like" + autoINPUT.modelo + 
    //                            "OR cantidadVentanas Like" + autoINPUT.cantidadVentanas +
    //                            "OR cantidadLlantas Like" + autoINPUT.cantidadLlantas;
    //      int cantidadFilasAfectadas = cmd.ExecuteNonQuery();

    //     resultado = cantidadFilasAfectadas > 0;
    // } catch (Exception ex) {
    //     throw new Exception("Error al encontrar el auto: " + ex.Message);
    // } finally {
    //     if (cmd != null) {
    //         cmd = null;
    //     }
    // }

    // return resultado;
    // }

    public List<Auto> buscarAuto(string buscar) {
        
    List<Auto> lista = new List<Auto>();
    MySqlCommand cmd = null;
    MySqlDataReader dr = null;

    try {
        cmd = new MySqlCommand();
        cmd.Connection = this.cn;
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "SELECT * FROM auto " +
                          "WHERE codigo LIKE '%" + buscar + "%' " +
                          "OR marca LIKE '%" + buscar + "%' " +
                          "OR modelo LIKE '%" + buscar + "%' " +
                          "OR cantidadVentanas LIKE '%" + buscar + "%' " +
                          "OR cantidadLlantas LIKE '%" + buscar + "%'";

        // cmd.Parameters.AddWithValue("@buscar", "%" + buscar + "%");
        dr = cmd.ExecuteReader();

        while (dr.Read()) {
            Auto auto = new Auto {
                codigo = dr.GetInt32("codigo"),
                marca = dr.GetString("marca"),
                modelo = dr.GetString("modelo"),
                cantidadVentanas = dr.GetInt16("cantidadVentanas"),
                cantidadLlantas = dr.GetInt16("cantidadLlantas")
            };
            lista.Add(auto);
        }
    } catch (Exception ex) {
        throw new Exception("Error al buscar autos: " + ex.Message);
    } finally {
        dr?.Close();
    }

    return lista;
}

}

