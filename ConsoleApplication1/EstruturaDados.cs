using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class EstruturaDados
    {
        private string caminhoArquivo = @"Lista.txt";//Variável recebe caminho arquivo
        private string Linhas; //Variavél que Lê linha á linha do arquivo
        int i = 0; //Variável armazena quantidade de linhas do arquivo
        int[,] MatrizAdjacencia; //Cria matriz de adjacencia sem instancia-la
        StreamReader arquivo = null;//Cria variável de leitura do arquivo

        //Método que conta a quantidade de linhas do arquivo e retorna a variável i com o total de linhas
        private int ContaLinhasArquivo()
        {
            if (File.Exists(caminhoArquivo)) //Verifica existencia do arquivo
            {
                try //Bloco de código padrão
                {
                    arquivo = new StreamReader(caminhoArquivo); //Caso o arquivo exista inicializa o mesmo
                    Linhas = arquivo.ReadLine();//Lê a primeira linha do arquivo
                    while (Linhas != null) //Lê o arquivo até o fim
                    {
                        if (Linhas != String.Empty)//Verifica se o valor da linha e diferente de espaço
                            i++; //Armazena a quantidade de linha
                        Linhas = arquivo.ReadLine(); //Passa para a próxima linha do arquivo
                    }
                }
                catch (IOException info) //Trata erros relacionados ao arquivo
                {
                    Console.WriteLine("Erro ao obter informações do arquivo"); //Exibe mensagem de erro
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("! Error:");
                    Console.WriteLine(info.Message); //Mensagem de erro padrão do C#
                }
                finally //Bloco que será executado independente do resultado do try catch
                {
                    if (arquivo != null)
                        arquivo.Close(); //Fecha o arquivo 
                }
            }
            return i;
        }
        //Método que cria matriz de Adjacencia
        public void CriaMatrizDeAdjacencia()
        {
            if (File.Exists(caminhoArquivo)) //Verifica existencia do arquivo
            {
                i = ContaLinhasArquivo();
                if (i != 0)
                {
                    MatrizAdjacencia = new int[i, i]; //Instancia matriz de adjacencia
                    try //Bloco de código padrão
                    {
                        arquivo = new StreamReader(caminhoArquivo); //Caso o arquivo exista inicializa o mesmo
                        Linhas = arquivo.ReadLine();//Lê a primeira linha do arquivo
                        while (Linhas != null) //Lê o arquivo até o fim
                        {
                            for (int k = 0; k < i; k++)//For para percorrer a matriz e atribuir valor de acordo com a adjacencia dos vértices
                            {
                                for (int j = 0; j < i; j++)
                                {
                                    do //Atribui 1 enquanto o valor lido do arquivo for diferente de linha em branco
                                    {
                                        if (k == j) //Se os indices forem iguais trata-se do mesmo vértice, por tanto o valor é 0
                                        {
                                            MatrizAdjacencia[k, j] = 0;
                                        }
                                        else
                                            MatrizAdjacencia[k, j] = 1;
                                    }
                                    while (Linhas != String.Empty);
                                    MatrizAdjacencia[k, j] = 0;
                                }
                            }
                            if (Linhas == String.Empty)//Verifica se o valor da linha e diferente de espaço
                                i++; //Armazena a quantidade de linha
                            Linhas = arquivo.ReadLine(); //Passa para a próxima linha do arquivo
                        }
                    }
                    catch (IOException info) //Trata erros relacionados ao arquivo
                    {
                        Console.WriteLine("Erro ao obter informações do arquivo"); //Exibe mensagem de erro
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("! Error:");
                        Console.WriteLine(info.Message); //Mensagem de erro padrão do C#
                    }
                finally //Bloco que será executado independente do resultado do try catch
                    {
                        if (arquivo != null)
                            arquivo.Close(); //Fecha o arquivo 
                    }
                }
            }
            else
                Console.WriteLine("Arquivo Vazio");
        }
        public void ImprimeMatriz()
        {
            i = ContaLinhasArquivo();
            for (int k = 0; k < i; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.WriteLine(MatrizAdjacencia[k,j]);
                    Console.Write("/t");
                    if (j > i)
                    {
                        Console.Write("/n");
                    }
                }
            }
        }
    }
}
