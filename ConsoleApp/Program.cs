﻿using CurrencyExchange;
using System;
using System.IO;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (ValidateParameters(args))
                {
                    using (var input = new StreamReader(InputFile.OpenRead()))
                    using (var output = new StreamWriter(OutputFile.OpenWrite()))
                    {
                        var interpreter = new LanguageInterpreter();
                        while (!input.EndOfStream)
                        {
                            var inputLine = input.ReadLine();
                            var outputLine = interpreter.Add(inputLine);
                            if (outputLine != null) output.WriteLine(outputLine);
                            output.Flush();
                        }
                    }
                    Console.WriteLine("Finished.");
                }
            }
            catch (Exception exception)
            {
                // not all exception can be caught here and not all should be,
                // but right here I just want to gracefully exit application
                Console.WriteLine(exception.Message);
            }
            Console.ReadKey();
        }

        private static bool ValidateParameters(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Wrong number of params specified. Usage:");
                Console.WriteLine(@"[applicaiton] Input.txt");
                Console.WriteLine(@"[applicaiton] Input.txt Output.txt");
                return false;
            }

            InputFile = new FileInfo(args[0]);
            OutputFile = new FileInfo(args.Length > 1 ? args[1] : args[0].Replace(".txt", "_output.txt"));
            if (!InputFile.Exists)
            {
                // There still might be some problems with access rights to files, but i didn't want to go too deep
                Console.WriteLine("Input file does not exist");
                return false;
            }

            return true;
        }

        private static FileInfo InputFile { get; set; }

        private static FileInfo OutputFile { get; set; }
    }
}