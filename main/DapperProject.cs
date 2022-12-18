using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using main.Interface;
using main.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

internal class Program
{
    private static async Task Main(string[] args)
    {
        await Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<ConsoleHostedService>()
                .AddSingleton<IMain_Repositoriy, Main_Repositoriy>(); //додаємо новий хост
            })
            .RunConsoleAsync();
    }
}

internal sealed class ConsoleHostedService : IHostedService
{
    private readonly ILogger _logger; //додаємо механізм логування
    private readonly IHostApplicationLifetime _appLifetime; //Дозволяє користувачам отримувати сповіщення про події часу існування програми.
    private readonly IMain_Repositoriy _main_Repositoriy; //main репозиторій
    public ConsoleHostedService(
        ILogger<ConsoleHostedService> logger, //логування з категорією ConsoleHostedService. Категорія задає текстову мітку,
                                              //з якою асоціюється повідомлення логера, і у виведенні лога ми її можемо побачити
        IHostApplicationLifetime appLifetime,
        IMain_Repositoriy main_Repositoriy)
    {
        _logger = logger;
        _appLifetime = appLifetime;
        _main_Repositoriy = main_Repositoriy;
    }

    public Task StartAsync(CancellationToken cancellationToken) //викликається при запуску сервісу, зазвичай містить код запуску фонового завдання, що виконується в рамках сервісу
    {
        _logger.LogDebug($"Starting with arguments: {string.Join(" ", Environment.GetCommandLineArgs())}");
        

        _appLifetime.ApplicationStarted.Register(() =>
        {
            Task.Run(async () =>
            {
                try
                {
                    _logger.LogInformation("Hello!"); //повідомлення у консоль
                    _main_Repositoriy.Start();
                }
                catch (Exception ex) //якщо буде помилка
                {
                    _logger.LogError(ex, "Unhandled exception!");
                }
            });
        });

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) //викликається, коли програма завершує роботу,
                                                               //і зазвичай містить код завершення фонового завдання та звільнення використовуваних ресурсів.
    {
        return Task.CompletedTask;
    }
}