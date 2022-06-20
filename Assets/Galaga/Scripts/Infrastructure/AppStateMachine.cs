using System;
using System.Collections.Generic;
using Galaga.Infrastructure.States;
using Zenject;

namespace Galaga.Infrastructure
{
  public class AppStateMachine : IInitializable
  {
    private readonly DiContainer _diContainer;
    private readonly Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;
    
    /*
     * States Sequence:
     * 
     * BootstrapState
     * LoadConfigState 
     * LoadProgressState
     * LoadLevelState
     * AppLoopState
     * 
     */
    
    public AppStateMachine(DiContainer diContainer)
    {
      _diContainer = diContainer;
    }

    public void Initialize()
    {
      Enter<BootstrapState>();
    }

    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
    {
      TState state = ChangeState<TState>();
      state.Enter(payload);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      _activeState?.Exit();
      TState state = GetState<TState>();
      _activeState = state;
      return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState =>
      _diContainer.Resolve<TState>();
  }
}