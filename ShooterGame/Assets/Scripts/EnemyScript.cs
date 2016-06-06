using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    private bool hasSpawn;
    private MoveScript moveScript;
    private WeaponScript[] weapons;

    void Awake()
    {
        weapons = GetComponentsInChildren<WeaponScript>();
        moveScript = GetComponent<MoveScript>();
    }

	// Use this for initialization
	void Start () {
        hasSpawn = false;
        GetComponent<Collider2D>().enabled = false;
        moveScript.enabled = false;
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (hasSpawn == false)
        {
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            foreach (WeaponScript weapon in weapons)
            {

                if (weapon != null && weapon.CanAttack && weapon.enabled)
                {
                    weapon.Attack(true);
                }
            }

            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
	}

    private void Spawn()
    {
        hasSpawn = true;

        GetComponent<Collider2D>().enabled = true;
        moveScript.enabled = true;
        foreach (WeaponScript weapon in weapons)
        {
          weapon.enabled = true;
        }
    }
}
