using UnityEngine;
using System.Collections;

public class MoveBehavior : MonoBehaviour {

	public float moveSpeed = 5.0f;

	[HideInInspector]
	public float posX = 0f;
	public float posY = 0f;
	public Vector3 mouseClickPos;
	public Vector2 tmpPos;

	Vector2 moveTowards;

	void Start()
	{}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton(0)) {
			mouseClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mouseClickPos.z = transform.position.z;

			// Find the difference vector pointing from the weapon to the cursor
			Vector3 diff = mouseClickPos - transform.position;			
			// Always normalize the difference vector before using Atan2 function			
			diff.Normalize();

			// calculate the Z rotation angle using atan2			
			// Atan2 will give you an angle in radians, so you			
			// must use Rad2Deg constant to convert it to degrees			
			float rotZ = Mathf.Atan2(diff.y,diff.x) * Mathf.Rad2Deg;

			if (Vector3.Dot(Vector3.right, diff) < 0)
				rotZ += 180;
									
			// now assign the roation using Euler angle function			
			transform.rotation = Quaternion.Euler(0f,0f,rotZ);
		}

		transform.position = Vector3.MoveTowards(transform.position, mouseClickPos, moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if(hit.transform.tag == "PosObstacle")
		{
			GameObject pos_obs = (GameObject)hit.gameObject;
			PositiveObstacles p_O = pos_obs.GetComponent<PositiveObstacles>();
			p_O.hitByPlayer = true;
		}
	}
}
