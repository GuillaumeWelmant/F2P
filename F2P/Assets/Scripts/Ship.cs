using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public float startHealth;
    public float startDamage;

    public float fireRate;
    public float summonRate;

    public Transform[] canons;
    public Transform[] hangars;
    public Projectile[] projectiles;
    public Ship[] summons;

    public float[] speeds;
    public Vector3[] directions;
    public float[] patternTimes;

    public bool playerShip;

    public bool ray;
    public float battleDist;
    public float fireRange;

    public int manaBurst;
    public float explosionDamage;
    public bool mover;
    public bool summoner;

    private int id;
    private float timeElapsed;
    private float fireRateTimeElapsed;
    private float summonRateTimeElapsed;
    private int projectileID;
    private int summonID;
    private int hangarID;


    private float shipDamage;
    private float shipHealth;
    private bool canMove;
    private bool canShoot;
    private bool canSummon;

    private UIManager ui;

	// Use this for initialization
	void Start ()
    {
        id = 0;
        timeElapsed = 0;
        canMove = mover;
        canSummon = summoner;
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

        summonID = 0;
        hangarID = 0;
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
        if (canSummon)
        {
            Summon();
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
        if ((directions[id].x > 0 && transform.position.x >= 55))
        {
            directions[id] = new Vector3(-directions[id].x, directions[id].y, directions[id].z);
        }

        if ((directions[id].x < 0 && transform.position.x <= -55))
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

            if (directions[id].x > 0 && transform.position.x >= 35)
            {
                directions[id] *= -1;
            }

            if (directions[id].x < 0 && transform.position.x <= -35)
            {
                directions[id] *= -1;
            }
        }
    }

    public void Shoot()
    {
        if(fireRateTimeElapsed <= 0f && projectiles[projectileID] != null)
        {
            if (playerShip)
            {
                for (int i = 0; i < canons.Length; i++)
                {
                    Instantiate(projectiles[projectileID], canons[i].position, Quaternion.identity).GetComponent<Projectile>().InitializeProj(shipDamage);
                }
            }
            else
            {
                for (int i = 0; i < canons.Length; i++)
                {
                    Projectile p = Instantiate(projectiles[projectileID], canons[i].position, Quaternion.identity).GetComponent<Projectile>();
                    p.InitializeProj(shipDamage);
                    p.transform.Rotate(0, 0, 180);
                }
            }

            projectileID++;

            if(projectileID >= projectiles.Length)
            {
                projectileID = 0;
            }

            fireRateTimeElapsed = fireRate;
        }
        else
        {
            fireRateTimeElapsed -= Time.deltaTime;
        }
    }

    public void Summon()
    {
        if(summonRateTimeElapsed <= 0f && summons[summonID] != null && hangars[hangarID] != null)
        {
            if (!playerShip)
            {
                Instantiate(summons[summonID], hangars[hangarID].position, Quaternion.identity);

                summonID++;
                hangarID++;

                if(summonID >= summons.Length)
                {
                    summonID = 0;
                }

                if(hangarID >= hangars.Length)
                {
                    hangarID = 0;
                }
            }

            summonRateTimeElapsed = summonRate;
        }
        else
        {
            summonRateTimeElapsed -= Time.deltaTime;
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
            if (gameObject.CompareTag("Boss"))
            {
                Player p = FindObjectOfType<Player>();
                p.CleanScene();
                ui.Win();
            }
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
                other.GetComponent<Ship>().Damage(explosionDamage);
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
