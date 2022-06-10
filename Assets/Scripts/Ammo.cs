using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int totalAmmoAmount = 900;

    public int GetCurrentAmmoAmount()
    {
        return totalAmmoAmount;
    }

    public void ReduceCurrentAmmo(int amountToReduce)
    {
        totalAmmoAmount -= amountToReduce;
    }
    public void IncreaseCurrentAmmo(int amountToIncrease)
    {
        totalAmmoAmount += amountToIncrease;
    }
}
