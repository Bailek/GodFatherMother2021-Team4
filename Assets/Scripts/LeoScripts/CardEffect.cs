using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : MonoBehaviour
{
    public GameObject Touret;
    public GameObject Lazer;
    public Drop drop;
    public enum Effect { TOURET, HEAL, LAZER, MEGABOOSTER, NOTHING }
    public Effect typeOfEffect = Effect.NOTHING;
  
    public CardDisplay lastcurrentCard;
    public CardDisplay currentCard;

    private void Start()
    {
        drop.DropCallback += ActivateEffect;
    }
    public void EndEffect()
    {
        lastcurrentCard = currentCard;
        Debug.Log("EndEffect");
        if (typeOfEffect == Effect.TOURET)
        {
            Debug.Log("Toutrelle desactivate");
            typeOfEffect = Effect.NOTHING;
            Touret.SetActive(false);
            lastcurrentCard.gameObject.SetActive(false);
        }
        else if (typeOfEffect == Effect.HEAL)
        {
            Debug.Log("Heal desactivate");
            typeOfEffect = Effect.NOTHING;
            lastcurrentCard.gameObject.SetActive(false);
        }
        else if (typeOfEffect == Effect.LAZER)
        {
            Debug.Log("Lazer desactivate");
            typeOfEffect = Effect.NOTHING;
            Lazer.SetActive(false);
            lastcurrentCard.gameObject.SetActive(false);
        }
        else if (typeOfEffect == Effect.MEGABOOSTER)
        {
            Debug.Log("MegaBooster desactivate");
            typeOfEffect = Effect.NOTHING;
            WaveEvent.OnBoostStop.Invoke();
            lastcurrentCard.gameObject.SetActive(false);
        }

        
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
                //if(lastcurrentCard.typeOfCard != currentCard.typeOfCard)
                //{
                //}
                Debug.Log("Toutrelle activate");
                    typeOfEffect = Effect.TOURET;
                    Touret.SetActive(true);
                    lastcurrentCard = currentCard;
                    currentCard.gameObject.SetActive(false);
                
                break;

            case CardDisplay.Slot.HEAL:
                Debug.Log("Heal activate");
                typeOfEffect = Effect.HEAL;
                ShipManager.Instance.health.HealShip(20);
                lastcurrentCard = currentCard;
                currentCard.gameObject.SetActive(false);
                break;

            case CardDisplay.Slot.LAZER:
                //if (lastcurrentCard.typeOfCard != currentCard.typeOfCard)
                //{
                //}
                Debug.Log("Lazer activate");
                    typeOfEffect = Effect.LAZER;
                    Lazer.SetActive(true);
                    lastcurrentCard = currentCard;
                    currentCard.gameObject.SetActive(false);
                
                break;

            case CardDisplay.Slot.MEGABOOSTER:
                Debug.Log("MegaBooster activate");
                typeOfEffect = Effect.MEGABOOSTER;
                WaveEvent.OnBoostActivated.Invoke();
                lastcurrentCard = currentCard;
                currentCard.gameObject.SetActive(false);
                break;
        }
        lastcurrentCard = currentCard;
        currentCard.gameObject.SetActive(false);


    }
    

    


}
