Shader "Custom/Abdomen" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _Tmp("Tmp", Range(0.1, 10)) = 1
        _West("West", float) = 0.5
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert vertex:vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        struct Input 
        {
            float2 uv_MainTex;
        };
        
        fixed4 _Color;
        float _Tmp;
        float _West;
        
        void vert(inout appdata_full v, out Input o )
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            if(v.vertex.y < 0)
            {
                v.vertex.xyz = float3(v.vertex.x * _Tmp, v.vertex.y, v.vertex.z);      
            }      
            else
            {
                v.vertex.x *= _West;
            }           
        }

        void surf (Input IN, inout SurfaceOutput o)
        {         
            o.Albedo = _Color;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
