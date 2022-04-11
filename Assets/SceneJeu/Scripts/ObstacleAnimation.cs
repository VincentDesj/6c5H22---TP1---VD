using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimation : MonoBehaviour
{
	public float speed = 5f;
	private Vector3 position;

	void Start()
	{
		position = transform.position;
	}

	void Update()
	{
		gameObject.transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 6) + position.x, transform.position.y, transform.position.z);
	}
}
