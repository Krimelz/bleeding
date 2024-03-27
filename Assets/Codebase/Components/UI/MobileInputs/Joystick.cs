using UnityEngine;
using UnityEngine.EventSystems;

public enum JoystickSide
{
	Left,
	Right,
}

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	[SerializeField]
	private JoystickSide _side;
	[SerializeField]
	private bool _dynamicHide;
	[SerializeField]
	private RectTransform _joystickArea;
	[SerializeField]
	private RectTransform _holder;
	[SerializeField]
	private RectTransform _stick;

	public static Vector2 LeftAxis { get; private set; }
	public static Vector2 RightAxis { get; private set; }

	private void Start()
	{
		Show(false);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		Show(true);
		_holder.position = eventData.position;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
			_holder, eventData.position, eventData.pressEventCamera, out var position))
		{
			float maxLength = _holder.rect.width / 2f;
			Vector2 clamped = Vector2.ClampMagnitude(position, maxLength);

			_stick.anchoredPosition = clamped;

			SetAxis(clamped / maxLength);
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_stick.anchoredPosition = _holder.pivot;
		SetAxis(Vector2.zero);
		Show(false);
	}

	private void SetAxis(Vector2 axis)
	{
		switch (_side)
		{
			case JoystickSide.Left:
				LeftAxis = axis;
				break;
			case JoystickSide.Right:
				RightAxis = axis;
				break;
		}
	}

	private void Show(bool value)
	{
		_holder.gameObject.SetActive(!_dynamicHide | value);
	}
}
