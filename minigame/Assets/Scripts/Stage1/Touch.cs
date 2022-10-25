using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public static Touch Inst { get; private set; }
    void Awake() => Inst = this;
    bool isTrigger;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //달리는 사운드
            Player.Inst.DoRun();
            isTrigger = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Player.Inst.DoIdle();
            isTrigger = false;
        }
    }

    private void OnDisable()
    {
        isTrigger = false;
    }

    public bool GetTrigger()
    {
        return isTrigger;
    }
}
