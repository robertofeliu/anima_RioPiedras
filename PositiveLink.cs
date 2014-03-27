using UnityEngine;
using System.Collections;

public class PositiveLink : MonoBehaviour {

	public byte link_id;
	public LayerMask layerMask;

	void Awake()
	{
		Physics2D.IgnoreLayerCollision(9,layerMask);
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if(hit.transform.tag == "PosObstacle")
		{
			GameObject pos_obj = (GameObject)hit.gameObject;
			PositiveObstacles p_O = pos_obj.GetComponent<PositiveObstacles>();

			if(p_O.object_link_id == link_id )
			{
				hit.transform.position = transform.position; 
				p_O.linked = true;
				Controller.instance.linked_objects++;
				if(Controller.instance.linked_objects >= Controller.instance.number_of_linked_objects)
				{
					Controller.instance.GetToPhase2();
				}
				p_O.transform.collider2D.enabled = false;
			}
		}
	}
}
