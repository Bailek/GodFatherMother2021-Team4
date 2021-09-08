using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropZone : MonoBehaviour
{
    public Drop drop;
    public Spaceship spaceship;
    
    private void Awake()
    {
        drop.DropCallback += OnDropReceive;
    }

    private void OnDropReceive(CardDisplay obj)
    {
        obj.GetComponent<CardEffect>().ActivateEffect(spaceship, this);
    }

    public void Init(Spaceship spaceship)
    {
        this.spaceship = spaceship;
    }

    
}
