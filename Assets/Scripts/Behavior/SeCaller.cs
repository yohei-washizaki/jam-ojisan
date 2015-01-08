using UnityEngine;
using System.Collections;

public class SeCaller : SingletonSystem<SeCaller>
{
	// Inspector
	//---------------------------------------------------
	public int			VoiceNum = 64;		// 最大発音数 
	public GameObject	VoicePrefab;		// 作成するボイスのプレファブ、発音数分だけ作成する 

	// private
	//---------------------------------------------------	
	private SeVoice[]	mVoices;				// 全ボイスへのリンク 
	private int			mCurrentVoiceIndex = 0;	// 現在のボイスインデックス（検索高速化用）　
	

	/// <summary>
	/// 通常発音.
	/// </summary>
	/// <param name="clip">Clip.</param>
	/// <param name="follow">Follow.</param>
	public static AudioSource call( AudioClip clip )
	{
		SeVoice v = _Instance.searchEmptyVoice();
		if( v ){
			v.play( clip );
			return v.audio;
		}
		return null;
	}

	/// <summary>
	/// 発音（Transform追従） 
	/// </summary>
	/// <param name='clip'>
	/// Clip.
	/// </param>
	/// <param name='follow'>
	/// Follow.
	/// </param>
	public static AudioSource call( AudioClip clip, Transform follow )
	{
		SeVoice v = _Instance.searchEmptyVoice();
		if( v ){
			v.FollowTrans = follow;
			v.play( clip );
			return v.audio;
		}
		return null;
	}
	
	/// <summary>
	/// 発音（座標指定） 
	/// /// </summary>
	/// <param name='clip'>
	/// Clip.
	/// </param>
	/// <param name='pos'>
	/// Position.
	/// </param>
	public static AudioSource call( AudioClip clip, Vector3 pos )
	{
		SeVoice v = _Instance.searchEmptyVoice();
		if( v ){
			v.transform.position = pos;
			v.play( clip );
			return v.audio;
		}
		return null;
	}
	
	// Start
	void Start()
	{
		createVoices();
	}

	/// <summary>
	/// ボイスを作成する 
	/// </summary>
	private void createVoices()
	{
		// 一旦削除 
		destroyVoices();
		
		// 作成 
		mVoices = new SeVoice[VoiceNum];
		for( int i=0 ; i<VoiceNum ; ++i ){
			GameObject instance = (GameObject)Instantiate( VoicePrefab );
			instance.transform.parent = transform;
			mVoices[i] = instance.GetComponent<SeVoice>();
		}
	}
	
	/// <summary>
	/// 全ボイスを削除 
	/// </summary>
	private void destroyVoices()
	{
		if( mVoices == null ){
			return;
		}
		
		foreach( SeVoice v in mVoices ){
			Destroy( v.gameObject );
		}
		mVoices = null;
	}
	
	/// <summary>
	/// 空のボイスを探す 
	/// </summary>
	/// <returns>
	/// The empty voice.
	/// </returns>
	private SeVoice searchEmptyVoice()
	{
		SeVoice v = searchEmptyVoice( mCurrentVoiceIndex++ );
		if( mCurrentVoiceIndex >= mVoices.Length ){
			mCurrentVoiceIndex = 0;
		}
		
		return v;
	}
	
	/// <summary>
	/// 空のボイスを探す（検索開始インデックス指定版） 
	/// </summary>
	/// <returns>
	/// The empty voice.
	/// </returns>
	/// <param name='startIndex'>
	/// Start index.
	/// </param>
	private SeVoice searchEmptyVoice( int startIndex )
	{
		// 指定されたインデックスから空きを調べる 
		int index = startIndex;
		
		for( int cnt=0 ; cnt<mVoices.Length ; ++cnt ){
			SeVoice v = mVoices[index];
			if( !v.isPlaying() ){	// 何もしてない？ 
				return v;
			}
			
			++index;
			if( index >= mVoices.Length ){
				index = 0;
			}
		}
		
		return null;
	}
}
