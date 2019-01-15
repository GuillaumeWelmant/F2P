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

	// Use this for initialization
	void Start ()
    {
        invok.SetActive(true);
        dailyInvok.SetActive(false);
        stdInvok.SetActive(false);
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

    public void StartExploration(int i)
    {
        StartCoroutine(Explore(i));
    }

    public IEnumerator Explore(int i)
    {
        foreach(CardDisplay c in loots)
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

        for(int j=0; j<i; j++)
        {
            rareMin = true;

            cardsLooted.Clear();

            for(int k=0; k<3; k++)
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
                    if(epicMin && j >= 9)
                    {
                        while(cardLooted.rarity != Card.Rarity.epic && cardLooted.rarity != Card.Rarity.legendry)
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

            for(int z=0; z<loots.Length; z++)
            {
                loots[z].gameObject.SetActive(true);
                loots[z].card = cardsLooted[z];
                loots[z].DisplayCard();
            }

            Debug.Log("Exploration " + (j + 1) + " terminée");

            yield return new WaitForSeconds(1.5f);

        }

        foreach(CardDisplay c in loots)
        {
            c.gameObject.SetActive(false);
        }
                
    }
}
