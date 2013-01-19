using UnityEngine;

public class RainbowCharacterController : MonoBehaviour
{
	public GameObject rainbowFront;
	public float minHeight = 2.0f;
	public float maxHeight = 2.0f;
	public float speed = 5.0f;
	public float rotationSpeed = 50.0f;
	public float constantForwardSpeed = 0.1f;
	
	protected float translation;
	protected float rotation;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (rainbowFront == null) return;
		
		// Move to new position
		translation = Input.GetAxis("Vertical") * speed * Time.deltaTime + constantForwardSpeed;
		rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
		
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);
		
		// Calc new rainbow height
		float height = Mathf.Max(minHeight, maxHeight);//TEMP
		
		// Ensure proper height
		RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
		{
			float distanceToGround = hit.distance;
			float heightAdjustment = height - distanceToGround;
			transform.Translate(0, heightAdjustment, 0);
		}
        
	}
}
