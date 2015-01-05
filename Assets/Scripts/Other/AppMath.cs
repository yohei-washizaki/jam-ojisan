using UnityEngine;
using System.Collections;


public static class AppMath
{
	public enum CurveType
	{
		LinearTween,

		EaseInQuad,
		EaseInCubic,
		EaseInQuart,
		EaseInQuint,
		EaseInSine,
		EaseInExpo,
		EaseInCirc,

		EaseOutQuad,
		EaseOutCubic,
		EaseOutQuart,
		EaseOutQuint,
		EaseOutSine,
		EaseOutExpo,
		EaseOutCirc,

		EaseInOutQuad,
		EaseInOutCubic,
		EaseInOutQuart,
		EaseInOutQuint,
		EaseInOutSine,
		EaseInOutExpo,
		EaseInOutCirc,
	}

	// 引数
	// v : Change In Value
	// t : Current Time
	// d : Duration
	
	/// <summary>
	/// Linears tween.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float linearTween( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		return v * t / d;
	}
	
	
	// Quad
	//-------------------------------------------------------------------------
	
	/// <summary>
	/// In Quad.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeInQuad( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d;
		return v * t * t;
	}
	
	/// <summary>
	/// Quad Out.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeOutQuad( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d;
		return -v * t * (t - 2f);
	}	
	
	/// <summary>
	/// InOut Quad.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeInOutQuad( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d / 2f;
		if( t < 1f ){
			return v / 2f * t * t;
		}
		t -= 1f;
		return -v / 2f * (t * (t - 2f) - 1f);
	}	
	
	
	// Cubic
	//-------------------------------------------------------------------------
	
	/// <summary>
	/// In Cubic.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeInCubic( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d;
		return v * t * t * t;
	}	
	
	/// <summary>
	/// Out Cubic.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeOutCubic( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d;
		t -= 1f;
		return v * (t * t * t + 1f);
	}
	
	/// <summary>
	/// InOut Cubic.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeInOutCubic( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d / 2f;
		if( t < 1f ){
			return v / 2f * t * t * t;
		}
		t -= 2f;
		return v / 2f * (t * t * t + 2f);
	}
	
	
	// Quart
	//-------------------------------------------------------------------------
	
	/// <summary>
	/// In Quart.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeInQuart( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d;
		return v * t * t * t * t;
	}
	
	/// <summary>
	/// Out Quart.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeOutQuart( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d;
		t -= 1f;
		return -v * (t * t * t * t - 1f);
	}
	
	/// <summary>
	/// InOut Quart.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeInOutQuart( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d / 2f;
		if( t < 1f ){
			return v / 2f * t * t * t * t;
		}
		t -= 2f;
		return -v / 2f * (t * t * t * t -2f);
	}
	
	
	// Quint
	//-------------------------------------------------------------------------
	
	/// <summary>
	/// In Quint.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeInQuint( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d;
		return v * t * t * t * t * t;
	}
	
	/// <summary>
	/// Out Quint.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeOutQuint( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d;
		t -= 1f;
		return v * (t * t * t * t * t + 1f);
	}
	
	/// <summary>
	/// InOut Quint.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeInOutQuint( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d / 2f;
		if( t < 1f ){
			return v / 2f * t * t * t * t * t;
		}
		t -= 2f;
		return v / 2f * (t * t * t * t * t + 2f);
	}
	
	
	// Sine
	//-------------------------------------------------------------------------
	
	/// <summary>
	/// In Sine.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeInSine( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		return -v * Mathf.Cos(t / d * (Mathf.PI / 2f)) + v;
	}	
	
	/// <summary>
	/// Out Sine.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeOutSine( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		return v * Mathf.Sin(t / d * (Mathf.PI / 2f));
	}	
	
	/// <summary>
	/// InOut Sine.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeInOutSine( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		return -v / 2f * (Mathf.Cos(Mathf.PI * t / d) - 1f);
	}
	
	
	// Expo
	//-------------------------------------------------------------------------
	
	/// <summary>
	/// In Expo.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeInExpo( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		return v * Mathf.Pow(2f, 10f * (t / d - 1f));
	}
	
	/// <summary>
	/// Out Expo.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeOutExpo( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		return v * (-Mathf.Pow(2f, -10f * t / d) + 1f);
	}
	
	/// <summary>
	/// InOut Expo.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeInOutExpo( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d / 2f;
		if( t < 1f ){
			return v / 2f * Mathf.Pow(2f, 10f * (t - 1f));
		}
		t -= 1f;
		return v / 2f * (-Mathf.Pow(2f, -10f * t) + 2f);
	}
	
	
	// Circ
	//-------------------------------------------------------------------------
	
	/// <summary>
	/// In Circ.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeInCirc( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d;
		return -v * (Mathf.Sqrt(1f - t * t) - 1f);
	}
	
	/// <summary>
	/// Out Circ.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeOutCirc( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d;
		t -= 1f;
		return v * Mathf.Sqrt(1f - t * t);
	}
	
	/// <summary>
	/// InOUt Circ.
	/// </summary>
	/// <param name='t'>Current Time</param>
	/// <param name='st'>Start Value</param>
	/// <param name='v'>Change In Value</param>
	/// <param name='d'>Duration</param>
	public static float easeInOutCirc( float v, float t, float d )
	{
		if( d <= 0.0f ){
			return v;
		}
		t /= d / 2f;
		if( t < 1f ){
			return -v / 2f * (Mathf.Sqrt(1f - t * t) - 1f);
		}
		t -= 2f;
		return v / 2f * (Mathf.Sqrt(1f - t * t) + 1f);
	}
	
}