using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoiceInteraction
{
    public class audio : MonoBehaviour
    {
        public VoiceInteraction.InteractionObjets Io;


        public AudioClip bienvenue;
        public AudioClip noDonut;
        public AudioClip donutGive;
        public AudioClip noMoneyGuard;
        public AudioClip moneyGuard;
        public AudioClip noPicturesFound;
        public AudioClip picturesFound;
        public AudioClip fakeButtton;
        public AudioClip trueButtton;
        public AudioClip randomAttention;
        public AudioClip randomDiplom;
        public AudioClip randomLetSee;
        public AudioClip randomSee;
        public AudioClip insideRoom2;
        public AudioClip computerTest;

        public GameObject door1;
        public GameObject door2;

        private AudioSource audioSource;


        private float timer = 0;



        // Start is called before the first frame update
        void Start()
        {
            audioSource = this.GetComponent<AudioSource>();            
        }

        // Update is called once per frame
        void Update()
        {
            timer += 1f;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "StartButton")
            {
                audioSource.clip = bienvenue;
                audioSource.Play();
            }
        }


        private void OnTriggerStay(Collider other)
        {
            if (!door1 && door2)
            {
                Zone1();
            }
            else if (!door2 && !door1)
            {
                Zone2();
            }
        }

        public void Zone1()
        {
            audioSource.clip = noDonut;
            audioSource.Play();
            if ((Io.inventory["Donut"] == 0) && timer > 60)
            {
                audioSource.clip = noDonut;
                audioSource.Play();
            }
            else if (Io.inventory["Donut"] == 2)
            {
                audioSource.clip = donutGive;
                audioSource.Play();
            }
            else if ((Io.inventory["Money"] == 0) && (Io.inventory["Donut"] == 2) && timer > 120)
            {
                audioSource.clip = noMoneyGuard;
                audioSource.Play();
            }
            else if (Io.inventory["Money"] == 2)
            {
                audioSource.clip = moneyGuard;
                audioSource.Play();
            }
            else if ((Io.inventory["Picture"] == 0) && (Io.inventory["Donut"] == 2) && (Io.inventory["Money"] == 2) && timer > 180)
            {
                audioSource.clip = noPicturesFound;
                audioSource.Play();
            }
            else if (Io.inventory["Picture"] == 2)
            {
                audioSource.clip = picturesFound;
                audioSource.Play();
            }
        }

        //Changer Ne lanvce pas la piste audio

        IEnumerator Zone2()
        {
            if ((Io.inventory["Picture"] == 2) && (Io.inventory["Donut"] == 2) && (Io.inventory["Money"] == 2))
            {
                audioSource.clip = insideRoom2;
                audioSource.Play();
                yield return new WaitForSeconds(audioSource.clip.length);
                audioSource.clip = computerTest;
                audioSource.Play();
            }
        }
    }
}
