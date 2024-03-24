using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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
		[Header("Ease")]
		[SerializeField]
		private Ease _ease;
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
		private AudioSource _audioSource;
		[SerializeField]
		private AudioClip _hoverClip;
		[SerializeField]
		private AudioClip _clickClip;
		[Header("Events")]
		[SerializeField]
		private UnityEvent OnClick;

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
				_audioSource.PlayOneShot(_hoverClip);

				_exitSequence.Complete();
				_enterSequence = DOTween.Sequence()
					.Join(_text.transform.DOShakePosition(_shakePositionDuration, _shakePositionStrength, 16))
					.Join(_text.transform.DOShakeRotation(_shakeRotationDuration, Vector3.forward * _shakeRotationStrength, 12))
					.Join(_text.transform.DOShakeScale(_shakeScaleDuration, _shakeScaleStrength, 12))
					.SetEase(_ease)
					.Play();
			};

			EventHandler.OnExit += (data) =>
			{
				_audioSource.PlayOneShot(_hoverClip, 0.5f);

				_enterSequence.Complete();
				_exitSequence = DOTween.Sequence()
					.Join(_text.transform.DOShakePosition(_shakePositionDuration, _shakePositionStrength, 5))
					.Join(_text.transform.DOShakeRotation(_shakeRotationDuration, Vector3.forward * _shakeRotationStrength, 6))
					.SetEase(_ease)
					.Play();
			};

			EventHandler.OnClick += () =>
			{
				if (Clickable)
				{
					_audioSource.PlayOneShot(_clickClip);

					_clickSequence.Complete();
					_clickSequence = DOTween.Sequence()
						.Append(_text.transform.DOShakeScale(_shakeScaleDuration, _shakeScaleStrength, 10))
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

		private void OnDestroy()
		{
			_enterSequence?.Kill();
			_exitSequence?.Kill();
			_clickSequence?.Kill();
		}
	}
}