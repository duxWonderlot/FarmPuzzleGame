using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Obj_clicker : MonoBehaviour
{
    [SerializeField]
    int count_objects;
    [SerializeField]
    List<GameObject> store = new List<GameObject>();
    public static Obj_clicker instance_Clicker;
    [SerializeField]
    public AudioSource tap,next;
    private void Awake()
    {
       if(instance_Clicker == null)
        {
            instance_Clicker = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count_objects += 1;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            LayerMask mask = LayerMask.GetMask("q");
            LayerMask mask_e = LayerMask.GetMask("e");
            if (Physics.Raycast(ray, out hit, 100.0f,mask))
            {
                if (hit.transform != null)
                {
                    //Print_object(hit.transform.gameObject);
                    store.Add(hit.transform.gameObject);
                    hit.transform.gameObject.SetActive(false);
                    UI_Manager.instance_q.Score();
                    tap.Play();
                }

            }           
            else if (Physics.Raycast(ray, out hit, 100.0f, mask_e))
            {
                if (hit.transform != null)
                {
                    //Print_object(hit.transform.gameObject);
                    hit.transform.gameObject.SetActive(false);
                    UI_Manager.instance_q.Score_ = 0;
                    PlayerPrefs.SetInt("Sc", UI_Manager.instance_q.Score_);
                    print("Game Over");
                    SceneManager.LoadSceneAsync(0);

                }
            }
        }
        print("TS"+store.Count);
        print("Grid_" + Grid_.instance_Grid.Solution.Count);

        if(store.Count == Grid_.instance_Grid.Solution.Count || store.Count-1 == Grid_.instance_Grid.Solution.Count || store.Count == Grid_.instance_Grid.Solution.Count-1)
        {
            
            
            SceneManager.LoadSceneAsync(0);
            print("Test_WIn");

        }
    }

    private void Print_object(GameObject go)
    {
        print(go.name);
    }

    
}
