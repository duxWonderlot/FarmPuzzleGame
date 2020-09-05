using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Grid_ : MonoBehaviour
{
    [SerializeField]
    GameObject []obj;
    [SerializeField]
    Transform origin;
    [SerializeField]
    public List<GameObject> Solution;
    public static Grid_ instance_Grid;

    private void Awake()
    {
        if (instance_Grid == null)
        {
            instance_Grid = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }


    private void Start()
    {
        for(int i =0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                Solution = new List<GameObject>(GameObject.FindGameObjectsWithTag("hey"));
                Vector3 grid_position = new Vector3(obj[1].transform.position.x + i+1, -1, obj[1].transform.position.z+j+1);
                var new_obj = Instantiate(obj[Random.Range(0,obj.Length)], grid_position, Quaternion.identity);             
                Solution.Add(new_obj);
                new_obj.transform.parent = this.gameObject.transform;

                
            }
        }
    }

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
