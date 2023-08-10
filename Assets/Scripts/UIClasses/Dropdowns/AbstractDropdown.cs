using TMPro;
using UnityEngine;

namespace Assets.Scripts.UIClasses
{
    public abstract class AbstractDropdown : MonoBehaviour
    {
        [SerializeField] protected TMP_Dropdown dropdown;

        public abstract void Init();

        public abstract void OnValueChanged();
    }
}
