using System;
using System.Collections.Generic;
using System.IO;

namespace RegistrosVotacao
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> candidatos = new Dictionary<string, int>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                using StreamReader sr = File.OpenText(path);
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    string NomeCandidato = line[0];
                    int votos = int.Parse(line[1]);
                    
                    if (candidatos.ContainsKey(NomeCandidato))                                            
                        candidatos[NomeCandidato] += votos;                    
                    else                    
                        candidatos.Add(NomeCandidato, votos);                   
                }                                
                Console.WriteLine("RESULTADO!");                
                foreach (var item in candidatos)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
