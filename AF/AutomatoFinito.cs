using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCS2427.AF
{
    public class AutomatoFinito
    {
        public List<string> Estados { get; set; }
        public string Simbolos { get; set; }
        public string EstadoInicial { get; set; }
        public List<Transicao> Transicoes { get; set; }
        public List<string> EstadosFinais { get; set; }

        #region Funções
        public static AutomatoFinito LeituraDispositivo(string path)
        {
            //var json = System.IO.File.ReadAllText("C:\\Users\\José Henrique\\Documents\\ProjetoPCS-2427-2016\\af2.json");
            //var json = System.IO.File.ReadAllText("C:\\Users\\joseh\\OneDrive\\Documentos\\GitHub\\projetopcs-2427-2016\\af2.json");
            var json = System.IO.File.ReadAllText(path);
            //Console.WriteLine(json);

            AutomatoFinito automato = JsonConvert.DeserializeObject<AutomatoFinito>(json);

            return automato;
        }

        /// <summary>
        /// Método recursivo que excecuta um passo da simulação do Autômato Finito.
        /// Desse modo, cada recursão corresponde a um novo passo na excecução.
        /// </summary>
        /// <param name="automato"> Automato Finito sendo simulado </param>
        /// <param name="cabecote"> Cabeçote, que contem informações sobre a fita de entrada e estado atual do Autômato </param>
        public void Simulacao(Cabecote cabecote)
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
                Console.WriteLine(cabecote.ImprimeFita() + "\n");
                // Leitura do Simbolo
                var simbolo = cabecote.PosicaoAtual.Value;
                Console.WriteLine("Leitura do Símbolo '{0}'", simbolo);

                // Caso de Fim da Fita e Estado Final
                if (simbolo == '#' && ConfereEstadoFinal(cabecote))
                {
                    Console.WriteLine("#### Fim da Fita");
                    Console.WriteLine("#### Estado {0} é final", cabecote.EstadoAtual);
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
                        // Procura transições válidas
                        var estadoAtual = cabecote.EstadoAtual;
                        var transicoes = BuscaTransicoes(estadoAtual, simbolo);
                        // Salva posição atual para o caso de mais de uma transição
                        var posicao = cabecote.PosicaoAtual;
                        Console.WriteLine("Foi(ram) encontada(s) {0} transição(ões)", transicoes.Count.ToString());
                        // Caso sem transições possíveis
                        if (!transicoes.Any())
                        {
                            Console.WriteLine("##### Nenhuma transição encontrada");
                            if (simbolo == '#')
                            {
                                Console.WriteLine("#### Fim da Fita");
                                // Confere se esta em um estado final
                                if (ConfereEstadoFinal(cabecote))
                                {
                                    Console.WriteLine("#### Estado {0} é final", cabecote.EstadoAtual);
                                    cabecote.Aceito = true;
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
                                    // Volta posição para o caso de mais de uma transição
                                    cabecote.PosicaoAtual = posicao;
                                    Console.WriteLine("Transição: {0} -> {1} : símbolo = '{2}'", transicao.Origem, transicao.Destino, transicao.Simbolo);
                                    // Realiza transição
                                    RealizaTransicao(cabecote, transicao);
                                    // Move Cabeçote para a Direita, caso a transição não tenha sido em vazio
                                    if (transicao.Simbolo != ' ') cabecote.MoveParaDireita();
                                    // Chama próximo passo da Simulação
                                    Simulacao(cabecote);
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
        }

        List<Transicao> BuscaTransicoes(string estadoAtual, char simbolo)
        {
            var transicoes = new List<Transicao>();

            transicoes = Transicoes.Where(t => t.Origem == estadoAtual
                                                  && (t.Simbolo == simbolo || t.Simbolo == ' ')
                                              ).ToList();

            return transicoes;
        }

        bool ConfereEstadoFinal(Cabecote cabecote)
        {
            return EstadosFinais.Contains(cabecote.EstadoAtual);
        }

        static void RealizaTransicao(Cabecote cabecote, Transicao transicao)
        {
            cabecote.EstadoAtual = transicao.Destino;
        }        
        #endregion
    }

    public class Transicao
    {
        public virtual string Origem { get; set; }
        public virtual char Simbolo { get; set; }
        public virtual string Destino { get; set; }
    }
}
