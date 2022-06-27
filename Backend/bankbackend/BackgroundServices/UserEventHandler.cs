using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using System.Data;
using EasyNetQ;


namespace bankbackend.BackgroundServices
{
      
    public class UserRequest
    {
        public long Id { get; set; }

        public UserRequest(long id)
        {
            Id = id;
        }

    }

    public class UserResponse
    {
        public String Name { get; set; }
        public UserResponse() { }
    }

    public class UserEventHandler : BackgroundService
    {

        private readonly IBus _bus;

        public UserEventHandler(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _bus.Rpc.RespondAsync<UserRequest, UserResponse>(ProcessUserRequest);
        }

        private UserResponse ProcessUserRequest(UserRequest userRequest)
        {
            return new UserResponse(){ Name = "Ipsum" };
        }
    }  
}


