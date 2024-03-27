using UnityEngine;

namespace Codebase.Infrastructure.Services.Inputs
{
	public interface IInputService
	{
		Vector2 Movement { get; }
		Vector2 Fire { get; }
	}
}
