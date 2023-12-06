using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStage : MonoBehaviour
{
    //private int sizeX = 800;
    public void StageExit(int num)
    {
        this.transform.localPosition = new Vector2(-num, 0);
    }
}
