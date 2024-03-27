using UnityEngine;

namespace Codebase.Infrastructure.Services.Inputs
{
	public class StandaloneInputService : InputService
	{
		public override Vector2 Movement =>
			new Vector2(Input.GetAxisRaw(Horizontal), Input.GetAxisRaw(Vertical));

		public override Vector2 Fire =>
			Vector2.zero;
	}
}
