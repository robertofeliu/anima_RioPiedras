using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public static Controller instance;

	public GameObject NegativeObjects;
	public GameObject PositiveObjects;
	Rigidbody2D[] neg_rigid;
	SpriteRenderer[] pos_objects;
	byte phase;

	[HideInInspector]
	public byte linked_objects;
	public byte number_of_linked_objects;
	public bool hit_player;
	public bool hit_neg_obj;
	public bool hit_pos_obj;
	
	// Use this for initialization
	void Start () {
		neg_rigid = NegativeObjects.GetComponentsInChildren<Rigidbody2D>();
		pos_objects = PositiveObjects.GetComponentsInChildren<SpriteRenderer>();
		linked_objects = 0;
		phase = 1;
		DetectNumberOfPosObjects();
	}

	void Awake()
	{
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void GetToPhase2()
	{
		foreach(Rigidbody2D r in neg_rigid)
		{
			r.rigidbody2D.gravityScale = 1;
		}
	}

	void DetectNumberOfPosObjects()
	{
		foreach(SpriteRenderer s in pos_objects)
		{
			number_of_linked_objects++;
		}
	}

	public byte GetPhase()
	{
		return phase;
	}
}
