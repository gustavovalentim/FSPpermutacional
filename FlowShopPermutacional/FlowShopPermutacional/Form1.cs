using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FlowShopPermutacional
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProblemaFSP MeuProblema = new ProblemaFSP();
            MeuProblema.LerProblema(@"D:\Teste\ExemploFSP2.txt");
            Stopwatch Cronometro = new Stopwatch();
            Cronometro.Start();
            DadosSequencia MelhorSequencia = MeuProblema.EncontraMelhorSequenciaAleatoria(int.Parse(txtNumeroSequencias.Text));
            Cronometro.Stop();
            MessageBox.Show(Cronometro.ElapsedMilliseconds.ToString());
            string SequenciaAtual = MelhorSequencia.Sequencia[0].ToString();
            for (int i = 1; i < MelhorSequencia.Sequencia.GetLength(0); i++)
            {
                SequenciaAtual = SequenciaAtual + "-" + MelhorSequencia.Sequencia[i].ToString();
            }
            MessageBox.Show("O makespan da sequência " + SequenciaAtual + " é " + MelhorSequencia.Makespan.ToString() + " e foi a melhor sequência encontrada");
        }

        private void btnBuscaVizinhamca_Click(object sender, EventArgs e)
        {
            ProblemaFSP MeuProblema = new ProblemaFSP();
            MeuProblema.LerProblema(@"D:\Teste\ExemploFSP2.txt");
            Stopwatch Cronometro = new Stopwatch();
            Cronometro.Start();
            DadosSequencia MelhorSequencia = new DadosSequencia();
            MelhorSequencia = MeuProblema.EncontraMelhorSequenciaBuscaVizinhanca();
            Cronometro.Stop();
            MessageBox.Show(Cronometro.ElapsedMilliseconds.ToString());
            string SequenciaAtual = MelhorSequencia.Sequencia[0].ToString();
            for (int i = 1; i < MelhorSequencia.Sequencia.GetLength(0); i++)
            {
                SequenciaAtual = SequenciaAtual + "-" + MelhorSequencia.Sequencia[i].ToString();
            }
            MessageBox.Show("O makespan da sequência " + SequenciaAtual + " é " + MelhorSequencia.Makespan.ToString() + " e foi a melhor sequência encontrada");
        }
    }
}
