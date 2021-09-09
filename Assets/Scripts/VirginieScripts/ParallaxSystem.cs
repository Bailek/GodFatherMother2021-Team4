using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ParallaxSystem : MonoBehaviour
{
    public float speed = 0.1f;

    private RawImage img;
    private void Start()
    {
        img = GetComponent<RawImage>(); 
    }

    private void Update()
    {
        Rect rect = img.uvRect;
        rect.x += speed;
        img.uvRect = rect;
    }
}
