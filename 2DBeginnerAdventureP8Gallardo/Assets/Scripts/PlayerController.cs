using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.WSA;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;

    public GameObject projectilePrefab;
    public int maxHealth = 5;
    public float timeInvincible = 2;
    public int health { get { return currentHealth; } }
    int currentHealth;

    bool isInvincible;
    float invincibleTimer;




    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    private Vector2 lookDirection;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;




    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                Launch();
            } 
            
        }


    }

    private void Launch()
    {
        throw new NotImplementedException();
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;

        position.y = position.y + speed * vertical * Time.deltaTime;




        rigidbody2d.MovePosition(position);

    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if(isInvincible)
            {
                return;

            }  
            isInvincible = true;
            invincibleTimer = timeInvincible;
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            Debug.Log(currentHealth + "/" + maxHealth);

            void Launch()
            {

                GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
                Projectile projectile = projectileObject.GetComponent<Projectile>();
                projectile.Launch(lookDirection, 300);
                
            }
        }
    }
}