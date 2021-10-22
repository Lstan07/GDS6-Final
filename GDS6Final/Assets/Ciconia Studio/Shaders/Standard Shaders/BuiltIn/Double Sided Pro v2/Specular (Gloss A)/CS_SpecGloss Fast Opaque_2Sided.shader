Shader "Ciconia Studio/Standard (Double Sided) V2 Legacy/Specular Gloss/Fast/Opaque"
{
	Properties
	{
		[Space(15)][Header(Main Maps)]
		[Space(15)]_GeneralTiling("General Tiling", Float) = 1
		[Space(10)]_Color("Color", Color) = (1,1,1,0)
		_MainTex("Albedo", 2D) = "white" {}
		[Space(10)]_Desaturation1("Desaturation", Float) = 0
		_Saturation1("Saturation", Range( 0 , 0.45)) = 0
		_Brightness1("Brightness", Range( -1 , 1)) = 0
		
		[Space(35)]_SpecularIntensity("Specular Intensity", Range( 0 , 2)) = 0.2
		_Glossiness("Glossiness", Range( 0 , 2)) = 0.5
		
		[Space(35)]_EmissionColor("Emission Color", Color) = (0,0,0,0)
		_EmissionMap("Emission map", 2D) = "white" {}
		_EmissiveIntensity1("Emissive Intensity", Range( 0 , 2)) = 1
		
		
        [Space(45)][Header(Reflection Properties)]
        [Space(15)][Toggle]_EnableReflection("Enable Reflection", Float) = 1
		[Space(15)]_CubemapColor("Color", Color) = (0,0,0,0)
		_Cubemap1("Cubemap", CUBE) = "black" {}
		_DesaturationCubemap("Desaturation", Range( 0 , 1)) = 0
		[Space(10)]_ReflectionIntensity1("Reflection Intensity", Range( 0 , 10)) = 2
		_BlurReflection1("Blur Reflection", Range( 0 , 7)) = 0.5
		[Space(10)]_FresnelStrength1("Fresnel Strength", Range( 0 , 8)) = 0
		_AmbientLight1("Ambient Light", Range( 0 , 8)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Off
		CGINCLUDE
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		#ifdef UNITY_PASS_SHADOWCASTER
			#undef INTERNAL_DATA
			#undef WorldReflectionVector
			#undef WorldNormalVector
			#define INTERNAL_DATA half3 internalSurfaceTtoW0; half3 internalSurfaceTtoW1; half3 internalSurfaceTtoW2;
			#define WorldReflectionVector(data,normal) reflect (data.worldRefl, half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal)))
			#define WorldNormalVector(data,normal) half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal))
		#endif
		struct Input
		{
			float2 uv_texcoord;
			float3 worldRefl;
			INTERNAL_DATA
			float3 worldPos;
			float3 worldNormal;
		};

		uniform float4 _Color;
		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform float _GeneralTiling;
		uniform float _Brightness1;
		uniform float _Saturation1;
		uniform float _Desaturation1;
		uniform float4 _EmissionColor;
		uniform sampler2D _EmissionMap;
		uniform float4 _EmissionMap_ST;
		uniform float _EmissiveIntensity1;
		uniform float _EnableReflection;
		uniform float4 _CubemapColor;
		uniform samplerCUBE _Cubemap1;
		uniform float _BlurReflection1;
		uniform float _ReflectionIntensity1;
		uniform float _DesaturationCubemap;
		uniform float _AmbientLight1;
		uniform float _SpecularIntensity;
		uniform float _FresnelStrength1;
		uniform float _Glossiness;

		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			float2 uv_MainTex = i.uv_texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
			float TilingLayer1105 = _GeneralTiling;
			float4 tex2DNode7_g26 = tex2D( _MainTex, ( uv_MainTex * TilingLayer1105 ) );
			float4 temp_cast_0 = (( 1.0 - _Brightness1 )).xxxx;
			float4 temp_cast_1 = (_Saturation1).xxxx;
			float4 temp_cast_2 = (( 1.0 - _Saturation1 )).xxxx;
			float4 temp_cast_3 = (0.0).xxxx;
			float4 temp_cast_4 = (1.0).xxxx;
			float clampResult15_g26 = clamp( _Desaturation1 , 0.0 , 1.0 );
			float3 desaturateInitialColor16_g26 = (temp_cast_3 + (pow( tex2DNode7_g26 , temp_cast_0 ) - temp_cast_1) * (temp_cast_4 - temp_cast_3) / (temp_cast_2 - temp_cast_1)).rgb;
			float desaturateDot16_g26 = dot( desaturateInitialColor16_g26, float3( 0.299, 0.587, 0.114 ));
			float3 desaturateVar16_g26 = lerp( desaturateInitialColor16_g26, desaturateDot16_g26.xxx, clampResult15_g26 );
			float4 Albedomap34 = ( _Color * float4( desaturateVar16_g26 , 0.0 ) );
			o.Albedo = Albedomap34.rgb;
			float2 uv_EmissionMap = i.uv_texcoord * _EmissionMap_ST.xy + _EmissionMap_ST.zw;
			float4 temp_cast_8 = (0.0).xxxx;
			float3 ase_worldReflection = normalize( i.worldRefl );
			float4 texCUBENode27 = texCUBElod( _Cubemap1, float4( ase_worldReflection, _BlurReflection1) );
			float clampResult21 = clamp( _ReflectionIntensity1 , 0.0 , 100.0 );
			float3 desaturateInitialColor101 = ( texCUBENode27 * ( texCUBENode27.a * clampResult21 ) ).rgb;
			float desaturateDot101 = dot( desaturateInitialColor101, float3( 0.299, 0.587, 0.114 ));
			float3 desaturateVar101 = lerp( desaturateInitialColor101, desaturateDot101.xxx, _DesaturationCubemap );
			float temp_output_8_0_g50 = Albedomap34.r;
			float4 temp_output_5_0_g50 = ( temp_output_8_0_g50 * UNITY_LIGHTMODEL_AMBIENT );
			float4 Emissivemap31 = ( ( _EmissionColor * tex2D( _EmissionMap, ( uv_EmissionMap * TilingLayer1105 ) ) * _EmissiveIntensity1 ) + ( lerp(temp_cast_8,( _CubemapColor * float4( desaturateVar101 , 0.0 ) ),_EnableReflection) + ( temp_output_5_0_g50 * _AmbientLight1 ) ) );
			o.Emission = Emissivemap31.rgb;
			float3 ase_worldPos = i.worldPos;
			float3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			float3 ase_worldNormal = i.worldNormal;
			float fresnelNdotV11_g53 = dot( ase_worldNormal, ase_worldViewDir );
			float fresnelNode11_g53 = ( 0.0 + 1.0 * pow( 1.0 - fresnelNdotV11_g53, 5.0 ) );
			float Specularmap95 = ( _SpecularIntensity + ( ( ( 0.95 * fresnelNode11_g53 ) + 0.05 ) * _FresnelStrength1 ) );
			float3 temp_cast_13 = (Specularmap95).xxx;
			o.Specular = temp_cast_13;
			float Glossiness94 = _Glossiness;
			o.Smoothness = Glossiness94;
			o.Alpha = 1;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf StandardSpecular keepalpha fullforwardshadows 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float4 tSpace0 : TEXCOORD2;
				float4 tSpace1 : TEXCOORD3;
				float4 tSpace2 : TEXCOORD4;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				half3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
				half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				half3 worldBinormal = cross( worldNormal, worldTangent ) * tangentSign;
				o.tSpace0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
				o.tSpace1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
				o.tSpace2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = float3( IN.tSpace0.w, IN.tSpace1.w, IN.tSpace2.w );
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.worldPos = worldPos;
				surfIN.worldNormal = float3( IN.tSpace0.z, IN.tSpace1.z, IN.tSpace2.z );
				surfIN.worldRefl = -worldViewDir;
				surfIN.internalSurfaceTtoW0 = IN.tSpace0.xyz;
				surfIN.internalSurfaceTtoW1 = IN.tSpace1.xyz;
				surfIN.internalSurfaceTtoW2 = IN.tSpace2.xyz;
				SurfaceOutputStandardSpecular o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandardSpecular, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
}
