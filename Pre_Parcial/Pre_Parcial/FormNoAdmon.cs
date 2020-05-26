﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;

namespace Pre_Parcial
{
    public partial class FormNoAdmon : Form
    {
        public FormNoAdmon()
        {
            InitializeComponent();
        }

        private void FormNoAdmon_Load(object sender, EventArgs e)
        {
            var videogames = Conexion.realizarConsulta("SELECT nombre_art FROM INVENTARIO");
            var videogamescombo = new List<string>();

            foreach (DataRow dr in videogames.Rows)
            {
                videogamescombo.Add(dr[0].ToString());
            }

            comboBox1.DataSource = videogamescombo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Equals("") || comboBox1.Equals("") || textBox2.Equals(""))

            {
                MessageBox.Show("No puede dejar los campos vacios!");
            }
            else
            {

                try
                {

                    var dt = Conexion.realizarConsulta(
                        $"SELECT id_articulo FROM INVENTARIO WHERE nombre_art='{comboBox1.SelectedItem.ToString()}'");
                    var dr = dt.Rows[0];
                    var Codigo_articulo = Convert.ToInt32(dr[0].ToString());

                    string nonquery = $"INSERT INTO PEDIDO (codigo_articulo, cantidad, nombre_user) VALUES (" +
                                      $"{Codigo_articulo}," +
                                      $"{textBox1.Text}," +
                                      $"'{textBox2.Text}')";
                    Conexion.realizarAccion(nonquery);

                    MessageBox.Show("Pedido Realizado");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }
        
    }
}