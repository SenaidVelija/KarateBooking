using KarateBooking.Application.Common;
using KarateBooking.Application.CQRS.Event.Commands.Create;
using KarateBooking.Application.CQRS.Event.Commands.Delete;
using KarateBooking.Application.CQRS.Event.Commands.Update;
using KarateBooking.Application.CQRS.Event.Queries.GetList;
using KarateBooking.Application.DTO;
using KarateBooking.Domain.Entities.Event;
using KarateBooking.Infrastructure;
using KarateBooking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KarateBooking.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            ConfigureServices(services);
            using var serviceProvider = services.BuildServiceProvider();

            var mainForm = serviceProvider.GetRequiredService<EventsForm>();
            System.Windows.Forms.Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");


            services.AddDbContextFactory<KarateBookingDbContext>(options =>
           options.UseSqlServer(connectionString));


            services.AddScoped<IEventRepository, EventRepository>();

            
            services.AddScoped<IQueryHandler<GetEventListQuery, List<EventDto>>, GetEventListQueryHandler>();
            services.AddScoped<ICommandHandler<DeleteEventCommand, bool>, DeleteEventHandler>();
            services.AddScoped<ICommandHandler<CreateEventCommand, EventDto>, CreateEventHandler>();
            services.AddScoped<ICommandHandler<UpdateEventCommand, EventDto>, UpdateEventHandler>();


            services.AddTransient<EventsForm>();
            services.AddTransient<Func<EventDto?, EventFormDialog>>(sp => existingEvent =>
                new EventFormDialog(
                sp.GetRequiredService<ICommandHandler<CreateEventCommand, EventDto>>(),
                sp.GetRequiredService<ICommandHandler<UpdateEventCommand, EventDto>>(),
                existingEvent));
        }
    }

}