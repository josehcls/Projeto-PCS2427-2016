using PCS2427.AF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using PCS2427.MT;
using PCS2427.AP;

namespace PCS2427
{
    class Program
    {
        static void Main(string[] args)
        {
            //TesteOutput();
            //TesteCabecote();
            //MTTesteOutput();
            //APTesteOutput();

            ////TesteAF1
            //var automato = AutomatoFinito.LeituraDispositivo(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\TesteAF1.json");
            //var cabecote = new Cabecote()
            //{
            //    //10101
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaAF1-1.txt")
            //};

            //automato.Simulacao(cabecote);

            //if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            //else Console.WriteLine("\nAutomato REJEITA a cadeia");
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //cabecote = new Cabecote()
            //{
            //    //10
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaAF1-2.txt")
            //};

            //automato.Simulacao(cabecote);

            //if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            //else Console.WriteLine("\nAutomato REJEITA a cadeia");
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //////TesteAF2
            //automato = AutomatoFinito.LeituraDispositivo(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\TesteAF2.json");
            //cabecote = new Cabecote()
            //{
            //    //11011
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaAF2-1.txt")
            //};

            //automato.Simulacao(cabecote);

            //if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            //else Console.WriteLine("\nAutomato REJEITA a cadeia");
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //cabecote = new Cabecote()
            //{
            //    //110
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaAF2-2.txt")
            //};

            //automato.Simulacao(cabecote);

            //if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            //else Console.WriteLine("\nAutomato REJEITA a cadeia");
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //cabecote = new Cabecote()
            //{
            //    //11
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaAF2-3.txt")
            //};

            //automato.Simulacao(cabecote);

            //if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            //else Console.WriteLine("\nAutomato REJEITA a cadeia");
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //////TesteAF3
            //automato = AutomatoFinito.LeituraDispositivo(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\TesteAF3.json");
            //cabecote = new Cabecote()
            //{
            //    //110
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaAF3-1.txt")
            //};

            //automato.Simulacao(cabecote);

            //if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            //else Console.WriteLine("\nAutomato REJEITA a cadeia");
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //cabecote = new Cabecote()
            //{
            //    //10
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaAF3-2.txt")
            //};

            //automato.Simulacao(cabecote);

            //if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            //else Console.WriteLine("\nAutomato REJEITA a cadeia");
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //cabecote = new Cabecote()
            //{
            //    //111
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaAF3-3.txt")
            //};

            //automato.Simulacao(cabecote);

            //if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            //else Console.WriteLine("\nAutomato REJEITA a cadeia");
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            ////TesteMT1
            //MaquinaDeTuring maquina = MaquinaDeTuring.LeituraDispositivo(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\TesteMT1.json");
            //var cabecote = new Cabecote()
            //{
            //    //11
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaMT1-1.txt")
            //};
            //maquina.Simulacao(cabecote);
            //if (cabecote.Aceito && !cabecote.Erro) Console.WriteLine("\nMaquina de Turing ACEITA a cadeia");
            //else Console.WriteLine("\nMaquina de Turing REJEITA a cadeia");
            //Console.WriteLine("Fita Final: " + cabecote.BuscaElementosListaEsquerda());
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //cabecote = new Cabecote()
            //{
            //    //10
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaMT1-2.txt")
            //};
            //maquina.Simulacao(cabecote);
            //if (cabecote.Aceito && !cabecote.Erro) Console.WriteLine("\nMaquina de Turing ACEITA a cadeia");
            //else Console.WriteLine("\nMaquina de Turing REJEITA a cadeia");
            //Console.WriteLine("Fita Final: " + cabecote.BuscaElementosListaEsquerda());
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //cabecote = new Cabecote()
            //{
            //    //111
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaMT1-3.txt")
            //};
            //maquina.Simulacao(cabecote);
            //if (cabecote.Aceito && !cabecote.Erro) Console.WriteLine("\nMaquina de Turing ACEITA a cadeia");
            //else Console.WriteLine("\nMaquina de Turing REJEITA a cadeia");
            //Console.WriteLine("Fita Final: " + cabecote.BuscaElementosListaEsquerda());
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            ////TesteMT2
            //var maquina = MaquinaDeTuring.LeituraDispositivo(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\TesteMT2.json");
            //var cabecote = new Cabecote()
            //{
            //    //0011
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaMT2-1.txt")
            //};
            //maquina.Simulacao(cabecote);
            //if (cabecote.Aceito && !cabecote.Erro) Console.WriteLine("\nMaquina de Turing ACEITA a cadeia");
            //else Console.WriteLine("\nMaquina de Turing REJEITA a cadeia");
            //Console.WriteLine("Fita Final: " + cabecote.BuscaElementosListaEsquerda());
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //cabecote = new Cabecote()
            //{
            //    //001
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaMT2-2.txt")
            //};
            //maquina.Simulacao(cabecote);
            //if (cabecote.Aceito && !cabecote.Erro) Console.WriteLine("\nMaquina de Turing ACEITA a cadeia");
            //else Console.WriteLine("\nMaquina de Turing REJEITA a cadeia");
            //Console.WriteLine("Fita Final: " + cabecote.BuscaElementosListaEsquerda());
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            ////TesteMT3
            //maquina = MaquinaDeTuring.LeituraDispositivo(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\TesteMT3.json");
            //cabecote = new Cabecote()
            //{
            //    //0011
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaMT3-1.txt")
            //};
            //maquina.Simulacao(cabecote);
            //if (cabecote.Aceito && !cabecote.Erro) Console.WriteLine("\nMaquina de Turing ACEITA a cadeia");
            //else Console.WriteLine("\nMaquina de Turing REJEITA a cadeia");
            //Console.WriteLine("Fita Final: " + cabecote.BuscaElementosListaEsquerda());
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //cabecote = new Cabecote()
            //{
            //    //001
            //    Fita = LeituraFita(@"C:\Users\José Henrique\Documents\ProjetoPCS-2427-2016\PCS2427\Arquivos\FitaMT3-2.txt")
            //};
            //maquina.Simulacao(cabecote);
            //if (cabecote.Aceito && !cabecote.Erro) Console.WriteLine("\nMaquina de Turing ACEITA a cadeia");
            //else Console.WriteLine("\nMaquina de Turing REJEITA a cadeia");
            //Console.WriteLine("Fita Final: " + cabecote.BuscaElementosListaEsquerda());
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            ////TesteAP1
            //var automatoPilha = AutomatoPilha.LeituraDispositivo(@"C:\Users\joseh\Source\Repos\PCS2427\PCS2427\Arquivos\TesteAP1.json");
            //var cabecote = new Cabecote()
            //{
            //    //aaaxbb
            //    Fita = LeituraFita(@"C:\Users\joseh\Source\Repos\PCS2427\PCS2427\Arquivos\FitaAP1-1.txt")
            //};

            //automatoPilha.Simulacao(cabecote);

            //if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            //else Console.WriteLine("\nAutomato REJEITA a cadeia");
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //cabecote = new Cabecote()
            //{
            //    //aaabb
            //    Fita = LeituraFita(@"C:\Users\joseh\Source\Repos\PCS2427\PCS2427\Arquivos\FitaAP1-2.txt")
            //};

            //automatoPilha.Simulacao(cabecote);

            //if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            //else Console.WriteLine("\nAutomato REJEITA a cadeia");
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //cabecote = new Cabecote()
            //{
            //    //aax
            //    Fita = LeituraFita(@"C:\Users\joseh\Source\Repos\PCS2427\PCS2427\Arquivos\FitaAP1-3.txt")
            //};

            //automatoPilha.Simulacao(cabecote);

            //if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            //else Console.WriteLine("\nAutomato REJEITA a cadeia");
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            ////TesteAP2
            ///*var */ automatoPilha = AutomatoPilha.LeituraDispositivo(@"C:\Users\joseh\Source\Repos\PCS2427\PCS2427\Arquivos\TesteAP2.json");
            ///*var */ cabecote = new Cabecote()
            //{
            //    //aaaxbbb
            //    Fita = LeituraFita(@"C:\Users\joseh\Source\Repos\PCS2427\PCS2427\Arquivos\FitaAP2-1.txt")
            //};

            //automatoPilha.Simulacao(cabecote);

            //if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            //else Console.WriteLine("\nAutomato REJEITA a cadeia");
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //cabecote = new Cabecote()
            //{
            //    //aaaxbb
            //    Fita = LeituraFita(@"C:\Users\joseh\Source\Repos\PCS2427\PCS2427\Arquivos\FitaAP2-2.txt")
            //};

            //automatoPilha.Simulacao(cabecote);

            //if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            //else Console.WriteLine("\nAutomato REJEITA a cadeia");
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //cabecote = new Cabecote()
            //{
            //    //aabb
            //    Fita = LeituraFita(@"C:\Users\joseh\Source\Repos\PCS2427\PCS2427\Arquivos\FitaAP2-3.txt")
            //};

            //automatoPilha.Simulacao(cabecote);

            //if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            //else Console.WriteLine("\nAutomato REJEITA a cadeia");
            //Console.ReadLine();
            //Console.WriteLine("------------------------------------\n");

            //TesteAP3
            var automatoPilha = AutomatoPilha.LeituraDispositivo(@"C:\Users\joseh\Source\Repos\PCS2427\PCS2427\Arquivos\TesteAP3.json");
            var cabecote = new Cabecote()
            {
                //aaxybb
                Fita = LeituraFita(@"C:\Users\joseh\Source\Repos\PCS2427\PCS2427\Arquivos\FitaAP3-1.txt")
            };

            automatoPilha.Simulacao(cabecote);

            if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            else Console.WriteLine("\nAutomato REJEITA a cadeia");
            Console.ReadLine();
            Console.WriteLine("------------------------------------\n");

            cabecote = new Cabecote()
            {
                //xxyy
                Fita = LeituraFita(@"C:\Users\joseh\Source\Repos\PCS2427\PCS2427\Arquivos\FitaAP3-2.txt")
            };

            automatoPilha.Simulacao(cabecote);

            if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            else Console.WriteLine("\nAutomato REJEITA a cadeia");
            Console.ReadLine();
            Console.WriteLine("------------------------------------\n");

            cabecote = new Cabecote()
            {
                //axxyy
                Fita = LeituraFita(@"C:\Users\joseh\Source\Repos\PCS2427\PCS2427\Arquivos\FitaAP3-3.txt")
            };

            automatoPilha.Simulacao(cabecote);

            if (cabecote.Aceito) Console.WriteLine("\nAutomato ACEITA a cadeia");
            else Console.WriteLine("\nAutomato REJEITA a cadeia");
            Console.ReadLine();
            Console.WriteLine("------------------------------------\n");
        }

