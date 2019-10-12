using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public GameObject hixboxPrefab;
    [SerializeField] private GameObject wolfForm;
    [SerializeField] public UserInterface userScreen;
    [HideInInspector] public List<GameObject> myPersons = new List<GameObject>();
    [HideInInspector] public bool transformed = false;
    public float talkTimer;
    public float killTimer;
    private void Awake()
    {
        if(null != instance)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if(0 >= talkTimer && !transformed)
        {
            transformed = true;
            Transformation();
        }
    }

    public void Transformation()
    {
        GameObject temp = Instantiate(wolfForm, player.transform.position, player.transform.rotation);
        Destroy(player.gameObject);
        player = temp;
    }
}
