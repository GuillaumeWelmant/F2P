using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public PlayerStats player;

    public GameObject storyMap;
    public GameObject eventMap;
    public GameObject shopPanel;
    public GameObject explorationPanel;
    public GameObject libraryPanel;
    public GameObject socialPanel;
    public GameObject mothershipPanel;
    public GameObject optionsPanel;

    public Text scrapsText;
    public Text darkMatterText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        scrapsText.text = player.scraps.ToString("n0");
        darkMatterText.text = player.darkMatter.ToString("n0");
	}

    public void DisplatStoryMap()
    {
        storyMap.SetActive(true);
        eventMap.SetActive(false);
        shopPanel.SetActive(false);
        explorationPanel.SetActive(false);
        libraryPanel.SetActive(false);
        socialPanel.SetActive(false);
        mothershipPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void DisplatEventMap()
    {
        storyMap.SetActive(false);
        eventMap.SetActive(true);
        shopPanel.SetActive(false);
        explorationPanel.SetActive(false);
        libraryPanel.SetActive(false);
        socialPanel.SetActive(false);
        mothershipPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void DisplatShopPanel()
    {
        storyMap.SetActive(false);
        eventMap.SetActive(false);
        shopPanel.SetActive(true);
        explorationPanel.SetActive(false);
        libraryPanel.SetActive(false);
        socialPanel.SetActive(false);
        mothershipPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void DisplatExplorationPanel()
    {
        storyMap.SetActive(false);
        eventMap.SetActive(false);
        shopPanel.SetActive(false);
        explorationPanel.SetActive(true);
        libraryPanel.SetActive(false);
        socialPanel.SetActive(false);
        mothershipPanel.SetActive(false);
        optionsPanel.SetActive(false);

        shopPanel.GetComponent<Shop>().DiplayBaseShop();
    }

    public void DisplatLibraryPanel()
    {
        storyMap.SetActive(false);
        eventMap.SetActive(false);
        shopPanel.SetActive(false);
        explorationPanel.SetActive(false);
        libraryPanel.SetActive(true);
        socialPanel.SetActive(false);
        mothershipPanel.SetActive(false);
        optionsPanel.SetActive(false);

        libraryPanel.GetComponent<Library>().UpdateLibrary();
    }

    public void DisplatSocialPanel()
    {
        storyMap.SetActive(false);
        eventMap.SetActive(false);
        shopPanel.SetActive(false);
        explorationPanel.SetActive(false);
        libraryPanel.SetActive(false);
        socialPanel.SetActive(true);
        mothershipPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void DisplatMothershipPanel()
    {
        storyMap.SetActive(false);
        eventMap.SetActive(false);
        shopPanel.SetActive(false);
        explorationPanel.SetActive(false);
        libraryPanel.SetActive(false);
        socialPanel.SetActive(false);
        mothershipPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void DisplatOptionsPanel()
    {
        storyMap.SetActive(false);
        eventMap.SetActive(false);
        shopPanel.SetActive(false);
        explorationPanel.SetActive(false);
        libraryPanel.SetActive(false);
        socialPanel.SetActive(false);
        mothershipPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }


}
