using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaPrincesa
{
    public class Funcoes
    {
        public string perguntas(int NrPergunta, Candidato candidato, Candidato[] candidatos)
        {
                string resposta;
                switch (NrPergunta)
                {
                    case 1:
                        resposta = "Quem é você? " + pergunta1(candidato, candidatos);
                        break;
                    case 2:
                        resposta = "Quem é ela? " + pergunta2(candidato, candidatos);
                        break;
                    default:
                        resposta = "Onde está a princesa? " + pergunta3(candidato, candidatos);
                        break;
                }
                return resposta;
        }

        public string pergunta1(Candidato candidato, Candidato[] candidatos)
        {
            string resposta = "";
            if (candidato.decisao)
            {
                resposta = candidato.nomeReal;
            }
            else
            {
                Ini:
                Random rnd = new Random();
                int verificador = rnd.Next(1, 7);
                if(verificador != candidato.numero)
                {
                    foreach(var i in candidatos)
                    {
                        if(verificador == i.numero)
                        {
                            resposta = i.nomeReal;
                        }
                    }
                }
                else
                {
                    goto Ini;
                }
            }
            return resposta;
        }

        public string pergunta2(Candidato candidato, Candidato[] candidatos)
        {
            string resposta = "";
            Console.Clear();
            Console.WriteLine("Quem é ela?");
            foreach(var cand in candidatos)
            {
                if(cand.numero != candidato.numero)
                {
                    Console.WriteLine(cand.nome);
                }
            }
            int escolha = int.Parse(Console.ReadLine());

            if (candidato.decisao)
            {
                resposta = "A " + candidatos[escolha - 1].nome + " é " + candidatos[escolha - 1].nomeReal;
            }
            else
            {
            Ini:
                Random rnd = new Random();
                int verificador = rnd.Next(1, 7);
                if (verificador != candidatos[escolha - 1].numero)
                {
                    foreach (var i in candidatos)
                    {
                        if (verificador == i.numero)
                        {
                            resposta = "A " + candidatos[escolha - 1].nome + " é " + i.nomeReal;
                        }
                    }
                }
                else
                {
                    goto Ini;
                }
            }
            return resposta;
        }

        public string pergunta3(Candidato candidato, Candidato[] candidatos)
        {
            string resposta = "";
            Candidato princesa = new Candidato();
            foreach(var i in candidatos)
            {
                if(i.tipo == 1)
                {
                    princesa = i;
                }
            }
            if (candidato.decisao)
            {
                resposta = "A princesa é a " + princesa.nome;
            }
            else
            {
            Ini:
                Random rnd = new Random();
                int verificador = rnd.Next(1, 7);
                if (verificador != princesa.numero)
                {
                    foreach (var i in candidatos)
                    {
                        if (verificador == i.numero)
                        {
                            resposta = "A princesa é a " + i.nome;
                        }
                    }
                }
                else
                {
                    goto Ini;
                }
            }
            return resposta;
        }

        public int[] PreencherTipos()
        {
            Random rnd = new Random();
            int sorteado = 0;
            int[] verificador = new int[6];
            int[] resultado = new int[6];

            for (int i = 0; i < 6; i++)
            {
            inicio:
                sorteado = rnd.Next(1, 7);
                for (int j = 0; j < 6; j++)
                {
                    if (verificador[j] == sorteado)
                    {
                        goto inicio;
                    }
                }

                resultado[i] = sorteado;
                verificador[i] = sorteado;

            }
            return resultado;
        }

        public Candidato[] PreencherCandidatos(int[] tipos)
        {
            candidato = new Candidato() { };
            candidato1 = new Candidato() { };
            candidato2 = new Candidato() { };
            candidato3 = new Candidato() { };
            candidato4 = new Candidato() { };
            candidato5 = new Candidato() { };
            candidatos = new Candidato[6] {candidato, candidato1, candidato2, candidato3, candidato4, candidato5};

            for (int i = 0; i < 6; i++)
            {
                candidatos[i].numero = i + 1;
                candidatos[i].nome = "Candidata " + (i + 1);
                candidatos[i].tipo = tipos[i];
                if (candidatos[i].tipo == 1 || candidatos[i].tipo == 2)
                {
                    candidatos[i].classe = "Verde";
                }
                else if (candidatos[i].tipo == 3 || candidatos[i].tipo == 4)
                {
                    candidatos[i].classe = "Vermelho";
                }
                else
                {
                    candidatos[i].classe = "Azul";
                }

                if (candidatos[i].classe == "Verde")
                {
                    candidatos[i].decisao = true;
                }
                else if (candidatos[i].classe == "Vermelho")
                {
                    candidatos[i].decisao = false;
                }
                else
                {
                    Random rnd = new Random();
                    int verificador = rnd.Next(1, 11);
                    if (verificador % 2 != 0)
                    {
                        candidatos[i].decisao = false;
                    }
                    else
                    {
                        candidatos[i].decisao = true;
                    }

                }

                switch (candidatos[i].tipo)
                {
                    case 1:
                        candidatos[i].nomeReal = "Larissa a Princesa";
                        break;

                    case 2:
                        candidatos[i].nomeReal = "a Fada madrinha";
                        break;

                    case 3:
                        candidatos[i].nomeReal = "a Rainha má";
                        break;

                    case 4:
                        candidatos[i].nomeReal = "Serjão o Guarda";
                        break;

                    case 5:
                        candidatos[i].nomeReal = "Julio o Espião";
                        break;

                    default:
                        candidatos[i].nomeReal = "a Camponesa";
                        break;
                }
                candidatos[i].pergunta1 = false;
                candidatos[i].pergunta2 = false;



            }
            return candidatos;
        }

        public Candidato[] candidatos { get; set; }
        public Candidato candidato { get; set; }
        public Candidato candidato1 { get; set; }
        public Candidato candidato2 { get; set; }
        public Candidato candidato3 { get; set; }
        public Candidato candidato4 { get; set; }
        public Candidato candidato5 { get; set; }

    }
    
    
}
