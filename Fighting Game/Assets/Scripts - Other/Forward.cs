using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mAnimator != null)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                mAnimator.SetTrigger("TrForwardLeft");   
            }

            if(Input.GetKeyDown(KeyCode.X))
            {
                mAnimator.SetTrigger("TrForward");
            }

            if(Input.GetKeyDown(KeyCode.C))
            {
                mAnimator.SetTrigger("TrForwardRight");
            }

            if(Input.GetKeyDown(KeyCode.V))
            {
                mAnimator.SetTrigger("TrLeft");
            }

            if(Input.GetKeyDown(KeyCode.B))
            {
                mAnimator.SetTrigger("TrRight");
            }

            if(Input.GetKeyDown(KeyCode.N))
            {
                mAnimator.SetTrigger("TrBackwardLeft");
            }

            if(Input.GetKeyDown(KeyCode.M))
            {
                mAnimator.SetTrigger("TrBackward");
            }

            if(Input.GetKeyDown(KeyCode.L))
            {
                mAnimator.SetTrigger("TrBackwardRight");
            }

            if(Input.GetKeyDown(KeyCode.P))
            {
                mAnimator.SetTrigger("Attack");
            }
        }
    }
}
