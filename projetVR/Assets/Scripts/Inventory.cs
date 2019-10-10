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

        if (objet.tag == "Donut" && (inventory["Donut"]==0))
        {
            Debug.Log("DONUT +1");
            inventory["Donut"] += 1;
        }
        else if (objet.tag == "Money" && (inventory["Money"] == 0))
        {
            Debug.Log("MONEY +1");
            inventory["Money"] += 1;
        }
        else if (objet.tag == "Picture" && (inventory["Picture"] == 0))
        {
            Debug.Log("PICTURE +1");
            inventory["Picture"] += 1;
        }
    }


}