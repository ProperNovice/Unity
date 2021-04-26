using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerKeyCode : MonoBehaviour
{

    private int keyCodeID = 0;

    private void Update()
    {

        this.keyCodeID = 0;

        if (Input.GetKeyDown(KeyCode.Q))
            this.keyCodeID = 1;
        else if (Input.GetKeyDown(KeyCode.W))
            this.keyCodeID = 2;
        else if (Input.GetKeyDown(KeyCode.E))
            this.keyCodeID = 3;
        else if (Input.GetKeyDown(KeyCode.R))
            this.keyCodeID = 4;

        if (this.keyCodeID == 0)
            return;

        ManagerText.INSTANCE.handleKeyCodeID(this.keyCodeID);

    }

}
