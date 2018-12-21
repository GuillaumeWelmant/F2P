using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int maxCardsInHand;

    public List<Card> deck;
    public CardDisplay[] uiHand;

    private List<Card> graveyard;
    private List<Card> hand;

    public float maxMana;

    public UIManager ui;

    private float mana;
    private int cardsInHand;

	// Use this for initialization
	void Start ()
    {
        cardsInHand = 0;
        mana = maxMana;

        hand = new List<Card>();
        graveyard = new List<Card>();

        Draw(3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetMana()
    {
        return mana;
    }

    public void GainMana(int m)
    {
        mana += m;
        if (mana >= maxMana)
        {
            mana = maxMana;
        }
        ui.DisplayMana();
    }

    public void LoseMana(float m)
    {
        mana -= m;
        if (mana <= 0)
        {
            mana = 0;
            Debug.LogWarning("You Lose !");
        }
        ui.DisplayMana();
    }

    public void Draw(int n)
    {
        Debug.Log("Draw " + n + " cards");
        for(int i=0; i < n; i++)
        {
            if (cardsInHand < maxCardsInHand)
            {
                if(deck.Count <= 0)
                {
                    foreach(Card ca in graveyard)
                    {
                        deck.Add(ca);
                    }
                    graveyard.Clear();
                }

                int r = Random.Range(0, deck.Count);

                int j = 0;
                bool stop = false;
                for(int k = 0; k < uiHand.Length; k++)
                {
                    if (!stop)
                    {
                        if (!uiHand[k].isActiveAndEnabled)
                        {
                            j = k;
                            stop = true;
                        }
                    }
                }
                uiHand[j].gameObject.SetActive(true);

                Card c = deck[r];

                uiHand[j].card = c;
                uiHand[j].DisplayCard();
                hand.Add(c);
                deck.Remove(c);
                cardsInHand++;
            }
        }
    }

    public void UseCard(Card c)
    {
        graveyard.Add(c);
        bool stop = false;
        for(int i=0; i < uiHand.Length; i++)
        {
            if (!stop)
            {
                if(uiHand[i].isActiveAndEnabled && uiHand[i].card == c)
                {
                    StartCoroutine(CardDisappear(i));
                    stop = true;
                }
            }
        }
        StartCoroutine(TimerDraw(c.cooldown));
        hand.Remove(c);
        cardsInHand--;
    }

    public IEnumerator CardDisappear(int id)
    {
        uiHand[id].transform.position = new Vector3(5000, 5000, 5000);
        yield return new WaitForEndOfFrame();
        uiHand[id].ResetPos();
        uiHand[id].gameObject.SetActive(false);
    }

    public IEnumerator TimerDraw(float t)
    {
        yield return new WaitForSeconds(t);
        Draw(1);
    }
}
