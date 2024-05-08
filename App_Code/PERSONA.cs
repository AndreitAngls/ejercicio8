using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de PERSONA
/// </summary>
public class PERSONA
{

    private string cuenta;
    private string nombre;
    private string apellido;
    private string ci;
    private string domicilio;
    private string celular;
    private string correo;

    public string Cuenta
    {
        get { return cuenta; }
        set { cuenta = value; }
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Apellido
    {
        get { return apellido; }
        set { apellido = value; }
    }

    public string Ci
    {
        get { return ci; }
        set { ci = value; }
    }

    public string Domicilio
    {
        get { return domicilio; }
        set { domicilio = value; }
    }

    public string Celular
    {
        get { return celular; }
        set { celular = value; }
    }

    public string Correo
    {
        get { return correo; }
        set { correo = value; }
    }
    
    public PERSONA()
	{

	}

    string conStr = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;

    public string Insert()
    {
        using (SqlConnection sqlcon = new SqlConnection(conStr))
        {
            SqlCommand sqlcmd = new SqlCommand("spInsertPersona", sqlcon);

            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@cuenta", Cuenta);
            sqlcmd.Parameters.AddWithValue("@nombre", Nombre);
            sqlcmd.Parameters.AddWithValue("@apellido", Apellido);
            sqlcmd.Parameters.AddWithValue("@ci", Ci);
            sqlcmd.Parameters.AddWithValue("@domicilio", Domicilio);
            sqlcmd.Parameters.AddWithValue("@celular", Celular);
            sqlcmd.Parameters.AddWithValue("@correo", Correo);

            sqlcon.Open();
            int count = sqlcmd.ExecuteNonQuery();

            if (count > 0)
                return "PASS";
            else
                return "FAIL";
        }
    }

    public string Update()
    {
        using (SqlConnection sqlcon = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("spUpdatePersona", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@cuenta", Cuenta);
            cmd.Parameters.AddWithValue("@nombre", Nombre);
            cmd.Parameters.AddWithValue("@apellido", Apellido);
	    cmd.Parameters.AddWithValue("@ci", Ci);
            cmd.Parameters.AddWithValue("@domicilio", Domicilio);
            cmd.Parameters.AddWithValue("@celular", Celular);
            cmd.Parameters.AddWithValue("@correo", Correo);

            sqlcon.Open();
            int count = cmd.ExecuteNonQuery();
            sqlcon.Close();

            if (count > 0)
                return "PASS";
            else
                return "FAIL";
        }
    }

    public List<PERSONA> Select(int id)
    {
        using (SqlConnection sqlcon = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("spSelectPersona", sqlcon);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            sqlcon.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            List<PERSONA> lstper = new List<PERSONA>();

            while (dr.Read())
            {
                PERSONA per = new PERSONA
                {
                    Cuenta = dr["CUENTA"].ToString(),
                    Nombre = dr["NOMBRE"].ToString(),
                    Apellido = dr["APELLIDO"].ToString(),
                    Ci = dr["CI"].ToString(),
                    Domicilio = dr["DOMICILIO"].ToString(),
                    Celular = dr["CELULAR"].ToString(),
                    Correo = dr["CORREO"].ToString()
                };

                lstper.Add(per);
            }

            return lstper;
        }
    }

    public string Delete(int id)
    {
        using (SqlConnection sqlcon = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("spDeletePersona", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            sqlcon.Open();
            int count = cmd.ExecuteNonQuery();
            sqlcon.Close();

            if (count > 0)
                return "PASS";
            else
                return "FAIL";
        }
    }

}
