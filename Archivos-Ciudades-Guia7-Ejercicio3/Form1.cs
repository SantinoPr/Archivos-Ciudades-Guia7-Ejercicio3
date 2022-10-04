using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;

namespace Archivos_Ciudades_Guia7_Ejercicio3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Ciudad ciudad;
        ArrayList ciudades=new ArrayList();
        string archivo = "C:/Users/Santino/Documents/pedidos.dat.txt";
        //string archivoFaltantes = "C:/Users/Santino/Documents/faltantes.txt";
        private void button1_Click(object sender, EventArgs e)
        {           
            
            if (File.Exists(archivo))
            {
                try
                {
                    ciudad = new Ciudad(txtciudad.Text.ToString(), Convert.ToInt32(txtReclamos.Text), Convert.ToInt32(txtReparaciones.Text));
                    string text = txtciudad.Text.ToString() + ";" + txtReclamos.Text.ToString() + ";" +ciudad.Reparaciones+ ";"+ciudad.Porcentaje();
                    FileStream fs = new FileStream(archivo, FileMode.Append, FileAccess.Write);
                  
                    StreamWriter sw = new StreamWriter(fs);
                    {
                        sw.WriteLine(text);
                    }
                    sw.Close();
                    fs.Close();           
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Ocurrio un error en el fichero" + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtciudad_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(archivo, FileMode.Open, FileAccess.Read);
            StreamReader leer = new StreamReader(fs);
            Thread.Sleep(100);
            dataGridView1.Rows.Clear();
            ciudades.Clear();
            try
            {
                while (!leer.EndOfStream)
                {
                    string linea = leer.ReadLine();
                    string[] campos = linea.Split(';');
                    dataGridView1.ColumnCount = linea.Split(';').Length;
                    dataGridView1.Rows.Add(campos);
                    if(campos[1] is string)
                    {

                    }
                    else
                    {
                        ciudad = new Ciudad(campos[0].Trim(), Convert.ToInt32(campos[1].Trim()), Convert.ToInt32(campos[2].Trim()));//ciudad,reclamos,reparaciones
                        ciudades.Add(ciudad);//agregamos los faltantes de cada ciudad
                    }
                }
                   
                leer.Close();
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error en la operacion de lectura: " + ex.Message);
            }
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Rows.Clear();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw=new StreamWriter(fs);
                sw.WriteLine("Localidad; Reparaciones faltantes");
                foreach(Ciudad c in ciudades)
                {
                    sw.WriteLine(c.Nombre+";"+c.Faltantes());
                }
                sw.Close();
                fs.Close();
                
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
