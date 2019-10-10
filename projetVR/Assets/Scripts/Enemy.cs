using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static bool enemyCheck = false;

    public GameObject player;
    public GameObject floor;
    public GameObject cube;
    public float rot_speed = 10;
    public Vector3 enemyPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && floor != null)
        {
            enemyPosition = cube.transform.position;
            this.transform.position = new Vector3( player.transform.position.x, floor.transform.position.y, player.transform.position.z);
            this.transform.Rotate( new Vector3( 0, Time.deltaTime * rot_speed, 0 ) );

        }
    }
}
