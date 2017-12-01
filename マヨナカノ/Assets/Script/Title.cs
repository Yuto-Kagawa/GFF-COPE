using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public AudioSource TitleBGM;  //BGM
                                   
    // Use this for initialization
    void Start ()
    {
        TitleBGM = gameObject.GetComponent<AudioSource>();//音を取得
    }
	
	// Update is called once per frame
	void Update ()
    {
        TitleBGM.PlayOneShot(TitleBGM.clip);//不気味な音を再生
    }
}
