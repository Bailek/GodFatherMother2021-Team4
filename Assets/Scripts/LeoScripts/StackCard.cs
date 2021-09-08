using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StackCard : MonoBehaviour,IPointerDownHandler, IDropHandler,IDragHandler, IPointerUpHandler, IEndDragHandler, IBeginDragHandler
{
    public enum Slot { TOURET, HEAL, ZAPPER, LAZER, MEGABOOSTER }
    public Slot typeOfStack = Slot.TOURET;

    public Drag.Slot typeOfCard = Drag.Slot.TOURET;
    public Drag drag;
    public int numberStack;
    public GameObject PrefabCard;
    public GameObject LastPrefab;
    public GameObject Canvas;
    public void CreatPrefab()
    {
        GameObject newCard = Instantiate<GameObject>(PrefabCard);
        newCard.transform.position = this.transform.position;
        newCard.transform.parent = Canvas.transform;
        LastPrefab = newCard;
        LastPrefab.GetComponent<CanvasGroup>().blocksRaycasts = false;
        numberStack--;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (numberStack > 0)
        {
            CreatPrefab();
        }
        else
        {
            return;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        drag.parentToReturnTo = LastPrefab.transform.parent;
        LastPrefab.transform.SetParent(LastPrefab.transform.parent);
        LastPrefab.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        drag.parentToReturnTo = LastPrefab.transform.parent;
        LastPrefab.transform.position = eventData.position;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        LastPrefab.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void OnDrop(PointerEventData eventData)
    {
        
        //LastPrefab.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //LastPrefab.transform.SetParent(drag.parentToReturnTo);
        //LastPrefab = null;
        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        Debug.Log("OnDrop to " + gameObject.name);
        if (d != null)
        {
            if (typeOfCard == d.typeOfCard)
            {
                d.parentToReturnTo = this.transform;
            }
            else if (typeOfCard == Drag.Slot.HAND)
            {
                d.parentToReturnTo = this.transform;
            }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        LastPrefab.GetComponent<CanvasGroup>().blocksRaycasts = true;
        LastPrefab.transform.SetParent(drag.parentToReturnTo);
        LastPrefab = null;

    }

}
