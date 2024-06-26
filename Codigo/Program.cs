﻿using System;
class Program
{
    static void Main(string[] args)
    {
        //As linhas representando os voos. As colunas representam, respectivamente: Código do voo, Distância percorrida, Assentos disponíveis e Assentos ocupados.
        string[,] voos = new string[100, 4];
        //As linhas representam os passageiros. As colunas representam, respectivamente: Código do voo, Código do passageiro e Nome do passageiro.
        string[,] passageiro = new string[10000, 3];

        int quantVoo = 0; //Variável para representar a quantidade de voos cadastrados na matriz.
        int quantPassageiro = 0; //Variável para representar a quantidade de passageiros cadastrados na matriz.
        int opcao = 0;

        AtribuirValorMatrizes(voos, passageiro);

        while (opcao != 9)
        {
            Console.WriteLine("\n------------Menu-----------");
            Console.WriteLine("1 - Cadastrar voo");
            Console.WriteLine("2 - Cadastrar passageiro");
            Console.WriteLine("3 - Ver voos");
            Console.WriteLine("4 - Ver passageiros");
            Console.WriteLine("5 - Alterar passageiro");
            Console.WriteLine("6 - Excluir passageiro");
            Console.WriteLine("7 - Alterar voo");
            Console.WriteLine("8 - Excluir voo");
            Console.WriteLine("9 - Sair");

            Console.Write("Escolha uma opção: \n");
            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    if (quantVoo <= 100) quantVoo = CadastrarVoo(voos, quantVoo);
                    else Console.WriteLine("\nNão possuí mais espaço para cadastrar voos.\n");
                break;

                case 2:
                    if (quantVoo > 0) quantPassageiro = CadastrarPassageiro(voos, passageiro, quantVoo, quantPassageiro);
                    else Console.Write("\nNão tem como cadastrar passageiros, pois não possuí voos cadastrados.\n");
                break;

                case 3:
                    if (quantVoo > 0) VerVoos(voos, quantVoo);
                    else Console.Write("\nNão possuí voos cadastrados.\n");
                break;

                case 4:
                    if (quantVoo > 0)
                    {
                        if (quantPassageiro > 0) VerPassageiros(passageiro, quantPassageiro);
                        else Console.Write("\nNão possuí passageiros cadastrados.\n");
                    }
                    else Console.Write("\nNão tem como visualizar os passageiros, pois não possuí voos cadastrados.\n");
                break;

                case 5:
                    if (quantVoo > 0)
                    { 
                        if (quantPassageiro > 0) AlterarPassageiro(passageiro, quantPassageiro, voos, quantPassageiro);
                        else Console.Write("Não possuí passageiros cadastrados.");
                    }          
                    else Console.Write("\nNão tem como alterar um passageiro, pois não possuí voos cadastrados.\n");
                break;

                case 6:
                    if (quantVoo > 0)
                    { 
                        if (quantPassageiro > 0) quantPassageiro = ExcluirPassageiro(passageiro, quantPassageiro, voos, quantVoo);
                        else Console.Write("Não possuí passageiros cadastrados.");
                    }          
                    else Console.Write("\nNão tem como excluir um passageiro, pois não possuí voos cadastrados.\n");
                break;

                case 7:
                    if (quantVoo > 0) AlterarVoo(voos, quantVoo);
                    else Console.WriteLine("\nNão tem como alterar um voo, pois não possui voos cadastrados.\n");
                break;

                case 8:
                    if (quantVoo > 0) ExcluirVoo(voos, ref quantVoo, passageiro, ref quantPassageiro);
                    else Console.WriteLine("\nNão possuí voos cadastrados.\n");
                break;

                case 9:
                    Console.WriteLine("\nPrograma encerrado.\n");
                break;

                default:
                    Console.WriteLine("\nOpção inválida. Por favor, tente novamente.\n");
                break;
            }
        }
    }
    
    //Função usada para atribuir para todos os campos das matrizes o valor 0.
    static void AtribuirValorMatrizes(string[,] voos, string[,] passageiro)
    {
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                voos[i, j] = "0";
            }
        }

        for (int i = 0; i < 10000; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                passageiro[i, j] = "0";
            }
        }
    }
    
    //Função 1, usada para cadastrar os voos, tendo como retorno um valor inteiro.
    static int CadastrarVoo(string[,] voos,  int quantVoo)
    {
        Console.WriteLine("----------Cadastrar voo----------");
        bool CodigoSeRepete = false; //Variável do tipo bool, usada para verificar se o código a ser digitado não se repete na matriz.

        if (quantVoo == 0) 
        {
            for (int i = quantVoo; i <= quantVoo; i++)
            {
                Console.Write("Digite o código do voo: ");
                voos[i, 0] = Console.ReadLine();
                Console.Write("Digite a distância a ser percorrida: ");
                voos[i, 1] = Console.ReadLine();
                Console.Write("Digite a quantidade de assentos disponíveis: ");
                voos[i, 2] = Console.ReadLine();
            }
            Console.WriteLine("Voo cadastrado com sucesso!");
        }

        else
        {
            for (int i = quantVoo; i <= quantVoo; i++)
            {
                Console.Write("Digite o código do voo: ");
                string codigo = Console.ReadLine();

                //For para comparar o código digitado com os códigos que estão na matriz "voos".
                for (int linha = 0; linha < quantVoo; linha++)
                {
                    if (codigo == voos[linha, 0])
                    {
                        Console.WriteLine("\nCódigo já cadastrado!\n");
                        CodigoSeRepete = true; 
                        break;
                    }
                }

                if (CodigoSeRepete == false)
                {
                    voos[i, 0] = codigo;
                    Console.Write("Digite a distância a ser percorrida: ");
                    voos[i, 1] = Console.ReadLine();
                    Console.Write("Digite a quantidade de assentos disponíveis: ");
                    voos[i, 2] = Console.ReadLine();
                    Console.WriteLine("Voo cadastrado com sucesso!");
                }
            }
        }

        if(CodigoSeRepete == false){quantVoo++;}
        return quantVoo;
    }
    
    //Função 2, usada para cadastrar os passageiros, tendo como retorno um valor inteiro.
    static int CadastrarPassageiro(string[,] voos, string[,] passageiro, int quantVoo, int quantPassageiro)
    {
        Console.WriteLine("----------Cadastrar Passageiros----------");
        string codigoVoo;
        string codigoPassageiro;
        bool verificaCodigoVoo = false, verificaCodigoPassageiroRepitido = false, verificaAssentosDisponiveis = false; 

        Console.Write("Digite o código do voo: ");
        codigoVoo = Console.ReadLine();

        //For para correr sob a matriz "voos".
        for (int i=0; i <quantVoo; i++)
        {
            //Condicional para verificar se o código digitado está presente na matriz "voos".
            if (codigoVoo == voos[i, 0])
            {
                verificaCodigoVoo = true;

                //Condicional para verificar se no campo "Assentos disponíveis" da matriz "voos", tem espaço para mais um cadastro de passageiro.
                if (voos[i, 2] != "0")
                {
                    verificaAssentosDisponiveis = true;
                }
                else{Console.WriteLine("Não foi possível cadastrar mais um passageiro, pois não possuí espaço suficiente no voo.");}

                break;
            }
        }

        if (verificaCodigoVoo == false)
        {
            Console.WriteLine("Código do voo inválido.");
        }

        if (verificaCodigoVoo == true && verificaAssentosDisponiveis == true){
            Console.Write("Digite o código do passageiro: ");
            codigoPassageiro = Console.ReadLine();

            //For para correr sob a matriz passageiros.
            for (int i=0; i<quantPassageiro; i++)
            {
                //Condicional para verificar se o código do passageiro não se repete.
                if (codigoPassageiro == passageiro[i, 1])
                {
                    verificaCodigoPassageiroRepitido = true;
                    Console.WriteLine("Já possuí este código de passageiro.");
                    break;
                }
            }

            if (verificaCodigoPassageiroRepitido == false)
            {
                for (int i = quantPassageiro; i <= quantPassageiro; i++)
                {
                    passageiro[i, 0] = codigoVoo;
                    passageiro[i, 1] = codigoPassageiro;
                    Console.Write("Digite o nome do passageiro: ");
                    passageiro[i, 2] = Console.ReadLine();
                }

                //For para correr sob a matriz "voos".
                for (int i = 0; i <= quantVoo; i++)
                {
                    //Condicional para verificar em qual posição da matriz "voos" irá fazer o decremento e Incremento dos campos "Assentos ocupados" e "Assentos disponíveis".
                    if (codigoVoo == voos[i, 0])
                    {
                        voos[i, 3] = (int.Parse(voos[i, 3]) + 1).ToString(); // Incrementando mais 1 no campo "Assentos ocupados".
                        voos[i, 2] = (int.Parse(voos[i, 2]) - 1).ToString(); // Decrementando menos 1 no campo "Assentos disponíveis".
                    }
                }
                Console.WriteLine("Passageiro cadastrado com sucesso!");
                quantPassageiro++;
            }
        }
        return quantPassageiro;
    }
    
    //Função 3, usada para ver os voos cadastrados, não tendo retorno.
    static void VerVoos(string[,] voos, int quantVoo)
    {
        int opcao = 0;
        while (opcao != 7)
        {
            Console.WriteLine("\n----------Ver voos----------");
            Console.WriteLine("1. Ver todos os voos");
            Console.WriteLine("2. Ver voos com mais passageiros");
            Console.WriteLine("3. Ver voos com menos passageiros");
            Console.WriteLine("4. Ver voo com maior distância");
            Console.WriteLine("5. Ver voo com menor distância");
            Console.WriteLine("6. Ver ocupação média dos voos");
            Console.WriteLine("7. Voltar ao menu inicial");

            Console.Write("Escolha uma opção: \n");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("\nTodos os vôos cadastrados:");
                    for (int i = 0; i < quantVoo; i++)
                    {
                        Console.WriteLine("Código: " + voos[i, 0] + ", Distância percorrida: " + voos[i, 1] + " km, Assentos disponíveis: " + voos[i, 2] + ", Assentos ocupados: " + voos[i, 3]);
                    }
                break;

                case 2:
                    double maispassageiros = int.Parse(voos[0, 3]);
                    int PosicaoVooMaisPassageiros = 0;
                    Console.WriteLine("\nVoo com mais passageiros: ");
                    for (int i = 0; i < quantVoo; i++)
                    {
                        if (int.Parse(voos[i, 3]) > maispassageiros)
                        {
                            maispassageiros = int.Parse(voos[i, 3]);
                            PosicaoVooMaisPassageiros = i;
                        }
                    }
                    Console.WriteLine("Código: " + voos[PosicaoVooMaisPassageiros, 0] + ", Distância percorrida: " + voos[PosicaoVooMaisPassageiros, 1] + " km, Assentos disponíveis: " + voos[PosicaoVooMaisPassageiros, 2] + ", Assentons ocupados: " + voos[PosicaoVooMaisPassageiros, 3]);
                break;

                case 3:
                    int menospassageiros = int.Parse(voos[0, 3]);
                    int PosicaoVooMenosPassageiros = 0;
                    Console.WriteLine("\nVoo com menos passageiros: ");
                    for (int i = 0; i < quantVoo; i++)
                    {
                        if (int.Parse(voos[i, 3]) < menospassageiros)
                        {
                            menospassageiros = int.Parse(voos[i, 3]);
                            PosicaoVooMenosPassageiros = i;
                        }
                    }
                    Console.WriteLine("Código: " + voos[PosicaoVooMenosPassageiros, 0] + ", Distância percorrida: " + voos[PosicaoVooMenosPassageiros, 1] + " km, Assentos disponíveis: " + voos[PosicaoVooMenosPassageiros, 2] + ", Assentons ocupados: " + voos[PosicaoVooMenosPassageiros, 3]);
                break;

                case 4:
                    double maiordistancia = double.Parse(voos[0, 1]);
                    int PosicaoVooMaiorDistancia = 0;
                    Console.WriteLine("\nVoo com maior distância: ");
                    for (int i = 0; i < quantVoo; i++)
                    {
                        if (double.Parse(voos[i, 1]) > maiordistancia)
                        {
                            maiordistancia = double.Parse(voos[i, 1]);
                            PosicaoVooMaiorDistancia = i;
                        }
                    }
                    Console.WriteLine("Código: " + voos[PosicaoVooMaiorDistancia, 0] + ", Distância percorrida: " + voos[PosicaoVooMaiorDistancia, 1] + " km, Assentos disponíveis: " + voos[PosicaoVooMaiorDistancia, 2] + ", Assentons ocupados: " + voos[PosicaoVooMaiorDistancia, 3]);
                break;

                case 5:
                    Console.WriteLine("\nVoo com menor distância: ");
                    double menorDistancia = double.Parse(voos[0, 1]);
                    int PosicaoVooMenorDistancia = 0;
                    for (int i = 0; i < quantVoo; i++)
                    {
                        double distancia = double.Parse(voos[i, 1]);
                        if (distancia < menorDistancia)
                        {
                            menorDistancia = distancia;
                            PosicaoVooMenorDistancia = i;
                        }
                    }
                    Console.WriteLine("Código: " + voos[PosicaoVooMenorDistancia, 0] + ", Distância percorrida: " + voos[PosicaoVooMenorDistancia, 1] + " km, Assentos disponíveis: " + voos[PosicaoVooMenorDistancia, 2] + ", Assentons ocupados: " + voos[PosicaoVooMenorDistancia, 3]);
                break;

                case 6:
                    float media = 0, soma = 0;
                    Console.WriteLine("\nOcupação média dos voos: ");
                    for (int i = 0; i < quantVoo; i++)
                    {
                        soma += float.Parse(voos[i, 3]);
                    }
                    media = soma / quantVoo;
                    Console.WriteLine("Ocupação média dos voos é de: " + media + " passageiro(s).");
                break;

                case 7:
                    Console.WriteLine("\nVoltando ...");
                break;

                default:
                    Console.WriteLine("\nOpção inválida. Por favor, tente novamente.");
                break;
            }
        }
    }
    
    //Função 4, usada para ver os passageiros, não tendo retorno.
    static void VerPassageiros(string[,] passageiro, int quantPassageiro)
    {
        int opcao = 0;
        while (opcao != 3)
        {
            Console.WriteLine("\n----------Ver Passageiros----------");
            Console.WriteLine("1 - Ver passageiro especifico. ");
            Console.WriteLine("2 - Ver todos os passageiros de um voo. ");
            Console.WriteLine("3 - Voltar ao menu inicial.");

            Console.Write("\nEscolha uma opção:\n");
            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Console.Write("\nDigite o código do passageiro: ");
                    string codigoPassageiro = Console.ReadLine();
                    bool verificaCodigoPassageiro = false;
                    
                    //For para correr sob a matriz "passageiro".
                    for (int i=0; i<quantPassageiro; i++)
                    {
                        //Condicional para verificar se o o código do foi encontrado na matriz "passageiro".
                        if (codigoPassageiro == passageiro[i, 1])
                        {
                            verificaCodigoPassageiro = true;
                            Console.WriteLine("O passageiro: " + passageiro[i, 2] + " com o código: " + passageiro[i, 1] + " está no voo: " + passageiro[i, 0]);
                            break;
                        }
                    }

                    if (verificaCodigoPassageiro == false)
                    {
                        Console.WriteLine("Código de passageiro não encontrado!");
                    }

                break;

                case 2:
                    Console.Write("\nDigite o código do voo: ");
                    string codigoVoo = Console.ReadLine();
                    bool verificaCodigoVoo = false;

                    //For para correr sob a matriz "passageiro".
                    for (int i = 0; i < quantPassageiro; i++)
                    {
                        //Condicional para verificar se o codigo do voo existe.
                        if (codigoVoo == passageiro[i, 0])
                        {
                            verificaCodigoVoo = true;
                            Console.WriteLine("Voo: " + passageiro[i, 0] + ", Código de passageiro: " + passageiro[i, 1] + ", Nome do passageiro: " + passageiro[i, 2]);                       
                        }
                    }

                    if (verificaCodigoVoo == false)
                    {
                        Console.WriteLine("Código de voo não encontrado!");
                    }

                break;

                case 3:
                    Console.WriteLine("\nVoltando ...");
                break;

                default:
                    Console.WriteLine("Valor inválido. Favor insira um valor válido.");
                break;
            }
        }
    }
    
    //Função 5, usada para alterar os passageiros, não tendo retorno.
    static void AlterarPassageiro(string[,] passageiro, int quantPassageiro, string [,] voos, int quantVoo) 
    {
        Console.WriteLine("----------Alterar Passageiro----------");
        Console.Write("Digite o código do passageiro a ser alterado: ");
        string codigoPassageiro = Console.ReadLine();

        //Variável para indicar se o passageiro foi encontrado
        int PassageiroEncontrado = -1;

        //Verificar se o código do passageiro está presente na matriz de passageiros
        for (int i = 0; i < quantPassageiro; i++)
        {
            if (codigoPassageiro == passageiro[i, 1])
            {
                PassageiroEncontrado = i;
                break;
            }
        }

        if (PassageiroEncontrado != -1)
        {   
            Console.WriteLine("Passageiro encontrado:");
            Console.WriteLine("Código do voo: " + passageiro[PassageiroEncontrado, 0] + ", Código do passageiro: " + passageiro[PassageiroEncontrado, 1] + ", Nome do passageiro: " + passageiro[PassageiroEncontrado, 2]);
            
            int opcao=0;
            while(opcao!=3){
                Console.WriteLine("\n----------Menu de Opções----------");
                Console.WriteLine("1 - Mudar de voo.");
                Console.WriteLine("2 - Mudar nome do passageiro.");
                Console.WriteLine("3 - Voltar.");

                opcao = int.Parse(Console.ReadLine());
                switch(opcao){
                    case 1:
                        Console.Write("\nDigite o novo código do voo: ");
                        string novoCodigoVoo = Console.ReadLine();
                        string velhoCodigoVoo="";
                        bool verificaVoo = false, verificaEspacoVoo = false;
                        for(int i=0;i<=quantVoo;i++){
                            if (novoCodigoVoo == voos[i,0]){//Verifica se existe um código de voo igual ao digitado.
                                if(voos[i,2] != "0")//Verifica se existe espaço disponível no voo.
                                {
                                    velhoCodigoVoo = passageiro[PassageiroEncontrado, 0];
                                    passageiro[PassageiroEncontrado, 0] = novoCodigoVoo;
                                    verificaEspacoVoo = true;
                                }
                                else
                                {
                                    Console.WriteLine("Não possuí assentos disponível");
                                }
                                verificaVoo = true;
                                break;
                            }
                        }
                        if(verificaVoo != true){Console.WriteLine("\nCódigo de voo não encontrado!");}

                        if(verificaVoo == true && verificaEspacoVoo == true){
                            for(int i=0;i<=quantVoo;i++){

                                if (velhoCodigoVoo == voos[i, 0])
                                {
                                    voos[i, 3] = (int.Parse(voos[i, 3]) - 1).ToString(); // Decrementando menos 1 no campo "Assentos ocupados".
                                    voos[i, 2] = (int.Parse(voos[i, 2]) + 1).ToString(); // Incrementando mais 1 no campo "Assentos disponíveis".
                                }

                                if(novoCodigoVoo == voos[i,0])
                                {
                                    voos[i, 2] = (int.Parse(voos[i, 2]) - 1).ToString(); // Decrementando menos 1 no campo "Assentos disponíveis".
                                    voos[i, 3] = (int.Parse(voos[i, 3]) + 1).ToString(); // Incrementando mais 1 no campo "Assentos ocupados".
                                } 
                            }
                            Console.Write("Alteração feita com sucesso!");
                        }      
                    
                    break;

                    case 2:
                        Console.Write("Digite o novo nome do passageiro: ");
                        string novoNomePassageiro = Console.ReadLine();
                        passageiro[PassageiroEncontrado, 2] = novoNomePassageiro;
                    break;

                    case 3:
                        Console.WriteLine("Voltando...");
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("Passageiro não encontrado.");
        }
    }

    //Função 6, usada para excluir os passageiros, tendo como retorno um valor inteiro.
    static int ExcluirPassageiro(string[,] passageiro, int quantPassageiro, string[,] voos, int quantVoo)
    {
        Console.WriteLine("\n----------Excluir Passageiro----------");
        Console.WriteLine("Digite o código do passageiro a ser excluído: ");
        string codPassageiro = Console.ReadLine();

        int posiCod = -1; //Variável para armazenar a posição de i da matriz passageiro.

        //For para correr sob a matriz passageiro.
        for (int i = 0; i < quantPassageiro; i++)
        {
            //Condicional para verificar se o código do passageiro está presente na matriz "passageiro".
            if (codPassageiro == passageiro[i, 1])
            {
                posiCod = i;
                break;
            }
        }

        if (posiCod == -1)
        {
            Console.WriteLine("Código do passageiro não encontrado.");
        }
        else
        {
            string codigoVoo = passageiro[posiCod,0];
            //For para correr sob a matriz "voos".
            for (int i = 0; i < quantVoo; i++)
            {
                //Condicional para verificar em qual posição da matriz "voos" irá fazer o decremento e Incremento dos campos "Assentos ocupados" e "Assentos disponíveis".
                if (codigoVoo == voos[i, 0])
                {
                    voos[i, 3] = (int.Parse(voos[i, 3]) - 1).ToString(); // Decrementando menos 1 no campo  "Assentos ocupados".
                    voos[i, 2] = (int.Parse(voos[i, 2]) + 1).ToString(); // Incrementando mais 1 no campo "Assentos disponíveis".
                }
            }
        
            //Deslocar os voos para preecher o espaço excluído, ou seja, sobrepor as informações do passageiro anterior.
            for (int i = posiCod; i < quantPassageiro; i++)
            {
                passageiro[i, 0] = passageiro[i + 1, 0];
                passageiro[i, 1] = passageiro[i + 1, 1];
                passageiro[i, 2] = passageiro[i + 1, 2];
            }                                           
            quantPassageiro--;
            Console.WriteLine("Passageiro excluído com sucesso!");
        }
        return quantPassageiro;
    }
   
    //Função 7, usada para alterar um voo, não tendo retorno.
    static void AlterarVoo(string[,] voos, int quantVoo)
    {
        Console.WriteLine("\n----------Alterar Voo----------");
        Console.WriteLine("Digite o código do voo a ser alterado: ");
        string codVoo = Console.ReadLine();

        int PosiCod = -1; //Variável para armazenar a posição do código da matriz "voos".
        for (int i=0; i<quantVoo; i++)
        {
            if (codVoo == voos[i, 0])
            {
                PosiCod = i;
                break;
            }
        }

        if (PosiCod == -1)
        {
            Console.WriteLine("Código do voo não encontrado.");
        }
        else
        {
            Console.WriteLine("\nInsira os novos dados:\n");
            Console.WriteLine("Digite a nova distância percorrida: ");
            voos[PosiCod, 1] = Console.ReadLine();
    
            Console.WriteLine("Voo alterado com sucesso!");
        }
    }
    
    //Função 8, usada para excluir um voo, tendo como retorno um vetor de valor inteiro.
    static void ExcluirVoo(string[,] voos, ref int quantVoo, string[,] passageiro, ref int quantPassageiro)
    {
        Console.WriteLine("----------Excluir Voo----------");
        Console.Write("Digite o código do voo a ser excluído: ");
        string codigoVoo = Console.ReadLine();

        int indiceVoo = -1; //Variável para armazenar a posição de i da matriz "voos".
        for (int i = 0; i < quantVoo; i++)
        {
            if (voos[i, 0] == codigoVoo)
            {
                indiceVoo = i;
                break;
            }
        }

        if (indiceVoo != -1)
        {
            //Deslocar voos para preencher o espaço, ou seja, sobrepor as informações do voo anterior.
            for (int i = indiceVoo; i < quantVoo; i++)
            {
                voos[i, 0] = voos[i + 1, 0];
                voos[i, 1] = voos[i + 1, 1];
                voos[i, 2] = voos[i + 1, 2];
                voos[i, 3] = voos[i + 1, 3];
            }

            //Remover passageiros com o mesmo código de voo
            for (int i = 0; i < quantPassageiro; i++)
            {
                if (passageiro[i, 0] == codigoVoo)
                {
                    // Deslocar passageiros para preencher o espaço
                    for (int j = i; j < quantPassageiro; j++)
                    {
                        passageiro[j, 0] = passageiro[j + 1, 0];
                        passageiro[j, 1] = passageiro[j + 1, 1];
                        passageiro[j, 2] = passageiro[j + 1, 2];
                    }
                    quantPassageiro--;
                    i--; //Decrementar a contagem para verificando o passageiro movido
                }
            }
            quantVoo--;
            Console.WriteLine("Voo excluído com sucesso!");
        }
        else
        {
            Console.WriteLine("Voo não encontrado.");
        }
    }
}