        static void AFTesteOutput()
        {
            var transicao1 = new Transicao()
            {
                Origem = "q0",
                Simbolo = 'a',
                Destino = "q1"
            };

            var transicao2 = new Transicao()
            {
                Origem = "q1",
                Simbolo = 'b',
                Destino = "q1"
            };

            var automato = new AutomatoFinito()
            {
                Estados = new List<string>() { "q0", "q1" },
                Simbolos = "ab",
                EstadoInicial = "q0",
                Transicoes = new List<Transicao>() { transicao1, transicao2 },
                EstadosFinais = new List<string>() { "q1" }
            };

            var json = JsonConvert.SerializeObject(automato);
            Console.WriteLine(json);
        }

        static void AFTesteCabecote()
        {
            char[] entrada = { 'a', 'b', 'a', 'a' };

            var cabecote = new Cabecote()
            {
                Fita = new LinkedList<char>(entrada),
            };
            cabecote.PosicaoAtual = cabecote.Fita.First;

            Console.WriteLine(cabecote.PosicaoAtual.Value);
            Console.WriteLine(cabecote.PosicaoAtual.Next.Value);
        }

        static LinkedList<char> LeituraFita(string path)
        {
            //var entrada = System.IO.File.ReadAllText("C:\\Users\\José Henrique\\Documents\\ProjetoPCS-2427-2016\\fita.txt");
            //var entrada = System.IO.File.ReadAllText("C:\\Users\\joseh\\OneDrive\\Documentos\\GitHub\\projetopcs-2427-2016\\fita.txt");
            var entrada = System.IO.File.ReadAllText(path);
            //Console.WriteLine(json);

            var fita = new LinkedList<char>(entrada);

            return fita;
        }


