using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcFight : MonoBehaviour
{
    private int lifePoints;
   // private int hitTime;

    // Start is called before the first frame update
    void Start()
    {
        lifePoints = 3;
        //hitTime = 10;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("-1 lifepoint");
            lifePoints -= 1;
            //while (hitTime > 0)
            //{
            //    hitTime--;
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (hitTime <= 0)
        //{
        //    hitTime = 10;
        //}

        if (lifePoints == 0)
        {
            Enemy.enemyCheck = false;
            Destroy(this.gameObject);
        }
    }
}
