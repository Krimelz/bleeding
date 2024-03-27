using UnityEngine;

namespace Codebase.Infrastructure.Services.Inputs
{
	public class MobileInputService : InputService
	{
		public override Vector2 Movement =>
			Joystick.LeftAxis;

		public override Vector2 Fire =>
			Joystick.RightAxis;
	}
}
