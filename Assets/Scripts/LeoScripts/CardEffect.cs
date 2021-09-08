using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : MonoBehaviour
{
    public GameObject panel1;
    public GameObject Touret1;
    public DropZone dropZone;
    public enum Slot { TOURET, HEAL, ZAPPER, LAZER, MEGABOOSTER }
    public Slot typeOfCard = Slot.TOURET;
    public void ActivateEffect(Spaceship spaceship, DropZone dropZone)
    {

        switch (dropZone.GetComponent<CardDisplay>().typeOfCard)
        {
            case Slot.TOURET:
                SpawnTouret();
                break;

            case Slot.HEAL:
                Heal();
                break;

            case Slot.LAZER:
                Lazer();
                break;

            case Slot.MEGABOOSTER:
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
        
    }



    
    
        
}
