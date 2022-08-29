using System;

namespace JogoDaPrincesa
{
    public class Program
    {
        static void Main(string[] args)
        {
            Candidato[] candidatos = new Candidato[7];
            bool entrada = true;
            bool perguntas = true;
            int contador = 0;
            int escolher = 0;
            int opcao = 0;
            int pgt = 0;
            Funcoes funcao = new Funcoes();
            while (entrada == true)
            {
                Console.Clear();
                Console.WriteLine("Bem vindo ao jogo da princesa");
                Console.WriteLine("Insira 1 para jogar");
                Console.WriteLine("Insira 2 para saber as regras do jogo");
                Console.WriteLine("Insira 0 para sair");
                escolher = int.Parse(Console.ReadLine());
                if (escolher == 1)
                {  
                    int[] resultado = new int[7];

                    resultado = funcao.PreencherTipos();
                    candidatos = funcao.PreencherCandidatos(resultado);
                    
                    Console.Clear();
                    while (perguntas)
                    {
                        if(contador < 7)
                        {
                            Console.Clear();
                            Console.WriteLine("Olá principe, temos aqui 6 candidatas, porém somente uma é a real princesa, para descobrir qual é faça uma pergunta para cada uma e deduza por si mesmo");
                            Console.WriteLine("Insira o número da candidata que deseja fazer a pergunta: \n");
                            foreach (var candidato in candidatos)
                            {
                                Console.WriteLine(candidato.nome);
                                if (candidato.pergunta1)
                                {
                                    Console.WriteLine(candidato.resposta1);
                                }
                                if (candidato.pergunta2)
                                {
                                    Console.WriteLine(candidato.resposta2);
                                }
                                Console.WriteLine();
                            }

                            opcao = int.Parse(Console.ReadLine());
                            Console.Clear();

                            if (candidatos[opcao - 1].pergunta1)
                            {
                                Console.Clear();
                                Console.WriteLine("Você já perguntou para esse candidato, por favor pergunte á outro");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Agora insira o número de acordo com a pergunta que queira fazer para a candidata " + opcao + ":");
                                Console.WriteLine("1 - Quem é você?");
                                Console.WriteLine("2 - Quem é ela?");
                                Console.WriteLine("3 - Onde está a princesa?");
                                pgt = int.Parse(Console.ReadLine());

                                candidatos[opcao - 1].resposta1 = funcao.perguntas(pgt, candidatos[opcao - 1], candidatos);
                                candidatos[opcao - 1].pergunta1 = true;
                                contador++;

                                Console.Clear();
                            }
                        }
                        else
                        {
                            
                            Console.Clear();
                            Console.WriteLine("ATENÇÃO!!! Você já perguntou para todas as candidatas e ganhou o direito de uma pergunta bônus!");
                            Console.WriteLine("Insira o número da candidata que deseja fazer a pergunta bônus: \n");
                            foreach (var candidato in candidatos)
                            {
                                Console.WriteLine(candidato.nome);
                                if (candidato.pergunta1)
                                {
                                    Console.WriteLine(candidato.resposta1);
                                }
                                if (candidato.pergunta2)
                                {
                                    Console.WriteLine(candidato.resposta2);
                                }
                                Console.WriteLine();
                            }

                            opcao = int.Parse(Console.ReadLine());
                            Console.Clear();

                            Console.WriteLine("Agora insira o número de acordo com a pergunta que queira fazer para a candidata " + opcao + ":");
                            Console.WriteLine("1 - Quem é você?");
                            Console.WriteLine("2 - Quem é ela?");
                            Console.WriteLine("3 - Onde está a princesa?");
                            pgt = int.Parse(Console.ReadLine());

                            candidatos[opcao - 1].resposta2 = funcao.perguntas(pgt, candidatos[opcao - 1], candidatos);
                            candidatos[opcao - 1].pergunta2 = true;
                            perguntas = false;

                            Console.Clear();
                            
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Agora é a hora da verdade, com base nas respostas escolha a candidata com quem irá se casar: \n");
                    foreach (var candidato in candidatos)
                    {
                        Console.WriteLine(candidato.nome);
                        if (candidato.pergunta1)
                        {
                            Console.WriteLine(candidato.resposta1);
                        }
                        if (candidato.pergunta2)
                        {
                            Console.WriteLine(candidato.resposta2);
                        }
                        Console.WriteLine();
                    }

                    opcao = int.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("Parabéns principe, você se casou com " + candidatos[opcao - 1].nomeReal);
                    Console.ReadLine();
                    contador = 0;
                    perguntas = true;
                }
                else if (escolher == 2)
                {

                }
                else if (escolher == 0)
                    {
                    entrada = false;
                }
                else
                {
                    Console.WriteLine("Essa opção não existe.");
                }
            }
        }
    }
}
