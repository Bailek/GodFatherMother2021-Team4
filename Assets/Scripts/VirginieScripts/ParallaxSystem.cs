using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ParallaxSystem : MonoBehaviour
{
    public float speed = 0.1f;

    private RawImage img;
    private Camera cam;
    private RectTransform rectTransform;
    private float camHeight, camWidth;
    private float minHeight, maxHeight, minWidth, maxWidth;
    private float length;

    private void Start()
    {
        cam = Camera.main;
        camHeight = cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        minHeight = -camHeight;
        maxHeight = camHeight;
        minWidth = -camWidth;
        maxWidth = camWidth;

        img = GetComponent<RawImage>();
        rectTransform = GetComponent<RectTransform>();
        length = rectTransform.rect.width; 
    }

    private void Update()
    {
        Rect rect = img.uvRect;
        rect.x += speed;
        img.uvRect = rect;
    }
}
