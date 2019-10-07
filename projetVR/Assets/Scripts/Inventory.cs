using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public static Dictionary<string, int> inventory = new Dictionary<string, int>()
    {
            { "Donut", 0 },
            { "Picture", 0 },
            { "Money", 0 },
    };

    public static void Modify(GameObject objet)
    {
        Debug.Log("Inventory");
        if (objet.tag == "Donut")
        {
            Debug.Log("DONUT +1");
        }
    }


}