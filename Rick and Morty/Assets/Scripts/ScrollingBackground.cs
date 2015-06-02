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
}