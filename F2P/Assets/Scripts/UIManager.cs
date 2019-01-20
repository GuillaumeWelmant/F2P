using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public Text mana;
    public Player player;

    public GameObject manaJauge;
    public GameObject bossJauge;

    public GameObject winPanel;
    public GameObject losePanel;

    public int scrapsWin;
    public int darkMatterWin;

    public Text scrapsText;
    public Text darkMatterText;

    public Button endLevelButton;
    public Button recolteurButton;

    private PlayerStats stats;

	// Use this for initialization
	void Start ()
    {
        stats = FindObjectOfType<PlayerStats>();
        mana.text = player.GetMana() + " / " + player.maxMana;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        scrapsText.gameObject.SetActive(false);
        darkMatterText.gameObject.SetActive(false);
        endLevelButton.gameObject.SetActive(false);
        recolteurButton.gameObject.SetActive(false);
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

    public void Win()
    {
        endLevelButton.gameObject.SetActive(true);
        recolteurButton.gameObject.SetActive(true);
        scrapsText.gameObject.SetActive(true);
        darkMatterText.gameObject.SetActive(true);
        scrapsText.text = scrapsWin.ToString("n0");
        darkMatterText.text = darkMatterWin.ToString("n0");
        winPanel.SetActive(true);
        losePanel.SetActive(false);
    }

    public void Lose()
    {
        endLevelButton.gameObject.SetActive(true);
        recolteurButton.gameObject.SetActive(true);
        scrapsText.gameObject.SetActive(true);
        darkMatterText.gameObject.SetActive(true);
        scrapsWin = 0;
        darkMatterWin = 0;
        scrapsText.text = scrapsWin.ToString("n0");
        darkMatterText.text = darkMatterWin.ToString("n0");
        losePanel.SetActive(true);
        winPanel.SetActive(false);
    }

    public void EndLevel()
    {
        stats.scraps += scrapsWin;
        stats.darkMatter += darkMatterWin;
        SceneManager.LoadScene(0);
    }

    public void UseRecolteur()
    {
        recolteurButton.interactable = false;
        scrapsWin *= 2;
        darkMatterWin *= 3;
        scrapsText.text = scrapsWin.ToString("n0");
        darkMatterText.text = darkMatterWin.ToString("n0");
    }
}
