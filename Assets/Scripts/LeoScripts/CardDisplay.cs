using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDisplay : MonoBehaviour, IDragHandler
{
    public Card card;

    public Image artworkImage;
    public Image articonImage;

    public Text statText;
    public Text numberText;
    void Start()
    {
        artworkImage.sprite = card.artWork;
        articonImage.sprite = card.artIcon;
        statText.text = card.stat.ToString();
    }
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }
    
}
