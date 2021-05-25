using System;
using System.Reflection.Metadata.Ecma335;

namespace Day00
{
    class Program
    {
        static double MonthlyPayment(double sumOfCredit, int numOfMonths, double interestRate)
        {
            double annuityPayment  = sumOfCredit * interestRate * Math.Pow((1 + interestRate), numOfMonths)
                                    / (Math.Pow((1 + interestRate), numOfMonths) - 1);
            return annuityPayment;
        }

        static double InterestRate(double annualInterestRate)
        {
            return annualInterestRate / 12 / 100;
        }

        static double MonthlyPaymentInterest(double totalDebtAmount, double interestRate,
                                        double numOfDaysInPeriod, int numOfDaysInYear)
        {
            double percent = (totalDebtAmount * interestRate * numOfDaysInPeriod) / (100 * numOfDaysInYear);
            return percent;
        }

        static int NumberOfLoanMonths(double paymentAmounts, double totalDebtAmount, double interestRate)
        {
            double num = Math.Log((paymentAmounts / (paymentAmounts - interestRate * totalDebtAmount)), (1 + interestRate));
            return (int)num;
        }

        static double LessOverpayment(double sum, double rate, int term, int selectedMonth, double payment)
        {
            DateTime date1 = new DateTime(2021, 5, 1);
            DateTime date2 = new DateTime(2022, 3, 1);
            DateTime date3 = new DateTime(2021, 5, 1);
            var numOfDaysInPeriod = date2.Subtract(date1).TotalDays;
            double interestRate = InterestRate(rate);
            double totalDebt = sum;
            double balanceOwed = sum;
            double monthlyPayment = MonthlyPayment(sum, term, interestRate);
            double monthlyPaymentInterest = MonthlyPaymentInterest(balanceOwed, rate, numOfDaysInPeriod, 365);
            double result = 0;

            Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15} {4, -15}", "Дата", "Платеж", "ОД", "Проценты", "Остаток долга");

            for (int i = 1; i <= term; i++)
            {
                date1 = date1.AddMonths(1);
                numOfDaysInPeriod = date1.Subtract(date3).TotalDays;
                monthlyPaymentInterest = MonthlyPaymentInterest(balanceOwed, rate, numOfDaysInPeriod, 365);
                totalDebt = monthlyPayment - monthlyPaymentInterest;
                balanceOwed = balanceOwed - totalDebt;

                if (i == selectedMonth)
                {
                    balanceOwed = balanceOwed - payment;
                    monthlyPayment = MonthlyPayment(balanceOwed, term - selectedMonth, interestRate);
                }

                Console.WriteLine("{0, -15:f2} {1, -15:f2} {2, -15:f2} {3, -15:f2} {4, -15:f2}",
                date1.ToShortDateString(),
                monthlyPayment, 
                totalDebt, 
                monthlyPaymentInterest,
                balanceOwed);

                date3 = date3.AddMonths(1);
                result += monthlyPaymentInterest;
            }
            return result;
        }
        
        static double ReductionOfLoanTerm(double sum, double rate, int term, int selectedMonth, double payment)
        {
            DateTime date1 = new DateTime(2021, 5, 1);
            DateTime date2 = new DateTime(2022, 3, 1);
            DateTime date3 = new DateTime(2021, 5, 1);
            var numOfDaysInPeriod = date2.Subtract(date1).TotalDays;
            double interestRate = InterestRate(rate);
            double totalDebt = sum;
            double balanceOwed = sum;
            double monthlyPayment = MonthlyPayment(sum, term, interestRate);
            double monthlyPaymentInterest = MonthlyPaymentInterest(balanceOwed, rate, numOfDaysInPeriod, 365);
            double result = 0;

            Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15} {4, -15}", "Дата", "Платеж", "ОД", "Проценты", "Остаток долга");

            for (int i = 1; i <= term; i++)
            {
                date1 = date1.AddMonths(1);
                numOfDaysInPeriod = date1.Subtract(date3).TotalDays;
                monthlyPaymentInterest = MonthlyPaymentInterest(balanceOwed, rate, numOfDaysInPeriod, 365);
                totalDebt = monthlyPayment - monthlyPaymentInterest;
                balanceOwed = balanceOwed - totalDebt;
                if (balanceOwed < 0)
                    balanceOwed = 0;

                if (i == selectedMonth)
                {
                    balanceOwed = balanceOwed - payment;
                    term = i + NumberOfLoanMonths(monthlyPayment, balanceOwed, interestRate);
                }

                Console.WriteLine("{0, -15:f2} {1, -15:f2} {2, -15:f2} {3, -15:f2} {4, -15:f2}",
                date1.ToShortDateString(),
                monthlyPayment, 
                totalDebt, 
                monthlyPaymentInterest,
                balanceOwed);

                date3 = date3.AddMonths(1);
                result += monthlyPaymentInterest;
            }
            return result;     
        }
        
        static void Main(string[] args)
        {
            if (args.Length != 5)
            {
                Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
                return;
            }

            double  sum;
            double  rate;
            int     term;
            int     selectedMonth;
            double  payment;

            double.TryParse(args[0], out sum);
            double.TryParse(args[1], out rate);
            int.TryParse(args[2], out term);
            int.TryParse(args[3], out selectedMonth);
            double.TryParse(args[4], out payment);

            double resultLessOverpayment = LessOverpayment(sum, rate, term, selectedMonth, payment);
            double resultReductionOfLoanTerm = ReductionOfLoanTerm(sum, rate, term, selectedMonth, payment);
            Console.WriteLine("Переплата при уменьшении платежа: {0:f2} р.", resultLessOverpayment);
            Console.WriteLine("Переплата при уменьшении срока: {0:f2} р.", resultReductionOfLoanTerm);
            if (resultLessOverpayment > resultReductionOfLoanTerm)
                Console.WriteLine("Уменьшение срока выгоднее уменьшения платежа на: {0:f2} р.", 
                    resultLessOverpayment - resultReductionOfLoanTerm);
            else if (resultLessOverpayment < resultReductionOfLoanTerm)
                Console.WriteLine("Уменьшение платежа выгоднее уменьшения срока на: {0:f2} р.", 
                    resultReductionOfLoanTerm - resultLessOverpayment);
            else
                Console.WriteLine("Переплата одинакова в обоих вариантах.");
        }
    }
}
