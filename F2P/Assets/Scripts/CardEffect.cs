using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : MonoBehaviour {

    public bool summon;

    public GameObject shipSummoned;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Effect(Transform t, int atk, int hp)
    {
        if (summon)
        {
            Ship s = Instantiate(shipSummoned, t.position, Quaternion.identity).GetComponent<Ship>();
            s.InitiateShip(atk, hp);
        }
    }

}
