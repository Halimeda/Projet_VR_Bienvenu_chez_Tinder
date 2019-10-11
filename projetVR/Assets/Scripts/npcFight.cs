using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VoiceInteraction
{
    public class npcFight : MonoBehaviour
    {
        private static int lifePoints;
        private static int hitTime;

        // Start is called before the first frame update
        void Start()
        {
            lifePoints = 3;
            hitTime = 10;
        }

        // Update is called once per frame
        void Update()
        {
            if (hitTime <= 0)
            {
                hitTime = 10;
            }

            if (lifePoints == 0)
            {
                Enemy.enemyCheck = false;
                Destroy(this.gameObject);
            }
        }

        public static void hit()
        {
            Debug.Log("-1 lifepoint");
            lifePoints -= 1;
            while (hitTime > 0)
            {
                hitTime--;
            }
        }
    }


}
