using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hola a todos";
    }
    [WebMethod]
    public  DataSet estudiante(int ci)
    {
        SqlConnection con=new SqlConnection();
        con.ConnectionString = "server=DESKTOP-JJMELD8;user=sa;pwd=1234567;database=examen";
        SqlDataAdapter ada = new SqlDataAdapter();
        ada.SelectCommand = new SqlCommand();
        ada.SelectCommand.Connection =con;
        ada.SelectCommand.CommandText = "select * from estudiante where ci=@ci";
        ada.SelectCommand.CommandType = CommandType.Text;
        ada.SelectCommand.Parameters.Add("@ci", SqlDbType.Int).Value = ci;
        DataSet ds = new DataSet();
        ada.Fill(ds);
        return ds;
    }
    [WebMethod]
    public DataSet Inscribirse(int ci, String sigla) 
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "server=DESKTOP-JJMELD8;user=sa;pwd=1234567;database=examen";
        SqlDataAdapter ada = new SqlDataAdapter();
        ada.SelectCommand = new SqlCommand();
        ada.SelectCommand.Connection = con;
        ada.SelectCommand.CommandText = "insert into inscrito values(ci=@ci,sigmat=@sigla)";
        ada.SelectCommand.CommandType = CommandType.Text;
        ada.SelectCommand.Parameters.Add("@ci", SqlDbType.Int).Value = ci;
       
        DataSet ds = new DataSet();
        
        return ds;
    }

    [WebMethod]
    public string Inscrito(int ciest, String sigmat)
    {
        string mensaje = "";
         SqlConnection con = new SqlConnection();
         con.ConnectionString = "server=DESKTOP-JJMELD8;user=sa;pwd=1234567;database=examen";
        List<string> estudiantes = new List<string>();
           {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM inscrito WHERE ciest = @ciest and sigmat=@sigmat", con );
            cmd.Parameters.AddWithValue("@ciest", ciest);
            cmd.Parameters.AddWithValue("@sigmat", sigmat);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                mensaje = "ESTUDIANTE INSCRITO";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ci = dt.Rows[i]["ciest"].ToString();
                    string sigla = dt.Rows[i]["sigmat"].ToString();

                    estudiantes.Add(ci);
                    estudiantes.Add(sigla);

                }
            }
            else
            {
                mensaje = "ESTUDIANTE NO INSCRITO";
            }
            con.Close();
        }
        return mensaje;


        
    }
    
}
