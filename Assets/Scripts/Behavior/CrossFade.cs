using UnityEngine;
using System.Collections;

public enum FadeState {
	Fading,
	Normal
};

public class CrossFade : MonoBehaviour 
{	
	// fade speed
	public float FadeSpeed;
	// current fade state
	public FadeState State { get; set; }

	// クロスフェードかGrayScale.
	public enum Type{
		CrossFade,
		GrayScale,
	};
	public Type ShaderType { get; set; }
		
	
	// property name of main texture
	private static readonly string PROPERTY_MAINTEX = "_MainTex";
	//property name of destination texture
	private static readonly string PROPERTY_NEWTEX = "_NewTex";
	//property name of blend rate of two textures
	private static readonly string PROPERTY_BLEND = "_Blend";
	public static readonly Color SepiaColor = new Color( 0.94f, 0.78f, 0.57f, 1.0f );

	// blend rate
	private float mBlendRate;
	
	// -------------------------------------------------------
	// Start
	// -------------------------------------------------------
	void Start () {
		if (State != FadeState.Fading) {
			State = FadeState.Normal;
			mBlendRate = this.renderer.material.GetFloat(PROPERTY_BLEND);
		}
	}
	
	// -------------------------------------------------------
	// Update
	// -------------------------------------------------------
	void Update () {
		if( renderer == null ){
			return;
		}
		switch (State) {
			case FadeState.Normal:
				break;
			case FadeState.Fading:
				mBlendRate = renderer.material.GetFloat(PROPERTY_BLEND);
				mBlendRate += FadeSpeed * Time.deltaTime;
				if ( mBlendRate > 1.0f ) {
					mBlendRate = 1.0f;
					Vector3 offset = renderer.material.GetTextureOffset(PROPERTY_NEWTEX);
					Vector3 scale = renderer.material.GetTextureScale(PROPERTY_NEWTEX);
					Texture tex = renderer.material.GetTexture(PROPERTY_NEWTEX);
					renderer.material.SetTexture(PROPERTY_MAINTEX, tex);
					renderer.material.SetTextureOffset(PROPERTY_MAINTEX, offset);
					renderer.material.SetTextureScale(PROPERTY_MAINTEX, scale);
					renderer.material.SetTexture(PROPERTY_NEWTEX, null);
					mBlendRate = 0.0f;
					State = FadeState.Normal;
				} 
				renderer.material.SetFloat(PROPERTY_BLEND, mBlendRate);
			break;
		}
	}
	
	// -------------------------------------------------------
	// ChangeTexture
	// -------------------------------------------------------
	public void ChangeTexture (Texture newTex, Vector3 offset, Vector3 scale ) 
	{		
		mBlendRate = 0.0f;
		string targetTex = PROPERTY_NEWTEX;
		renderer.material.SetTexture(targetTex, newTex);
		renderer.material.SetTextureOffset(targetTex, offset);
		renderer.material.SetTextureScale(targetTex, scale);
		renderer.material.SetFloat(PROPERTY_BLEND, mBlendRate);
	}
}
