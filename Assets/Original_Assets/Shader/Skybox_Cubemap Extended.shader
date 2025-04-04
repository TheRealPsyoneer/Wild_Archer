Shader "Skybox/Cubemap Extended" {
	Properties {
		[HideInInspector] _IsStandardPipeline ("_IsStandardPipeline", Float) = 1
		[StyledBanner(Skybox Cubemap Extended)] _SkyboxExtended ("< SkyboxExtended >", Float) = 1
		[StyledCategory(Cubemap)] _Cubemapp ("[ Cubemapp ]", Float) = 1
		[Gamma] _TintColor ("Tint Color", Vector) = (0.5,0.5,0.5,1)
		_Exposure ("Exposure", Range(0, 8)) = 1
		[NoScaleOffset] _Tex ("Cubemap (HDR)", Cube) = "black" {}
		_CubemapPosition ("Cubemap Position", Float) = 0
		[StyledCategory(Rotation)] _Rotationn ("[ Rotationn ]", Float) = 1
		[Toggle(_ENABLEROTATION_ON)] _EnableRotation ("Enable Rotation", Float) = 0
		[IntRange] [Space(10)] _Rotation ("Rotation", Range(0, 360)) = 0
		_RotationSpeed ("Rotation Speed", Float) = 1
		[StyledCategory(Fog)] _Fogg ("[ Fogg ]", Float) = 1
		[StyledMessage(Info, The fog color can be changed from the fog settings section under the Lighting window., _EnableFog, 1, 0, 5)] _FogMessage ("# FogMessage", Float) = 0
		[Toggle(_ENABLEFOG_ON)] _EnableFog ("Enable Fog", Float) = 0
		[Space(10)] _FogIntensity ("Fog Intensity", Range(0, 1)) = 1
		_FogHeight ("Fog Height", Range(0, 1)) = 1
		_FogSmoothness ("Fog Smoothness", Range(0.01, 1)) = 0.01
		_FogFill ("Fog Fill", Range(0, 1)) = 0.5
		[HideInInspector] _Tex_HDR ("DecodeInstructions", Vector) = (0,0,0,0)
		_FogPosition ("Fog Position", Float) = 0
		[StyledCategory(Advanced)] _Advancedd ("[ Advancedd ]", Float) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
	Fallback "Skybox/Cubemap"
}