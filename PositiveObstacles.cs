using UnityEngine;
using System.Collections;

public class PositiveObstacles : MonoBehaviour {

	public float moveSpeed;
	public byte object_link_id;
	GameObject playerObject;
	[HideInInspector]
	public bool hitByPlayer;
	public bool linked;
	
	// Use this for initialization
	void Start () 
	{
		hitByPlayer = false;
		linked = false;
		moveSpeed = 4.5f;
		playerObject = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hitByPlayer == true && linked == false)
		{
			transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, moveSpeed * Time.deltaTime);
		}
	}
}
