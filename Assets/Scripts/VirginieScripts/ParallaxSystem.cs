using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ParallaxSystem : MonoBehaviour
{
    public float speed = 100.0f;

    private RawImage img;
    private Camera cam;
    private RectTransform rectTransform;
    [HideInInspector]
    public float camHeight, camWidth;
    private float minHeight, maxHeight, minWidth, maxWidth;
    private float length;

    private void Start()
    {
        cam = Camera.main;
        camHeight = cam.orthographicSize * 2f;
        camWidth = camHeight * cam.aspect;

        minHeight = -camHeight;
        maxHeight = camHeight;
        minWidth = -camWidth;
        maxWidth = camWidth;

        img = GetComponent<RawImage>();
        rectTransform = GetComponent<RectTransform>();
        length = rectTransform.rect.width;
    }

    public virtual void Update()
    {
        //faster movement
        //transform.position = new Vector3(
        //    transform.position.x - speed * Time.deltaTime,
        //    transform.position.y,
        //    0);

        rectTransform.anchoredPosition = new Vector2(
            rectTransform.anchoredPosition.x - speed * Time.deltaTime,
            rectTransform.anchoredPosition.y);
    }
}
