using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mothership : MonoBehaviour {

    public int upgradeCost;
    public float upgradeTime;

    public Text[] timeText;
 


    private PlayerStats player;
    private float timeLeft;
    private float secondCounter;



	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerStats>();
        timeLeft = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(timeLeft > 0)
        {
            secondCounter -= Time.deltaTime;
            if(secondCounter <= 0)
            {
                secondCounter = 1;
                timeLeft--;
                if(timeLeft <= 0)
                {
                    player.mothershipLevel += 1;
                }
            }
        }
        DisplayTimeText();
	}


    public void DisplayTimeText()
    {
        if(timeLeft > 0)
        {
            foreach(Text txt in timeText)
            {
                txt.gameObject.SetActive(true);
            }
            int h = 0;
            int m = 0;
            int s = 0;


            int t = (int)timeLeft;

            while (t > 0)
            {
                if(t >= 3600)
                {
                    h++;
                    t -= 3600;
                }
                else if(t >= 60)
                {
                    m++;
                    t -= 60;
                }
                else
                {
                    s += t;
                    t = 0;
                } 
            }

            if (h >= 10)
            {
                timeText[0].text = h.ToString("n0");
            }
            else
            {
                timeText[0].text = "0" + h.ToString("n0");
            }

            if (m >= 10)
            {
                timeText[2].text = m.ToString("n0");
            }
            else
            {
                timeText[2].text = "0" + m.ToString("n0");
            }

            if (s >= 10)
            {
                timeText[4].text = s.ToString("n0");
            }
            else
            {
                timeText[4].text = "0" + s.ToString("n0");
            }

        }
        else
        {
            foreach (Text t in timeText)
            {
                t.gameObject.SetActive(false);
            }
        }
    }


    public void UpgradeShields()
    {
        timeLeft = upgradeTime;
        secondCounter = 1;
    }
}
