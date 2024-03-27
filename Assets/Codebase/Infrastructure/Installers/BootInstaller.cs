using Codebase.Infrastructure.Services;
using Codebase.Infrastructure.Services.Inputs;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Codebase.Infrastructure.Installers
{
	public class BootInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject _eventSystemPrefab;

		public override void InstallBindings()
		{
			BindEventSystem();
			BindInputService();
			BindSceneService();
		}

		private void BindEventSystem()
		{
			Container.InstantiatePrefab(_eventSystemPrefab);

			Debug.LogFormat("<color=green>{0}</color>", nameof(EventSystem));
		}

		private void BindInputService()
		{
			Container
				.Bind<IInputService>()
				.To<MobileInputService>()
				.AsSingle()
				.NonLazy();

			Debug.LogFormat("<color=green>{0}</color>", nameof(IInputService));
		}

		private void BindSceneService()
		{
			Container
				.BindInterfacesAndSelfTo<SceneService>()
				.AsSingle()
				.NonLazy();

			Debug.LogFormat("<color=green>{0}</color>", nameof(SceneService));
		}
	}
}
