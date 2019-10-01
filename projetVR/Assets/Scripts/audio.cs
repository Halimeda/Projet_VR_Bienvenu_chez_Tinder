using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

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
        public AudioClip endSpech;



        public GameObject door1;
        public GameObject door2;

        public AudioSource audioSource;


        private float timer = 0;



        // Start is called before the first frame update
        void Start()
        {
            audioSource = this.GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update() // Don't put zone1 zone2 dans update sinon relance en boucle le code dés que la porte est dead...
        {
            timer += 1f;
            //if (!door1 && door2)
            //{
            //    Debug.Log("Entre Voix Off Z1");
            //    Zone1();
            //}
            //else if (!door2 && !door1)
            //{
            //    Debug.Log("Entre Voix Off Z2");
            //    //Zone2();
            //}
        }


        public void welcomeSpeech()
        {
                Debug.Log("Welcome");
                audioSource.clip = bienvenue;
                audioSource.Play();
        }

        public void endSpeech()
        {
            audioSource.clip = endSpech;
            audioSource.Play();
        }

        public void Zone1()
        {
            audioSource.clip = noDonut;
            audioSource.Play();
            Debug.Log("Entre Voix Off1 Donut");
            //if ((Io.inventory["Donut"] == 0) && timer > 60)
            //{
            //    audioSource.clip = noDonut;
            //    audioSource.Play();
            //}
            //else if (Io.inventory["Donut"] == 2)
            //{
            //    audioSource.clip = donutGive;
            //    audioSource.Play();
            //}
            //else if ((Io.inventory["Money"] == 0) && (Io.inventory["Donut"] == 2) && timer > 120)
            //{
            //    audioSource.clip = noMoneyGuard;
            //    audioSource.Play();
            //}
            //else if (Io.inventory["Money"] == 2)
            //{
            //    audioSource.clip = moneyGuard;
            //    audioSource.Play();
            //}
            //else if ((Io.inventory["Picture"] == 0) && (Io.inventory["Donut"] == 2) && (Io.inventory["Money"] == 2) && timer > 180)
            //{
            //    audioSource.clip = noPicturesFound;
            //    audioSource.Play();
            //}
            //else if (Io.inventory["Picture"] == 2)
            //{
            //    audioSource.clip = picturesFound;
            //    audioSource.Play();
            //}
        }

        //Changer Ne lanvce pas la piste audio

        //IEnumerator Zone2()
        //{
        //    //if ((Io.inventory["Picture"] == 2) && (Io.inventory["Donut"] == 2) && (Io.inventory["Money"] == 2))
        //    //{
        //    //    audioSource.clip = insideRoom2;
        //    //    audioSource.Play();
        //    //    yield return new WaitForSeconds(audioSource.clip.length);
        //    //    audioSource.clip = computerTest;
        //    //    audioSource.Play();
        //    //}
        //}
    }
}
