using Codebase.Infrastructure.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.ResourceProviders;

public class SceneLoader : MonoBehaviour
{
	[SerializeField]
	private string _sceneName;

	private SceneService _sceneService;

	private SceneInstance _scene;

	[Inject]
	private void Construct(SceneService sceneService)
	{
		_sceneService = sceneService;
	}

	public async UniTask Load()
	{
		_scene = await _sceneService.Load(_sceneName, false, LoadSceneMode.Single);
	}

	public void Activate()
	{
		_scene.ActivateAsync();
	}	
}
