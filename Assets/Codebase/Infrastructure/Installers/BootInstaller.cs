using Codebase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Codebase.Infrastructure.Installers
{
	public class BootInstaller : MonoInstaller
	{
		[SerializeField]
		private EventSystem _eventSystemPrefab;

		public override void InstallBindings()
		{
			BindEventSystem();
			BindInputService();
			BindSceneService();
		}

		private void BindEventSystem()
		{
			Container
				.Bind<EventSystem>()
				.FromComponentInNewPrefab(_eventSystemPrefab)
				.AsSingle()
				.NonLazy();
		}

		private void BindInputService()
		{
			Container
				.BindInterfacesAndSelfTo<InputService>()
				.AsSingle()
				.NonLazy();
		}

		private void BindSceneService()
		{
			Container
				.BindInterfacesAndSelfTo<SceneService>()
				.AsSingle()
				.NonLazy();
		}
	}
}
