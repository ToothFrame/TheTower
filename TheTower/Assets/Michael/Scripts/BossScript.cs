using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float updateBossMove;
    private float updateBossAtt;
    private int RandomPlace;
    private int Temp;
    private int Prev;
    [SerializeField] private List<GameObject> l_go;
    public GameObject Bullet;
    public GameObject Self;



    void MoveBoss()
    {
        Temp = Random.Range(0, 4);
        if (Temp == RandomPlace || Prev == Temp)
        {
            MoveBoss();
        }
        else
        {
            Prev = RandomPlace;
            RandomPlace = Temp;
        }

        transform.position = l_go[RandomPlace].transform.position;
            
    }


    void ChooseAtt()
    {
        int attchoice = Random.Range(0, 1);
        if (attchoice == 0)
        {
            AttA();
        }
        else AttA();
    }

    void AttA()
    {
        Instantiate(Bullet, Self.transform.position, Self.transform.rotation, transform);
     }

    void AttB()
    {

    }

    void SpawnEnemy()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (updateBossMove > 0)
        {
            updateBossMove -= Time.deltaTime;
        }
        if (updateBossMove <= 0)
        {
            updateBossMove = 5000f;
            MoveBoss();
        }
        if (updateBossAtt > 0)
        {
            updateBossAtt -= Time.deltaTime;
        }
        if (updateBossAtt <= 0)
        {
            updateBossAtt = 1f;
            ChooseAtt();
        }
    }
}
