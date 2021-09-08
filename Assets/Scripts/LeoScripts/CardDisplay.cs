using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDisplay : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum Slot { TOURET, HEAL, BOOST, HAND }
    public Slot typeOfCard = Slot.TOURET;
    public Vector3 positionToReturnTo;
    public GameObject PanelCard;


    public void OnBeginDrag(PointerEventData eventData)
    {
        positionToReturnTo = this.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        this.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        this.transform.position = positionToReturnTo;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

    public Card card;

    public Image artworkImage;
    public Image articonImage;

    public Text statText;
    public Text numberText;
    private StackCard stackCard;

    public void OnPosition()
    {
        this.stackCard.OnCardPosition();
    }
    internal void SetStack(StackCard stackCard)
    {
        this.stackCard = stackCard;
    }
    void Start()
    {
        if (card != null)
        {
            artworkImage.sprite = card.artWork;
            articonImage.sprite = card.artIcon;
            statText.text = card.stat.ToString();
        }
    }
    
    
}
