using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Codebase.Components.UI
{
	public class EventHandlerComponent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, 
		IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
	{
		public event System.Action OnClick;
		public event System.Action OnDown;
		public event System.Action OnEnter;
		public event System.Action OnExit;
		public event System.Action OnUp;

		public void OnPointerClick(PointerEventData eventData)
		{
			OnClick?.Invoke();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			OnDown?.Invoke();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			OnEnter?.Invoke();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			OnExit?.Invoke();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			OnUp?.Invoke();
		}
	}
}