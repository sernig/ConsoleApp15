using System;
public class BankruptException : Exception
{
    public BankruptException(string message) : base(message) { }
}

