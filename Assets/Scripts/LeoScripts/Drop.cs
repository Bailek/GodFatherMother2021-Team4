using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Drop : MonoBehaviour, IDropHandler
{
    
    public Action<CardDisplay> DropCallback;
    public enum ZoneDrop { Front, Back}
    public ZoneDrop typeOfZone = ZoneDrop.Front;
    public void OnDrop(PointerEventData eventData)
    {
        CardDisplay c = eventData.pointerDrag.GetComponent<CardDisplay>();
        if (c != null)
        {
            Debug.Log("Drop on Zone" + typeOfZone);
            c.positionToReturnTo = this.transform.position;
            c.OnPosition();
            DropCallback(c);
        }
    }

}
