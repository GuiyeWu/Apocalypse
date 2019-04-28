using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public static ShopMenu shopMenu;
    public Slider addHealth;
    public Slider addDamage;
    public Slider addSpeed;

    public Text health;
    public Text damage;
    public Text speed;

    public Text totalCost;

    public Text buyError;

    public GameObject shopMenuUI;
    public bool menuActive;

    private int lastGold;

    void Awake()
    {
        if (shopMenu != null)
        {
            //Destroy(shopMenu);
        }
        else
        {
            shopMenu = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        lastGold = 0;
        menuActive = false;
        shopMenuUI.SetActive(false);
        addHealth.maxValue = 50;
        addDamage.maxValue = 10;
        addSpeed.maxValue = 10;
        addHealth.minValue = 0;
        addDamage.minValue = 0;
        addSpeed.minValue = 0;
        buyError.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.playerStats.coins - lastGold == 50 * PlayerStats.playerStats.level)
        {
            ShowMenu();
        }

        updateUI();
    }

    void ShowMenu()
    {
        if (!menuActive)
        {
            addHealth.value = 0;
            addHealth.maxValue = 50 - PlayerStats.playerStats.health;
            addDamage.value = 0;
            addSpeed.value = 0;

            Time.timeScale = 0;
            shopMenuUI.SetActive(true);
            menuActive = true;
        }
        
    }

    public void Buy()
    {
        if (CanBuy())
        {
            PlayerStats.playerStats.HealCharacter(Mathf.Ceil(addHealth.value));
            TestSpell.minDamage += Mathf.Ceil(addDamage.value);
            TestSpell.maxDamage += Mathf.Ceil(addDamage.value);
            PlayerMovement.speed += Mathf.Ceil(addSpeed.value) / 10;

            PlayerStats.playerStats.coins -= (int)GetTotalCost();
            Debug.Log(PlayerStats.playerStats.coins);
            Debug.Log("Purchase Success");
            Next();
        } else
        {
            buyError.text = "Insufficient Funds";

        }
    }

    public void Next()
    {
        PlayerStats.playerStats.level += 1;
        EnemySpawner.NumberOfEnemies += 5 * PlayerStats.playerStats.level;
        EnemySpawner.spawnRate -= 0.2f;
        EnemyMovement.speed += 0.5f;
        shopMenuUI.SetActive(false);
        lastGold = PlayerStats.playerStats.coins;
        PlayerStats.playerStats.coinsValue.text = "Gold: " + PlayerStats.playerStats.coins.ToString();
        Time.timeScale = 1;
        menuActive = false;

        //

    }

    private bool CanBuy()
    {
        return PlayerStats.playerStats.coins >= GetTotalCost();
    }

    private float GetTotalCost()
    {
        return Mathf.Ceil(addHealth.value) + Mathf.Ceil(addDamage.value) + Mathf.Ceil(addSpeed.value);

    }

    private void updateUI()
    {
        health.text = "Cost: " + Mathf.Ceil(addHealth.value).ToString();
        damage.text = "Cost: " + Mathf.Ceil(addDamage.value).ToString();
        speed.text = "Cost: " + Mathf.Ceil(addSpeed.value).ToString();

        totalCost.text = "Total Cost: " + Mathf.Ceil(GetTotalCost()).ToString();

    }


}
