using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCard : MonoBehaviour {

    public Card card;
    public int level;
    public int number;

    public Image icon;
    public Image pattern;
    public Text cardName;
    public Text manaCostText;
    public Text attackText;
    public Text healthText;
    public Text cardLevel;
    public Text cardNumber;

    public GameObject levelUpButton;
    public GameObject unavailablePanel;

	// Use this for initialization
	void Start ()
    {
        DisplayMenuCards();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayMenuCards()
    {
        icon.sprite = card.artwork;
        pattern.sprite = card.pattern;
        cardName.text = card.name;
        manaCostText.text = card.manaCost.ToString("n0");
        attackText.text = card.attack.ToString("n0");
        healthText.text = card.health.ToString("n0");

        if (number > 0)
        {
            cardLevel.text = "Level : " + level.ToString("n0");
            cardNumber.text = "x " + number.ToString("n0");
            unavailablePanel.SetActive(false);
            levelUpButton.SetActive(true);
        }
        else
        {
            cardLevel.text = "";
            cardNumber.text = "";
            unavailablePanel.SetActive(true);
            levelUpButton.SetActive(false);
        }
                

    }
}
