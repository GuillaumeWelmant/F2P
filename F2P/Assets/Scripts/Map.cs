using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour {

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    private Vector3 currentPos;

    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
      /*  currentPos = transform.position;
        rb = GetComponent<Rigidbody>(); */
	}
	
	// Update is called once per frame
	void Update ()
    {
	   /* if(Input.GetMouseButton(0))
        {
            if(currentPos != Input.mousePosition)
            {
                Vector3 movement = Input.mousePosition - currentPos;
                rb.AddForce(movement*150);
                currentPos = Input.mousePosition;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }*/
	}

    public void DragMap()
    {
        transform.position = Input.mousePosition;
    }

    public void GoToLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

}
