using System;
using System.Collections.Generic;

namespace _20._06._24
{
    internal class Program
    {
        private static string username;
        private static bool isAuthenticated = false;
        private static DateTime loginDateTime;
        private static List<DateTime> accessi = new List<DateTime>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("===============OPERAZIONI==============");
                Console.WriteLine("Scegli l'operazione da effettuare:");
                Console.WriteLine("1.: Login");
                Console.WriteLine("2.: Logout");
                Console.WriteLine("3.: Verifica ora e data di login");
                Console.WriteLine("4.: Lista degli accessi");
                Console.WriteLine("5.: Esci");
                Console.WriteLine("========================================");
                Console.Write("Scrivici una scelta (1-5): ");

                char input = Choice();
                Console.WriteLine($"Hai scelto: {input}");

                switch (input)
                {
                    case '1':
                        Login();
                        break;
                    case '2':
                        Logout();
                        break;
                    case '3':
                        VerificaLogin();
                        break;
                    case '4':
                        ListaAccessi();
                        break;
                    case '5':
                        Exit();
                        return;
                }
            }
        }

        static char Choice()
        {
            char answer;
            do
            {
                string input = Console.ReadLine();
                if (input.Length == 1 && char.IsDigit(input[0]))
                {
                    answer = input[0];
                }
                else
                {
                    answer = '0'; // valore non valido
                }
            } while (answer < '1' || answer > '5');
            return answer;
        }

        static void Login()
        {
            Console.Write("Inserisci il tuo username: ");
            string inputUsername = Console.ReadLine();

            Console.Write("Inserisci la tua password: ");
            string password = Console.ReadLine();

            Console.Write("Conferma la tua password: ");
            string confirmPassword = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputUsername) && password == confirmPassword)
            {
                username = inputUsername;
                isAuthenticated = true;
                loginDateTime = DateTime.Now;
                accessi.Add(loginDateTime);
                Console.WriteLine("Login effettuato con successo.");
            }
            else
            {
                Console.WriteLine("Errore nel login. Username vuoto o password non corrispondenti.");
            }
        }

        static void Logout()
        {
            if (isAuthenticated)
            {
                isAuthenticated = false;
                username = null;
                Console.WriteLine("Logout effettuato con successo.");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato.");
            }
        }

        static void VerificaLogin()
        {
            if (isAuthenticated)
            {
                Console.WriteLine($"Login effettuato il: {loginDateTime}");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato.");
            }
        }

        static void ListaAccessi()
        {
            if (accessi.Count > 0)
            {
                Console.WriteLine("Lista degli accessi:");
                foreach (var accesso in accessi)
                {
                    Console.WriteLine(accesso);
                }
            }
            else
            {
                Console.WriteLine("Nessun accesso registrato.");
            }
        }

        static void Exit()
        {
            Console.WriteLine("Uscita dal programma.");
        }
    }
}
