using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Codebase.Components.UI
{
	[RequireComponent(typeof(EventHandlerComponent))]
	public class ButtonComponent : MonoBehaviour
	{
		public EventHandlerComponent EventHandler { get; private set; }
		[field: SerializeField]
		public bool Clickable { get; set; } = true;

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