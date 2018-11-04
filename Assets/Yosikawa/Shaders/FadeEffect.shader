//
// FadeEffect.shader
//

/// <summary>
/// フェードエフェクト
/// </summary>
Shader "Custom/FadeEffect" 
{
	Properties
	{
		_DisolveTex("Disolve tex", 2D) = "white"{}
		_Threshold("Threshold", Range(0, 1)) = 0.0
		_Color("Color", Color) = (1,1,1,1)
	}
	SubShader
	{
		Tags
		{
			"RenderType" = "Transparent"
			"Queue" = "Transparent"
		}

		Cull Off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM

			#include "UnityCG.cginc"

			#pragma vertex vert_img
			#pragma fragment frag

			sampler2D _DisolveTex;
			float _Threshold;
			float4 _Color;

			float4 frag(v2f_img i) : COLOR
			{
				float4 albedo = float4(1,1,1,1);
				float4 main = float4(0, 0, 0, 1);

				//i.uv *= 20;
				float4 m = tex2D(_DisolveTex, i.uv);
				
				float g = m.r * 0.2 + m.g * 0.7 + m.b * 0.1;
				if (g < _Threshold * 1.05) 
				{
					discard;
				}

				albedo = main;
				albedo.a = main.a;
				return albedo;
			}
		ENDCG
		}
	}
}