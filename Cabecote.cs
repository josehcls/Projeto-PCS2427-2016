using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS2427.AF
{
    public class Cabecote
    {
        // Lista Ligada que representa a Fita
        public LinkedList<char> Fita { get; set; }
        // Nó da Lista Ligada que representa a Posição Atual
        public LinkedListNode<char> PosicaoAtual { get; set; }
        // Armazena Estado Atual de Simulação (Para todas as Classes de Autômato)
        public string EstadoAtual { get; set; }
        // Armazena se o Autômato aceitou ou recusou a Cadeia de Entrada
        public bool Aceito { get; set; }
        public bool Erro { get; set; }

        // Pilha usada no Autômato de Pilha
        public Stack<ControlePilha> Pilha { get; set; }
        // Submáquina Atual do Autômato de Pilha
        public string SubmaquinaAtual { get; set; }

        #region Funções

        public Cabecote()
        {
            Aceito = false;
            Erro = false;
        }

        public void MoveParaDireita()
        {
            PosicaoAtual = PosicaoAtual.Next;
        }

        public void AdiconaBrancoFinal(char branco)
        {
            Fita.AddLast(branco);
            PosicaoAtual = Fita.Last;
        }

        public void MoveParaEsquerda()
        {
            PosicaoAtual = PosicaoAtual.Previous;
        }

        public void GravaSimbolo(char simbolo)
        {
            PosicaoAtual.Value = simbolo;
        }

        public string BuscaElementosListaDireita()
        {
            var no = this.PosicaoAtual.Next;
            var elementos = "";
                        
            while (no != null)
            {
                elementos += no.Value;
                no = no.Next;
            }
            if (elementos.Length == 0) elementos = "#";

            return elementos;
        }

        public string BuscaElementosListaEsquerda()
        {
            var no = this.PosicaoAtual.Previous;
            var elementos = "";

            while (no != null)
            {
                elementos += no.Value;
                no = no.Previous;
            }
            if (elementos.Length == 0) elementos = "#";
            else if (elementos.Length > 1) elementos = Reverse(elementos);
            
            return elementos;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public string ImprimeFita()
        {
            return
                "Fita: ("
                + this.BuscaElementosListaEsquerda()
                + ", "
                + this.PosicaoAtual.Value
                + ", "
                + this.BuscaElementosListaDireita()
                + ")";
        }

        public string ImprimePilha()
        {
            return
                "Pilha: ("
                + this.BuscaElementosPilha()
                + ")";
        }

        public string BuscaElementosPilha()
        {
            var pilhaArray = this.Pilha.Select(p =>p.Retorno).ToArray().Reverse();
            var elementos = "";
            foreach (var item in pilhaArray)
            {
                elementos += item + ",";
            }
            elementos = elementos.Remove(elementos.Length - 1);

            return elementos;
        }

        #endregion
    }

    public class ControlePilha
    {
        public string Submaquina { get; set; }
        public string Retorno { get; set; }
    }
}
