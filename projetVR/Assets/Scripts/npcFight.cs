using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcFight : MonoBehaviour
{
    private int lifePoints;
    private int hitTime;
    // Start is called before the first frame update
    void Start()
    {
        lifePoints = 3;
        hitTime = 5;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && hitTime == 5)
        {
            lifePoints -= 1;
            while (hitTime > 0)
            {
                hitTime--;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hitTime <= 0)
        {
            hitTime = 5;
        }

        if (lifePoints == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
