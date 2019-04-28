using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    public GameObject projectile;
    public static float minDamage;
    public static float maxDamage;
    public float projectileForce;

    void Start()
    {
        minDamage = 25;
        maxDamage = 25;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!PauseMenu.pauseMenu.isPaused && !ShopMenu.shopMenu.menuActive)
            {
                if (projectile != null)
                {
                    GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 myPos = transform.position;
                    Vector2 direction = (mousePos - myPos).normalized;
                    spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
                    spell.GetComponent<TestProjectile>().damage = Random.Range(minDamage, maxDamage);
                }

            }
        }
        
    }
}
