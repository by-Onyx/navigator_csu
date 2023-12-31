﻿namespace Assets.Scripts.DataClasses.Properties
{
    public class PointPopupProperty
    {
        public string Header { get; private set; }
        public string FieldHintFirst { get; private set; }
        public string FieldHintSecond { get; private set; }
        public string FieldHintThird { get; private set; }

        public PointPopupProperty(string header, string fieldHintFirst, string fieldHintSecond, string fieldHintThird)
        {
            Header = header;
            FieldHintFirst = fieldHintFirst;
            FieldHintSecond = fieldHintSecond;
            FieldHintThird = fieldHintThird;
        }
    }
}
