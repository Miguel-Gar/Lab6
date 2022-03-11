using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        List<Clientes> cliente = new List<Clientes>();
        List<DatosVehiculos> datosVe = new List<DatosVehiculos>();
        List<DatosRenta> DRental = new List<DatosRenta>();
        List<Rsultado> rTotal = new List<Rsultado>();
        public Form1()
        {
            InitializeComponent();
        }
        private void GuardarDCliente(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var p in cliente)
            {
                writer.WriteLine(p.Nit);
                writer.WriteLine(p.Nombre);
                writer.WriteLine(p.Dirección);
            }
            writer.Close();
        }
        private void GuardarDVehiculos(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var p in datosVe)
            {
                writer.WriteLine(p.Placa);
                writer.WriteLine(p.Marca);
                writer.WriteLine(p.Modelo);
                writer.WriteLine(p.Color);
                writer.WriteLine(p.Precios);
            }
            writer.Close();

        }
        private void GuardarRe(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var p in datosVe)
            {
                writer.WriteLine(p.Placa);
                writer.WriteLine(p.Marca);
                writer.WriteLine(p.Modelo);
                writer.WriteLine(p.Color);
                writer.WriteLine(p.Precios);
            }
            writer.Close();

        }
        private void GuardaR(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var p in DRental)
            {
                writer.WriteLine(p.Nit);
                writer.WriteLine(p.Placa);
                writer.WriteLine(p.klmRecorridos);
                writer.WriteLine(p.fechaAlquiler);
                writer.WriteLine(p.fechaDebolucion);
            }
            writer.Close();

        }
        private void GaR(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var p in rTotal)
            {
                writer.WriteLine(p.nombre);
                writer.WriteLine(p.Nit);
                writer.WriteLine(p.Placa);
                writer.WriteLine(p.klmRecorridos);
                writer.WriteLine(p.fechaAlquiler);
                writer.WriteLine(p.Total_a_Pagar);

            }
            writer.Close();

        }
        private void buttonAgrgar_Click(object sender, EventArgs e)
        {
            int i = 0;
            int x = 0;
            int x2 = 0;
            if (i == 0)
            {
                Clientes er = new Clientes();
                er.Nit = textNiit.Text;
                er.Nombre = textBox2.Text;
                er.Dirección = textBox3.Text;
                cliente.Add(er);
            }
            GuardarDCliente("Clientes.txt");
            int p = datosVe.FindIndex(t => t.Placa == textp.Text);
            if (p == -1)
            {
                DatosVehiculos dire = new DatosVehiculos();
                dire.Placa = textp.Text;
                dire.Marca = comboMarca.Text;
                dire.Modelo = comboModelo.Text;
                dire.Color = comboColores.Text;
                dire.Precios = Convert.ToInt16(textPrecio.Text);
                datosVe.Add(dire);
            }
            else
            {
               MessageBox.Show("La Placa Ya exite ", "Tome en cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return;
            }
            GuardarDVehiculos("Vehiculos.txt");

            if (x == 0)
            {
                DatosRenta er = new DatosRenta();
                er.Nit = textBox1.Text;
                er.Placa = textBox2.Text;
                er.klmRecorridos = Convert.ToInt16(textBox4.Text);
                er.fechaAlquiler = dateTimeFalquiler.Value;
                er.fechaDebolucion = dateTimeFdevolucion.Value;
                DRental.Add(er);
                GuardaR("Renta.txt");
            }
            if (x2==0)
            {
                for (int i2 = 0; i2 < cliente.Count; i2++)
                {
                    for (int a = 0; a < datosVe.Count; a++)
                    {
                        for (int i1 = 0; i1 < DRental.Count; i1++)
                        {
                            if (datosVe[a].Precios == DRental[i1].klmRecorridos)
                            {
                                Rsultado he = new Rsultado();
                                he.nombre = cliente[i2].Nombre;
                                he.Nit = cliente[i2].Nit;
                                he.Placa = datosVe[a].Placa;
                                he.klmRecorridos = DRental[i1].klmRecorridos;
                                he.fechaAlquiler = DRental[i1].fechaAlquiler;
                                he.Total_a_Pagar = datosVe[i1].Precios * DRental[a].klmRecorridos;
                                rTotal.Add(he);
                                GaR("resultado.txt");
                            }
                        }
                    }
                }
            }
            textNiit.Text = "";
            textBox1.Text = "";
            textBox2.Text= "";
            textBox3.Text = "";
            textp.Text = "";
            textPrecio.Text = "";
            comboColores.Text = "";
            comboMarca.Text = "";
            comboModelo.Text = "";

        }
        private void mostrar()
        {
            //función de mostrar los datos en los datagridview
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = cliente;

            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = datosVe;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            dataGridView3.DataSource = null;
            dataGridView3.Refresh();
            dataGridView3.DataSource = rTotal;
        }
    }
}
