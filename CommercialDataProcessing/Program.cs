// See https://aka.ms/new-console-template for more information
using CommercialDataProcessing;

string userpath = @"E:\Bridgelabz\Oops-Programing\CommercialDataProcessing\user.json";
string marketpath = @"E:\Bridgelabz\Oops-Programing\CommercialDataProcessing\Stocks.json";

DataProcessing data = new DataProcessing(marketpath,userpath);
