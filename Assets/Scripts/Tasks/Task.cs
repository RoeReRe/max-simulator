using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Task : MonoBehaviour
{
    public int count = 0;
    public abstract void DoTask();
}
