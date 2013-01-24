Shader "Custom/SaturationEffect" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
}

SubShader {
	Pass {
		ZTest Always Cull Off ZWrite Off
		Fog { Mode off }
				
CGPROGRAM
#pragma vertex vert_img
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest 
#include "UnityCG.cginc"

uniform sampler2D _MainTex;
uniform half _red;
uniform half _green;
uniform half _blue;

fixed4 frag (v2f_img i) : COLOR
{
	float3 luminanceWeights = float3(0.299,0.587,0.114);
	fixed4 original = tex2D(_MainTex, i.uv);
	float luminance = dot(original, luminanceWeights);
	float outputR = lerp(luminance, original.r, _red);
	float outputG = lerp(luminance, original.g, _green);
	float outputB = lerp(luminance, original.b, _blue);
	//retain the incoming alpha
	float4 output = float4(outputR, outputG, outputB, original.a);
	return output;
}
 
ENDCG

	}
}

Fallback off
}