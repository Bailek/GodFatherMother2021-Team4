using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Drop : MonoBehaviour, IDropHandler
{
    public Drag.Slot typeOfCard = Drag.Slot.TOURET;
    public Transform newParent = null;
    
    
    public void OnDrop(PointerEventData eventData)
    {
        CardDisplay c = eventData.pointerDrag.GetComponent<CardDisplay>();
        if (c != null)
        {
            c.positionToReturnTo = this.transform.position;
            c.OnPosition();
        }
    }
}
