using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Proyecto1.Models;
using System.Data.SqlClient;

namespace Proyecto1.Data
{    
    public class ConexionBD
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;
        public ConexionBD()
        {
            try
            {
                cn = new SqlConnection("Data Source=.;Initial Catalog=Mundial2018;Integrated Security=True");
                cn.Open();
                Console.WriteLine("conectado con la base de datos Mundial2018");
            }
            catch(Exception ex)
            {
                Console.WriteLine("no se pudo conectar con la base de datos"+ex.ToString());
            }
        }
        //public string insertarEquipo(int id, string nombre, string nomband)
        public string insertarEquipo(Equipo equprec)
        {
            int id;
            id = equprec.EquipoID+1;
            string nombre;
            nombre = equprec.NomEquipo;
            string nomband;
            nomband = equprec.ImagenBandera;

            string salida = "se inserto en la BD";
            try
            {
                cmd = new SqlCommand("Insert into Equipo(EquipoID,NomEquipo,ImagenBandera) values(" + id + ",'" + nombre + "','" + nomband + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "no se pudo insertar: " + ex.ToString();
                Console.WriteLine(salida);
            }
            return salida;
        }

        public void RetirarEquipo(int id)
        {
            string salida = "se inserto en la BD";
            try
            {
                cmd = new SqlCommand("Delete from Equipo where EquipoID = " + id + "", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "no se pudo insertar: " + ex.ToString();
            }            
        }

        //public string insertarJugador(int id, string nombre, string histo,int posi,string fotjug,string pajug)//****************************************************************************************************************************************
        public string insertarJugador(Jugador jugu)//************************
        {
            int id = jugu.JugadorID;
            string nombre = jugu.Nombre;
            string histo=jugu.Historia;
            int posi = jugu.Posicion;
            string fotjug = jugu.ImagenJug;
            string pajug = jugu.PaisJugador;
            string salida = "se inserto en la BD";
            try
            {
                cmd = new SqlCommand("Insert into Jugador(JugadorID,Nombre,Historia,posicion,ImagenJug,PaisJugador) values(" + id + ",'" + nombre + "','" + histo + "'," + posi + ",'" + fotjug + "','" + pajug + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "no se pudo insertar: " + ex.ToString();
            }
            return salida;
        }

        public void RetirarJugador(int id)
        {
            string salida = "se inserto en la BD";
            try
            {
                cmd = new SqlCommand("Delete from Jugador where JugadorID = " + id + "", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "no se pudo insertar: " + ex.ToString();
            }
        }

        public int EquipoRegistrado(string nomequi)
        {
            int contador = 0;
            try
            {
                cmd = new SqlCommand("Select * from Equipo where NomEquipo = '"+nomequi+"'", cn);// ver cuantas veces se registro el mismo equipo
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    contador++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("no se pudo ejecutar consulta: " + ex.ToString());
            }
            return contador;
        }

        public int JugadorRegistrado(string nomjug)
        {
            int contador = 0;
            try
            {
                cmd = new SqlCommand("Select * from Jugador where Nombre = '" + nomjug + "'", cn);// ver cuantas veces se registro el mismo jugador
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contador++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("no se pudo ejecutar consulta: " + ex.ToString());
            }
            return contador;
        }

        public int JugadorRegistradoID(int IDju)
        {
            int jugid=0;
            try
            {
                cmd = new SqlCommand("Select * from Jugador where JugadorID = " + IDju + "", cn);// ver cuantas veces se registro el mismo jugador
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    jugid = Int32.Parse(dr["JugadorID"].ToString());                    
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("no se pudo ejecutar consulta: " + ex.ToString());
            }
            return jugid;
        }

        public int NumRegistrosEquipo()// ver cuantos registros hay en la tabla Equipo
        {
            int contador = 0;
            try
            {
                cmd = new SqlCommand("Select EquipoID from Equipo",cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contador++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("no se pudo ejecutar consulta: " + ex.ToString());
            }
            return contador;
        }

        public int NumRegistrosJugador()// ver cuantos registros hay en la tabla Jugador
        {
            int contador = 0;
            try
            {
                cmd = new SqlCommand("Select JugadorID from Jugador", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contador++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("no se pudo ejecutar consulta: " + ex.ToString());
            }
            return contador;
        }

        public List<Jugador> NumRegistrosJugadores(string paisid)// ver cuantos registros hay en la tabla Jugador
        {
            int contador = 0;
            List<Jugador> juga = new List<Jugador>();
            try
            {
                cmd = new SqlCommand("Select * from Jugador where PaisJugador = '" + paisid + "'", cn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    juga.Add(new Jugador() {  JugadorID = Int32.Parse(dr["JugadorID"].ToString()), Nombre = dr["Nombre"].ToString(), PaisJugador = paisid,ImagenJug=dr["ImagenJug"].ToString(),Posicion= Int32.Parse(dr["posicion"].ToString()) });
                    contador++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("no se pudo ejecutar consulta: " + ex.ToString());
            }
            return juga;
        }

        public List<Jugador> ListaJugadoresEquipo(string equip) // carga en una lista los jugadores pertenecientes a un equipo
        {
            List<Jugador> EquipoPais = new List<Jugador>();
            int NumJug = 0;

            try
            {
                cmd = new SqlCommand("Select Nombre from Jugador where PaisJugador = '"+equip+"'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EquipoPais.Add(new Jugador() {JugadorID= Int32.Parse(dr["JugadorID"].ToString()), Nombre =dr["Nombre"].ToString(), PaisJugador = equip });
                    NumJug++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("no se pudo ejecutar consulta: " + ex.ToString());
            }

            return EquipoPais;
        }

        public List<Equipo> ListaEquipos()  // carga en una lista los equipos de la base de datos
        {
            List<Equipo> EquipoPais = new List<Equipo>();


            try
            {
                cmd = new SqlCommand("Select * from Equipo", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EquipoPais.Add(new Equipo() {EquipoID = Int32.Parse(dr["EquipoID"].ToString()), NomEquipo = dr["NomEquipo"].ToString(), ImagenBandera=dr["ImagenBandera"].ToString()});
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("no se pudo ejecutar consulta: " + ex.ToString());
            }

            return EquipoPais;
        }

        public Equipo mostrareqp(int id)
        {
            Equipo eqq = new Equipo();
            try
            {
                cmd = new SqlCommand("Select * from Equipo where EquipoID = '" + id + "'", cn);                
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    eqq.EquipoID = Int32.Parse(dr["EquipoID"].ToString());
                    eqq.NomEquipo = dr["NomEquipo"].ToString();
                    eqq.ImagenBandera = dr["ImagenBandera"].ToString();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("no se pudo ejecutar consulta: " + ex.ToString());
            }
            return eqq;
        }

        public void CargarJug(string equip) // seleccionar un grupo segun equipo y guardar en una tabla
        {
            try
            {
                da = new SqlDataAdapter("Select Nombre from Jugador where PaisJugador = '" + equip + "'", cn);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch(Exception ex)
            {

            }
        }

    }
}
