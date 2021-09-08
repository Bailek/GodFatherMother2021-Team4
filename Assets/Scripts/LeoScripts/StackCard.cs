using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StackCard : MonoBehaviour,IPointerDownHandler, IDropHandler,IDragHandler
{
    public enum Slot { TOURET, HEAL, ZAPPER, LAZER, MEGABOOSTER }
    public Slot typeOfStack = Slot.TOURET;

    public Card.Slot typeOfCard = Card.Slot.TOURET;

    public int numberStack;
    public GameObject PrefabCard;
    public GameObject LastPrefab;
    
    public void CreatPrefab()
    {
        GameObject newCard = Instantiate<GameObject>(PrefabCard);
        newCard.transform.position = this.transform.position;
        newCard.transform.parent = this.transform;
        LastPrefab = newCard;
        numberStack--;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (numberStack > 0)
        {
            CreatPrefab();
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        LastPrefab.transform.position = eventData.position;
    }
    public void OnDrop(PointerEventData eventData)
    {
        LastPrefab = null;
        Card d = eventData.pointerDrag.GetComponent<Card>();
        if (d != null)
        {
            if (typeOfCard == d.typeOfCard)
            {
                Debug.Log("Drop");
            }

        }
    }
    public void Update()
    {
        
    }

}
