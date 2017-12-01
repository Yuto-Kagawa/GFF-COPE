using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trick : MonoBehaviour
{
    public Firend firend;           //Friendクラスから参照    
    public AudioSource EerieSound;  //不気味な音
    public X_Move X;                //X_Moveクラスから参照
    public Trick_Light FlashLight;  //Trick_LightクラスのGameObject FlashLightを参照
    public Stalker SK;              //Stalkerクラスから参照
    public bool GameOverFlag;       //ゲームオーバーするかどうか
    public bool GameClearFlag;      //ゲームクリアするかどうか 

    public bool HomingFlag;         //友人の行動を行うかどうか

    // Use this for initialization
    void Start ()
    {
       //初期化
       EerieSound = GetComponent<AudioSource>();//音を取得
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="Friend")
        {
            //主人公と友人の当たり判定を行う
            //当たれば友人は停止
            //当たらなければ主人公に対して行動（ホーミング）を行う
            //Debug.Log("友人ホーミングフラグ変更");
            HomingFlag = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name=="Friend")
        {
            HomingFlag = false;
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        //仕掛け1
        //不気味な音を流す
        if (other.gameObject.tag == "Trick_EerieSound")   //タグ"Trick_EerieSound"に当たれば
        {
            //Debug.Log("不気味な音を流す");
            EerieSound.PlayOneShot(EerieSound.clip);//不気味な音を再生
        }

        //仕掛け2
        //物体Xが前を通る
        else if (other.gameObject.tag=="Trick_X")//タグ"Trick_X"に当たれば
        { 
            //Debug.Log("物体X移動開始");
            X.XFlag = true;
        }

        //仕掛け3
        //懐中電灯の光が消える
        //友人が消える
        else if (other.gameObject.tag == "Trick_Delete")//タグ"Trick_Delete"に当たれば
        {
            FlashLight.FlashLightFlag = true; 
        }

        //仕掛け4
        //後ろからストーカー
        else if(other.gameObject.tag== "Trick_Stalker")
        {
            //Debug.Log("ストーカーグラぐ");
            SK.StalkerFlag = true;
            SK.gameObject.SetActive(true);
        }

        //ストーカーに当たればゲームオーバー
        else if(other.gameObject.tag=="Stalker")
        {
            //Debug.Log("ゲームオーバーフラグ");
            GameOverFlag = true;
        }

        //ゲームクリアオブジェクトに当たればゲームクリア
        else if(other.gameObject.tag=="GameClear")
        {
             //Debug.Log("ゲームクリア");
             GameClearFlag = true;
        }
    }

    
}


