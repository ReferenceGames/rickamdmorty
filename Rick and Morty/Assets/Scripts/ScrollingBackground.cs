using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour
{
	
	public float speed = 1;
	public static ScrollingBackground current;

	void Update()
	{
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (Time.time * speed, 0f);
	}

	/*
	public float scrollSpeed;
	public float tileSizeZ;
	
	private Vector3 startPosition;
	
	void Start ()
	{
		startPosition = transform.position;
	}
	
	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;
	}
	*/
	
}