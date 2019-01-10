using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exploration : MonoBehaviour {

    public GameObject invok;

    public GameObject dailyInvok;
    public GameObject stdInvok;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DailyInvok()
    {
        invok.SetActive(false);
        dailyInvok.SetActive(true);
        stdInvok.SetActive(false);
    }

    public void StandardInvok()
    {
        invok.SetActive(false);
        dailyInvok.SetActive(false);
        stdInvok.SetActive(true);
    }

    public void Return()
    {
        invok.SetActive(true);
        dailyInvok.SetActive(false);
        stdInvok.SetActive(false);
    }
}
