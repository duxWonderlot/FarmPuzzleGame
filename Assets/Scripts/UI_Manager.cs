using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    Text txt_area;
    public int Score_;
    public static UI_Manager instance_q;
    [SerializeField]
    int hight_score;
    [SerializeField]
    GameObject[] txt;
    Text get_text;
    private void Awake()
    {
        if(instance_q == null)
        {
            instance_q = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        //PlayerPrefs.DeleteAll();
    }
    private void Start()
    {
        Score_ = PlayerPrefs.GetInt("Sc");
        hight_score = PlayerPrefs.GetInt("high");
        txt[Random.Range(0, txt.Length)].SetActive(true);
    }
    public void Score()
    {
        Score_ = Score_ + ((int)GameManager.instance_GM.timer_value);
        txt_area.text = "Score:"+(int)Score_;
        PlayerPrefs.SetInt("Sc", Score_);
        
        if(Score_ > hight_score)
        {
            
            PlayerPrefs.SetInt("high", Score_);
            Obj_clicker.instance_Clicker.next.Play();
            
        }
       
         
    }
     
}
