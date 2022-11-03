using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private KeyCode userKeyRight = KeyCode.RightArrow, userKeyLeft = KeyCode.LeftArrow, userKeyUp = KeyCode.UpArrow;
    [SerializeField] private float f_speed;









    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (Input.GetKey(userKeyRight))
        {
            transform.position += transform.right * f_speed * Time.deltaTime;
        }

        if (Input.GetKey(userKeyLeft))
        {
            transform.position -= transform.right * f_speed * Time.deltaTime;
        }
    }
}
