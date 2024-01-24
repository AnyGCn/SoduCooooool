using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodukuView : MonoBehaviour
{
    public SodukuElement[] elements = new SodukuElement[81];
    public SodukuFull sodukuFull;
    public GameObject elementPrefab;
}
