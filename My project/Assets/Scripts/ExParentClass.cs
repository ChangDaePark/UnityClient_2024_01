using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExParentClass : MonoBehaviour
{

    protected int protectedValue;

}


    public class ExChildClass : ExParentClass
{
        void Start()
        {
            Debug.Log("Protected Value from Child Class :" + protectedValue);
        }
}
