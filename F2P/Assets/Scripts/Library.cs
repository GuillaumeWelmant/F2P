using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour {


    public MenuCard[] cards;
    public PlayerStats player;

    private int page;


	// Use this for initialization
	void Start ()
    {
        page = 0;
	    for(int i = 0; i<cards.Length; i++)
        {
            cards[i].level = player.cardLevels[i];
            cards[i].number = player.cardNumbers[i];
        }	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateLibrary()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if(i >= 6 * page && i < 6 * page + 6 && i <= 9)
            {
                cards[i].gameObject.SetActive(true);
                cards[i].level = player.cardLevels[i];
                cards[i].number = player.cardNumbers[i];
                cards[i].DisplayMenuCards();
            }
            else
            {
                cards[i].gameObject.SetActive(false);
            }

        }
    }

    public void ChangePage(int i)
    {
        page = i;
        UpdateLibrary();
    }
}
