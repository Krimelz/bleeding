using Codebase.Components.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Codebase.Components.UI
{
	public class MainMenuComponent : MonoBehaviour
	{
		[SerializeField]
		private ButtonComponent _start;
		[SerializeField]
		private ButtonComponent _sound;
		[SerializeField]
		private ButtonComponent _music;
		[SerializeField]
		private ButtonComponent _exit;
		[SerializeField]
		private Image _startFade;
		[SerializeField]
		private Image _exitFade;

		private bool _isEnabledSound = true;
		private bool _isEnabledMusic = true;

		private void Start()
		{
			_start.EventHandler.OnClick += async () =>
			{
				if (_start.Clickable)
				{
					_startFade.raycastTarget = true;
					await _startFade.DOFade(1f, 1f).AwaitForComplete();
					await _startFade.DOFade(0f, 0.2f).AwaitForComplete();
					_startFade.raycastTarget = false;
				}
			};

			_sound.EventHandler.OnClick += () =>
			{
				if (_sound.Clickable)
				{
					_isEnabledSound = !_isEnabledSound;
					_sound.SetActive(_isEnabledSound);
				}
			};

			_music.EventHandler.OnClick += () =>
			{
				if (_music.Clickable)
				{
					_isEnabledMusic = !_isEnabledMusic;
					_music.SetActive(_isEnabledMusic);
				}
			};

			_exit.EventHandler.OnClick += async () =>
			{
				if (_exit.Clickable)
				{
					_exitFade.raycastTarget = true;
					await _exitFade.DOFade(1f, 1f).AwaitForComplete();
					Application.Quit();

					#if UNITY_EDITOR
					await _exitFade.DOFade(0f, 0.2f).AwaitForComplete();
					_exitFade.raycastTarget= false;
					#endif
				}
			};
		}
	}
}