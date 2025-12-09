// See https://aka.ms/new-console-template for more information

using Kata3;

Proxy proxy =  new Proxy();

Console.WriteLine("~~~ WITHOUT PROXY (Original) ~~~\n");
proxy.RunWithoutProxy();   

Console.WriteLine("~~~ WITH PROXY (Cached) ~~~\n");
proxy.RunWithProxy();