using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

/// </summ ebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class ServicePersona : System.Web.Services.WebService {

    public ServicePersona () 
    {

    }

    PERSONA per;
    private SqlCommand Comando = new SqlCommand();

    [WebMethod]
    public string InsertPersona(string CUENTA, string NOMBRE, string APELLIDO, string CI, string DOMICILIO, string CELULAR, string CORREO)
    {
        Common(CUENTA, NOMBRE, APELLIDO, CI, DOMICILIO, CELULAR, CORREO);

        string status = per.Insert();

        if (status == "PASS")
            return "PERSONA AGREGADA";
        else
            return "PERSONA NO AGREGADA";
    }

    [WebMethod]
    public string UpdatePersona(string CUENTA, string NOMBRE, string APELLIDO, string CI, string DOMICILIO, string CELULAR, string CORREO)
    {
        Common(CUENTA, NOMBRE, APELLIDO, CI, DOMICILIO, CELULAR, CORREO);

        string status = per.Update();

        if (status == "PASS")
            return "PERSONA EDITADA";
        else
            return "PERSONA NO EDITADA";
    }

    [WebMethod]
    public string DeletePersona(int ID)
    {
        string status = per.Delete(ID);

        if (status == "PASS")
            return "PERSONA ELIMINADA";
        else
            return "PERSONA NO ELIMINADA";
    }

    //[WebMethod]
    public List<PERSONA> SelectPersona(int ID)
    {
        List<PERSONA> lstbal = per.Select(ID);

        if (lstbal != null)
            return lstbal;
        else
            return lstbal;
    }

    private void Common(string CUENTA, string NOMBRE, string APELLIDO, string CI, string DOMICILIO, string CELULAR, string CORREO)
    {
        per = new PERSONA
        {
            Cuenta = CUENTA,
            Nombre = NOMBRE,
            Apellido = APELLIDO,
            Ci = CI,
            Domicilio = DOMICILIO,
            Celular = CELULAR,
            Correo = CORREO
        };
    }
}
