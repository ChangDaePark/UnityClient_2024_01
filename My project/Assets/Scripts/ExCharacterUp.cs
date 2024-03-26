using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCharacterUp : ExCharacter
{
    protected override void Move()
    {
        base.Move();
        transform.Translate(
            Vector3.up * speed * 2
            * Time.deltaTime);
    }
}
