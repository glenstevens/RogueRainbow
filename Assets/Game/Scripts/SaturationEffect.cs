using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/SaturationEffect")]
public class SaturationEffect : ImageEffectBase {
	public float    red;
	public float    green;
	public float    blue;

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		material.SetFloat("_red", red);
		material.SetFloat("_green", green);
		material.SetFloat("_blue", blue);
		Graphics.Blit (source, destination, material);
	}
}
