using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trick_Light : MonoBehaviour
{
    public float FlashLightDeleteTime;   //懐中電灯の光を消してる時間
    public GameObject FlashLight;       //懐中電灯のオブジェクトをとるため
    public bool FlashLightFlag;         //懐中電灯の光を付けるかどうか

    // Use this for initialization
    void Start()
    {
        FlashLightDeleteTime = 0;
        FlashLightFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FlashLightFlag == true)
        {
            if (FlashLightDeleteTime < 10f)
            {
                //Debug.Log("光消去");
                FlashLightDeleteTime += Time.deltaTime;
                gameObject.GetComponent<Light>().intensity = 0.0f;//ライトの強さを0.0にする
            }
            else
            {
                FlashLight.SetActive(true);                       //オブジェクトをアクティブにする
                FlashLight.GetComponent<Light>().intensity = 5.0f;//ライトの強さを5.0にする
                //Debug.Log("光再度");
            }
        }
    }
}
