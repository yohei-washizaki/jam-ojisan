Shader "CrossFade Textures" { 
	Properties {
	    _Color ("Main Color", Color) = (1,1,1,1)
	    _Blend ("Blend", Range (0, 1) ) = 0 
	    _MainTex ("Current Texture", 2D) = "" 
	    _NewTex ("New Texture", 2D) = ""
	}
	
	SubShader { 
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha 
		
	    Pass {	    	        
	        SetTexture[_MainTex]
	        SetTexture[_NewTex] { 
	            ConstantColor (1,1,1, [_Blend]) 
	            Combine texture Lerp(constant) previous
	        }      		
	    }
	}
}