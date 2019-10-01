using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

namespace VoiceInteraction
{


    public class InteractionObjets : MonoBehaviour
    {
        public GameObject Donut;
        public GameObject Picture;
        public GameObject Money;
        public GameObject ball;
        public AudioClip endSpeech;
        public AudioSource audioSource;
        public Dictionary<string, int> inventory = new Dictionary<string, int>(){
            { "Donut", 0 },
            { "Picture", 0 },
            { "Money", 0 },
        };
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //public void Modify(GameObject other)
        //{
        //    if (other.gameObject.tag == "Donut")
        //    {
        //        /* 0--> pas encore récupéré
        //         * 1--> récupéré
        //         * 2--> donné
        //         */
        //        inventory["Donut"] += 1;

        //    }

        //    else if (other.gameObject.tag == "Picture")
        //    {
        //        inventory["Picture"] += 1;
        //        //print("Tu as récupéré une photo cochonne. Elle est ajoutée à ton inventaire ");
        //    }

        //    else if (other.gameObject.tag == "Money")
        //    {
        //        inventory["Money"] += 1;
        //        //print("Tu as récupéré ton salaire. Il est ajouté  ton inventaire");

        //    }

        //}

        //private void OnTriggerEnter(Collider other)
        //{

        //    if (other.gameObject.tag == "Pig")
        //    {
        //        if (inventory["Donut"] == 0)
        //        {
        //            print("Le cochon semble avoir envie de quelque chose...");
        //        }

        //        else if (inventory["Donut"] == 1)
        //        {

        //            Modify(gameObject);

        //            GameObject Money = Resources.Load("Money") as GameObject;
        //            Instantiate(Money, Vector3.zero, Quaternion.identity);
        //            Destroy(Donut.gameObject);
        //        }

        //    }

        //    else if (other.gameObject.tag == "Donut")
        //    {
        //        Modify(gameObject);
        //    }

        //    else if (other.gameObject.tag == "Money")
        //    {
        //        Modify(gameObject);
        //    }

        //    else if (other.gameObject.tag == "Picture")
        //    {
        //        Modify(gameObject);
        //    }

        //    else if (other.gameObject.tag == "GardePlante")
        //    {
        //        if (inventory["Money"] == 1 && inventory["Picture"] == 1)
        //        {
        //            Destroy(Money.gameObject);
        //            Destroy(Picture.gameObject);
        //            //faire bouger garde
        //            Destroy(this.gameObject);
        //            GameObject RealButton = Resources.Load("RealButtonobj") as GameObject;
        //            //modifier position pour qu'il apparaisse dans le dos du garde
        //            Instantiate(RealButton, Vector3.zero, Quaternion.identity);
        //        }
        //    }

        //    else if (other.gameObject.tag == "ball")
        //    {
        //        audioSource.clip = endSpeech;
        //        audioSource.Play();
        //        Destroy(this.gameObject);
        //    }
        //}
    }
}
