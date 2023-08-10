using Assets.Scripts.DataClasses;
using System.Collections.Generic;

namespace Assets.Scripts.UIClasses.Dropdowns
{
    public class PointDropdown : AbstractDropdown
    {
        public override void Init()
        {
            List<string> options = new List<string>() { "Ничего не выбранно", "Создать кабинет", "Создать точку интереса" };
            dropdown.ClearOptions();
            dropdown.AddOptions(options);
            dropdown.onValueChanged.AddListener(delegate { OnValueChanged(); });
        }

        public override void OnValueChanged()
        {
            switch (dropdown.value)
            {
                case 0:
                    OptionSelectUse.Option = OptionSelect.NothingSelected;
                    break;
                case 1:
                    OptionSelectUse.Option = OptionSelect.Cabinetselected;
                    break;
                case 2:
                    OptionSelectUse.Option = OptionSelect.InterestSelected;
                    break;
            }
        }
    }
}
