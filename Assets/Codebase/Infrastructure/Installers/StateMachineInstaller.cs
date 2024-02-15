using Codebase.Infrastructure.StateMachine;
using Zenject;

namespace Codebase.Infrastructure.Installers
{
	public class StateMachineInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<StateFactory>().AsSingle().NonLazy();

			Container.Bind<BootState>().AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
		}
	}
}
