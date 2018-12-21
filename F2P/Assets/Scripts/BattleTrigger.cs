using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour {

    private Ship ship;

	// Use this for initialization
	void Start ()
    {
        ship = GetComponentInParent<Ship>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (ship.playerShip)
        {
            if (other.CompareTag("EnemyShip"))
            {
                ship.SetCanMove(false);
                ship.SetCanShoot(true);
            }
        }
        else
        {
            if (other.CompareTag("Ship"))
            {
                ship.SetCanMove(false);
                ship.SetCanShoot(true);
            }
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (ship.playerShip)
        {
            if (other.CompareTag("EnemyShip"))
            {
                ship.SetCanMove(true);
                ship.SetCanShoot(false);
            }
        }
        else
        {
            if (other.CompareTag("Ship"))
            {
                ship.SetCanMove(true);
                ship.SetCanShoot(false);
            }
        }
    }
}
