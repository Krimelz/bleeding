using Codebase.Infrastructure.Services.Inputs;
using UnityEngine;
using Zenject;

namespace Codebase.Components.Player
{
	[RequireComponent(typeof(CharacterController))]
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField]
		private float _movementSpeed;

		private CharacterController _characterController;
		private IInputService _inputService;

		private Vector3 _movementDirection;
		private Vector3 _lookDirection;

		[Inject]
		private void Construct(IInputService inputService)
		{
			_inputService = inputService;
		}

		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
		}

		private void Update()
		{
			_movementDirection = new Vector3(
				_inputService.Movement.x, 
				0f, 
				_inputService.Movement.y
			);

			_lookDirection = new Vector3(
				_inputService.Fire.x, 
				0f, 
				_inputService.Fire.y
			);

			if (_movementDirection != Vector3.zero)
			{
				Move();
			}

			if (_lookDirection != Vector3.zero)
			{
				Look();
			}
		}

		private void Move()
		{
			var motion = _movementSpeed * Time.deltaTime * _movementDirection;
			_characterController.Move(motion);

			transform.forward = _movementDirection;
		}

		private void Look()
		{
			transform.forward = _lookDirection;
		}
	}
}
