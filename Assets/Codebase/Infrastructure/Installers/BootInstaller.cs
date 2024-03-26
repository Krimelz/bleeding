using Codebase.Infrastructure.Services;
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
				.BindInterfacesAndSelfTo<InputService>()
				.AsSingle()
				.NonLazy();

			Debug.LogFormat("<color=green>{0}</color>", nameof(InputService));
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
