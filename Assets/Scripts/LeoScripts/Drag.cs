using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum Slot { TOURET,HEAL,BOOST,HAND}
    public Slot typeOfCard = Slot.TOURET;
    public Transform parentToReturnTo = null;
    public GameObject PanelCard;
    public CardDisplay cardDisplay;

    
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        
        //parentToReturnTo = this.transform.parent;
        //this.transform.SetParent(this.transform.parent.parent);
        //GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        //this.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        //if (LastCard != null)
        //{
        //    LastCard.GetComponent<CardDisplay>();
        //    Destroy(this.gameObject);
        //}
        //this.transform.SetParent(parentToReturnTo);
        //GetComponent<CanvasGroup>().blocksRaycasts = true;
        
    }

    
}
