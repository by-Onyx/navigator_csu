using Assets.Scripts.DataClasses;
using System.Collections.Generic;

namespace Assets.Scripts.UIClasses.Dropdowns
{
    public class TransitionDropdown : AbstractDropdown
    {
        public override void Init()
        {
            List<string> options = new List<string>()
            {
                "Ничего не выбранно",
                "Создать выход",
                "Создать пожарный выход",
                "Создать мужской туалет",
                "Создать женский туалет"
            };
            AddOptionsToDropdown(options);
        }

        public override void OnValueChanged()
        {
            switch (dropdown.value)
            {
                case 0:
                    OptionSelectUse.Option = OptionSelect.NothingSelected;
                    break;
                case 1:
                    OptionSelectUse.Option = OptionSelect.ExitSelected;
                    break;
                case 2:
                    OptionSelectUse.Option = OptionSelect.FireExitSelected;
                    break;
                case 3:
                    OptionSelectUse.Option = OptionSelect.ManToiletSelected;
                    break;
                case 4:
                    OptionSelectUse.Option = OptionSelect.WomanToiletSelected;
                    break;
            }
        }
    }
}
