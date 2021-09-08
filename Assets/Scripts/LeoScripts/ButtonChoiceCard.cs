using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChoiceCard : MonoBehaviour
{
    public enum Slot { CHOICE1, CHOICE2, CHOICE3}
    public Slot typeOfCard = Slot.CHOICE1;

    
    public void DrawCard()
    {
        if (typeOfCard == Slot.CHOICE1)
        {

        }
        else if (typeOfCard == Slot.CHOICE2)
        {

        }
        else if (typeOfCard == Slot.CHOICE3)
        {

        }
    }
}
