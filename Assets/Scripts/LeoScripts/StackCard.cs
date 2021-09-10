using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StackCard : MonoBehaviour
{
    public CardDisplay.Slot typeOfStack = CardDisplay.Slot.TOURET;
    public int numberStack;
    public CardDisplay PrefabCard;
    public GameObject LastPrefab;
    public GameObject Canvas;
    private bool stackNoCard = false;
    public void Start()
    {
        if (numberStack > 0)
        {
            CreatPrefab();
        }
    }
    public void Update()
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
