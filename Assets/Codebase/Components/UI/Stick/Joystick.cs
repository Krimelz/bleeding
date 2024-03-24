using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	[SerializeField]
	private RectTransform _holder;
	[SerializeField]
	private RectTransform _stick;

	public Vector2 Direction { get; private set; }

	public void OnPointerDown(PointerEventData eventData)
	{
		OnDrag(eventData);
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
			_holder, eventData.position, eventData.pressEventCamera, out var position))
		{
			float maxLength = _holder.rect.width / 2f;
			Vector2 clamped = Vector2.ClampMagnitude(position, maxLength);

			_stick.anchoredPosition = clamped;
			Direction = clamped / maxLength;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_stick.anchoredPosition = _holder.anchoredPosition;
		Direction = Vector2.zero;
	}
}
