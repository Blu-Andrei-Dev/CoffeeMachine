using CoffeeMachine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Tests.TestDoubles
{
    public class FakeWeatherService : IWeatherService
    {
        private readonly double _temperature;

        public FakeWeatherService(double temperature)
        {
            _temperature = temperature;
        }

        public Task<double> GetCurrentTemperatureAsync()
        {

            return Task.FromResult(_temperature);
        }
    }

}
