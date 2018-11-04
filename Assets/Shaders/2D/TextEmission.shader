Shader "Unlit/TextEmission"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		ZWrite On
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
				float3 viewDir : TEXCOORD1;
			};
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.normal = normalize(UnityObjectToWorldNormal(v.vertex));
				o.viewDir = normalize(ObjSpaceViewDir(v.vertex));
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float4 albedo = float4(1,1,1,1);
				float4 emission = float4(1, 1, 1, 1);

				fixed4 baseColor = fixed4(1, 0, 0, 1);
				fixed4 rimColor = fixed4(0,0,1,1);
	
				albedo = baseColor;
				float rim = 1 - saturate(dot(i.viewDir, i.normal));
				emission = rimColor * pow(rim, 2.5);
				return albedo + emission;
			}
			ENDCG
		}
	}
}
