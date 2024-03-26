using Codebase.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Codebase.Components.Player
{
	[RequireComponent(typeof(CharacterController))]
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField]
		private float _movementSpeed;
		[SerializeField]
		private Joystick _joystick;

		private CharacterController _characterController;
		private InputService _inputService;

		[Inject]
		private void Construct(InputService inputService)
		{
			_inputService = inputService;
		}

		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
		}

		private void Update()
		{
			var direction = new Vector3(_joystick.Direction.x, 0f, _joystick.Direction.y);
			var motion = _movementSpeed * Time.deltaTime * direction;
			var flags = _characterController.Move(motion);

			transform.forward = direction;
		}
	}
}
