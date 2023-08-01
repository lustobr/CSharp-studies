﻿using BankSystem;

// Convert string to ContaCorrente
Bank StringToCurrentAccount(string line)
{
    // Split string
    var campos = line.Split(',');

    // Get values from string and convert to int and double
    var account = campos[0];
    var number = campos[1];
    var balance = campos[2].Replace('.', ',');
    var holderName = campos[3];

    var accountInt = int.Parse(account);
    var numberInt = int.Parse(number);
    var balanceDouble = double.Parse(balance);

    // Create a new Client and set the name
    var holder = new Client();
    holder.Name = holderName;

    // Create a new ContaCorrente and set the values
    var result = new Bank(accountInt, numberInt);

    result.Deposit(balanceDouble);
    result.Holder = holder;
    
    return result;
}

// Open file (Contas.txt) and read line by line
using (var file = new FileStream("Contas.txt", FileMode.Open)) // Contas.txt is in the root folder of the project (06. Files\01. File to class)
{
    // Read file
    var reader = new StreamReader(file);

    // Read line
    while(!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        var currentAccount = StringToCurrentAccount(line!);

        // Write line in console
        Console.WriteLine($"{currentAccount.Holder!.Name} : Number {currentAccount.Number}, ag {currentAccount.Account}, balance {currentAccount.Balance}");
    }   
}
Console.ReadLine();

/*
Output:

Guilherme : Number 456, ag 123, balance 400
Mariana : Number 789, ag 123, balance 500
Luiza : Number 101112, ag 456, balance 1500
...
*/