using System;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using Cysharp.Threading.Tasks;

namespace Codebase.Infrastructure.Services
{
	public class SceneService
    {
		public UniTask<SceneInstance> Load(string name, bool activateOnLoad, LoadSceneMode loadMode = LoadSceneMode.Additive)
		{
			return Addressables.LoadSceneAsync(name, loadMode, activateOnLoad).Task.AsUniTask();
		}

		public async UniTask Unload(Scene scene)
		{
			await SceneManager.UnloadSceneAsync(scene, UnloadSceneOptions.None).ToUniTask();
		}

		public async UniTask Unload(string name, Action onUnloaded = null)
		{
			await SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(name), UnloadSceneOptions.None).ToUniTask();
		}

		public void SetActiveScene(string name)
		{
			SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
		}

		public void SetActiveScene(Scene scene)
		{
			SceneManager.SetActiveScene(scene);
		}

		public Scene GetActiveScene()
		{
			return SceneManager.GetActiveScene();
		}
	}
}
