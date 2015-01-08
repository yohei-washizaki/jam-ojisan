using UnityEngine;
using System.Collections;

public class AppInput : MonoBehaviour 
{
	// スクロール方向.
	public enum ScrollDirection{
		None,
		Up,
		Down		
	};

	// インスタンス取得.
	private static AppInput mInstance;
	// 計算誤差用.
	private readonly float ScrollEpsilon = 0.01f;

	// 位置取得.
	private Vector3 mPos;
	private Vector3 mTriggerPos;
	private Vector3 mReleasePos;

	// 判定周り.
	private bool mIsTrigger;
	private bool mIsRelease;
	private ScrollDirection mMoveScrollDir;

	static public Vector3 getPos(){ return mInstance != null ? mInstance.mPos : Vector3.zero; }
	static public Vector3 getTrgPos(){ return mInstance != null ? mInstance.mTriggerPos : Vector3.zero; }
	static public Vector3 getRelPos(){ return mInstance != null ? mInstance.mReleasePos : Vector3.zero; }

	static public bool isTrg(){ return mInstance != null ? mInstance.mIsTrigger : false; }
	static public bool isRel(){ return mInstance != null ? mInstance.mIsRelease : false; }
	static public ScrollDirection getScrollDir(){ return mInstance != null ? mInstance.mMoveScrollDir : ScrollDirection.None; }

	// -------------------------------------------------------
	// singletonはawakeじゃないとだめ.
	// -------------------------------------------------------
	void Awake()
	{
		if( mInstance == null ){
			mInstance = this;
		}
		else{
			Destroy( this );
		}		
	}
	
	// -------------------------------------------------------
	// Use this for initialization
	// -------------------------------------------------------
	void Start () 
	{
	}
	
	// -------------------------------------------------------
	// Update is called once per frame
	// -------------------------------------------------------
	void Update () 
	{
		mIsTrigger = false;
		mIsRelease = false;
		
		mPos =  Input.mousePosition;
		mIsTrigger = Input.GetMouseButtonDown( 0 );
		if( mIsTrigger ){
			mTriggerPos = mPos;
		}
		mIsRelease = Input.GetMouseButtonUp( 0 );
		if( mIsRelease ){
			mReleasePos = mPos;
		}
		
		float scroll = Input.GetAxis( "Mouse ScrollWheel" );
		if( scroll > ScrollEpsilon ){
			mMoveScrollDir = ScrollDirection.Up;
		} else if( scroll < -ScrollEpsilon ) {
			mMoveScrollDir = ScrollDirection.Down;
		} else {
			mMoveScrollDir = ScrollDirection.None;
		}
	}
}
