Shader "Flip Normals" {
          Properties {   
			_MainTex ("Color (RGB) Alpha (A)", 2D) = "white"
         }
          SubShader {
            
            Tags { "Queue"="Transparent" "RenderType"="Transparent" }
            
            Cull Front
            
            CGPROGRAM
            
            #pragma surface surf Lambert vertex:vert
			#pragma surface surf Lambert alpha

            sampler2D _MainTex;
     
             struct Input {
                 float2 uv_MainTex;
                 float4 color : COLOR;
             };
            
            
            void vert(inout appdata_full v)
            {
                v.normal.xyz = v.normal * -1;
            }
            
            void surf (Input IN, inout SurfaceOutput o) {
                      fixed3 result = tex2D(_MainTex, IN.uv_MainTex);
                 o.Albedo = result.rgb;
                 o.Alpha = tex2D (_MainTex, IN.uv_MainTex).a;
            }
            
            ENDCG
            
          }
          
          Fallback "Diffuse"
     }