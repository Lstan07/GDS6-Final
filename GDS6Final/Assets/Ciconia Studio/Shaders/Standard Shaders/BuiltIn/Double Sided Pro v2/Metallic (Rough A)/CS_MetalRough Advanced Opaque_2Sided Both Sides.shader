Shader "Ciconia Studio/Standard (Double Sided) V2 Legacy/MetalRough/Advanced (Both Sides)/Opaque"
{
	Properties
	{
		[Space(15)][Header(Main Maps)]
		[Space(15)]_GeneralTilingLayer1("General Tiling", Float) = 1
		[Space(10)]_Color("Color", Color) = (1,1,1,0)
		_MainTex("Albedo", 2D) = "white" {}
		[Space(10)]_Desaturation1("Desaturation", Float) = 0
		_Saturation1("Saturation", Range( 0 , 0.45)) = 0
		_Brightness1("Brightness", Range( -1 , 1)) = 0
		
		[Space(35)]_MetallicGlossMap("Metallic(RoughA)", 2D) = "white" {}
		[Space(10)]_Metallic("Metallic", Range( 0 , 2)) = 0
		_Glossiness("Roughness", Range( 0 , 2)) = 0.5
		
		[Space(35)]_BumpMap("Normal map", 2D) = "bump" {}
		_BumpScale("Normal Intensity", Range( 0 , 2)) = 1
		
		[Space(35)]_OcclusionMap("Ambient Occlusion map", 2D) = "white" {}
		_AoIntensity1("Ao Intensity", Range( 0 , 2)) = 0
		
		[Space(35)]_EmissionColor("Emission Color", Color) = (0,0,0,0)
		_EmissionMap("Emission map", 2D) = "white" {}
		_EmissiveIntensity1("Emissive Intensity", Range( 0 , 2)) = 1
		
		
        [Space(45)][Header(Reflection Properties)]
        [Space(15)][Toggle]_EnableReflection("Enable Reflection", Float) = 1
		[Toggle]_WorldDirection("World Direction", Float) = 1
		[Space(15)]_CubemapColor("Color", Color) = (0,0,0,0)
		_Cubemap1("Cubemap", CUBE) = "black" {}
		_DesaturationCubemap("Desaturation", Range( 0 , 1)) = 0
		[Space(10)]_ReflectionIntensity1("Reflection Intensity", Range( 0 , 10)) = 2
		_BlurReflection1("Blur Reflection", Range( 0 , 7)) = 0.5
		[Space(10)]_DoubleSidedBlend("Double Sided Blend", Range( 0 , 1)) = 1
		[Space(10)]_FresnelStrength1("Fresnel Strength", Range( 0 , 8)) = 0
		_AmbientLight1("Ambient Light", Range( 0 , 8)) = 0
		
		
        [Space(45)][Header(Secondary Maps)]
        [Space(15)]_GeneralTilingLayer2("General Tiling", Float) = 1
		[Space(10)]_Color2("Color", Color) = (1,1,1,0)
		_DetailAlbedoMap("Albedo", 2D) = "white" {}
		[Space(10)]_Desaturation2("Desaturation", Float) = 0
		_Saturation2("Saturation", Range( 0 , 0.45)) = 0
		_Brightness2("Brightness", Range( -1 , 1)) = 0
		
		[Space(35)]_MetallicGlossMap2("Metallic(RoughA)", 2D) = "white" {}
		[Space(10)]_Metallic2("Metallic", Range( 0 , 2)) = 0
		_Glossiness2("Roughness", Range( 0 , 2)) = 0.5
		
		[Space(35)]_DetailNormalMap("Normal map", 2D) = "bump" {}
		_DetailNormalMapScale("Normal Intensity", Range( 0 , 2)) = 1
		
		[Space(35)]_OcclusionMap2("Ambient Occlusion map", 2D) = "white" {}
		_AoIntensity2("Ao Intensity", Range( 0 , 2)) = 0
		
		[Space(35)]_EmissionColor2("Emission Color", Color) = (0,0,0,0)
		_EmissionMap2("Emission map", 2D) = "white" {}
		_EmissiveIntensity2("Emissive Intensity", Range( 0 , 2)) = 1
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
			half ASEVFace : VFACE;
			float3 worldRefl;
			INTERNAL_DATA
			float3 worldPos;
			float3 worldNormal;
		};

		uniform sampler2D _BumpMap;
		uniform float4 _BumpMap_ST;
		uniform float _GeneralTilingLayer1;
		uniform float _BumpScale;
		uniform sampler2D _DetailNormalMap;
		uniform float4 _DetailNormalMap_ST;
		uniform float _GeneralTilingLayer2;
		uniform float _DetailNormalMapScale;
		uniform float4 _Color;
		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform float _Brightness1;
		uniform float _Saturation1;
		uniform float _Desaturation1;
		uniform float4 _Color2;
		uniform sampler2D _DetailAlbedoMap;
		uniform float4 _DetailAlbedoMap_ST;
		uniform float _Brightness2;
		uniform float _Saturation2;
		uniform float _Desaturation2;
		uniform float4 _EmissionColor;
		uniform sampler2D _EmissionMap;
		uniform float4 _EmissionMap_ST;
		uniform float _EmissiveIntensity1;
		uniform float4 _EmissionColor2;
		uniform sampler2D _EmissionMap2;
		uniform float4 _EmissionMap2_ST;
		uniform float _EmissiveIntensity2;
		uniform float _EnableReflection;
		uniform float4 _CubemapColor;
		uniform samplerCUBE _Cubemap1;
		uniform float _WorldDirection;
		uniform float _BlurReflection1;
		uniform float _ReflectionIntensity1;
		uniform float _DesaturationCubemap;
		uniform float _DoubleSidedBlend;
		uniform float _AmbientLight1;
		uniform float _FresnelStrength1;
		uniform sampler2D _MetallicGlossMap;
		uniform float4 _MetallicGlossMap_ST;
		uniform float _Metallic;
		uniform sampler2D _MetallicGlossMap2;
		uniform float4 _MetallicGlossMap2_ST;
		uniform float _Metallic2;
		uniform float _Glossiness;
		uniform float _Glossiness2;
		uniform sampler2D _OcclusionMap;
		uniform float4 _OcclusionMap_ST;
		uniform float _AoIntensity1;
		uniform sampler2D _OcclusionMap2;
		uniform float4 _OcclusionMap2_ST;
		uniform float _AoIntensity2;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_BumpMap = i.uv_texcoord * _BumpMap_ST.xy + _BumpMap_ST.zw;
			float TilingLayer1148 = _GeneralTilingLayer1;
			float3 lerpResult5_g91 = lerp( float3(0,0,1) , UnpackNormal( tex2D( _BumpMap, ( uv_BumpMap * TilingLayer1148 ) ) ) , _BumpScale);
			float2 uv_DetailNormalMap = i.uv_texcoord * _DetailNormalMap_ST.xy + _DetailNormalMap_ST.zw;
			float TilingLayer2147 = _GeneralTilingLayer2;
			float3 lerpResult5_g90 = lerp( float3(0,0,1) , UnpackNormal( tex2D( _DetailNormalMap, ( uv_DetailNormalMap * TilingLayer2147 ) ) ) , _DetailNormalMapScale);
			float3 switchResult176 = (((i.ASEVFace>0)?(lerpResult5_g91):(lerpResult5_g90)));
			float3 Normalmap19 = switchResult176;
			o.Normal = Normalmap19;
			float2 uv_MainTex = i.uv_texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
			float4 tex2DNode7_g93 = tex2D( _MainTex, ( uv_MainTex * TilingLayer1148 ) );
			float4 temp_cast_0 = (( 1.0 - _Brightness1 )).xxxx;
			float4 temp_cast_1 = (_Saturation1).xxxx;
			float4 temp_cast_2 = (( 1.0 - _Saturation1 )).xxxx;
			float4 temp_cast_3 = (0.0).xxxx;
			float4 temp_cast_4 = (1.0).xxxx;
			float clampResult15_g93 = clamp( _Desaturation1 , 0.0 , 1.0 );
			float3 desaturateInitialColor16_g93 = (temp_cast_3 + (pow( tex2DNode7_g93 , temp_cast_0 ) - temp_cast_1) * (temp_cast_4 - temp_cast_3) / (temp_cast_2 - temp_cast_1)).rgb;
			float desaturateDot16_g93 = dot( desaturateInitialColor16_g93, float3( 0.299, 0.587, 0.114 ));
			float3 desaturateVar16_g93 = lerp( desaturateInitialColor16_g93, desaturateDot16_g93.xxx, clampResult15_g93 );
			float2 uv_DetailAlbedoMap = i.uv_texcoord * _DetailAlbedoMap_ST.xy + _DetailAlbedoMap_ST.zw;
			float4 tex2DNode7_g92 = tex2D( _DetailAlbedoMap, ( uv_DetailAlbedoMap * TilingLayer2147 ) );
			float4 temp_cast_7 = (( 1.0 - _Brightness2 )).xxxx;
			float4 temp_cast_8 = (_Saturation2).xxxx;
			float4 temp_cast_9 = (( 1.0 - _Saturation2 )).xxxx;
			float4 temp_cast_10 = (0.0).xxxx;
			float4 temp_cast_11 = (1.0).xxxx;
			float clampResult15_g92 = clamp( _Desaturation2 , 0.0 , 1.0 );
			float3 desaturateInitialColor16_g92 = (temp_cast_10 + (pow( tex2DNode7_g92 , temp_cast_7 ) - temp_cast_8) * (temp_cast_11 - temp_cast_10) / (temp_cast_9 - temp_cast_8)).rgb;
			float desaturateDot16_g92 = dot( desaturateInitialColor16_g92, float3( 0.299, 0.587, 0.114 ));
			float3 desaturateVar16_g92 = lerp( desaturateInitialColor16_g92, desaturateDot16_g92.xxx, clampResult15_g92 );
			float4 switchResult173 = (((i.ASEVFace>0)?(( _Color * float4( desaturateVar16_g93 , 0.0 ) )):(( _Color2 * float4( desaturateVar16_g92 , 0.0 ) ))));
			float4 Albedomap34 = switchResult173;
			o.Albedo = Albedomap34.rgb;
			float2 uv_EmissionMap = i.uv_texcoord * _EmissionMap_ST.xy + _EmissionMap_ST.zw;
			float2 uv_EmissionMap2 = i.uv_texcoord * _EmissionMap2_ST.xy + _EmissionMap2_ST.zw;
			float4 switchResult178 = (((i.ASEVFace>0)?(( _EmissionColor * tex2D( _EmissionMap, ( uv_EmissionMap * TilingLayer1148 ) ) * _EmissiveIntensity1 )):(( _EmissionColor2 * tex2D( _EmissionMap2, ( uv_EmissionMap2 * TilingLayer2147 ) ) * _EmissiveIntensity2 ))));
			float4 temp_cast_15 = (0.0).xxxx;
			float3 ase_worldReflection = normalize( WorldReflectionVector( i, float3( 0, 0, 1 ) ) );
			float4 texCUBENode27 = texCUBElod( _Cubemap1, float4( lerp(normalize( WorldReflectionVector( i , Normalmap19 ) ),ase_worldReflection,_WorldDirection), _BlurReflection1) );
			float clampResult21 = clamp( _ReflectionIntensity1 , 0.0 , 100.0 );
			float3 desaturateInitialColor129 = ( texCUBENode27 * ( texCUBENode27.a * clampResult21 ) ).rgb;
			float desaturateDot129 = dot( desaturateInitialColor129, float3( 0.299, 0.587, 0.114 ));
			float3 desaturateVar129 = lerp( desaturateInitialColor129, desaturateDot129.xxx, _DesaturationCubemap );
			float4 temp_output_132_0 = ( _CubemapColor * float4( desaturateVar129 , 0.0 ) );
			float4 temp_cast_18 = (0.0).xxxx;
			float4 lerpResult180 = lerp( temp_cast_18 , temp_output_132_0 , _DoubleSidedBlend);
			float4 switchResult179 = (((i.ASEVFace>0)?(temp_output_132_0):(lerpResult180)));
			float temp_output_8_0_g125 = Albedomap34.r;
			float4 temp_output_5_0_g125 = ( temp_output_8_0_g125 * UNITY_LIGHTMODEL_AMBIENT );
			float3 ase_worldPos = i.worldPos;
			float3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			float3 ase_worldNormal = WorldNormalVector( i, float3( 0, 0, 1 ) );
			float fresnelNdotV11_g124 = dot( ase_worldNormal, ase_worldViewDir );
			float fresnelNode11_g124 = ( 0.0 + 1.0 * pow( 1.0 - fresnelNdotV11_g124, 5.0 ) );
			float4 Emissivemap31 = ( switchResult178 + ( lerp(temp_cast_15,switchResult179,_EnableReflection) + ( temp_output_5_0_g125 * _AmbientLight1 ) + ( ( ( 0.95 * fresnelNode11_g124 ) + 0.05 ) * _FresnelStrength1 ) ) );
			o.Emission = Emissivemap31.rgb;
			float2 uv_MetallicGlossMap = i.uv_texcoord * _MetallicGlossMap_ST.xy + _MetallicGlossMap_ST.zw;
			float4 tex2DNode3_g127 = tex2D( _MetallicGlossMap, ( uv_MetallicGlossMap * TilingLayer1148 ) );
			float2 uv_MetallicGlossMap2 = i.uv_texcoord * _MetallicGlossMap2_ST.xy + _MetallicGlossMap2_ST.zw;
			float4 tex2DNode3_g128 = tex2D( _MetallicGlossMap2, ( uv_MetallicGlossMap2 * TilingLayer1148 ) );
			float switchResult175 = (((i.ASEVFace>0)?(( tex2DNode3_g127.r * _Metallic )):(( tex2DNode3_g128.r * _Metallic2 ))));
			float Metallic37 = switchResult175;
			o.Metallic = Metallic37;
			float switchResult174 = (((i.ASEVFace>0)?(( tex2DNode3_g127.a * _Glossiness )):(( tex2DNode3_g128.a * _Glossiness2 ))));
			float Roughness38 = switchResult174;
			o.Smoothness = Roughness38;
			float2 uv_OcclusionMap = i.uv_texcoord * _OcclusionMap_ST.xy + _OcclusionMap_ST.zw;
			float blendOpSrc2_g130 = tex2D( _OcclusionMap, ( uv_OcclusionMap * TilingLayer1148 ) ).r;
			float blendOpDest2_g130 = ( 1.0 - _AoIntensity1 );
			float2 uv_OcclusionMap2 = i.uv_texcoord * _OcclusionMap2_ST.xy + _OcclusionMap2_ST.zw;
			float blendOpSrc2_g129 = tex2D( _OcclusionMap2, ( uv_OcclusionMap2 * TilingLayer2147 ) ).r;
			float blendOpDest2_g129 = ( 1.0 - _AoIntensity2 );
			float switchResult177 = (((i.ASEVFace>0)?(( saturate( ( 1.0 - ( 1.0 - blendOpSrc2_g130 ) * ( 1.0 - blendOpDest2_g130 ) ) ))):(( saturate( ( 1.0 - ( 1.0 - blendOpSrc2_g129 ) * ( 1.0 - blendOpDest2_g129 ) ) )))));
			float Aomap41 = switchResult177;
			o.Occlusion = Aomap41;
			o.Alpha = 1;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard keepalpha fullforwardshadows 

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
				SurfaceOutputStandard o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandard, o )
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
