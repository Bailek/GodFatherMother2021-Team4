using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Drag.Slot typeOfCard = Drag.Slot.TOURET;
    public Transform newParent = null;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        d.parentToReturnTo = eventData.pointerDrag.GetComponent<Drop>().newParent;

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");

    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop to " + gameObject.name);
        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        if(d != null)
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
}
