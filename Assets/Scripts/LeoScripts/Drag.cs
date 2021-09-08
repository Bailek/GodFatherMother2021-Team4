using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum Slot { TOURET,HEAL,BOOST,HAND}
    public Slot typeOfCard = Slot.TOURET;
    public Vector3 positionToReturnTo;
    public GameObject PanelCard;
    public CardDisplay cardDisplay;

    
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


}
