using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    public bool randomMove = false;
    private Vector2 movement;
    private float changeTime = 0;
    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        if (randomMove && Time.time >= changeTime)
        {
            RandomMove(bottomBorder, topBorder);
            transform.position = new Vector3(
                    transform.position.x,
                    Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
                    transform.position.z
                );
        }

        
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);   
	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    private void RandomMove(float minY, float maxY)
    {
        int randomY = Random.Range(-1, 2);
        changeTime = Time.time + Random.value;

        if (transform.position.y >= maxY-1 || transform.position.y <= minY-1)
        {
            randomY = -randomY;
        }

        direction.y = randomY; 
    }

}
