using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    public static PlayerStats playerStats;

    public int mothershipLevel;

    public int[] cardLevels;
    public int[] cardNumbers;

    public int scraps;
    public int darkMatter;

	// Use this for initialization
	void Start ()
    {
	    if(playerStats == null)
        {
            playerStats = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(playerStats);
                
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
        mothershipLevel++;
    }
}
