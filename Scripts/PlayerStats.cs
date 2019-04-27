using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    public GameObject player;
    public Text healthText;
    public Slider healthSlider;

    public float health;
    public float maxHealth;

    public int level;

    public int coins;
    public int gems;

    public Text coinsValue;
    public Text gemsValue;

    public GameObject GameOverUI;

    void Awake()
    {
        /*if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {*/
            playerStats = this;
        //}
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        health = maxHealth;
        level = 1;
        SetHealUI();
        GameOverUI.SetActive(false);
    }
    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        SetHealUI();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
        SetHealUI();
    }

    private void SetHealUI()
    {
        healthSlider.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
    }

    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    private void CheckDeath()
    {
        if (health <= 0)
        {
            health = 0;
            GameOverUI.SetActive(true);
            Time.timeScale = 0;
            //Destroy(player);
        }
    }

    float CalculateHealthPercentage()
    {
        return health / maxHealth;
    }

    public void AddCurrency(CurrenctPickUp currency)
    {
        if(currency.currentObject == CurrenctPickUp.PickUpObject.COIN)
        {
            coins += currency.pickupQuantity;
            coinsValue.text = "Gold: " + coins.ToString();
        }
        else if(currency.currentObject == CurrenctPickUp.PickUpObject.GEM)
        {
            gems += currency.pickupQuantity;
            gemsValue.text = "Gems " + gems.ToString();
        }
    }
}
