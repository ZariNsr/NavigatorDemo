using NavigatorDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NavigatorDemo.Repositories
{
    public class BaseEntityRepository
    {       
        protected IInputOutput _InputOutput { get; set; }
        protected List<string> InputText { get; set; }

        public BaseEntityRepository(IInputOutput fileIO)
        {
            _InputOutput = fileIO;

            if (!_InputOutput.Content.Any())
            {
                var msg = string.Format("{0}: Input file is empty, application is not able to do the job.", this.GetType().Name);
                throw new ArgumentNullException(msg);             
            }

            InputText = _InputOutput.Content;
        }

        public void DoValidation(string[] input, int expectedLength, string entity)
        {
            if (!input.Any() || input.Length != expectedLength)
            {
                var msg = string.Format("{0}: Input text does not contain {1} information, application is not able to create the {1}.", this.GetType().Name, entity);
                throw new ArgumentNullException(msg);
            }

            foreach (var chr in input)
            {
                chr.DoValidation();
            }
        }
    }
}
