using Shouldly;
using static Traffic.TrafficLight;

namespace Traffic.Tests;

public class TrafficLightTests
{
    [Fact]
    public async Task GivenGreen_WhenYield_ThenYellow()
    {
        // Given
        TrafficLight sut = new TrafficLight(TrafficLightState.Green);

        // When
        await sut.FireAsync(TrafficLightTrigger.Yield);

        // Then
        sut.State.ShouldBe(TrafficLightState.Yellow);
    }
}