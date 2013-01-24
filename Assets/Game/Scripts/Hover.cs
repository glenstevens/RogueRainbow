using UnityEngine;

/// <summary>
/// Make an object hover above a surface
/// </summary>
public class Hover : MonoBehaviour {
	//public bool aboveSurface = true;
	public Vector3 bounceAmount = new Vector3(0f, 0.5f, 0f);
	public float bounceSpeed = 0.5f;
	
	Transform this_transform;
	Vector3 originalPosition;
	bool movingAway = true;
	
	// Use this for initialization
	void Start () {
		this_transform = transform;
		originalPosition = this_transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.paused) return;
		
		// Update the direction so it goes away and comes back
		if (movingAway && this_transform.position == originalPosition + bounceAmount)
		{
			movingAway = false;
		}
		else if (!movingAway && this_transform.position == originalPosition)
		{
			movingAway = true;
		}
		
		// Move the object
		if (movingAway)
		{
			this_transform.position = Vector3.MoveTowards(this_transform.position, originalPosition + bounceAmount, bounceSpeed);
		}
		else
		{
			this_transform.position = Vector3.MoveTowards(this_transform.position, originalPosition, bounceSpeed);
		}
	}
}
