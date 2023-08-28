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
                "Создать лестницу", 
                "Создать лифт", 
                "Создать туалет"
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
                    OptionSelectUse.Option = OptionSelect.LadderSelected;
                    break;
                case 2:
                    OptionSelectUse.Option = OptionSelect.ElevatorSelected;
                    break;
                case 3:
                    OptionSelectUse.Option = OptionSelect.ToiletSelected;
                    break;
            }
        }
    }
}
