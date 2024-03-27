using UnityEngine;

public class FrameRateSetter : MonoBehaviour
{
	private void Start()
	{
		Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
	}
}
