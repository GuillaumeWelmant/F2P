using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public GameObject shop1;
    public GameObject shop2;

    public int id;

    private void Start()
    {
        id = 0;
        shop1.SetActive(true);
        shop2.SetActive(false);
    }

    public void Switch()
    {
        id++;

        if (id > 1)
        {
            id = 0;
        }

        if (id == 0)
        {
            shop1.SetActive(true);
            shop2.SetActive(false);
        }
        else
        {
            shop1.SetActive(false);
            shop2.SetActive(true);
        }
    }

    public void DiplayBaseShop()
    {
        id = 0;
        shop1.SetActive(true);
        shop2.SetActive(false);
    }
}
