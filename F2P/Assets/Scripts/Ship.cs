using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public float startHealth;
    public float startDamage;

    public float fireRate;
    public Transform[] canons;
    public Projectile projectile;

    public float[] speeds;
    public Vector3[] directions;
    public float[] patternTimes;

    public bool playerShip;

    public bool ray;
    public float battleDist;
    public float fireRange;

    public int manaBurst;

    private int id;
    private float timeElapsed;
    private float fireRateTimeElapsed;

    private float shipDamage;
    private float shipHealth;
    private bool canMove;
    private bool canShoot;

    private UIManager ui;

	// Use this for initialization
	void Start ()
    {
        id = 0;
        timeElapsed = 0;
        canMove = true;
        if (!ray)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }

        if(startHealth > 0)
        {
            shipHealth = startHealth;
        }
        if(startDamage > 0)
        {
            shipDamage = startDamage;
        }
        ui = FindObjectOfType<UIManager>();
	}

    public void InitiateShip(int atk, int hp)
    {
        shipDamage = atk;
        shipHealth = hp;

        Debug.Log("New ship has " + shipHealth + " hit points and do " + shipDamage + " damage");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (canMove)
        {
            Move();
        }
        if (canShoot)
        {
            Shoot();
        }


        if (ray)
        {
            RaycastHit hit;
            Ray upRay;

            if (playerShip)
            {
                upRay = new Ray(transform.position, transform.up);
            }
            else
            {
                upRay = new Ray(transform.position, -transform.up);
            }
                    



            if(Physics.Raycast(upRay, out hit))
            {
                if (!hit.collider.CompareTag("Shredder"))
                {
                    if (playerShip)
                    {
                        float d = hit.distance;
                        if (d <= battleDist && !hit.collider.CompareTag("Boss") && !hit.collider.CompareTag("Ship"))
                        {
                            SetCanMove(false);
                        }
                        else
                        {
                            SetCanMove(true);
                        }

                        if (d <= fireRange && !hit.collider.CompareTag("Ship"))
                        {
                            SetCanShoot(true);
                        }
                        else
                        {
                            SetCanShoot(false);
                        }
                    }
                    else
                    {
                        float d = hit.distance;
                        if (d <= battleDist && !hit.collider.CompareTag("Mothership") && !hit.collider.CompareTag("EnemyShip"))
                        {
                            SetCanMove(false);
                        }
                        else
                        {
                            SetCanMove(true);
                        }

                        if (d <= fireRange && !hit.collider.CompareTag("EnemyShip"))
                        {
                            SetCanShoot(true);
                        }
                        else
                        {
                            SetCanShoot(false);
                        }
                    }

                }

            }
        }

	}

    public void Move()
    {
        if ((directions[id].x > 0 && transform.position.x >= 45))
        {
            directions[id] = new Vector3(-directions[id].x, directions[id].y, directions[id].z);
        }

        if ((directions[id].x < 0 && transform.position.x <= -45))
        {
            directions[id] = new Vector3(-directions[id].x, directions[id].y, directions[id].z);
        }

        transform.position += directions[id] * speeds[id] * 0.01f;
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= patternTimes[id])
        {
            id++;
            timeElapsed = 0;
            if (id >= speeds.Length)
            {
                id = 0;
            }
        }
    }

    public void Shoot()
    {
        if(fireRateTimeElapsed <= 0f && projectile != null)
        {
            if (playerShip)
            {
                for (int i = 0; i < canons.Length; i++)
                {
                    Instantiate(projectile, canons[i].position, Quaternion.identity).GetComponent<Projectile>().InitializeProj(shipDamage);
                }
            }
            else
            {
                for (int i = 0; i < canons.Length; i++)
                {
                    Projectile p = Instantiate(projectile, canons[i].position, Quaternion.identity).GetComponent<Projectile>();
                    p.InitializeProj(shipDamage);
                    p.transform.Rotate(0, 0, 180);
                }
            }

            fireRateTimeElapsed = fireRate;
        }
        else
        {
            fireRateTimeElapsed -= Time.deltaTime;
        }
    }

    public void SetCanMove(bool t)
    {
        canMove = t;
    }

    public void SetCanShoot(bool t)
    {
        canShoot = t;
    }

    public void Damage(float d)
    {
        shipHealth -= d;
        if (shipHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (gameObject.CompareTag("Boss"))
        {
            ui.DisplayBossJauge(shipHealth, startHealth);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerShip)
        {
            if (other.CompareTag("Boss"))
            {
                other.GetComponent<Ship>().Damage(shipDamage);
                Player p = FindObjectOfType<Player>();
                p.GainMana(manaBurst);
                Destroy(gameObject);
            }
        }
        else
        {
            if (other.CompareTag("Mothership"))
            {
                Player p = FindObjectOfType<Player>();
                p.LoseMana(shipDamage);
                Destroy(gameObject);
            }
        }
    }
}
