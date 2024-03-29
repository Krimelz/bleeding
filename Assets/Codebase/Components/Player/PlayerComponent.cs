using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
	[SerializeField]
	private SceneLoader _sceneLoader;

	private async void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Finish"))
		{
			await UniTask.WaitForSeconds(0.4f);
			await _sceneLoader.Load();
			_sceneLoader.Unload("Gameplay");
		}
	}
}
