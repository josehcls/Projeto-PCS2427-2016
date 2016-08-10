using Newtonsoft.Json;
using PCS2427.AF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS2427.AP
{
    class AutomatoPilha : AutomatoFinito
    {
        //public List<string> Estados { get; set; }
        public List<string> Submaquinas { get; set; }
        //public string Simbolos { get; set; }
        public List<string> SimbolosPilha { get; set; }
        [JsonProperty("Transicoes")]
        public new List<TransicaoAP> TransicoesAP { get; set; }
        public string MarcadorPilhaVazia { get; set; }
        //public string EstadoInicial { get; set; }
        //public List<string> EstadosFinais { get; set; }       

        #region Funções
        public new static AutomatoPilha LeituraDispositivo(string path)
        {
            //var json = System.IO.File.ReadAllText("C:\\Users\\José Henrique\\Documents\\ProjetoPCS-2427-2016\\af2.json");
            //var json = System.IO.File.ReadAllText("C:\\Users\\joseh\\OneDrive\\Documentos\\GitHub\\projetopcs-2427-2016\\af2.json");
            var json = System.IO.File.ReadAllText(path);
            //Console.WriteLine(json);

            AutomatoPilha automato = JsonConvert.DeserializeObject<AutomatoPilha>(json);

            return automato;
        }

        /// <summary>
        /// Método recursivo que excecuta um passo da simulação do Autômato Finito.
        /// Desse modo, cada recursão corresponde a um novo passo na excecução.
        /// </summary>
        /// <param name="automato"> Automato Finito sendo simulado </param>
        /// <param name="cabecote"> Cabeçote, que contem informações sobre a fita de entrada e estado atual do Autômato </param>
        public new void Simulacao(Cabecote cabecote)
        {
            // Caso Partida Inicial
            if (cabecote.EstadoAtual == null)
            {
                Console.WriteLine("Partida Inicial");
                PartidaInicial(cabecote);
                Simulacao(cabecote);
            }
            else
            {
                Console.WriteLine("\nSubmáquina Atual: {0}", cabecote.SubmaquinaAtual);
                Console.WriteLine(cabecote.ImprimeFita());
                Console.WriteLine(cabecote.ImprimePilha());

                // Leitura do Simbolo
                var simbolo = cabecote.PosicaoAtual.Value;
                Console.WriteLine("Leitura do Símbolo '{0}'", simbolo);

                // Caso de Fim da Fita, Estado Final e Pilha Vazia
                if (simbolo == '#' && ConfereEstadoFinal(cabecote) && ConferePilhaVazia(cabecote))
                {
                    Console.WriteLine("#### Fim da Fita");
                    Console.WriteLine("#### Estado {0} é final e Pilha está Vazia", cabecote.EstadoAtual);
                    cabecote.Aceito = true;
                }
                else
                {
                    // Checa se símbolo é válido
                    if (!Simbolos.Contains(simbolo) && simbolo != '#')
                    {
                        Console.WriteLine("#### Símbolo de entrada inválido");
                    }
                    else
                    {
                        // Salva posição, estado, submáquina e pilha atuais para o caso de mais de uma transição
                        var posicao = cabecote.PosicaoAtual;
                        var estadoAtual = cabecote.EstadoAtual;
                        var submaquina = cabecote.SubmaquinaAtual;
                        var pilha = cabecote.Pilha;

                        // Procura transições válidas
                        var transicoes = BuscaTransicoes(estadoAtual, simbolo);

                        Console.WriteLine("Foi(ram) encontada(s) {0} transição(ões)", transicoes.Count.ToString());
                        // Caso sem transições possíveis
                        if (!transicoes.Any())
                        {
                            Console.WriteLine("##### Nenhuma transição encontrada");
                            if (simbolo == '#')
                            {
                                Console.WriteLine("#### Fim da Fita");
                                // Confere se esta em um estado final e pilha está vazia
                                if (ConfereEstadoFinal(cabecote) && ConferePilhaVazia(cabecote))
                                {
                                    Console.WriteLine("#### Estado {0} é final e Pilha está vazia", cabecote.EstadoAtual);
                                    cabecote.Aceito = true;
                                }
                                else if (ConfereEstadoFinal(cabecote))
                                {
                                    Console.WriteLine("#### Estado {0} é final mas Pilha não está vazia", cabecote.EstadoAtual);                                
                                }                                
                                else
                                {
                                    Console.WriteLine("#### Estado {0} não é final", cabecote.EstadoAtual);
                                }
                            }

                        }                  
                        else
                        {
                            foreach (var transicao in transicoes)
                            {
                                // Ignora transição caso a entrada já tenha sido aceita
                                if (!cabecote.Aceito)
                                {
                                    // Volta posição, estado, submáquina e pilha para o caso de mais de uma transição
                                    cabecote.PosicaoAtual = posicao;
                                    cabecote.EstadoAtual = estadoAtual;
                                    cabecote.SubmaquinaAtual = submaquina;
                                    cabecote.Pilha = pilha;
                                    
                                    // Caso Chamada de Submáquina
                                    if (transicao.Acao == EnumAcao.Chamada)
                                    {
                                        Console.WriteLine("Chamada de Submáquina: Estados {0} -> {1} : Empilha {2}", transicao.Origem, transicao.Destino, transicao.EstadoRetorno);
                                        // Realiza a chamada de Submáquina
                                        RealizaChamadaSubmaquina(cabecote, transicao);                                        
                                        // Chama próximo passo da Simulação
                                        Simulacao(cabecote);
                                    }
                                    // Caso Chamada de Submáquina
                                    else if (transicao.Acao == EnumAcao.Retorno)
                                    {
                                        Console.WriteLine("Retorno de Submáquina: Estados {0} -> {1} : Desempilha {2}", transicao.Origem, cabecote.Pilha.Peek().Retorno, cabecote.Pilha.Peek().Retorno) ;
                                        // Realiza o retorno de Submáquina
                                        RealizaRetornoSubmaquina(cabecote, transicao);
                                        // Chama próximo passo da Simulação
                                        Simulacao(cabecote);
                                    }
                                    // Caso Transição interna
                                    else
                                    {
                                        Console.WriteLine("Transição Interna: {0} -> {1} : símbolo = '{2}'", transicao.Origem, transicao.Destino, transicao.SimboloAP);
                                        // Realiza transição
                                        RealizaTransicaoInterna(cabecote, transicao);
                                        // Move Cabeçote para a Direita, caso a transição não tenha sido em vazio
                                        if (transicao.SimboloAP != ' ') cabecote.MoveParaDireita();
                                        // Chama próximo passo da Simulação
                                        Simulacao(cabecote);
                                    }                                
                                }
                            }
                        }
                    }
                }
            }
        }

        void PartidaInicial(Cabecote cabecote)
        {
            cabecote.PosicaoAtual = cabecote.Fita.First;
            cabecote.EstadoAtual = EstadoInicial;
            cabecote.SubmaquinaAtual = Submaquinas.First();
            cabecote.Pilha = new Stack<ControlePilha>();
            cabecote.Pilha.Push(new ControlePilha() { Submaquina = Submaquinas.First(), Retorno = MarcadorPilhaVazia });
        }

        List<TransicaoAP> BuscaTransicoes(string estadoAtual, char simbolo)
        {
            var transicoes = new List<TransicaoAP>();

            // Transicoes Internas
            transicoes.AddRange(TransicoesAP.Where(t => t.Origem == estadoAtual
                                                  && (t.SimboloAP == simbolo || t.SimboloAP == ' ')
                                              ).ToList());
            // Transicoes entre Submáquinas
            transicoes.AddRange(TransicoesAP.Where(t => t.Origem == estadoAtual
                                                  && t.Acao != null).ToList());

            return transicoes;
        }

        bool ConfereEstadoFinal(Cabecote cabecote)
        {
            return EstadosFinais.Contains(cabecote.EstadoAtual);
        }

        bool ConferePilhaVazia(Cabecote cabecote)
        {
            // Apenas o Marcador de Pilha Vazia
            return cabecote.Pilha.Count == 1 && cabecote.Pilha.Select(p => p.Retorno).SingleOrDefault() == MarcadorPilhaVazia;
        }

        static void RealizaTransicaoInterna(Cabecote cabecote, TransicaoAP transicao)
        {
            cabecote.EstadoAtual = transicao.Destino;
        }

        static void RealizaChamadaSubmaquina (Cabecote cabecote, TransicaoAP transicao)
        {
            cabecote.EstadoAtual = transicao.Destino;            
            cabecote.Pilha.Push(new ControlePilha() { Submaquina = cabecote.SubmaquinaAtual , Retorno = transicao.EstadoRetorno });
            cabecote.SubmaquinaAtual = transicao.SubMaquinaChamada;
        }

        static void RealizaRetornoSubmaquina (Cabecote cabecote, TransicaoAP transicao)
        {
            ControlePilha controle = cabecote.Pilha.Pop();
            cabecote.EstadoAtual = controle.Retorno;
            cabecote.SubmaquinaAtual = controle.Submaquina;
        }

        #endregion
    }
    //public class Submaquina
    //{
    //    public string Id { get; set; }
    //    public List<string> Estados { get; set; }
    //    public string Simbolos { get; set; }
    //    public List<Transicao> Transicoes { get; set; }
    //    public string EstadoInicial { get; set; }
    //    public List<string> EstadosFinais { get; set; }
    //}

    public class TransicaoAP : Transicao
    {
        //public string Origem { get; set; }
        [JsonProperty("Simbolo")]
        public char? SimboloAP { get; set; }

        //public string Destino { get; set; }
        public string EstadoRetorno { get; set; }
        public string SubMaquinaChamada { get; set; }
        public EnumAcao? Acao { get; set; }
    }

    public enum EnumAcao
    {
        Chamada = 1,
        Retorno = -1
    }
}