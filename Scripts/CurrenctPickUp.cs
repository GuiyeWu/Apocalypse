using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrenctPickUp : MonoBehaviour
{
    public enum PickUpObject{COIN,GEM};
    public PickUpObject currentObject;
    public int pickupQuantity;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            PlayerStats.playerStats.AddCurrency(this);
            Destroy(gameObject);
        }   
    }
}
