using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firend : MonoBehaviour
{
    public new Trick_Light light;//Trick_Lightクラスのから参照
                                 //懐中電灯の光を消すと同時に友人を消すため
    float speed;                 //友人の行動の速さ
    public Rigidbody rb;         //Rigidbodyをとる

    public Trick trick;
    public Transform target;

    // Use this for initialization
    void Start ()
    {
       // trick.HomingFlag = false;
        speed = 4.0f;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(trick.HomingFlag == true)
        {
           //Debug.Log("友人ストップ");
           rb.velocity= Vector3.zero;
           rb.isKinematic = true;
        }
        else
        {
            GameObject player = GameObject.Find("Player");//ターゲットとなるオブジェクト        
            float step = Time.deltaTime * speed;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);//Vector3.MoveTowards:二点間の特定の位置を返す                                        
                                                                                                          //　　　　　　　　　　　（主人公と友人）
            transform.LookAt(target);//主人公に向ける
        }
 
        //友人の消去（懐中電灯の光が消えたとき）
        //Trick_Light.csのFlashLightFlagの状態を見る
        if(light.FlashLightFlag==true)
        {
            gameObject.SetActive(false);//オブジェクトを非アクティブにする
        }

    }
}

