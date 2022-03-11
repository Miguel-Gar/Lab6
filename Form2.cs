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
    public partial class Form2 : Form
    {
        List<DatosVehiculos> datosVe = new List<DatosVehiculos>();
        List<Rsultado> rTotal = new List<Rsultado>();
        public Form2()
        {
            InitializeComponent();
        }
        private void Leer(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                DatosVehiculos dire = new DatosVehiculos();
                dire.Placa = reader.ReadLine();
                dire.Marca = reader.ReadLine();
                dire.Modelo = reader.ReadLine();
                dire.Color = reader.ReadLine();
                dire.Precios = Convert.ToInt16(reader.ReadLine());
                datosVe.Add(dire);
            }
        }
        private void LeerResultados(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Rsultado dire = new Rsultado();
                dire.nombre = reader.ReadLine();
                dire.Nit = reader.ReadLine();
                dire.Placa = reader.ReadLine();
                dire.klmRecorridos = Convert.ToInt16(reader.ReadLine());
                dire.fechaAlquiler = Convert.ToDateTime(reader.ReadLine());
                dire.Total_a_Pagar = Convert.ToInt16(reader.ReadLine());
                rTotal.Add(dire);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Leer("Vehiculos.txt");
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = datosVe;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LeerResultados("resultado.txt");
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = rTotal;
        }
    }
}
