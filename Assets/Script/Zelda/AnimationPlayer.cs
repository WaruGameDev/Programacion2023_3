using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if(Mathf.Abs(x) + Mathf.Abs(y) > 0)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Attack", true);
            StartCoroutine(Attack());
        }
    
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("Attack", false);
        yield break;
    }
}
