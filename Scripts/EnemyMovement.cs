using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static float speed;
    public GameObject player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        speed = 1.0f + MainMenu.difficulty * 0.5f;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (player != null)
        {
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.transform.position;
            Vector2 direction = (targetPos - myPos).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }


}
