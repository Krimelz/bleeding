using Codebase.Infrastructure.Services.Inputs;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Codebase.Components.Player
{
	public class PlayerFire : MonoBehaviour
	{
		[SerializeField]
		private float _fireRate;

		private IInputService _inputService;

		private bool _canFire = true;

		[Inject]
		private void Construct(IInputService inputService)
		{
			_inputService = inputService;
		}

		private void Update()
		{
			if (_inputService.Fire != Vector2.zero && _canFire)
			{
				Fire().Forget();
			}
		}

		private async UniTask Fire()
		{
			_canFire = false;
			await transform.DOShakePosition(0.2f, 0.5f, 30, fadeOut: true);
			await UniTask.WaitForSeconds(_fireRate);
			Debug.Log("<color=yellow>Fire!</color>");
			_canFire = true;
		}
	}
}
