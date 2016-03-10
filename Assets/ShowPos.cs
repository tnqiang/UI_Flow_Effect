using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShowPos : MonoBehaviour, IPointerClickHandler 
{
	Transform trans;

	void Start()
	{
        Canvas canvas = GetComponentInParent<Canvas>();
        Rect canvasRect = (canvas.transform as RectTransform).rect;
        Debug.Log("camera Rect(x, y, width, height): " +
                    canvasRect.x * canvas.transform.localScale.x + " " + canvasRect.y * canvas.transform.localScale.y + " " +
                    canvasRect.width * canvas.transform.localScale.x + " " + canvasRect.height * canvas.transform.localScale.y);

        Vector3 pos = transform.position;
        Debug.Log("world pos: " + pos);
        pos = new Vector3(pos.x, pos.y, 90);

		Rect rect = (transform as RectTransform).rect;      
		Debug.Log ("Rect(x, y, width, height): " + rect.x + " " + rect.y + " " + rect.width + " " + rect.height);

		if (null != canvas && null != canvas.worldCamera && RenderMode.ScreenSpaceOverlay != canvas.renderMode) 
		{
			Camera cam = canvas.worldCamera;
			pos = cam.WorldToScreenPoint (pos);
		}
		Debug.Log ("ui pos: " + pos);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log ("click pos: " + eventData.position);
	}
}
