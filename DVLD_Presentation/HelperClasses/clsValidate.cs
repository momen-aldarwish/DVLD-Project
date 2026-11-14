using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DVLD_Presentation.HelperClasses
{
    public class clsValidate
    {
        public static bool Email(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string pattern = @"^[a-zA-Z0-9]+@[a-zA-Z]{2,}\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(input, pattern);
        }

        public static bool PhoneNomber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string pattern = @"^\+?[0-9]+$";

            return Regex.IsMatch(input, pattern);
        }

        public static bool SanitizeNumericInput(object sender, bool condition)
        {
            if (condition && sender is TextBox txt && !string.IsNullOrEmpty(txt.Text))
            {
                string cleanText = System.Text.RegularExpressions.Regex.Replace(txt.Text, @"[^\d]", "");

                if (txt.Text != cleanText)
                {
                    txt.Text = cleanText;
                    txt.SelectionStart = txt.Text.Length;
                    return true;
                }
            }
            return false;
        }

        public static bool PressOnlyNombers(KeyPressEventArgs e, bool Condition)
        {
            if (Condition && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // إلغاء إدخال الحرف المكتوب
                return true;
            }
            return false;

        }

        public static bool HasAnyErrors(Control parent, ErrorProvider errorProvider)
        {
            foreach (Control c in parent.Controls)
            {
                // 1. إذا كان العنصر نفسه عليه خطأ حالياً في ErrorProvider
                if (!string.IsNullOrEmpty(errorProvider.GetError(c)))
                    return true;

                // 2. الدخول داخل الـ GroupBoxes والـ Panels لفحص ما بداخلها
                if (c.HasChildren)
                {
                    if (HasAnyErrors(c, errorProvider))
                        return true;
                }
            }
            return false;
        }
    
    
    }
}
