Shader "Custom/Leg" 
{
	Properties 
    {
		_Color ("Color", Color) = (1,1,1,1)
        _Tmp("Tmp", Range(0.1, 10)) = 1
	}
	SubShader 
    {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Lambert vertex:vert
		#pragma target 3.0

		struct Input 
        {
			float2 uv_MainTex;
		};

		float4 _Color;
        float _Tmp;
        
        void vert(inout appdata_full v, out Input o )
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            v.vertex.xyz = float3(v.vertex.x * _Tmp, v.vertex.y, v.vertex.z);            
        }

		void surf (Input IN, inout SurfaceOutput o) 
        {
			o.Albedo = _Color;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
