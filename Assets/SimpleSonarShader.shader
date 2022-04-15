// SimpleSonarShader scripts and shaders were written by Drew Okenfuss.
// For this shader to work, the object must have values passed in to it from the SimpleSonarShader_Parent.cs script.
// By default, this happens by having the object be a child of SimpleSonarShader_Parent.
Shader "MadeByProfessorOakie/SimpleSonarShader" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", 2D) = "white" {}
		_Metallic_Range_("Metallic (Range)", Range(0,1)) = 0.0
		_Emission("Emission", float) = 0
		[HDR] _EmissionColor("EmissionColor", Color) = (0,0,0,0)

		_RingColor("Ring Color", Color) = (1,1,1,1)
		_RingColorIntensity("Ring Color Intensity", float) = 2
		_RingSpeed("Ring Speed", float) = 1
		_RingWidth("Ring Width", float) = 0.1
		_RingIntensityScale("Ring Range", float) = 1
		_RingTex("Ring Texture", 2D) = "white" {}

		_BumpTex("Normal Map", 2D) = "bump" {}
		_OcclTex("Occlusion Map", 2D) = "white" {}

		[HDR]_RingEmission("RingEmission", Color) = (1,1,1,1)
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf Standard fullforwardshadows
#pragma target 3.0

	sampler2D _MainTex;
	sampler2D _RingTex;
	sampler2D _BumpTex;
	sampler2D _OcclTex;

	struct Input {
		float2 uv_MainTex;
		float2 uv_BumpTex;
		float2 uv_OcclTex;

		float3 worldPos;
	};

	// The size of these arrays is the number of rings that can be rendered at once.
	// If you want to change this, you must also change QueueSize in SimpleSonarShader_Parent.cs
	half4 _hitPts[5];
	half _StartTime;
	half _Intensity[5];
	half _Glossiness;
	half _Metallic;
	half _Metallic_Range_;

	half _RingColorIntensity;
	half _RingSpeed;
	half _RingWidth;
	half _RingIntensityScale;
	half _Emission;

	fixed4 _RingEmission;
	fixed4 _EmissionColor;
	fixed4 _Color;
	fixed4 _RingColor;

	void surf(Input IN, inout SurfaceOutputStandard o)
	{
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		float3 n = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex));
		fixed4 oc = tex2D(_OcclTex, IN.uv_MainTex);

		o.Albedo = c.rgb;
		o.Normal = n;
		o.Occlusion = oc.g;
		o.Emission = c.rgb * tex2D(_MainTex, IN.uv_MainTex).a * _EmissionColor * _Emission;

		half DiffFromRingCol = abs(o.Albedo.r - _RingColor.r) + abs(o.Albedo.b - _RingColor.b) + abs(o.Albedo.g - _RingColor.g);
		
		// Check every point in the array
		// The goal is to set RGB to highest possible values based on current sonar rings
		for (int i = 0; i < 5; i++) {

			half d = distance(_hitPts[i], IN.worldPos);
			half intensity = _Intensity[i] * _RingIntensityScale;
			half val = (1 - (d / intensity));

			if (d < (_Time.y - _hitPts[i].w) * _RingSpeed && d >(_Time.y - _hitPts[i].w) * _RingSpeed - _RingWidth && val > 0) {
				half posInRing = (d - ((_Time.y - _hitPts[i].w) * _RingSpeed - _RingWidth)) / _RingWidth;

				// Calculate predicted RGB values sampling the texture radially
				float angle = acos(dot(normalize(IN.worldPos - _hitPts[i]), float3(1,0,0))); //반사각
				val *= tex2D(_RingTex, half2(1 - posInRing, angle));
				half3 tmp = _RingColor * val + c * (1 - val);

				// Determine if predicted values will be closer to the Ring color
				half tempDiffFromRingCol = abs(tmp.r - _RingColor.r) + abs(tmp.b - _RingColor.b) + abs(tmp.g - _RingColor.g);
				if (tempDiffFromRingCol < DiffFromRingCol)
				{
					// Update values using our predicted ones.
					DiffFromRingCol = tempDiffFromRingCol;
					o.Albedo.r = tmp.r;
					o.Albedo.g = tmp.g;
					o.Albedo.b = tmp.b;
					o.Albedo.rgb *= _RingColorIntensity;
					o.Emission = tmp.rgb * _RingEmission; //자체적으로 발광.
				}
			}
		}

		o.Metallic = _Metallic * _Metallic_Range_;
		o.Smoothness = _Glossiness;
	}

	ENDCG
	}
		FallBack "Diffuse"
}
