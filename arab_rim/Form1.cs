namespace arab_rim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(textBox1.Text, out num))
            {
                if (num < 1 || num > 9999)
                {
                    label1.Text = "mnogo";
                }
                else
                {
                    string rNumber = Convert(num);
                    label1.Text = rNumber;
                }
            }
            else
            {
                label1.Text = "mnogo";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Number = textBox1.Text;
            int arab = ConvertArab(Number);
            label1.Text = arab.ToString();
        }
        private string Convert(int number)
        {
            int[] arabicValues = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] romanNumerals = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            string romanNumber = "";
            for (int i = 0; i < arabicValues.Length; i++)
            {
                while (number >= arabicValues[i])
                {
                    romanNumber += romanNumerals[i];
                    number -= arabicValues[i];
                }
            }
            return romanNumber;
        }
        private int ConvertArab(string romanNumber)
        {
            string[] romanNumerals = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] arabicValues = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            int arabicNumber = 0;
            int index = 0;
            foreach (string numeral in romanNumerals)
            {
                while (romanNumber.StartsWith(numeral))
                {
                    arabicNumber += arabicValues[index];
                    romanNumber = romanNumber.Substring(numeral.Length);
                }
                index++;
            }
            return arabicNumber;
        }
    }
}