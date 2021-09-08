using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Drop : MonoBehaviour, IDropHandler
{
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
