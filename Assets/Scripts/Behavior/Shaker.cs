using UnityEngine;
using System.Collections.Generic;

public class Shaker : MonoBehaviour {
	/// <summary>
	/// The m shake sec.
	/// </summary>
	public float ShakeSec = 1.0f;


	public AnimationCurve _Curve;

	/// <summary>
	/// Shake this instance.
	/// </summary>
	public void Shake() {
		_State 			= State.Shaking;
		_ShakeSecTimer 	= this.ShakeSec;
	}

	enum State {
		Idle,
		Shaking,
	};

	State _State;
	float _ShakeSecTimer;
	Vector3 _Origin;

	/// <summary>
	/// 0.0 ~ 1.0 に正規化されたタイマーを得る。
	/// 5秒のタイマーで、現在2秒経過している場合は 0.4 を返す。
	/// 0秒のタイマーは常に 0 を返す。
	/// 5秒のタイマーで、現在6秒経過している場合は、 1.0 を返す。
	/// </summary>
	/// <value>The normalized timer.</value>
	float normalizedTimer
	{
		get
		{
			if( this.ShakeSec <= 0 )
				return 0.0f;

			if( _ShakeSecTimer <= 0 )
				return 1.0f;

			return (this.ShakeSec - _ShakeSecTimer) / this.ShakeSec;
		}
	}

	// Use this for initialization
	void Start () {
		_State = State.Idle;
		_ShakeSecTimer = ShakeSec;
		_Origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		switch( _State ){
		case State.Idle:
			break;
		case State.Shaking:
			execShake();
			break;
		}
	}

	void execShake(){
		// update time
		_ShakeSecTimer -= Time.deltaTime;

		// update state
		if( _ShakeSecTimer <= 0 ) {
			_State = State.Idle;
			transform.position = _Origin;
			return;
		}

		// shake this instance
		Vector3 degree = Random.insideUnitSphere * +_Curve.Evaluate(1.0f - this.normalizedTimer);
		this.transform.position = _Origin + degree;
	}

}
