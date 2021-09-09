using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCard : MonoBehaviour
{
    public GameObject ChoiceCardPanel;
    public StackCard[] stackCards;
    public GameObject[] Cards;

    public GameObject[] CardChoice1;
    public GameObject[] CardChoice2;
    public GameObject[] CardChoice3;

    public void Start()
    {
        ChoiceCardPanel = this.gameObject;
    }

    public void GiveChoice1()
    {
        stackCards[0].numberStack += 2;
        stackCards[1].numberStack += 1;
        stackCards[2].numberStack += 0;
        stackCards[3].numberStack += 0;
        ChoiceCardPanel.SetActive(false);
}
    public void GiveChoice2()
    {
        stackCards[0].numberStack += 0;
        stackCards[1].numberStack += 1;
        stackCards[2].numberStack += 1;
        stackCards[3].numberStack += 1;
        ChoiceCardPanel.SetActive(false);
    }
    public void GiveChoice3()
    {
        stackCards[0].numberStack += 0;
        stackCards[1].numberStack += 0;
        stackCards[2].numberStack += 2;
        stackCards[3].numberStack += 1;
        ChoiceCardPanel.SetActive(false);
    }
    public void GetSetCard()
    {
        //CardChoice1 = Random.Range(0, 5);
    }
}
