using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigWalk : MonoBehaviour
{
    private Animator pigWalk;
    
    
    // Start is called before the first frame update
    void Start()
    {
        pigWalk = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pigWalk.GetBool("pig_Walking")) // si l'anim du cochon est true 
        {
            //pig marche animation se lance

            //if () //si le pig reçoit donut alors 
            //{
            //    pigWalk.SetBool("pig_Walking", false); //arrête animation marcher
            //    pigPoo.SetBool("pig_Poo", true); // commencer animation ass money drop ou pigPoo.Play("pig_Poo") pour jouer 1x
            //}
        }





    }
}
