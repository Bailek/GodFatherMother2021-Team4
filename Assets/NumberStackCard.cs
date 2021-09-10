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
            if(stackCards[i].numberStack == 0)
            {
                int t = stackCards[i].numberStack;
                texts[i].text = t.ToString();
            }
            else if(stackCards[i].numberStack >= 1)
            {
                int t = stackCards[i].numberStack + 1;
                texts[i].text = t.ToString();
            }
            
        }
    }
}
