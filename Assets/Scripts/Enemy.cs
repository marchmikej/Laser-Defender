using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed = 3f;
	public float borderBuffer = 1f;
	public float laserSpeed;
	float xmin;
	float xmax;
	float ymin;
	float ymax;
	float ydirection;

	// Use this for initialization
	void Start () {
		// Get borders of screen
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		Vector3 uppermost = Camera.main.ViewportToWorldPoint(new Vector3(0,1,distance));
		Vector3 lowermost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		xmin = leftmost.x + borderBuffer;
		xmax = rightmost.x -  borderBuffer;
		ymin = lowermost.y + borderBuffer;
		ymax = uppermost.y - borderBuffer;
		ydirection = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Random rnd = new Random ();
		//float goX = (float)rnd.Next(-1, 1); 
		//float goY = (float)rnd.Next(-1, 1); 

		//transform.position += new Vector3(Random.Range(-1.0f, 1.0f)*speed*Time.deltaTime, Random.Range(-1.0f, 1.0f)*speed*Time.deltaTime, 0);
		transform.position += new Vector3(0, ydirection*speed*Time.deltaTime, 0);

		//Update direction if needed.  Enemies only move up and down in this case
		if (transform.position.y > ymax) {
			ydirection = -1.0f;
		} else if(transform.position.y < ymin) {
			ydirection = 1.0f;
		}

		//restricts the enemy to the game space.  Clamp keeps value within min and max
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		float newY = Mathf.Clamp(transform.position.y, ymin, ymax);
		transform.position = new Vector3(newX, newY, transform.position.z);
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "greenLaser") {
			print("hit by greenLaser");
			Destroy(gameObject);
		}
         //   coll.gameObject.SendMessage("ApplyDamage", 10);
        print("WE had a collision");
    }
}
