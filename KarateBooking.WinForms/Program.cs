using KarateBooking.Application.Common;
using KarateBooking.Application.CQRS.Booking.Commands.Cancel;
using KarateBooking.Application.CQRS.Booking.Commands.Create;
using KarateBooking.Application.CQRS.Booking.Commands.Update;
using KarateBooking.Application.CQRS.Booking.Queries.GetList;
using KarateBooking.Application.CQRS.Event.Commands.Cancel;
using KarateBooking.Application.CQRS.Event.Commands.Create;
using KarateBooking.Application.CQRS.Event.Commands.Delete;
using KarateBooking.Application.CQRS.Event.Commands.Update;
using KarateBooking.Application.CQRS.Event.Queries.GetList;
using KarateBooking.Application.CQRS.User.Commands.Create;
using KarateBooking.Application.CQRS.User.Commands.Delete;
using KarateBooking.Application.CQRS.User.Commands.Update;
using KarateBooking.Application.CQRS.User.Queries.GetList;
using KarateBooking.Application.DTO;
using KarateBooking.Application.Interface;
using KarateBooking.Domain.Entities.Event;
using KarateBooking.Infrastructure;
using KarateBooking.Infrastructure.Repositories;
using KarateBooking.WinForms.Booking;
using KarateBooking.WinForms.User;
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

            var mainForm = serviceProvider.GetRequiredService<MainForm>();
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
            services.AddScoped<IUserRepository, UserRepository>();

            
            services.AddScoped<IQueryHandler<GetEventListQuery, List<EventDto>>, GetEventListQueryHandler>();
            services.AddScoped<IQueryHandler<GetUserListQuery, List<UserDto>>, GetUserListQueryHandler>();
            services.AddScoped<ICommandHandler<DeleteEventCommand, bool>, DeleteEventHandler>();
            services.AddScoped<ICommandHandler<DeleteUserCommand, bool>, DeleteUserHandler>();
            services.AddScoped<ICommandHandler<CreateEventCommand, EventDto>, CreateEventHandler>();
            services.AddScoped<ICommandHandler<UpdateEventCommand, EventDto>, UpdateEventHandler>();
            services.AddScoped<ICommandHandler<CancelEventCommand, bool>, CancelEventHandler>();
            services.AddScoped<ICommandHandler<CreateUserCommand, UserDto>, CreateUserHandler>();
            services.AddScoped<ICommandHandler<UpdateUserCommand, UserDto>, UpdateUserHandler>();

            services.AddScoped<IBookingRepository, BookingRepository>();

            services.AddScoped<IQueryHandler<GetBookingListQuery, List<BookingDto>>, GetBookingListQueryHandler>();
            services.AddScoped<ICommandHandler<CreateBookingCommand, BookingDto>, CreateBookingHandler>();
            services.AddScoped<ICommandHandler<UpdateBookingCommand, BookingDto>, UpdateBookingHandler>();
            services.AddScoped<ICommandHandler<CancelBookingCommand, bool>, CancelBookingHandler>();
            services.AddTransient<Func<BookingDto?, int?, BookingFormDialog>>(sp => (existingBooking, preselectedEventId) =>
    new BookingFormDialog(
        sp.GetRequiredService<ICommandHandler<CreateBookingCommand, BookingDto>>(),
        sp.GetRequiredService<ICommandHandler<UpdateBookingCommand, BookingDto>>(),
        sp.GetRequiredService<IQueryHandler<GetEventListQuery, List<EventDto>>>(),
        sp.GetRequiredService<IQueryHandler<GetUserListQuery, List<UserDto>>>(),
        existingBooking,
        preselectedEventId));

            services.AddTransient<BookingForm>();
            services.AddTransient<Func<BookingForm>>(sp => () => sp.GetRequiredService<BookingForm>());

            services.AddTransient<Func<BookingDto?, BookingFormDialog>>(sp => existingBooking =>
                new BookingFormDialog(
                    sp.GetRequiredService<ICommandHandler<CreateBookingCommand, BookingDto>>(),
                    sp.GetRequiredService<ICommandHandler<UpdateBookingCommand, BookingDto>>(),
                    sp.GetRequiredService<IQueryHandler<GetEventListQuery, List<EventDto>>>(),
                    sp.GetRequiredService<IQueryHandler<GetUserListQuery, List<UserDto>>>(),
                    existingBooking));


            services.AddTransient<EventsForm>();
            services.AddTransient<UsersForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<Func<EventDto?, EventFormDialog>>(sp => existingEvent =>
                new EventFormDialog(
                sp.GetRequiredService<ICommandHandler<CreateEventCommand, EventDto>>(),
                sp.GetRequiredService<ICommandHandler<UpdateEventCommand, EventDto>>(),
                existingEvent));
            services.AddTransient<Func<EventsForm>>(sp => () => sp.GetRequiredService<EventsForm>());
            services.AddTransient<Func<UsersForm>>(sp => () => sp.GetRequiredService<UsersForm>());
            services.AddTransient<Func<UserDto?, UserFormDialog>>(sp => existingUser =>
               new UserFormDialog(
               sp.GetRequiredService<ICommandHandler<CreateUserCommand, UserDto>>(),
               sp.GetRequiredService<ICommandHandler<UpdateUserCommand, UserDto>>(),
               existingUser));
        }
    }

}