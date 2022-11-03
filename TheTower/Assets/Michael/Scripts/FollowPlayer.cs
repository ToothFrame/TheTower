using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] public GameObject Character;
    [SerializeField] public float Self;
    [SerializeField] private float updateEnemy;
    [SerializeField] public float Direction;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void getPos()
    {
        Self = this.transform.position.x;
        Self = Character.transform.position.x - Self;
        Debug.Log(Self);
    }

    void EnemyMovement()
    {
        getPos();
        if (Self >= 0)
        {
            Direction = 1;
        }
        else
        {
            Direction = -1;
        }
    }


// Update is called once per frame
void FixedUpdate()
    {
        
        if (updateEnemy > 0)
        {
            updateEnemy -= Time.deltaTime;
        }

        if (updateEnemy <= 0)
        {
            updateEnemy = 0.5f;
            EnemyMovement();
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(Direction, GetComponent<Rigidbody2D>().velocity.y);
    }

}
