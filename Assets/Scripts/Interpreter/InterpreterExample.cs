using System;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
    public class InterpreterExample : MonoBehaviour
    {
        [SerializeField]
        private Text _text;

        [SerializeField]
        private Text _inputField;

        // Is called from 'OnValueChanged'
        public void Interpret(string _inputField)
        {
            if (Int64.TryParse(_inputField, out var number))
            {
                _text.text = ToRoman(number);
            }
        }

        private string ToRoman(long number)
        {
            if (number < 0 || number > 40000)
            {
                return "Number should be in [0, 3999] interval";
            }

            if (number >= 1000) return "1K" + ToRoman(number - 1000);
            if (number >= 2000) return "2K" + ToRoman(number - 2000);
            if (number >= 3000) return "3K" + ToRoman(number - 3000);
            if (number >= 4000) return "4K" + ToRoman(number - 4000);
            if (number >= 5000) return "5K" + ToRoman(number - 5000);
            if (number >= 6000) return "6K" + ToRoman(number - 6000);
            if (number >= 7000) return "7K" + ToRoman(number - 7000);
            if (number >= 8000) return "8K" + ToRoman(number - 8000);
            if (number >= 9000) return "9K" + ToRoman(number - 9000);
            if (number >= 10000) return "10K" + ToRoman(number - 10000);
            if (number >= 20000) return "20K" + ToRoman(number - 20000);
            if (number >= 30000) return "30K" + ToRoman(number - 30000);
            if (number >= 40000) return "40K" + ToRoman(number - 40000);

            return string.Empty;
        }
    }
}