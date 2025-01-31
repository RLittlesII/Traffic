using Stateless;
using static TrafficLight.TrafficLight;

namespace TrafficLight;

public class TrafficLight : StateMachine<TrafficLightState, TrafficLightTrigger>
{
    public TrafficLight(Func<TrafficLightState> stateAccessor, Action<TrafficLightState> stateMutator) : base(stateAccessor, stateMutator) { }

    public TrafficLight(TrafficLightState initialState) : base(initialState) { }

    public TrafficLight(Func<TrafficLightState> stateAccessor, Action<TrafficLightState> stateMutator, FiringMode firingMode) : base(
        stateAccessor,
        stateMutator,
        firingMode
    ) { }

    public TrafficLight(TrafficLightState initialState, FiringMode firingMode) : base(initialState, firingMode) { }

    public enum TrafficLightTrigger
    {
        Stop,
        Yield,
        Go
    }

    public enum TrafficLightState
    {
        Red,
        Yellow,
        Green
    }

    public enum TrafficLightDirection
    {
        North,
        South,
        East,
        West
    }
}