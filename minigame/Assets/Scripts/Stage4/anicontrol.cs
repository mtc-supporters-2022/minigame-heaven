using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anicontrol : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("mujeok", false);
    }

    public void Returning()
    {
        anim.SetBool("mujeok", false);
    }

    public void Mujeok()
    {
        anim.SetBool("mujeok", true);
    }
}
