using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void DestroyObjectDelayed()
    {
        if(gameObject.name == "Bullet(Clone)")
        {
            Destroy(gameObject, 5);
        }
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Character.transform.position.x, Character.transform.position.y);
        float i = 0;
        if (i < 0)
        {
            i -= Time.deltaTime;
        }
        if(i >= 0)
        {
            i = 5;
            DestroyObjectDelayed();
        }
    }
}
