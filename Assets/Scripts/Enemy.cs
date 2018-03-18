using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 3f;

    Transform playerTransform;
    Rigidbody2D rb2d;
    Animator animator;
    float distanceToPlayer = 1f;
    float signoVector;

    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

    void Start()
    {
        // Inicializa variables
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

        // Parámetros para que solo se choque con objetos de la misma capa
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void Update()
    {
        if (GetComponent<SpriteRenderer>().isVisible) { Move(); }
    }

    void Move()
    {
        // Si está alejado del jugador se acerca a él
        if (Vector3.Distance(transform.position, playerTransform.position) > distanceToPlayer)
        {
            // Calcula la nueva posición
            Vector2 move = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

            // Calcula si debe rotar el objeto
            if ((move.x > transform.position.x && Mathf.Round(transform.rotation.y) == 0) || (move.x < transform.position.x && Mathf.Round(transform.rotation.y) == -1))
            {
                transform.Rotate(0f, 180f, 0f);
            }

            // Comprueba obstáculos a los lados
            if (transform.position.x > move.x) { signoVector = -1; }
            else { signoVector = 1; }

            int countX = rb2d.Cast(new Vector2(signoVector, 0f), contactFilter, hitBuffer, 0.3f);
            for (int i = 0; i < countX; i++)
            {
                if (hitBuffer[i].normal.x != 0)
                {
                    move.x = transform.position.x;
                }
            }

            // Comprueba obstáculos arriba y abajo
            if (transform.position.y > move.y) { signoVector = -1; }
            else { signoVector = 1; }

            int countY = rb2d.Cast(new Vector2(0f, signoVector), contactFilter, hitBuffer, 0.1f);
            for (int i = 0; i < countY; i++)
            {
                if (hitBuffer[i].normal.y != 0)
                {
                    move.y = transform.position.y;
                }
            }
            
            // Elige la animacion de movimiento o quieto
            if (Mathf.Approximately(move.magnitude, transform.position.magnitude))
            {
                animator.SetTrigger("wolfIdle");
            } else
            {
                animator.SetTrigger("wolfRun");
            }

            // Realiza el movimiento
            transform.position = move;
        }
        // Si está pegado al jugador le ataca
        else
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("wolfAttack");
    }
}
