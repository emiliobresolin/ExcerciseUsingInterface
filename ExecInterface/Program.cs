﻿using ExecInterface.Entities;
using ExecInterface.Services;
using System;
using System.Globalization;

namespace ExecInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int contractNumber = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int numberMonths = int.Parse(Console.ReadLine());
            Contract newContract = new Contract(contractNumber, contractDate, contractValue);
            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(newContract, numberMonths);
            Console.WriteLine("Installments:");
            foreach(Installment installment in newContract.Installment)
            {
                Console.WriteLine(installment);
            }
        }
    }
}