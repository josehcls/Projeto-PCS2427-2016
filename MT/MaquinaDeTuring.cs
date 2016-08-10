using Newtonsoft.Json;
using PCS2427.AF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS2427.MT
{
    public class MaquinaDeTuring : AutomatoFinito
    {
        //public List<string> Estados { get; set; }
        //public string Simbolos { get; set; }
        public string ConjuntoSimbolos { get; set; }
        [JsonProperty("Transicoes")]
        public List<TransicaoMT> TransicoesMT { get; set; }
        //public string EstadoInicial { get; set; }
        public char SimboloBranco { get; set; }
        //[JsonProperty("Halt")]
        //public List<string> EstadosFinais { get; set; }

        #region Funções
        public new static MaquinaDeTuring LeituraDispositivo(string path)
        {
            //var json = System.IO.File.ReadAllText("C:\\Users\\José Henrique\\Documents\\ProjetoPCS-2427-2016\\mt.json");
            //var json = System.IO.File.ReadAllText("C:\\Users\\joseh\\OneDrive\\Documentos\\GitHub\\projetopcs-2427-2016\\af2.json");
            var json = System.IO.File.ReadAllText(path);
            //Console.WriteLine(json);

            MaquinaDeTuring turing = JsonConvert.DeserializeObject<MaquinaDeTuring>(json);

            return turing;
        }

        /// <summary>
        /// Método recursivo que excecuta um passo da simulação da Maquina de Turing.
        /// Desse modo, cada recursão corresponde a um novo passo na excecução.
        /// </summary>
        /// <param name="cabecote"> Cabeçote, que contem informações sobre a fita de entrada e estado atual do Autômato </param>
        public new void Simulacao(Cabecote cabecote)
        {
            //// Caso em que a Máquina foi Aceita ou Parada foi acionada
            //if (cabecote.Aceito) return;
            //else
            //{
            // Caso Partida Inicial?
            if (cabecote.EstadoAtual == null)
            {
                Console.WriteLine("Partida Inicial");
                PartidaInicial(cabecote);
                Simulacao(cabecote);
            }
            else
            {
                Console.WriteLine(cabecote.ImprimeFita() + "\n");
                // Confere se MT se encontra em Estado de Halt
                if (ConfereEstadoFinal(cabecote))
                {                    
                    Console.WriteLine("#### Estado de Halt: {0}", cabecote.EstadoAtual);
                    cabecote.Aceito = true;                    
                }
                else                
                {
                    // Leitura do Simbolo
                    var simbolo = cabecote.PosicaoAtual.Value;
                    Console.WriteLine("Leitura do Símbolo '{0}'", simbolo);

                    // Checa se símbolo é válido
                    if (!ConjuntoSimbolos.Contains(simbolo))
                    {
                        Console.WriteLine("#### Símbolo de entrada inválido");
                        //cabecote.Halt = true; ///
                    }
                    else
                    {
                        //Console.WriteLine("Símbolo Válido");
                        // Procura transições válidas
                        var estadoAtual = cabecote.EstadoAtual;
                        var transicoes = BuscaTransicoes(estadoAtual, simbolo);
                        // Salva posição atual e estado atual da fita para o caso de mais de uma transição
                        var fita = cabecote.Fita;
                        var posicao = cabecote.PosicaoAtual;
                        
                        Console.WriteLine("Foi(ram) encontada(s) {0} transição(ões)", transicoes.Count.ToString());

                        // Caso sem transições possíveis
                        if (!transicoes.Any())
                        {
                            Console.WriteLine("##### Nenhuma transição encontrada");
                            //cabecote.Halt = true;
                        }
                        else
                        {
                            foreach (var transicao in transicoes)
                            {
                                // Ignora transição caso a entrada já tenha sido aceita
                                if (!cabecote.Aceito)
                                {
                                    // Volta posição para o caso de mais de uma transição
                                    cabecote.Fita = fita;
                                    cabecote.PosicaoAtual = posicao;
                                    
                                    Console.WriteLine("Transição: {0} -> {1} : símbolo = '{2}'", transicao.Origem, transicao.Destino, transicao.Simbolo);
                                    Console.WriteLine("Grava: {0}, Deslocamento: {1}", transicao.Gravacao, transicao.Direcao);
                                    // Realiza transição de Estado e Grava Símbolo na Fita
                                    RealizaTransicao(cabecote, transicao);

                                    // Move Caceçote:
                                    if (transicao.Direcao == EnumDirecao.Right)
                                    {
                                        cabecote.MoveParaDireita();
                                        // Se passou o final da fita, considera mais um espaço na fita
                                        if (cabecote.PosicaoAtual == null)
                                        {
                                            cabecote.AdiconaBrancoFinal(SimboloBranco);
                                        }
                                    }
                                    else if (transicao.Direcao == EnumDirecao.Left)
                                    {
                                        cabecote.MoveParaEsquerda();
                                        // Se passou o início da fita, encerra
                                        if (cabecote.PosicaoAtual == null)
                                        {
                                            Console.WriteLine("##### Tentativa de deslocar antes do início da fita");
                                            cabecote.Aceito = true;
                                            cabecote.Erro = true;
                                        }
                                    }
                                    // Chama próximo passo da Simulação
                                    if (!cabecote.Aceito) Simulacao(cabecote);
                                }
                            }
                        }
                    }
                }
            }
            //}
        }

        void PartidaInicial(Cabecote cabecote)
        {
            cabecote.PosicaoAtual = cabecote.Fita.First;
            cabecote.EstadoAtual = EstadoInicial;
        }

        List<TransicaoMT> BuscaTransicoes(string estadoAtual, char simbolo)
        {
            var transicoes = new List<TransicaoMT>();

            transicoes = TransicoesMT.Where(t => t.Origem == estadoAtual
                                                  && (t.Simbolo == simbolo)
                                              ).ToList();

            return transicoes;
        }

        bool ConfereEstadoFinal(Cabecote cabecote)
        {
            return EstadosFinais.Contains(cabecote.EstadoAtual);
        }

        static void RealizaTransicao(Cabecote cabecote, TransicaoMT transicao)
        {
            cabecote.EstadoAtual = transicao.Destino;
            cabecote.GravaSimbolo(transicao.Gravacao);          
        }
        #endregion
    }

    public class TransicaoMT : Transicao
    {
        //public string Origem { get; set; }
        //public char Simbolo { get; set; }
        //public string Destino { get; set; }
        public char Gravacao { get; set; }
        public EnumDirecao Direcao { get; set; }
    }

    public enum EnumDirecao
    {
        Right = 1,
        Left = -1
    }
}
