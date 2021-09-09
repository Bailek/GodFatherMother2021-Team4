using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardEffect : MonoBehaviour
{
    public GameObject panel1;
    public GameObject Touret1;
    public Drop drop;
    public enum Slot { TOURET, HEAL, ZAPPER, LAZER, MEGABOOSTER }
    public Slot typeOfCard = Slot.TOURET;
    public CardDisplay currentCard;
    private void Start()
    {
        drop.DropCallback += ActivateEffect;
    }
    public void EndEffect()
    {
        switch (currentCard.typeOfCard)
        {
            case CardDisplay.Slot.TOURET:
                Debug.Log("Toutrelle activate");
                DespawnTouret();
                break;

            case CardDisplay.Slot.HEAL:
                Debug.Log("Heal activate");
                Heal();
                break;

            case CardDisplay.Slot.LAZER:
                Debug.Log("Lazer activate");
                Lazer();
                break;

            case CardDisplay.Slot.MEGABOOSTER:
                Debug.Log("MegaBooster activate");
                Booster();
                break;
        }
    }

    private void DespawnTouret()
    {
        Touret1.SetActive(false);
    }

    public void ActivateEffect(CardDisplay obj)
    {
        if(currentCard != null)
        {
            EndEffect();
        }
        
        currentCard = obj;
        switch (obj.typeOfCard)
        {
            case CardDisplay.Slot.TOURET:
                Debug.Log("Toutrelle activate");
                SpawnTouret();
                break;

            case CardDisplay.Slot.HEAL:
                Debug.Log("Heal activate");
                Heal();
                break;

            case CardDisplay.Slot.LAZER:
                Debug.Log("Lazer activate");
                Lazer();
                break;

            case CardDisplay.Slot.MEGABOOSTER:
                Debug.Log("MegaBooster activate");
                Booster();
                break;
        }


    }
    

    private void Booster()
    {
        
    }

    private void Lazer()
    {

    }

    private void SpawnTouret()
    {
        Touret1.SetActive(true);
        
    }

    public void Heal()
    {
        //Spaceship.instance.HealShip(100);
    }


}
