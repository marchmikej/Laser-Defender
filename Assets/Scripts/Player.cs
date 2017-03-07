using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public float borderBuffer = 1f;
	public float laserSpeed;
	float xmin;
	float xmax;
	float ymin;
	float ymax;
	public GameObject laserPreFab;

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
	}
	
	// Update is called once per frame
	void Update () {

		if( Input.GetKeyDown( KeyCode.Space ) )
		{
			print("creating laser");

			GameObject laser = Instantiate(laserPreFab, transform.position, Quaternion.identity) as GameObject;
			laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0,laserSpeed,0);
		}

		// Using Time.deltaTime because it keeps speed consistent even if processor slows down.
		// Proper term is frame rate independant speed
		if( Input.GetKey( KeyCode.UpArrow ) )
		{
			transform.position += new Vector3(0, speed*Time.deltaTime, 0);
		}
		if( Input.GetKey( KeyCode.DownArrow ) )
		{
			transform.position += new Vector3(0, -speed*Time.deltaTime, 0);
		}
		if( Input.GetKey( KeyCode.RightArrow ) )
		{
			transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
		}
		if( Input.GetKey( KeyCode.LeftArrow ) )
		{
			transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);
		}

		//restricts the player to the game space.  Clamp keeps value within min and max
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		float newY = Mathf.Clamp(transform.position.y, ymin, ymax);
		transform.position = new Vector3(newX, newY, transform.position.z);
	}
}
