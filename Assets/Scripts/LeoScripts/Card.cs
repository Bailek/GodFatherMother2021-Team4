using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public enum Slot { TOURET, HEAL, ZAPPER, LAZER, MEGABOOSTER }
    public Slot typeOfCard = Slot.TOURET;

    public Sprite artWork;
    public Sprite artIcon;
    public int stat;
    public int number;
}
