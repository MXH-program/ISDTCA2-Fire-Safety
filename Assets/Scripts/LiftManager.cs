using UnityEngine;
using System.Collections;

public class LiftManager : MonoBehaviour 
{
	private void OnTriggerStay(Collider collision)
	{
		if(collision.transform.tag.Contains("Player"))
		{
			transform.parent.Translate(-transform.parent.up * 1f * Time.fixedDeltaTime, Space.World);
			collision.GetComponent<fireman>().playerHealth -= Time.fixedDeltaTime * 10;
		}
	}
}
