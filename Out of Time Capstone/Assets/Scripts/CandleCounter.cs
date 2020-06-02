using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("/First Person Player").GetComponent<GameStateController>().candles_lit += 1;
    }
}
