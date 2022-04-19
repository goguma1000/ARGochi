using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public int Love = 0;
    public int Cleanliness = 50;
    public int Fullness = 50;
    public int[] foodStock = { 5, 0, 0, 0, 0, 0, 0 }; // ���� �κ��丮 �������
    public int[] petStomach = { 0, 0, 0, 0, 0, 0, 0 };
    public int petNum = 0;
    public bool isFoodSpawn = false;

    [HideInInspector]
    public string petName = null;
   
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(decreaseStat());
        StartCoroutine(decreaseLove());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator decreaseStat()
    {
        while (true)
        {
            yield return new WaitForSeconds(180);
            if (Cleanliness - 5 < 0)
            {
                Cleanliness = 0;
            }
            else Cleanliness -= 5;

            if (Fullness - 5 < 0)
            {
                Fullness = 0;
            }
            else Fullness -= 5;
        }
    }
    IEnumerator decreaseLove()
    {
        while (true)
        {
            if ((Cleanliness <= 20 || Fullness <= 20) && Love > 0)
            {
                yield return new WaitForSeconds(1);
                if (Love - 5 < 0) Love = 0;
                else Love -= 5;
            }
            else yield return null;
        }

    }
}

