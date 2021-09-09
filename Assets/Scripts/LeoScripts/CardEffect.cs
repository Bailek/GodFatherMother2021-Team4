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
        Debug.Log("EndEffect");
        if (typeOfEffect == Effect.TOURET)
        {
            Debug.Log("Toutrelle desactivate");
            typeOfEffect = Effect.NOTHING;
            //DespawnTouret();
        }
        else if (typeOfEffect == Effect.HEAL)
        {
            Debug.Log("Heal desactivate");
            typeOfEffect = Effect.NOTHING;
        }
        else if (typeOfEffect == Effect.LAZER)
        {
            Debug.Log("Lazer desactivate");
            typeOfEffect = Effect.NOTHING;
            //DespawnLazer();
        }
        else if (typeOfEffect == Effect.MEGABOOSTER)
        {
            Debug.Log("MegaBooster desactivate");
            typeOfEffect = Effect.NOTHING;
        }

        //switch (typeOfEffect)
        //{
        //    case Effect.TOURET:
        //        Debug.Log("Toutrelle desactivate");
        //        DespawnTouret();
        //        typeOfEffect = Effect.NOTHING;
        //        break;

        //    case Effect.HEAL:
        //        Debug.Log("Heal desactivate");
        //        typeOfEffect = Effect.NOTHING;
        //        break;

        //    case Effect.LAZER:
        //        Debug.Log("Lazer desactivate");
        //        DespawnLazer();
        //        typeOfEffect = Effect.NOTHING;
        //        break;

        //    case Effect.MEGABOOSTER:
        //        Debug.Log("MegaBooster desactivate");
        //        typeOfEffect = Effect.NOTHING;
        //        break;
        //}
    }

   
    public void ActivateEffect(CardDisplay obj)
    {
        currentCard = obj;
        if(currentCard != null)
        {
            EndEffect();
        }
        
        
        switch (obj.typeOfCard)
        {
            case CardDisplay.Slot.TOURET:
                Debug.Log("Toutrelle activate");
                typeOfEffect = Effect.TOURET;
                //SpawnTouret();
                break;

            case CardDisplay.Slot.HEAL:
                Debug.Log("Heal activate");
                typeOfEffect = Effect.HEAL;
                //Heal();
                break;

            case CardDisplay.Slot.LAZER:
                Debug.Log("Lazer activate");
                typeOfEffect = Effect.LAZER;
                //SpawnLazer();
                break;

            case CardDisplay.Slot.MEGABOOSTER:
                Debug.Log("MegaBooster activate");
                typeOfEffect = Effect.MEGABOOSTER;
                //Booster();
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
