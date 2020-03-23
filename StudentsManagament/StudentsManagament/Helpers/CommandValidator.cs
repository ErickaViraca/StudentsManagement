using System;

namespace StudentsManagament.Helpers
{
    public class CommandValidator : ICommandValidator
    {
        private enum ValidParameter { name, type, gender };

        /// <summary>
        /// Method to verify if the parameter is valid or not.
        /// </summary>
        /// <param name="value"></param>
        /// <returns> bool </returns>
        public bool VerifyParameter(string value)
        {
            bool isValid = false;
            if (value.Equals(ValidParameter.name.ToString()) || value.Equals(ValidParameter.type.ToString()) || value.Equals(ValidParameter.gender.ToString()))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("The parameter type does not exist.");
            }
            return isValid;
        }

        /// <summary>
        /// Method to verify if the parameter format is correct.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns> bool </returns>
        public bool VerifyCorrectFormat(string parameter)
        {
            bool isCorrectFormat = false;
            if (parameter.Contains("="))
            {
                string[] parameters = parameter.Split("=");
                if (parameters.Length < 3)
                {
                    if (parameters[1] == "")
                    {
                        Console.WriteLine("The parameter value is empty.");
                    }
                    else
                    {
                        isCorrectFormat = VerifyParameter(parameters[0]);
                    }
                }
            }
            return isCorrectFormat;
        }

        /// <summary>
        /// Method that return the parameter denomination.
        /// </summary>
        /// <param name="argument"></param>
        /// <returns> parameter: name/type/gender </returns>
        public string GetCommandParameter(string argument)
        {
            string[] parameter = argument.Split("=");
            return parameter[0];
        }

        /// <summary>
        /// Method that return the parameter value.
        /// </summary>
        /// <param name="argument"></param>
        /// <returns>parameter value</returns>
        public string GetCommandParameterValue(string argument)
        {
            string[] parameterValue = argument.Split("=");
            return parameterValue[1];
        }
    }
}
