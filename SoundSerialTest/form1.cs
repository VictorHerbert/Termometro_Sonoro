using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO.Ports;
using System.Threading;
 

namespace SoundSerialTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SerialPort.GetPortNames().Length != 0)
            {
                button1.Text = "Atualizar Lista";
                comboBox1.Enabled = true;
                button2.Enabled = true;
                comboBox1.Items.Clear();
                foreach (string port in SerialPort.GetPortNames())
                {
                    comboBox1.Items.Add(port);
                }
                comboBox1.SelectedIndex = 0;
                label1.Text = "Conectar em " + comboBox1.Items[comboBox1.SelectedIndex].ToString();
                label1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Por favor, conecte o arduino","Nenhuma Conexão encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            serialPort1.Open();
            if (serialPort1.IsOpen) label1.Text = "Conectado em " + serialPort1.PortName;
            button1.Enabled = false;
            comboBox1.Enabled = false;
            button2.Enabled = false;
            label1.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoundPlayer Leitor;
            serialPort1.Write("3");
            string valor = serialPort1.ReadLine();
            if (valor[0] == '|')
            {
                string path;
                label2.Text = "Medições";

                if (valor.Length.Equals(9))
                {
                    path = "Audio/" + valor[1] + "00.wav";
                    Leitor = new SoundPlayer(path);
                    Leitor.PlaySync();
                    if (valor[2] == 1)
                    {
                        path = "Audio/" + valor[2].ToString() + valor[3].ToString() + "0.wav";
                        Leitor = new SoundPlayer(path);
                        Leitor.PlaySync();
                    }
                    else
                    {
                        path = "Audio/" + valor[2] + "0.wav";
                        Leitor = new SoundPlayer(path);
                        Leitor.PlaySync();

                        Leitor = new SoundPlayer(@"Audio/e.wav");
                        Leitor.PlaySync();

                        path = "Audio/" + valor[3] + ".wav";
                        Leitor = new SoundPlayer(path);
                        Leitor.PlaySync();
                    }
                    Leitor = new SoundPlayer(@"Audio/ponto.wav");
                    Leitor.PlaySync();

                    path = "Audio/" + valor[5] + ".wav";
                    Leitor = new SoundPlayer(path);
                    Leitor.PlaySync();

                    path = "Audio/" + valor[6] + ".wav";
                    Leitor = new SoundPlayer(path);
                    Leitor.PlaySync();

                }
                if (valor.Length.Equals(8))
                {
                    if (valor[1] == 1)
                    {
                        path = "Audio/" + valor[1].ToString() + valor[2].ToString()+ "0.wav";
                        Leitor = new SoundPlayer(path);
                        Leitor.PlaySync();
                    }
                    else
                    {
                        path = "Audio/" + valor[1] + "0.wav";
                        Leitor = new SoundPlayer(path);
                        Leitor.PlaySync();

                        Leitor = new SoundPlayer(@"Audio/e.wav");
                        Leitor.PlaySync();

                        path = "Audio/" + valor[2] + ".wav";
                        Leitor = new SoundPlayer(path);
                        Leitor.PlaySync();
                    }
                    
                    Leitor = new SoundPlayer(@"Audio/ponto.wav");
                    Leitor.PlaySync();

                    path = "Audio/" + valor[4] + ".wav";
                    Leitor = new SoundPlayer(path);
                    Leitor.PlaySync();

                    path = "Audio/" + valor[5] + ".wav";
                    Leitor = new SoundPlayer(path);
                    Leitor.PlaySync();
                }
                if (valor.Length.Equals(7))
                {
                    path = "Audio/" + valor[1] + ".wav";
                    Leitor = new SoundPlayer(path);
                    Leitor.PlaySync();

                    Leitor = new SoundPlayer(@"Audio/ponto.wav");
                    Leitor.PlaySync();

                    path = "Audio/" + valor[2] + ".wav";
                    Leitor = new SoundPlayer(path);
                    Leitor.PlaySync();

                    path = "Audio/" + valor[3] + ".wav";
                    Leitor = new SoundPlayer(path);
                    Leitor.PlaySync();
                }
                SoundPlayer Leitor2 = new SoundPlayer(@"Audio/°C.wav");
                Leitor2.PlaySync();
            }
            label2.Enabled = true;
            listView1.Enabled = true;
            valor += "°C";
            listView1.Items.Add(valor);
        }
    }
}

