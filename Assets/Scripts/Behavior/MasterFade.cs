using UnityEngine;
using System.Collections;

public class MasterFade : MonoBehaviour 
{	
	// Fade.
	public enum SpeedType{
		Slow,
		Normal,
		Fast,
	};
	
	// fadein or out.
	public enum DispType{
		In,
		Out,
	};
	
	// Instance.
	private static MasterFade mInstance;

	// 終了検知.
	private bool mIsFadeEnd;
	private bool mIsFading;
	private DispType mFadeType;

	private Texture2D mFadeTexture;
	private GUIStyle mBGStyle;
	private Color mTargetColor;
	private Color mCurrentColor;
	private Color mAddColor;

	// 速度調整テーブル.
	private static readonly float[] FADE_DURATION = { 3.0f, 2.0f, 1.0f };
	
	// -------------------------------------------------------
	// singleton.
	// -------------------------------------------------------
	void Awake()
	{
		if( mInstance == null ){
			mInstance = this;
			mFadeTexture = new Texture2D( 1, 1 );
			mBGStyle = new GUIStyle();
			mBGStyle.normal.background = mFadeTexture;
			mTargetColor = new Color( 0.0f, 0.0f, 0.0f, 0.0f );
			mCurrentColor = new Color( 0.0f, 0.0f, 0.0f, 0.0f );
			mAddColor = new Color( 0.0f, 0.0f, 0.0f, 0.0f );			
			SetTextureColor( mCurrentColor );
		}
		else{
			Destroy( this );
		}		
	}
	
	// -------------------------------------------------------
	// Use this for initialization
	// -------------------------------------------------------
	void Start () {

	}
	
	// -------------------------------------------------------
	// On GUI
	// -------------------------------------------------------
	void OnGUI () {		
		// color changed
		if( mCurrentColor != mTargetColor )
		{
			// next alpha is too small
			float subAlpha = Mathf.Abs( mTargetColor.a - mCurrentColor.a );
			float addAlpha = mAddColor.a * Time.deltaTime;
			if( subAlpha < Mathf.Abs( addAlpha ) ){
				SetTextureColor( mTargetColor );
				mAddColor = new Color( 0.0f, 0.0f, 0.0f, 0.0f );
			}
			// main
			else{
				SetTextureColor( mCurrentColor + ( mAddColor * Time.deltaTime ) );
			}
		}
		else{
			mIsFading = false;
			mIsFadeEnd = true;			
		}
		
		if( mCurrentColor.a > 0.0f ){
			// tekito.
			GUI.depth = 10000;
			GUI.Label( 
				new Rect( -10.0f, -10.0f, Screen.width + 10.0f, Screen.height + 10.0f ), 
				mFadeTexture,
				mBGStyle
				);
		}
	}
	
	// -------------------------------------------------------
	// テクスチャの初期色設定.
	// -------------------------------------------------------
	static public void SetTextureColor( Color col )
	{
		if( mInstance == null ){
			return;
		}
		mInstance.mCurrentColor = col;
		mInstance.mFadeTexture.SetPixel( 0, 0, mInstance.mCurrentColor );
		mInstance.mFadeTexture.Apply();
	}
	
	// -------------------------------------------------------
	// フェード開始.
	// -------------------------------------------------------
	static public void Start( DispType dispType, Color targetColor, SpeedType spdType = SpeedType.Normal )
	{
		if( mInstance == null ){
			return;
		}
		mInstance.mIsFading = true;
		mInstance.mIsFadeEnd = false;
		mInstance.mFadeType = dispType;
		if( dispType == DispType.Out ){
			mInstance.mTargetColor = new Color( targetColor.r, targetColor.g, targetColor.b, 0.0f );
		}
		else{
			mInstance.mTargetColor = targetColor;			
		}
		
		mInstance.mAddColor = ( mInstance.mTargetColor - mInstance.mCurrentColor ) / FADE_DURATION[(int)spdType];
	}
}