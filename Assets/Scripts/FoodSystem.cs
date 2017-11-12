using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSystem : MonoBehaviour {
    [Header("Variabelen")]
    [Space(10)]
    [SerializeField]
    private float CurrentFulliness;
    [SerializeField]
    private int DeathNum;
    [SerializeField]
    private float AddFood;
    [SerializeField]
    private float MinFood;
    [SerializeField]
    private float Maxfulliness;
    [SerializeField]
    private float Minfulliness;
    [SerializeField]
    private int FoodDecreaseTimer;
    [Header("Renderer and Bools")]
    [Space(10)]
    public Renderer rend;
    public bool IslosingFood;
    public bool IsGainingFood;
    public bool IsDeath;
    public bool IsEating;

    [SerializeField]
    private GameObject AnimObject;
	void Start ()
    {
        IsDeath = false;
       rend = GetComponent<Renderer>();
        rend.material.SetFloat("Amount", 0);
        CurrentFulliness = rend.material.GetFloat("Amount");
        StartCoroutine(FoodTimer());
    }
	
	void Update ()
    {
        if (!IsEating && !IsDeath)
        {
            if (CurrentFulliness > .008 || CurrentFulliness < -0.0004)
            {
                AnimObject.GetComponent<AnimController>().Panic();
            }
            else
            {
                AnimObject.GetComponent<AnimController>().Idle();
            }
        }
	}

   public void AddFoodFunc()
    {
        if (!IsDeath && !IsEating)
        {
            IsEating = true;
            rend.material.SetFloat("Amount", CurrentFulliness += AddFood);
            AnimObject.GetComponent<AnimController>().Eating();
            if (rend.material.GetFloat("Amount") > Maxfulliness)
            {
                Death();
            }
        }
    }

    void Death()
    {
        IsDeath = true;
        Debug.Log(" Your Dead");
        AnimObject.GetComponent<AnimController>().DeathAnim();   
    }

    IEnumerator FoodTimer()
    {
        while (!IsDeath)
        {
            yield return new WaitForSeconds(FoodDecreaseTimer);
            rend.material.SetFloat("Amount", CurrentFulliness -= MinFood);
            Debug.Log("Lessfood");
            if(CurrentFulliness < Minfulliness || CurrentFulliness > Maxfulliness)
            {
                Death();
            }
        }
    }

}
