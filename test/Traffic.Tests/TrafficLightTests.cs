using Shouldly;
using static Traffic.TrafficLight;

namespace Traffic.Tests;

public class TrafficLightTests
{
    public class GoTests
    {
        [Fact]
        public async Task GivenGreen_WhenGo_ThenException()
        {
            // Given
            TrafficLight sut = new TrafficLight(TrafficLightState.Green);

            // When
            var result = await Record.ExceptionAsync(async () => await sut.Go());

            // Then
            result.ShouldBeOfType<InvalidOperationException>();
        }

        [Fact]
        public async Task GivenYellow_WhenGo_ThenException()
        {
            // Given
            var sut = new TrafficLight(TrafficLightState.Yellow);

            // When
            var result = await Record.ExceptionAsync(async () => await sut.Go());

            // Then
            result.ShouldBeOfType<InvalidOperationException>();
        }

        [Fact]
        public async Task GivenRed_WhenGo_ThenGreen()
        {
            // Given
            var sut = new TrafficLight(TrafficLightState.Red);

            // When
            await sut.Go();

            // Then
            sut.State.ShouldBe(TrafficLightState.Green);
        }
    }

    public class StopTests
    {
        [Fact]
        public async Task GivenGreen_WhenStop_ThenException()
        {
            // Given
            TrafficLight sut = new TrafficLight(TrafficLightState.Green);

            // When
            await sut.Stop();

            // Then
            sut.State.ShouldBe(TrafficLightState.Yellow);
        }

        [Fact]
        public async Task GivenYellow_WhenStop_ThenRed()
        {
            // Given
            var sut = new TrafficLight(TrafficLightState.Yellow);

            // When
            await sut.Stop();

            // Then
            sut.State.ShouldBe(TrafficLightState.Red);
        }

        [Fact]
        public async Task GivenRed_WhenStop_ThenException()
        {
            // Given
            var sut = new TrafficLight(TrafficLightState.Red);

            // When
            var result = await Record.ExceptionAsync(async () => await sut.Stop());

            // Then
            result.ShouldBeOfType<InvalidOperationException>();
        }
    }

    public class YieldTests
    {
        [Fact]
        public async Task GivenGreen_WhenYield_ThenYellow()
        {
            // Given
            TrafficLight sut = new TrafficLight(TrafficLightState.Green);

            // When
            await sut.Yield();

            // Then
            sut.State.ShouldBe(TrafficLightState.Yellow);
        }

        [Fact]
        public async Task GivenYellow_WhenYield_ThenYellow()
        {
            // Given
            var sut = new TrafficLight(TrafficLightState.Yellow);

            // When
            var result = await Record.ExceptionAsync(async () => await sut.Yield());

            // Then
            result.ShouldBeOfType<InvalidOperationException>();
        }

        [Fact]
        public async Task GivenRed_WhenYield_ThenException()
        {
            // Given
            var sut = new TrafficLight(TrafficLightState.Red);

            // When
            var result = await Record.ExceptionAsync(async () => await sut.Yield());

            // Then
            result.ShouldBeOfType<InvalidOperationException>();
        }
    }
}