using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPhisics : MonoBehaviour
{
    // Ссылка на игрока
    public GameObject player;

    // Скорость движения коробки
    public float boxSpeed = 5f;

    // Флаг, указывающий на то, что коробка соприкоснулась с игроком
    private bool playerCollision = false;

    // Физическое тело коробки
    private Rigidbody2D rb;
    void Start()
    {
        // Получение ссылки на компонент Rigidbody2D коробки
        rb = GetComponent<Rigidbody2D>();   
    }
    void FixedUpdate()
    {
        // Если коробка соприкоснулась с игроком, двигаем коробку
        if (playerCollision)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * boxSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, соприкоснулась ли коробка с игроком
        if (collision.gameObject == player)
        {
            playerCollision = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Когда коробка перестает соприкасаться с игроком, останавливаем ее
        if (collision.gameObject == player)
        {
            playerCollision = false;
        }
    }
}
