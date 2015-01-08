using UnityEngine;
using System.Collections;

public class SeVoice : MonoBehaviour
{
	// public
	//---------------------------------------------------
	// 追従するトランスフォーム 
	public Transform FollowTrans{ 
		get{
			return mFollowTrans;
		}
		set{
			mFollowTrans = value;
			if( value != null ){
				// セットと同時に座標の更新もしておく 
				transform.position = value.position;
			}
		}
	}
	
	// private
	//---------------------------------------------------
	private Transform	mFollowTrans;	// 追従するトランスフォーム 

	

	/// <summary>
	/// 再生中かどうか　
	/// </summary>
	/// <returns>
	/// The playing.
	/// </returns>
	public bool isPlaying()
	{
		return audio.isPlaying;
	}

	/// <summary>
	/// 指定されたクリップを再生する 
	/// </summary>
	/// <param name='clip'>
	/// Clip.
	/// </param>
	public void play( AudioClip clip )
	{
		// オーディオパラメータの初期化 
		audio.volume = 1f;
		
		audio.clip = clip;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if( !audio.isPlaying ){
			return;
		}
		
		if( FollowTrans ){
			// 発音座標の更新  
			transform.position = FollowTrans.position;
		}
	}
}
