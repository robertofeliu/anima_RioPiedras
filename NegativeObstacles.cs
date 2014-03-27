using UnityEngine;
using System.Collections;

public class NegativeObstacles : MonoBehaviour {

	bool object_clicked;
	float scale_value;
	public LayerMask layerMask;

	// Use this for initialization
	void Start () {
		object_clicked = false;
		scale_value = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{
		RaycastHit2D hitInfo = new RaycastHit2D();
		hitInfo = Physics2D.Raycast(Input.mousePosition, Vector2.zero, 100, 1<<layerMask);
		if(hitInfo != null)
		{
			if(transform.gameObject.tag == "Obstacle")
		
			if(!object_clicked)
			{
				object_clicked = true;
				transform.localScale *= scale_value;
				Controller.instance.hit_neg_obj = true;
			}else
			{
				object_clicked = false;
				transform.localScale /= scale_value;
				Controller.instance.hit_neg_obj = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D hit)
	{
		if(hit.transform.tag == "Player") 
		{
			transform.rigidbody2D.AddForce((transform.position - hit.transform.position).normalized
			                               * 200);
		}else if(hit.transform.tag == "NegObstacle")
		{
			transform.rigidbody2D.AddForce((transform.position - hit.transform.position).normalized
			                               * 50);
			hit.transform.rigidbody2D.AddForce(-(transform.position - hit.transform.position).normalized
			                               * 50);
		}else if(hit.transform.tag == "Road")
		{
			transform.rigidbody2D.AddForce((transform.position - hit.transform.position).normalized
			                               * 50);
		}
	}
}
