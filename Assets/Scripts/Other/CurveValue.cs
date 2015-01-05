using UnityEngine;
using System.Collections;


public class CurveValue
{
	private delegate float CurveFunc( float v, float t, float d );
	private CurveFunc _CurveFunc = AppMath.linearTween;

	private float _CurrentValue;
	private float _BeginValue;
	private float _EndValue;
	private float _DurationTime;
	private float _Timer;


	public float CurrentValue{ get{return _CurrentValue;} }

	public AppMath.CurveType CurveType
	{
		set{
			switch( value ){
			case AppMath.CurveType.LinearTween:		_CurveFunc = AppMath.linearTween;		break;
			case AppMath.CurveType.EaseInQuad:		_CurveFunc = AppMath.easeInQuad;		break;
			case AppMath.CurveType.EaseInCubic:		_CurveFunc = AppMath.easeInCubic;		break;
			case AppMath.CurveType.EaseInQuart:		_CurveFunc = AppMath.easeInQuart;		break;
			case AppMath.CurveType.EaseInQuint:		_CurveFunc = AppMath.easeInQuint;		break;
			case AppMath.CurveType.EaseInSine:		_CurveFunc = AppMath.easeInSine;		break;
			case AppMath.CurveType.EaseInExpo:		_CurveFunc = AppMath.easeInExpo;		break;
			case AppMath.CurveType.EaseInCirc:		_CurveFunc = AppMath.easeInCirc;		break;
			case AppMath.CurveType.EaseOutQuad:		_CurveFunc = AppMath.easeOutQuad;		break;
			case AppMath.CurveType.EaseOutCubic:	_CurveFunc = AppMath.easeOutCubic;		break;
			case AppMath.CurveType.EaseOutQuart:	_CurveFunc = AppMath.easeOutQuart;		break;
			case AppMath.CurveType.EaseOutQuint:	_CurveFunc = AppMath.easeOutQuint;		break;
			case AppMath.CurveType.EaseOutSine:		_CurveFunc = AppMath.easeOutSine;		break;
			case AppMath.CurveType.EaseOutExpo:		_CurveFunc = AppMath.easeOutExpo;		break;
			case AppMath.CurveType.EaseOutCirc:		_CurveFunc = AppMath.easeOutCirc;		break;
			case AppMath.CurveType.EaseInOutQuad:	_CurveFunc = AppMath.easeInOutQuad;		break;	
			case AppMath.CurveType.EaseInOutCubic:	_CurveFunc = AppMath.easeInOutCubic;	break;
			case AppMath.CurveType.EaseInOutQuart:	_CurveFunc = AppMath.easeInOutQuart;	break;
			case AppMath.CurveType.EaseInOutQuint:	_CurveFunc = AppMath.easeInOutQuint;	break;
			case AppMath.CurveType.EaseInOutSine:	_CurveFunc = AppMath.easeInOutSine;		break;
			case AppMath.CurveType.EaseInOutExpo:	_CurveFunc = AppMath.easeInOutExpo;		break;
			case AppMath.CurveType.EaseInOutCirc:	_CurveFunc = AppMath.easeInOutCirc;		break;
			}
		}
	}

	// Update is called once per frame
	public bool update ()
	{
		_Timer += Time.deltaTime;
		if( _Timer >= _DurationTime ){
			_Timer = _DurationTime;
			_CurrentValue = _EndValue;
			return true;
		}

		_CurrentValue = _BeginValue + _CurveFunc( _EndValue - _BeginValue, _Timer, _DurationTime );
		return false;
	}

	public void start( float beginValue, float endValue, float durationTime )
	{
		_BeginValue = beginValue;
		_EndValue = endValue;
		_DurationTime = durationTime;
		_Timer = 0.0f;
	}
}
