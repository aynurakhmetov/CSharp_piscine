using System;
using System.IO;
using System.Collections.Generic;
using ex00;

static void ErrorMessage()
{
    Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
}

if (args.Length != 2)
{
    ErrorMessage();
    return;
}

var exchangeSum = new ExchangeSum(args[0]);
//Console.WriteLine("sum = {0}, identify = {1}", exchangeSum.sum, exchangeSum.currencyIdentifier);

var currencyIdList = new List<string>() {"USD", "RUB", "EUR"};
var exchangeRateList = new List<ExchangeRate>();
for(var i = 0; i < 3; i++)
{
    var path = args[1] + "/" + currencyIdList[i] + ".txt";
    var fileInfo = new FileInfo(path);
    if (!fileInfo.Exists)    
    {
        ErrorMessage();
        return;
    }
    var streamReader = new StreamReader(path);
    while (!streamReader.EndOfStream)
    {
        var readLine = streamReader.ReadLine();
        exchangeRateList.Add(new ExchangeRate(currencyIdList[i], 
            readLine .Split(":")[0], readLine .Split(":")[1]));
    }
    streamReader.Close();
}

// for (int i = 0; i < 6; i++)
//     Console.WriteLine("cFrom = {0}, cTo = {1}, coef = {2}",
// exchangeRateList[i].currencyFrom, exchangeRateList[i].currencyTo, exchangeRateList[i].coefficient);

var exchanger = new Exchanger(exchangeSum, exchangeRateList);
var sum = exchangeSum.sum;
var indexOfChar = sum.IndexOf('.');
if (indexOfChar == -1)
    sum = sum + ".00";
else
    sum = sum.Substring(0, indexOfChar + 3);

Console.WriteLine("Сумма в исходной валюте: {0} {1}", sum, exchangeSum.currencyIdentifier);

for (int i = 0; i < 3; i++)
{
    if (currencyIdList[i] != exchangeSum.currencyIdentifier)
    {
        decimal result = -1;
        result = exchanger.ToConvertCurrency(currencyIdList[i]);
        Console.WriteLine("Сумма в {0}: {1:f2} {0}", currencyIdList[i], result);
    }
}
