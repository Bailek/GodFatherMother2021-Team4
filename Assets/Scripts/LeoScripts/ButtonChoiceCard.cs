using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChoiceCard : MonoBehaviour
{
    public ChoiceCard choiceCard;
    public enum Slot { CHOICE1, CHOICE2, CHOICE3}
    public Slot typeOfCard = Slot.CHOICE1;

    
    public void DrawCard()
    {
        if (typeOfCard == Slot.CHOICE1)
        {
            Debug.Log("super 1");
            choiceCard.GiveChoice1();
        }
        else if (typeOfCard == Slot.CHOICE2)
        {
            Debug.Log("cool 2");
            choiceCard.GiveChoice2();
        }
        else if (typeOfCard == Slot.CHOICE3)
        {
            Debug.Log("genial 3");
            choiceCard.GiveChoice3();
        }
    }
}
