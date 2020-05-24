﻿using System.Data;
using Npgsql;

namespace Pre_Parcial
{
    
        public static class Conexion
        {
            //public static string CadenaConexion = 
            //    "Server=localhost;Port=5432;User Id=postgres;Password=root;Database=bddPedidos;";

            private static string CadenaConexion = 
                "Server=10.0.2.2;Port=5432;User Id=postgres;Password=root;Database=bddPedidos";
        
            public static DataTable realizarConsulta(string sql)
            {
                NpgsqlConnection conn = new NpgsqlConnection(CadenaConexion);
                DataSet ds = new DataSet();
            
                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                da.Fill(ds);
                conn.Close();
            
                return ds.Tables[0];
            }

            public static void realizarAccion(string sql)
            {
                NpgsqlConnection conn = new NpgsqlConnection(CadenaConexion);
            
                conn.Open();
                NpgsqlCommand nc = new NpgsqlCommand(sql, conn);
                nc.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
    