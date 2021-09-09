using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Zapper : MonoBehaviour
{
    public GameObject nova;
    public Animator Nova;
    private Charge charge;
    public Image chargeImage;
    [HideInInspector]
    public bool ChargeReady = false;
    [HideInInspector]
    public float curentcharge;
    public int waitAnim = 2;
    public int chargeSpeed = 5;

    public void Start()
    {
        charge = new Charge(chargeSpeed);
        ChargeReady = false;
    }
    
    public void Update()
    {
        charge.Update();
        chargeImage.fillAmount = charge.GetChargeNormalized();
        curentcharge = charge.CurrentCharge;
        if (curentcharge == Charge.MaxCharge)
        {
            ChargeReady = true;
        }
    }
    public void NovaAnim()
    {
        if (ChargeReady)
        {
            charge.SpendCharge(Charge.MaxCharge);
            ChargeReady = false;
            StartCoroutine(Wait(waitAnim));
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