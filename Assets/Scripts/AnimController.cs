using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour {
    public Animator anim;
    public GameObject LegoManfatController;
	
	void Start ()
    {
       anim = this.GetComponent<Animator>();
	}
	
	public void Panic()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Panic", true);
    }

    public void Idle()
    {
        anim.SetBool("Eat", false);
        anim.SetBool("Panic", false);
        anim.SetBool("Idle", true);
    }

    public void Eating()
    {
        StartCoroutine(EatTimer());
        
    }

   public void DeathAnim()
    {
        anim.SetBool("Eat", false);
        anim.SetBool("Panic", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Death", true);
    }

  public IEnumerator EatTimer()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Eat", true);
        yield return new WaitForSeconds(3);
        anim.SetBool("Eat", false);
       LegoManfatController.GetComponent<FoodSystem>().IsEating = false;

    }
}
