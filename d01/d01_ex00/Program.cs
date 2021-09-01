using System;
using System.IO;
using System.Collections.Generic;
using ex00;

static void ErrorMassage()
{
    Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
}

if (args.Length != 2)
{
    ErrorMassage();
    return;
}

ExchangeSum exSum = new ExchangeSum(args[0]);
//Console.WriteLine("sum = {0}, identify = {1}", exSum.sum, exSum.currencyIdentifier);

List<string> currencyID = new List<string>() {"USD", "RUB", "EUR"};
List<ExchangeRate> exRate = new List<ExchangeRate>();
for(int i = 0; i < 3; i++)
{
    string path = args[1] + "/" + currencyID[i] + ".txt";
    FileInfo fileInf = new FileInfo(path);
    if (!fileInf.Exists)    
    {
        ErrorMassage();
        return;
    }
    StreamReader f = new StreamReader(path);
    while (!f.EndOfStream)
    {
        string s = f.ReadLine();
        exRate.Add(new ExchangeRate(currencyID[i], s.Split(":")[0]
                                                            , s.Split(":")[1]));
    }
    f.Close();
}

// for (int i = 0; i < 6; i++)
//     Console.WriteLine("cFrom = {0}, cTo = {1}, coef = {2}", exRate[i].currencyFrom, exRate[i].currencyTo, exRate[i].coefficient);

Exchanger exchanger = new Exchanger(exSum, exRate);
string sum = exSum.sum;
int indexOfChar = sum.IndexOf('.');
if (indexOfChar == -1)
    sum = sum + ".00";
else
    sum = sum.Substring(0, indexOfChar + 3);

Console.WriteLine("Сумма в исходной валюте: {0} {1}", sum, exSum.currencyIdentifier);

for (int i = 0; i < 3; i++)
{
    if (currencyID[i] != exSum.currencyIdentifier)
    {
        decimal result = -1;
        result = exchanger.ToConvertCurrency(currencyID[i]);
        Console.WriteLine("Сумма в {0}: {1:f2} {0}", currencyID[i], result);
    }
}
