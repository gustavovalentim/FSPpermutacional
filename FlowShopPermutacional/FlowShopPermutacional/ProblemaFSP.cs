﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace FlowShopPermutacional
{
    class ProblemaFSP
    {
        public int NumeroTarefas;
        public int NumeroMaquinas;
        public int[] InstantesIniciaisDasMaquinas;
        public int[,] MatrizTemposProcessamento; //Linhas referem-se à tarefas e colunas referem-se à máquinas
        public int[,] MatrizRetorno;
        public int[,] MatrizInicio;
        public int[,] MatrizFim;
        public int Makespan;
        public void CalcularInstantesInicioFimCadaTarefaEmCadaMaquina(int[] Sequencia)
        {
            int[] InstanteLiberacaoMaquinas = new int[NumeroMaquinas];
            for(int j=0;j<NumeroMaquinas;j++)
            {
                InstanteLiberacaoMaquinas[j] = InstantesIniciaisDasMaquinas[j];
            }
            MatrizRetorno = new int[NumeroTarefas,2*NumeroMaquinas];
            int TarefaAtual;
            for(int i=0;i<NumeroTarefas;i++)
            {
                TarefaAtual = Sequencia[i];
                MatrizRetorno[TarefaAtual, 0] = InstanteLiberacaoMaquinas[0];
                MatrizRetorno[TarefaAtual, 0 + NumeroMaquinas] = MatrizRetorno[TarefaAtual, 0] + MatrizTemposProcessamento[TarefaAtual, 0];
                InstanteLiberacaoMaquinas[0] = MatrizRetorno[TarefaAtual, 0 + NumeroMaquinas];
                for(int j=1;j<NumeroMaquinas;j++)
                {
                    MatrizRetorno[TarefaAtual, j] = Maximo(MatrizRetorno[TarefaAtual, NumeroMaquinas + j - 1], InstanteLiberacaoMaquinas[j]);
                    MatrizRetorno[TarefaAtual, j + NumeroMaquinas] = MatrizRetorno[TarefaAtual, j] + MatrizTemposProcessamento[TarefaAtual, j];
                    InstanteLiberacaoMaquinas[j] = MatrizRetorno[TarefaAtual, j + NumeroMaquinas];
                }
            }
            Makespan = MatrizRetorno[Sequencia[Sequencia.GetLength(0) - 1], NumeroMaquinas * 2 - 1];
            //return MatrizRetorno;
        }
        public DadosSequencia EncontraMelhorSequenciaBuscaVizinhanca()
        {
            Random SementeAleatoria = new Random();
            DadosSequencia DadosMelhorSequencia = new DadosSequencia();
            DadosMelhorSequencia.Sequencia = new int[NumeroTarefas];
            DadosMelhorSequencia.Makespan = 9999999;            
            int[] Movimento = new int[2];
            int NumeroMaximoIteracoes = 10;
            int NumeroAtualIteracoes = 0;
            int[] Sequencia = new int[NumeroTarefas];
            for (int h=0;h<1000;h++)
            {
                Sequencia = GerarSequenciaAleatoria(SementeAleatoria.Next(0, 100000000));
                CalcularInstantesInicioFimCadaTarefaEmCadaMaquina(Sequencia);
                bool TeveMelhoria = true;
                while (TeveMelhoria)
                {
                    TeveMelhoria = false;
                    for (int i = 0; i < NumeroTarefas; i++)
                    {
                        for (int j = i + 1; j < NumeroTarefas; j++)
                        {
                            int[] SequenciaVizinhaAtual = new int[NumeroTarefas];
                            for (int k = 0; k < NumeroTarefas; k++)
                            {
                                SequenciaVizinhaAtual[k] = Sequencia[k];
                            }
                            SequenciaVizinhaAtual[i] = Sequencia[j];
                            SequenciaVizinhaAtual[j] = Sequencia[i];
                            CalcularInstantesInicioFimCadaTarefaEmCadaMaquina(SequenciaVizinhaAtual);
                            if (Makespan < DadosMelhorSequencia.Makespan)
                            {
                                DadosMelhorSequencia.Makespan = Makespan;
                                Movimento[0] = i;
                                Movimento[1] = j;
                                TeveMelhoria = true;
                            }
                        }
                    }
                    int aux = Sequencia[Movimento[0]];
                    Sequencia[Movimento[0]] = Sequencia[Movimento[1]];
                    Sequencia[Movimento[1]] = aux;
                    NumeroAtualIteracoes++;
                }
            }
            

            for (int k=0;k<NumeroTarefas;k++)
            {
                DadosMelhorSequencia.Sequencia[k] = Sequencia[k];
            }
            return DadosMelhorSequencia;
        }
        public DadosSequencia EncontraMelhorSequenciaAleatoria(int NumeroSequencias)
        {
            StreamWriter Escrever = new StreamWriter(@"C:\Teste\saidaFSP.txt");
            Random SementeAleatoria = new Random();
            DadosSequencia DadosMelhorSequencia = new DadosSequencia();
            DadosMelhorSequencia.Makespan = 9999999;
            DadosMelhorSequencia.Sequencia = new int[NumeroTarefas];
            for (int k = 0; k < NumeroSequencias; k++)
            {
                int[] Sequencia = GerarSequenciaAleatoria(SementeAleatoria.Next(0, 100000000));
                for (int i = 0; i < NumeroTarefas; i++)
                {
                    Escrever.Write(Sequencia[i].ToString() + ";");
                }
                CalcularInstantesInicioFimCadaTarefaEmCadaMaquina(Sequencia);
                Escrever.WriteLine(Makespan.ToString());
                if (Makespan < DadosMelhorSequencia.Makespan)
                {
                    DadosMelhorSequencia.Makespan = Makespan;
                    for (int i = 0; i < NumeroTarefas; i++)
                    {
                        DadosMelhorSequencia.Sequencia[i] = Sequencia[i];
                    }
                }
            }
            Escrever.Close();
            Escrever.Dispose();
            return DadosMelhorSequencia;
        }
        public int Maximo(int a, int b)
        {
            int Max;
            Max = b;
            if(a>b)
            {
                Max = a;
            }
            return Max;
        }
        public int[] GerarSequenciaAleatoria(int Semente)
        {
            int[] SequenciaGerada = new int[NumeroTarefas];
            Random Aleatorio = new Random(Semente);
            List<int> Papeizinhos = new List<int>();
            for(int i=0;i<NumeroTarefas;i++)
            {
                Papeizinhos.Add(i);
            }
            int PapeisRestantes = NumeroTarefas;
            for(int i=0;i<NumeroTarefas;i++)
            {
                int papel = Aleatorio.Next(0, PapeisRestantes);
                SequenciaGerada[i] = Papeizinhos[papel];
                Papeizinhos.RemoveAt(papel);
                PapeisRestantes--;
            }
            return SequenciaGerada;
        }
        public int CalcularMaeskpan()
        {
            int Makespan = 0;
            return Makespan;
        }
        public void LerProblema(string Arquivo)
        {
            string[] DadosLidos = File.ReadAllLines(Arquivo);
            NumeroTarefas = int.Parse(DadosLidos[0]);
            NumeroMaquinas = int.Parse(DadosLidos[1]);
            string[] s = DadosLidos[2].Split(';');
            InstantesIniciaisDasMaquinas = new int[NumeroMaquinas];
            for(int j=0; j< NumeroMaquinas;j++)
            {
                InstantesIniciaisDasMaquinas[j] = int.Parse(s[j]);
            }
            MatrizTemposProcessamento = new int[NumeroTarefas, NumeroMaquinas];
            for(int i=0;i<NumeroTarefas;i++)
            {
                s = DadosLidos[3 + i].Split(';');
                for(int j=0;j<NumeroMaquinas;j++)
                {
                    MatrizTemposProcessamento[i, j] = int.Parse(s[j]);
                }
            }
        }
        public Bitmap DesenharSolucaoMaquinasNasLinhas(DadosSequencia SequenciaDesenho)
        { 
            Bitmap Desenho = new Bitmap(600, 400);
            Graphics g = Graphics.FromImage(Desenho);
            Random Aleatorio = new Random(1);
            g.FillRectangle(Brushes.Black, 0, 0, 600, 400);
            g.FillRectangle(Brushes.White, 25, 25, 550, 350);
            Brush[] Pincel = new Brush[NumeroTarefas];
            for(int i=0;i<NumeroTarefas;i++)
            {
                Pincel[i] = new SolidBrush(Color.FromArgb(155, Aleatorio.Next(256), Aleatorio.Next(256), Aleatorio.Next(256)));
            }
            CalcularInstantesInicioFimCadaTarefaEmCadaMaquina(SequenciaDesenho.Sequencia);
            int Altura = 350 / NumeroMaquinas;
            double EscalaLargura = 550 / (double)Makespan;
            for(int i=0;i<NumeroTarefas;i++)
            {
                for(int j=0;j<NumeroMaquinas;j++)
                {
                    Rectangle Retangulo = new Rectangle(25 + (int)(EscalaLargura * MatrizRetorno[i, j]), 25 + Altura * j, (int)(EscalaLargura * (MatrizRetorno[i, j + NumeroMaquinas] - MatrizRetorno[i, j])), Altura);
                    g.FillRectangle(Pincel[i], Retangulo);
                }
            }
            return Desenho;
        }
        public Bitmap DesenharSolucaoTarefasNasLinhas(DadosSequencia SequenciaDesenho)
        {
            Bitmap Desenho = new Bitmap(600, 400);
            Graphics g = Graphics.FromImage(Desenho);
            Random Aleatorio = new Random(1);
            g.FillRectangle(Brushes.White, 0, 0, 600, 400);
            g.FillRectangle(Brushes.Black, 25, 25, 550, 350);
            Brush[] Pincel = new Brush[NumeroMaquinas];
            for (int i = 0; i < NumeroMaquinas; i++)
            {
                Pincel[i] = new SolidBrush(Color.FromArgb(175, Aleatorio.Next(256), Aleatorio.Next(256), Aleatorio.Next(256)));
            }
            CalcularInstantesInicioFimCadaTarefaEmCadaMaquina(SequenciaDesenho.Sequencia);
            double Altura = 350 / (double)NumeroTarefas;
            double EscalaLargura = 550 / (double)Makespan;
            for (int i = 0; i < NumeroTarefas; i++)
            {
                //int TarefaAtual = i;
                int TarefaAtual = SequenciaDesenho.Sequencia[i];
                for (int j = 0; j < NumeroMaquinas; j++)
                {
                    Rectangle Retangulo = new Rectangle(25 + (int)(EscalaLargura*MatrizRetorno[TarefaAtual,j]), 25 + (int)(Altura * i), (int)(EscalaLargura * (MatrizRetorno[TarefaAtual, j + NumeroMaquinas] - MatrizRetorno[TarefaAtual, j])), (int)(Altura));
                    g.FillRectangle(Pincel[j], Retangulo);
                }
            }
            return Desenho;
        }
    }
    class DadosSequencia
    {
        public int[] Sequencia;
        public int Makespan;
    }
}
