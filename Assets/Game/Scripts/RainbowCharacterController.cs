using UnityEngine;

public class RainbowCharacterController : MonoBehaviour
{
	public GameObject rainbowFront;
	public float height = 2.0f;
	public float forwardSpeed = 5.0f;
	public float reverseSpeed = 2.5f;
	public float rotationSpeed = 50.0f;
	public float constantForwardSpeed = 0.1f;
	
	Transform this_transform;
	Bounds terrainBounds;
	
	float Speed { get { return (Input.GetAxis("Vertical") > 0) ? forwardSpeed : reverseSpeed; } }
	
	// Use this for initialization
	void Start () {
		this_transform = transform;
		GameObject terrainObj = GameObject.FindGameObjectWithTag(Constants.TerrainTag);
		if (terrainObj != null) terrainBounds = terrainObj.collider.bounds;
	}
	
	// Update is called once per frame
	void Update () {
		if (rainbowFront == null) return;
		
		// Move to new position
		float translation = (Input.GetAxis("Vertical") * Speed + constantForwardSpeed) * Time.deltaTime;
		this_transform.Translate(0, 0, translation);
		// Check against bounds
		Vector3 pos = new Vector3(Mathf.Clamp(this_transform.position.x, terrainBounds.min.x, terrainBounds.max.x),
			Mathf.Clamp(this_transform.position.y, terrainBounds.min.y, terrainBounds.max.y),
			Mathf.Clamp(this_transform.position.z, terrainBounds.min.z, terrainBounds.max.z));
		this_transform.position = pos;
			
		// Change player direction
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
		this_transform.Rotate(0, rotation, 0);
		
		// Ensure proper height
		RaycastHit hit;
        if (Physics.Raycast(this_transform.position, -Vector3.up, out hit))
		{
			float distanceToGround = hit.distance;
			float heightAdjustment = height - distanceToGround;
			this_transform.Translate(0, heightAdjustment, 0);
		}
	}
}
