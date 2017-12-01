using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	//次のシーンの名前
    //一部以外はnextSceneで遷移を行う
	public  string nextScene;

    //リザルトが2種類あるため
    //nextGameClear(メイン→ゲームクリア)とnextGameOver(メイン→ゲームオーバー)
    public string nextGameClear;
    public string nextGameOver;


    // Use this for initialization
    private static float margin = 2.0f;
	//遷移したかどうかを保存する変数
	bool Moved = false;

    public Trick trick; //トリッククラスから参照

    void Start ()
    {
        //  AudioManager.Instance.PlayBGM("");
        // AudioManager.Instance.PlaySE("");
        //nextScene = null;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log (nextScene);
        if (!Moved)
        {
            switch (Application.loadedLevelName)
            {
                case "Title":
                    /*次のシーンに遷移する方法*/
				if (Input.GetKeyDown(KeyCode.Space))
                    {
                        ChangeScene(nextScene);
                    }
                    break;
				case "Explanation":
				if (Input.GetKeyDown(KeyCode.Space)) 
					{
						ChangeScene (nextScene);
					}
					break;
                case "Main":
                    /*次のシーンに遷移する方法*/
                    //メインからクリアへ
                    if (trick.GameClearFlag == true)
                    {
                        ChangeScene(nextGameClear);
                    }
                    //メインからゲームオーバーへ
                    if (trick.GameOverFlag == true)
                    {
                        ChangeScene(nextGameOver);
                    }
                    break;
                case "GameOver":
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        //Debug.Log("ゲームクリア");
                        ChangeScene(nextScene);
                    }
                    break;
                case "GameClear":
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        ChangeScene(nextScene);
                    }
                    break;
            }
        }
        if (nextScene == SceneManager.GetActiveScene().name)
        {
            //次のシーンをnull
            //nextScene = null;
            //Debug.Log(" null or NotNull:::" + nextScene);
            Moved = false;
        }
     
        /*	if ((nextScene != null) && (Moved == false))
            {
                Debug.Log ("nextScene name:::" + nextScene);
                Moved = true;
                //シーンの遷移
                FadeManager.Instance.LoadLevel (nextScene, 2.0f);

            }

            if(nextScene == SceneManager.GetActiveScene().name)
            {
                //次のシーンをnull
                nextScene = null;
                Debug.Log(" null or NotNull:::" + nextScene);
                Moved = false;
            }*/
    }
    public void ChangeScene(string next) {
		FadeManager.Instance.LoadLevel(next, 1.0f);
        Moved = true;        
    }
   
}
