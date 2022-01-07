using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    public Button ThisButton => _button;
}
