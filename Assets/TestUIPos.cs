using UnityEngine;
using System.Collections;

/// <summary>
/// 这个脚本的作用是在场景中选一个物体，然后在UI上选一个目标位置
/// 然后创建一个 UI 从场景中飞到我们的 UI 上
/// </summary>
public class TestUIPos : MonoBehaviour 
{
	public Camera sourceCamera;
	public GameObject source;
	public RectTransform targetRect;
	public RectTransform moveingRect;

	public float timeDuration = 1;
	private float timeFlow = 0;

	private Vector3 sourcePosition;
	private Vector3 targetPosition;

	void Start()
	{
		sourcePosition = sourceCamera.WorldToScreenPoint (source.transform.position);
		Canvas canvas = moveingRect.GetComponentInParent<Canvas> ();
		if (canvas.renderMode != RenderMode.ScreenSpaceOverlay && canvas.worldCamera != null) 
		{
			sourcePosition = canvas.worldCamera.ScreenToWorldPoint(sourcePosition);
		}

		targetPosition = targetRect.position;
		timeFlow = 0;
	}

	void Update()
	{
		if (timeFlow < timeDuration) 
		{
			moveingRect.position = sourcePosition * (timeDuration - timeFlow)/timeDuration + targetPosition * timeFlow/timeDuration;
			timeFlow += Time.deltaTime;
		}
	}
}
