using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyShooting : EnemyAttack
{
    public GameObject projectile;
    public static int damage;
    public static float projectileForce;
    public static float cooldown;

    public override void Start()
    {
        damage = 7 + MainMenu.difficulty*3;
        projectileForce = 5.0f;
        cooldown = 1.0f - 0.2f*MainMenu.difficulty;
        base.Start();
        StartCoroutine(ShootPlayer());

        //player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown);
        while (player != null)
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            //Debug.Log(player.transform.position);
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.transform.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<TestEnemyProjectile>().damage = damage;
            yield return new WaitForSeconds(cooldown);
            //StartCoroutine(ShootPlayer());
        }
    }
}
