using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputHandler
{
    public static bool HandleInput(InputCombinaison inputCombinaison)
    {
        int inputChecked = 0;

        foreach (var input in inputCombinaison.InputCombinaisonAxis) {
            if (CheckInput(input)) {
                inputChecked++;
            }
        }
        if ((inputCombinaison.Bind.Count == 0 || inputCombinaison.Bind[0] == Bind.And )&& inputChecked == inputCombinaison.InputCombinaisonAxis.Count) {
            return true;
        } else if (inputCombinaison.Bind.Count != 0 && inputCombinaison.Bind[0] == Bind.Or && inputChecked > 0) {
            return true;
        }
        return false;
    }

    private static bool CheckInput(Inputs input)
    {
        InputBinds inputBinds = GameManager.Instance.GetInputBinds(input.InputAxis);
    
        if (Input.GetKey(inputBinds.ButtonKeyCode) == true)
            return true;
        return false;
    }
}
