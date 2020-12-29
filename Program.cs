using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUusuario = obterOpcaoUsuario();

            while (opcaoUusuario.ToUpper() != "X")
            {
                switch (opcaoUusuario)
                {
                    case "1":
                        Console.WriteLine("Informe ai o nome do aluno");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe ai nota do aluno");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota)){
                           aluno.Nota = nota;     
                        }else{
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }
                        

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        foreach(var a in alunos){
                            //se  o nome não for nulo nem falso executa
                            if (!string.IsNullOrEmpty(a.Nome)){
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                            
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for(int i=0; i < alunos.Length;i++){
                            if (!string.IsNullOrEmpty(alunos[i].Nome)){
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Console.WriteLine($"Media geral: {mediaGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                

                opcaoUusuario = obterOpcaoUsuario();
            }

        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opção");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Lista alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUusuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUusuario;
        }
    }
}
