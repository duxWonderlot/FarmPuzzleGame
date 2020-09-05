using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    Slider slide_time;
    [SerializeField]
    public float timer_value;
    public static GameManager instance_GM;
    private void Awake()
    {
        if (instance_GM == null)
        {
            instance_GM = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        
    }
    private void Start()
    {
        slide_time.maxValue = 50;
         
    }


    private void Update()
    {
        slide_time.value += timer_value * Time.deltaTime;
        if(slide_time.value >= slide_time.maxValue){
            SceneManager.LoadSceneAsync(0);
            slide_time.value = 0;
            
        }
    }
}
