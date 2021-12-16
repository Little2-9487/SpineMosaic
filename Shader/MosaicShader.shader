Shader "Custom/MosaicShader"
{
	Properties
	{
		_Pixelation ("Pixelation", Range(0.001, 0.1)) = 0.01
		_XScale ("XScale", Range(0, 1)) = 1
		_YScale ("YScale", Range(0, 1)) = 1
	}
	SubShader
	{
		Tags { "RenderType"="Opaque"
		"Queue" = "Overlay" }
		LOD 100

		GrabPass
        {
			//Do a grab pass
        }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float4 screenUV : TEXCOORD1;
			};

			sampler2D _GrabTexture;
			float _Pixelation;
			float _XScale;
			float _YScale;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.screenUV = ComputeGrabScreenPos(o.vertex);
				return o;
			}

			
			fixed4 frag (v2f i) : SV_Target
			{
				float4 screenUV = i.screenUV / _Pixelation * 0.1;
				screenUV.x = round(screenUV.x / _XScale) * _XScale;
				screenUV.y = round(screenUV.y / _YScale) * _YScale;
				half4 screenColorPixelized = tex2Dproj(_GrabTexture, screenUV);
				return screenColorPixelized;
			}
			ENDCG
		}
	}
}
