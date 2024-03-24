using System;
using UnityEngine;
using Zenject;

namespace Codebase.Infrastructure.Services
{
	public class InputService
	{
		public Vector3 Movement => new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
	}
}
