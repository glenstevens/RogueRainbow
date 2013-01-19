using UnityEngine;

/// <summary>
/// Make an object hover above a surface
/// </summary>
public class Hover : MonoBehaviour {
	//public bool aboveSurface = true;
	public Vector3 bounceAmount = new Vector3(0f, 0.5f, 0f);
	public float bounceSpeed = 0.5f;
	
	Vector3 originalPosition;
	bool movingAway = true;
	
	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// Update the direction so it goes away and comes back
		if (movingAway && transform.position == originalPosition + bounceAmount)
		{
			movingAway = false;
		}
		else if (!movingAway && transform.position == originalPosition)
		{
			movingAway = true;
		}
		
		// Move the object
		if (movingAway)
		{
			transform.position = Vector3.MoveTowards(transform.position, originalPosition + bounceAmount, bounceSpeed);
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, originalPosition, bounceSpeed);
		}
	}
}
