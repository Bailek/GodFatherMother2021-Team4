using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChoiceCard : MonoBehaviour
{
    public GameObject ChoiceCardPanel;

    public StackCard[] stackCards;

    public CardDisplay[] Cards;

    public CardDisplay[] Choice1 = new CardDisplay[3];
    public Image[] Image1;
    public CardDisplay[] Choice2 = new CardDisplay[3];
    public Image[] Image2;
    public CardDisplay[] Choice3 = new CardDisplay[3];
    public Image[] Image3;



    public void Start()
    {
        WaveEvent.OnNoEnemy.AddListener(InterPhase);
        InterPhase();
        
    }
    public void RandomDraw()
    {
        for (int i = 0; i < 3; ++i)
        {
            int Rand = Random.Range(0, Cards.Length - 1);
            Choice1[i] = Cards[Rand];
            Image1[i].sprite = Cards[Rand].artworkImage.sprite;
        }
        for (int i = 0; i < 3; ++i)
        {
            int Rand = Random.Range(0, Cards.Length - 1);
            Choice2[i] = Cards[Rand];
            Image2[i].sprite = Cards[Rand].artworkImage.sprite;
        }
        for (int i = 0; i < 3; ++i)
        {
            int Rand = Random.Range(0, Cards.Length - 1);
            Choice3[i] = Cards[Rand];
            Image3[i].sprite = Cards[Rand].artworkImage.sprite;
        }
    }
    public void InterPhase()
    {
        ChoiceCardPanel.SetActive(true);
        RandomDraw();
        Time.timeScale = 0;
    }
    public void GiveChoice1()
    {
        for (int i = 0; i < 3; ++i)
        {
            if(stackCards[0].typeOfStack == Choice1[i].typeOfCard)
            {
                stackCards[0].numberStack ++;
            }
            if (stackCards[1].typeOfStack == Choice1[i].typeOfCard)
            {
                stackCards[1].numberStack++;
            }
            if (stackCards[2].typeOfStack == Choice1[i].typeOfCard)
            {
                stackCards[2].numberStack++;
            }
            if (stackCards[3].typeOfStack == Choice1[i].typeOfCard)
            {
                stackCards[3].numberStack++;
            }
        }
        ChoiceCardPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void GiveChoice2()
    {
        for (int i = 0; i < 3; ++i)
        {
            if (stackCards[0].typeOfStack == Choice2[i].typeOfCard)
            {
                stackCards[0].numberStack++;
            }
            if (stackCards[1].typeOfStack == Choice2[i].typeOfCard)
            {
                stackCards[1].numberStack++;
            }
            if (stackCards[2].typeOfStack == Choice2[i].typeOfCard)
            {
                stackCards[2].numberStack++;
            }
            if (stackCards[3].typeOfStack == Choice2[i].typeOfCard)
            {
                stackCards[3].numberStack++;
            }
        }
        ChoiceCardPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void GiveChoice3()
    {
        for (int i = 0; i < 3; ++i)
        {
            if (stackCards[0].typeOfStack == Choice3[i].typeOfCard)
            {
                stackCards[0].numberStack++;
            }
            if (stackCards[1].typeOfStack == Choice3[i].typeOfCard)
            {
                stackCards[1].numberStack++;
            }
            if (stackCards[2].typeOfStack == Choice3[i].typeOfCard)
            {
                stackCards[2].numberStack++;
            }
            if (stackCards[3].typeOfStack == Choice3[i].typeOfCard)
            {
                stackCards[3].numberStack++;
            }
        }
        ChoiceCardPanel.SetActive(false);
        Time.timeScale = 1;
    }
    
}
