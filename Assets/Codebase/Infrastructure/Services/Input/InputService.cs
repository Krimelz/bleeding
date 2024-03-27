using UnityEngine;

namespace Codebase.Infrastructure.Services.Inputs
{
	public abstract class InputService : IInputService
	{
		protected const string Horizontal = "Horizontal";
		protected const string Vertical = "Vertical";

		public abstract Vector2 Movement { get; }
		public abstract Vector2 Fire { get; }
	}
}
