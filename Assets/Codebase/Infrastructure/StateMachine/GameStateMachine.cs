using Codebase.Infrastructure.StateMachine.States;
using System;
using System.Collections.Generic;
using Zenject;

namespace Codebase.Infrastructure.StateMachine
{
	public class GameStateMachine : IInitializable
    {
		private readonly StateFactory _stateFactory;

		private Dictionary<Type, IExitableState> _states;
		private IExitableState _currentState;

		public GameStateMachine(StateFactory stateFactory)
		{
			_stateFactory = stateFactory;
		}

		public void Initialize()
		{
			_states = new Dictionary<Type, IExitableState>
			{
				[typeof(BootState)] = _stateFactory.CreateState<BootState>(),
			};

			Enter<BootState>();
		}

		public void Enter<TState>() where TState : class, IPayLoadedState
		{
			IPayLoadedState state = ChangeState<TState>();
			state.Enter();
		}

		public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadedState<TPayLoad>
		{
			TState state = ChangeState<TState>();
			state.Enter(payLoad);
		}

		private TState ChangeState<TState>() where TState : class, IExitableState
		{
			_currentState?.Exit();

			TState state = GetState<TState>();
			_currentState = state;

			return state;
		}

		private TState GetState<TState>() where TState : class, IExitableState =>
			_states[typeof(TState)] as TState;
	}
}