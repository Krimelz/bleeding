using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
	[SerializeField]
	private float _force = 4f;

	private Rigidbody _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	public void Shoot(Vector3 direction)
	{
		_rigidbody.AddForce(direction * _force, ForceMode.Impulse);
	}
}
