using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text mana;
    public Player player;

    public GameObject manaJauge;
    public GameObject bossJauge;

	// Use this for initialization
	void Start ()
    {
        mana.text = player.GetMana() + " / " + player.maxMana;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void DisplayMana()
    {
        mana.text = player.GetMana() + " / " + player.maxMana;
        manaJauge.transform.localScale = new Vector3(player.GetMana() / player.maxMana , manaJauge.transform.localScale.y, manaJauge.transform.localScale.z);
    }

    public void DisplayBossJauge(float life, float maxLife)
    {
        bossJauge.transform.localScale = new Vector3(life/maxLife, bossJauge.transform.localScale.y, bossJauge.transform.localScale.z);
    }
}
