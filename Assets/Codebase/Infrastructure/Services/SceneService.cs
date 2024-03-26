using System;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Codebase.Infrastructure.Services
{
	public class SceneService
    {
		public AsyncOperation Load(string name, LoadSceneMode loadMode = LoadSceneMode.Additive)
		{
			return SceneManager.LoadSceneAsync(name, loadMode);
		}

		public async UniTask Unload(Scene scene)
		{
			await SceneManager.UnloadSceneAsync(scene, UnloadSceneOptions.None).ToUniTask();
		}

		public async UniTask Unload(string name)
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
