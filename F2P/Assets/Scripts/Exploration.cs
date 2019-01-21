using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exploration : MonoBehaviour {

    public GameObject invok;

    public GameObject dailyInvok;
    public GameObject stdInvok;

    public Card[] cardPool;

    private bool rareMin;
    private bool epicMin;

    public CardDisplay[] loots;

    public GameObject[] selectedExplo;
    public GameObject[] exploButtons;

    public Button oneTimeButton;

    public PlayerStats player;

	// Use this for initialization
	void Start ()
    {

        foreach(GameObject g in selectedExplo)
        {
            g.SetActive(false);
        }

        foreach (GameObject g in exploButtons)
        {
            g.SetActive(false);
        }
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

    public void StandardInvok(int i)
    {

        for(int j=0; j<selectedExplo.Length; j++)
        {
            if (j == i)
            {
                selectedExplo[j].SetActive(true);
            }
            else
            {
                selectedExplo[j].SetActive(false);
            }
        }

        foreach (GameObject g in exploButtons)
        {
            g.SetActive(true);
        }

    }

    public void Return()
    {
        invok.SetActive(true);
        dailyInvok.SetActive(false);
        stdInvok.SetActive(false);
    }

    public void StartExploration(int i)
    {
        StartCoroutine(Explore(i));
    }

    public void StartDiscountExploration(int i)
    {
        StartCoroutine(DiscountExplore(i));
    }

    public IEnumerator Explore(int i)
    {

        if(player.darkMatter >= 5 * i)
        {
            foreach (GameObject g in exploButtons)
            {
                g.SetActive(false);
            }

            player.darkMatter -= 5 * i;

            foreach (CardDisplay c in loots)
            {
                c.gameObject.SetActive(false);
            }

            if (i >= 10)
            {
                epicMin = true;
                i++;
            }
            else
            {
                epicMin = false;
            }

            List<Card> cardsLooted = new List<Card>();
            Card cardLooted = null;

            for (int j = 0; j < i; j++)
            {
                rareMin = true;

                cardsLooted.Clear();

                for (int k = 0; k < 3; k++)
                {
                    if (k != 2)
                    {
                        int r = Random.Range(0, cardPool.Length);
                        cardLooted = cardPool[r];

                        if (cardLooted.rarity == Card.Rarity.epic || cardLooted.rarity == Card.Rarity.legendry)
                        {
                            epicMin = false;
                            rareMin = false;
                        }
                        else if (cardLooted.rarity == Card.Rarity.rare)
                        {
                            rareMin = false;
                        }

                        cardsLooted.Add(cardLooted);
                    }
                    else
                    {
                        if (epicMin && j >= 9)
                        {
                            while (cardLooted.rarity != Card.Rarity.epic && cardLooted.rarity != Card.Rarity.legendry)
                            {
                                int r = Random.Range(0, cardPool.Length);
                                cardLooted = cardPool[r];
                            }

                            epicMin = false;
                            rareMin = false;

                            cardsLooted.Add(cardLooted);
                        }
                        else if (rareMin)
                        {
                            while (cardLooted.rarity != Card.Rarity.rare)
                            {
                                int r = Random.Range(0, cardPool.Length);
                                cardLooted = cardPool[r];
                            }

                            rareMin = false;

                            cardsLooted.Add(cardLooted);
                        }
                        else
                        {
                            int r = Random.Range(0, cardPool.Length);
                            cardLooted = cardPool[r];

                            if (cardLooted.rarity == Card.Rarity.epic || cardLooted.rarity == Card.Rarity.legendry)
                            {
                                epicMin = false;
                                rareMin = false;
                            }
                            else if (cardLooted.rarity == Card.Rarity.rare)
                            {
                                rareMin = false;
                            }

                            cardsLooted.Add(cardLooted);
                        }

                    }
                }

                for (int z = 0; z < loots.Length; z++)
                {
                    loots[z].gameObject.SetActive(true);
                    loots[z].card = cardsLooted[z];
                    loots[z].DisplayCard();
                }

                AddPlayerCards(cardsLooted);

                Debug.Log("Exploration " + (j + 1) + " terminée");

                yield return new WaitForSeconds(1.5f);

            }

            foreach (CardDisplay c in loots)
            {
                c.gameObject.SetActive(false);
            }

            foreach (GameObject g in selectedExplo)
            {
                g.SetActive(false);
            }

            foreach (GameObject g in exploButtons)
            {
                g.SetActive(false);
            }
        }


    }


    public IEnumerator DiscountExplore(int i)
    {
        if(player.scraps >= 1000)
        {

            foreach (GameObject g in exploButtons)
            {
                g.SetActive(false);
            }

            player.scraps -= 1000;
            oneTimeButton.interactable = false;

            foreach (CardDisplay c in loots)
            {
                c.gameObject.SetActive(false);
            }

            if (i >= 10)
            {
                epicMin = true;

            }
            else
            {
                epicMin = false;
            }

            List<Card> cardsLooted = new List<Card>();
            Card cardLooted = null;

            for (int j = 0; j < i; j++)
            {
                rareMin = true;

                cardsLooted.Clear();

                for (int k = 0; k < 3; k++)
                {
                    if (k != 2)
                    {
                        int r = Random.Range(0, cardPool.Length);
                        cardLooted = cardPool[r];

                        if (cardLooted.rarity == Card.Rarity.epic || cardLooted.rarity == Card.Rarity.legendry)
                        {
                            epicMin = false;
                            rareMin = false;
                        }
                        else if (cardLooted.rarity == Card.Rarity.rare)
                        {
                            rareMin = false;
                        }

                        cardsLooted.Add(cardLooted);
                    }
                    else
                    {
                        if (epicMin && j >= 9)
                        {
                            while (cardLooted.rarity != Card.Rarity.epic && cardLooted.rarity != Card.Rarity.legendry)
                            {
                                int r = Random.Range(0, cardPool.Length);
                                cardLooted = cardPool[r];
                            }

                            epicMin = false;
                            rareMin = false;

                            cardsLooted.Add(cardLooted);
                        }
                        else if (rareMin)
                        {
                            while (cardLooted.rarity != Card.Rarity.rare)
                            {
                                int r = Random.Range(0, cardPool.Length);
                                cardLooted = cardPool[r];
                            }

                            rareMin = false;

                            cardsLooted.Add(cardLooted);
                        }
                        else
                        {
                            int r = Random.Range(0, cardPool.Length);
                            cardLooted = cardPool[r];

                            if (cardLooted.rarity == Card.Rarity.epic || cardLooted.rarity == Card.Rarity.legendry)
                            {
                                epicMin = false;
                                rareMin = false;
                            }
                            else if (cardLooted.rarity == Card.Rarity.rare)
                            {
                                rareMin = false;
                            }

                            cardsLooted.Add(cardLooted);
                        }

                    }
                }

                for (int z = 0; z < loots.Length; z++)
                {
                    loots[z].gameObject.SetActive(true);
                    loots[z].card = cardsLooted[z];
                    loots[z].DisplayCard();
                }

                AddPlayerCards(cardsLooted);

                Debug.Log("Exploration " + (j + 1) + " terminée");

                yield return new WaitForSeconds(1.5f);

            }

            foreach (CardDisplay c in loots)
            {
                c.gameObject.SetActive(false);
            }

            foreach (GameObject g in selectedExplo)
            {
                g.SetActive(false);
            }

            foreach (GameObject g in exploButtons)
            {
                g.SetActive(false);
            }
        }


    }


    public void AddPlayerCards(List<Card> cards)
    {
        foreach(Card c in cards)
        {
            switch (c.name)
            {
                case "Apex":
                    player.cardNumbers[0]++;
                    break;

                case "Blue":
                    player.cardNumbers[1]++;
                    break;

                case "Bomber":
                    player.cardNumbers[2]++;
                    break;

                case "Heal":
                    player.cardNumbers[3]++;
                    break;

                case "Int":
                    player.cardNumbers[4]++;
                    break;

                case "Lux":
                    player.cardNumbers[5]++;
                    break;

                case "Nox":
                    player.cardNumbers[6]++;
                    break;

                case "Tank":
                    player.cardNumbers[7]++;
                    break;

                case "Tanko":
                    player.cardNumbers[8]++;
                    break;

                case "Zouh":
                    player.cardNumbers[9]++;
                    break;

                default:
                    Debug.Log("Carte non trouvée");
                    break;


            }
        }
    }
}
