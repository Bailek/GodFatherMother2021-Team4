using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StackCard : MonoBehaviour
{
    public enum Slot { TOURET, HEAL, ZAPPER, LAZER, MEGABOOSTER }
    public Slot typeOfStack = Slot.TOURET;

    public Drag.Slot typeOfCard = Drag.Slot.TOURET;
    public Drag drag;
    public int numberStack;
    public CardDisplay PrefabCard;
    public GameObject LastPrefab;
    public GameObject Canvas;

    public void Start()
    {
        if (numberStack > 0)
        {
            CreatPrefab();
        }
    }

    internal void OnCardPosition()
    {
        if(numberStack > 0)
        {
            CreatPrefab();
        }
    }

    public void CreatPrefab()
    {
        CardDisplay newCard = Instantiate<CardDisplay>(PrefabCard, this.transform);
        //newCard.transform.position = this.transform.position;
        numberStack--;
        newCard.SetStack(this);
    }
    

}
