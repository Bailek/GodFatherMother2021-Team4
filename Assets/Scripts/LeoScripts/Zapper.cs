using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
public class Zapper : MonoBehaviour
{
    public GameObject nova;
    public Animator Nova;
    private Charge charge;
    public List<Sprite> chargeImages;
    [HideInInspector]
    public bool ChargeReady = false;
    [HideInInspector]
    public float curentcharge;
    public int waitAnim = 2;
    public int chargeSpeed = 5;

    private int spriteState = 0;

    public void Start()
    {
        charge = new Charge(chargeSpeed);
        ChargeReady = false;
        GetComponent<Button>().enabled = false;
    }
    
    public void Update()
    {
        int state = Mathf.Clamp((int) (curentcharge / 20) - 1, 0, 4);
        transform.GetChild(1).GetComponent<Image>().sprite = chargeImages[state];
        charge.Update();
        curentcharge = charge.CurrentCharge;
        if (curentcharge == Charge.MaxCharge && !ChargeReady)
        {
            ChargeReady = true;
            GetComponent<Button>().enabled = true;
            transform.GetChild(0).GetComponent<Animator>().Play("JaugeBack");
            transform.GetChild(2).GetComponent<Animator>().Play("JaugeFront");
        }
    }
    public void NovaAnim()
    {
        if (ChargeReady)
        {
            charge.SpendCharge(Charge.MaxCharge);
            ChargeReady = false;
            StartCoroutine(Wait(waitAnim));
            GetComponent<Button>().enabled = false;

        }
    }
    IEnumerator Wait(int waitAnim)
    {
        Nova.SetBool("Open", true);
        yield return new WaitForSeconds(waitAnim);
        Nova.SetBool("Open", false);
    }
}

public class Charge
{
    public const int MaxCharge = 100;
    public float CurrentCharge;
    public float RegenCharge;

    public Charge(int chargeSpeed)
    {
        RegenCharge = chargeSpeed;
         CurrentCharge = 0f;
    }
    public void Update()
    {
        CurrentCharge += RegenCharge * Time.deltaTime;
        if (CurrentCharge >= MaxCharge)
        {
            CurrentCharge = MaxCharge;
        }
    }

    public void SpendCharge(int amountCharge)
    {
        if(CurrentCharge >= amountCharge)
        {
            CurrentCharge -= amountCharge;
        }
    }

    public float GetChargeNormalized()
    {
        return CurrentCharge / MaxCharge;
    }

}