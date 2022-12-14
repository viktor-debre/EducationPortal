namespace EducationPortal.Presentation.Application
{
    internal class InputHandler
    {
        public bool TryInputStringValue(out string value, string fieldName, string operation, string entityName)
        {
            Console.WriteLine($"Input {fieldName} for {operation} {entityName}: ");
            var input = Console.ReadLine();
            value = input;
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine($"Empty {fieldName}, {operation}  {entityName} interrupted!");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return false;
            }

            return true;
        }

        public bool TryInputIntValue(out int value, string fieldName, string operation, string entityName)
        {
            Console.WriteLine($"Input {fieldName} for {operation}  {entityName}: ");
            var numberString = Console.ReadLine();
            int number;
            if (!int.TryParse(numberString, out number))
            {
                Console.WriteLine($"Wrong {fieldName}, {operation}  {entityName} interrupted!");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                value = 0;
                return false;
            }
            else
            {
                value = number;
                return true;
            }
        }

        public bool TryInputDateTimeValue(out DateTime value, string fieldName, string operation, string entityName)
        {
            Console.WriteLine($"Input {fieldName} for {operation}  {entityName}: ");
            var dateString = Console.ReadLine();
            DateTime dateValue;
            if (!DateTime.TryParse(dateString, out dateValue))
            {
                Console.WriteLine($"Wrong {fieldName} {operation}  {entityName} interrupted!");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                value = DateTime.Now;
                return false;
            }
            else
            {
                value = dateValue;
                return true;
            }
        }

        public bool TryInputTimeSpanValue(out TimeSpan value, string fieldName, string operation, string entityName)
        {
            Console.WriteLine($"Input {fieldName} for {operation}  {entityName}: ");
            var dateString = Console.ReadLine();
            TimeSpan dateValue;
            if (!TimeSpan.TryParse(dateString, out dateValue))
            {
                Console.WriteLine($"Wrong {fieldName} {operation}  {entityName} interrupted!");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                value = TimeSpan.MinValue;
                return false;
            }
            else
            {
                value = dateValue;
                return true;
            }
        }
    }
}
