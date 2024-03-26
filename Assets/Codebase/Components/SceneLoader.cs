using Codebase.Infrastructure.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[SerializeField]
	private string _sceneName;
	[SerializeField]
	private LoadSceneMode _loadSceneMode;
	[SerializeField]
	private bool loadOnStart;

	private SceneService _sceneService;

	[Inject]
	private void Construct(SceneService sceneService)
	{
		_sceneService = sceneService;
	}

	private void Start()
	{
		if (loadOnStart)
		{
			Load().Forget();
		}
	}

	public async UniTask Load()
	{
		await _sceneService.Load(_sceneName, _loadSceneMode).ToUniTask();
	}

	public async void Unload(string name)
	{
		await _sceneService.Unload(name);
	}
}
