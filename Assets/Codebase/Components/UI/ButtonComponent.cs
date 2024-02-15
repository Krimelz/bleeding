using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Codebase.Components.UI
{
	[RequireComponent(typeof(EventHandlerComponent))]
	public class ButtonComponent : MonoBehaviour
	{
		[field: SerializeField]
		public bool Clickable { get; set; } = true;
		public EventHandlerComponent EventHandler { get; private set; }

		[Header("Render Target")]
		[SerializeField]
		private TMP_Text _text;
		[Header("Duration")]
		[SerializeField]
		private float _shakePositionDuration = 1f;
		[SerializeField]
		private float _shakeRotationDuration = 1f;
		[SerializeField]
		private float _shakeScaleDuration = 1f;
		[Header("Strength")]
		[SerializeField]
		private float _shakePositionStrength = 10f;
		[SerializeField]
		private float _shakeRotationStrength = 2f;
		[SerializeField]
		private float _shakeScaleStrength = 0.3f;
		[Header("Sounds")]
		[SerializeField]
		private AudioClip _hoverClip;
		[SerializeField]
		private AudioClip _clickClip;

		private Sequence _enterSequence;
		private Sequence _exitSequence;
		private Sequence _clickSequence;

		private void Awake()
		{
			EventHandler = GetComponent<EventHandlerComponent>();
		}

		private void Start()
		{
			EventHandler.OnEnter += () =>
			{
				AudioSource.PlayClipAtPoint(_hoverClip, Vector3.zero);

				_exitSequence.Complete();
				_enterSequence = DOTween.Sequence()
					.Join(transform.DOShakePosition(_shakePositionDuration, _shakePositionStrength))
					.Join(transform.DOShakeRotation(_shakeRotationDuration, Vector3.forward * _shakeRotationStrength))
					.Play();
			};

			EventHandler.OnExit += () =>
			{
				_enterSequence.Complete();
				_exitSequence = DOTween.Sequence()
					.Join(transform.DOShakePosition(_shakePositionDuration, _shakePositionStrength))
					.Join(transform.DOShakeRotation(_shakeRotationDuration, Vector3.forward * _shakeRotationStrength))
					.Play();
			};

			EventHandler.OnClick += () =>
			{
				if (Clickable)
				{
					AudioSource.PlayClipAtPoint(_clickClip, Vector3.zero);

					_clickSequence.Complete();
					_clickSequence = DOTween.Sequence()
						.Append(transform.DOShakeScale(_shakeScaleDuration, _shakeScaleStrength, 10))
						.Play();
				}
			};
		}

		public void SetActive(bool value)
		{
			if (_text == null)
			{
				Debug.LogWarning($"{gameObject.name} has no text render target!");
				return;
			}

			_text.fontStyle = value ? FontStyles.Normal : FontStyles.Strikethrough;
		}
	}
}