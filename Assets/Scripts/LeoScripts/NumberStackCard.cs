using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberStackCard : MonoBehaviour
{
    public StackCard[] stackCards;
    public TMP_Text[] texts;
    
    void Update()
    {
        for(int i = 0; i < stackCards.Length; i++)
        {
                int t = stackCards[i].numberStack;
                texts[i].text = t.ToString();
            
        }
    }
}
