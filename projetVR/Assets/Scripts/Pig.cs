using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoiceInteraction
{
    public class Pig : MonoBehaviour
    {
        public audio voixOff;
        public void OnCollisionEnter(Collision collision)
        {
            Debug.Log("CochonTrigger");
            if (collision.gameObject.tag == "Donut")
            {
                Debug.Log("Cochon");
                voixOff.Donut();
                Inventory.Modify(collision.gameObject);

                GameObject Money = Resources.Load("Money") as GameObject;
                Instantiate(Money, Vector3.zero, Quaternion.identity);
                Destroy(collision.gameObject);
            }
        }
        //public void OnTriggerEnter(Collider other)
        //{
        //    Debug.Log("CochonTrigger");
        //    if (other.gameObject.tag == "Donut")
        //    {
        //        Debug.Log("Cochon");
        //        voixOff.Donut();
        //        Inventory.Modify(other.gameObject);

        //        GameObject Money = Resources.Load("Money") as GameObject;
        //        Instantiate(Money, Vector3.zero, Quaternion.identity);
        //        Destroy(other.gameObject);
        //    }
        //}
    }
}

