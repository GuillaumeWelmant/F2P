using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public bool playerProj;

    private float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.up* speed * 0.01f;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (playerProj)
        {
            if(other.CompareTag("EnemyShip") || other.CompareTag("Boss"))
            {
                other.GetComponent<Ship>().Damage(damage);
                Destroy(gameObject);
            }
        }
        else
        {
            if (other.CompareTag("Ship") || other.CompareTag("Mothership"))
            {
                if (other.CompareTag("Mothership"))
                {
                    Player player = FindObjectOfType<Player>();
                    player.LoseMana(damage);
                }
                else
                {
                    other.GetComponent<Ship>().Damage(damage);
                }

                Destroy(gameObject);
            }
        }
    }

    public void InitializeProj(float dmg)
    {
        damage = dmg;
    }
}
