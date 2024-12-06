using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    Rigidbody2D rigidbody2d;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    // FixedUpdate has the same call rate as the physics system
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            position.y = position.y + speed * Time.deltaTime;
        }
        else
        {
            position.x = position.x + speed * Time.deltaTime;
        }


        rigidbody2d.MovePosition(position);
    }
}

        
        

        
    

