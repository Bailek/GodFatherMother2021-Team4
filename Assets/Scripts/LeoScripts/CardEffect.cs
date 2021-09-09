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
    public CardDisplay currentCard;
    private void Start()
    {
        drop.DropCallback += ActivateEffect;
    }
    public void EndEffect()
    {
        switch (typeOfEffect)
        {
            case Effect.TOURET:
                Debug.Log("Toutrelle desactivate");
                DespawnTouret();
                typeOfEffect = Effect.NOTHING;
                break;

            case Effect.HEAL:
                Debug.Log("Heal desactivate");
                typeOfEffect = Effect.NOTHING;
                break;

            case Effect.LAZER:
                Debug.Log("Lazer desactivate");
                DespawnLazer();
                typeOfEffect = Effect.NOTHING;
                break;

            case Effect.MEGABOOSTER:
                Debug.Log("MegaBooster desactivate");
                typeOfEffect = Effect.NOTHING;
                break;
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
                Debug.Log("Toutrelle activate");
                SpawnTouret();
                typeOfEffect = Effect.TOURET;
                obj.gameObject.SetActive(false);
                break;

            case CardDisplay.Slot.HEAL:
                Debug.Log("Heal activate");
                Heal();
                typeOfEffect = Effect.HEAL;
                obj.gameObject.SetActive(false);
                break;

            case CardDisplay.Slot.LAZER:
                Debug.Log("Lazer activate");
                SpawnLazer();
                typeOfEffect = Effect.LAZER;
                obj.gameObject.SetActive(false);
                break;

            case CardDisplay.Slot.MEGABOOSTER:
                Debug.Log("MegaBooster activate");
                Booster();
                typeOfEffect = Effect.MEGABOOSTER;
                obj.gameObject.SetActive(false);
                break;
        }


    }
    

    private void Booster()
    {
        
    }

    private void SpawnLazer()
    {
        Lazer.SetActive(true);
    }
    private void DespawnLazer()
    {
        Lazer.SetActive(false);
    }

    private void SpawnTouret()
    {
        Touret.SetActive(true);

    }
    private void DespawnTouret()
    {
        Touret.SetActive(false);
    }

    public void Heal()
    {
        Spaceship.instance.HealShip(20);
    }


}