        static void MTTesteOutput()
        {
            var transicao1 = new TransicaoMT()
            {
                Origem = "q0",
                Simbolo = '1',
                Destino = "q1",
                Gravacao = '1',
                Direcao = EnumDirecao.Right
            };

            var transicao2 = new TransicaoMT()
            {
                Origem = "q1",
                Simbolo = '0',
                Destino = "q2",
                Gravacao = '0',
                Direcao = EnumDirecao.Right
            };

            var transicao3 = new TransicaoMT()
            {
                Origem = "q1",
                Simbolo = '1',
                Destino = "q0",
                Gravacao = '1',
                Direcao = EnumDirecao.Right
            };

            var transicao4 = new TransicaoMT()
            {
                Origem = "q1",
                Simbolo = '#',
                Destino = "h",
                Gravacao = '#',
                Direcao = EnumDirecao.Right
            };

            var turing = new MaquinaDeTuring()
            {
                Estados = new List<string>() { "q0", "q1" },
                Simbolos = "10",
                ConjuntoSimbolos = "10#",
                TransicoesMT = new List<TransicaoMT>() { transicao1, transicao2, transicao3, transicao4 },
                EstadoInicial = "q0",
                SimboloBranco = '#',
                EstadosFinais = new List<string>() { "q1" }
            };

            var json = JsonConvert.SerializeObject(turing);
            Console.WriteLine(json);
        }

        static void APTesteOutput()
        {
            var transicao1 = new TransicaoAP()
            {
                Origem = "q1",
                Simbolo = 'a',
                Destino = "q2",
                EstadoRetorno = null,
                SubMaquinaChamada = null,
                Acao = null,
            };

            var transicao2 = new TransicaoAP()
            {
                Origem = "q1",
                Simbolo = 'x',
                Destino = "q2",
                EstadoRetorno = null,
                SubMaquinaChamada = null,
                Acao = null,
            };

            var transicao3 = new TransicaoAP()
            {
                Origem = "q2",
                Simbolo = 'b',
                Destino = "q2",
                EstadoRetorno = null,
                SubMaquinaChamada = null,
                Acao = null,
            };

            var automatoPilha = new AutomatoPilha()
            {
                Estados = new List<string>() { "q1", "q2" },
                Submaquinas = new List<string>() { "a1" },
                Simbolos = "abx",
                SimbolosPilha = new List<string>() { "@" },
                TransicoesAP = new List<TransicaoAP>() { transicao1, transicao2, transicao3 },
                MarcadorPilhaVazia = "@",
                EstadoInicial = "q1",
                EstadosFinais = new List<string>() { "q2" }
            };

            var json = JsonConvert.SerializeObject(automatoPilha);
            Console.WriteLine(json);
        }
    }
}
