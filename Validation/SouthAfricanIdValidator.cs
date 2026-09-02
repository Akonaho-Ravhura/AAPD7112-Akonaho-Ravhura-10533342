namespace Municipal_Application.Validation
{
    
    /// Validates South African 13-digit ID numbers (format: YYMMDDSSSSCAZ),
    /// including the date-of-birth segment and the Luhn check digit.
        public static class SouthAfricanIdValidator
    {
        public static bool IsValid(string idNumber)
        {
            if (string.IsNullOrWhiteSpace(idNumber) || idNumber.Length != 13)
            {
                return false;
            }

            if (!idNumber.All(char.IsDigit))
            {
                return false;
            }

            if (!HasValidBirthDate(idNumber))
            {
                return false;
            }

            return HasValidCheckDigit(idNumber);
        }

        private static bool HasValidBirthDate(string idNumber)
        {
            var month = int.Parse(idNumber.Substring(2, 2));
            var day = int.Parse(idNumber.Substring(4, 2));

            if (month is < 1 or > 12)
            {
                return false;
            }

            var daysInMonth = month switch
            {
                2 => 29, // allow 29 Feb without knowing the century/leap-year rules
                4 or 6 or 9 or 11 => 30,
                _ => 31
            };

            return day >= 1 && day <= daysInMonth;
        }

        private static bool HasValidCheckDigit(string idNumber)
        {
            var digits = idNumber.Select(c => c - '0').ToArray();

            var oddSum = digits[0] + digits[2] + digits[4] + digits[6] + digits[8] + digits[10];

            var evenDigitsValue = string.Concat(digits[1], digits[3], digits[5], digits[7], digits[9], digits[11]);
            var evenDoubled = (long.Parse(evenDigitsValue) * 2).ToString();
            var evenSum = evenDoubled.Sum(c => c - '0');

            var checkDigit = (10 - (oddSum + evenSum) % 10) % 10;

            return checkDigit == digits[12];
        }
    }
}
