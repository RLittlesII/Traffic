using Stateless;

namespace Traffic;

public class TrafficLight : StateMachine<TrafficLight.TrafficLightState, TrafficLight.TrafficLightTrigger>
{
    public TrafficLight(Func<TrafficLightState> stateAccessor, Action<TrafficLightState> stateMutator) : base(stateAccessor, stateMutator) { }

    public TrafficLight(TrafficLightState initialState) : base(initialState)
    {
        Configure(TrafficLightState.Green)
           .Permit(TrafficLightTrigger.Stop, TrafficLightState.Yellow);

        Configure(TrafficLightState.Yellow)
           .Permit(TrafficLightTrigger.Stop, TrafficLightState.Red);

        Configure(TrafficLightState.Red)
           .Permit(TrafficLightTrigger.Go, TrafficLightState.Green);
    }

    public TrafficLight(Func<TrafficLightState> stateAccessor, Action<TrafficLightState> stateMutator, FiringMode firingMode) : base(
        stateAccessor,
        stateMutator,
        firingMode
    ) { }

    public TrafficLight(TrafficLightState initialState, FiringMode firingMode) : base(initialState, firingMode) { }

    public Task Go() => FireAsync(TrafficLightTrigger.Go);
    public Task Yield() => FireAsync(TrafficLightTrigger.Stop);
    public Task Stop() => FireAsync(TrafficLightTrigger.Stop);

    public enum TrafficLightTrigger
    {
        Stop,
        Yield, // TODO: [rlittlesii: May 02, 2025] Evaluate whether we need this trigger and how the state machine could be configured without it.
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