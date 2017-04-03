using NavigatorDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace NavigatorDemo.Repositories
{
    public class FileIO : IInputOutput
    {       
        private string _filePath;

        public List<string> Content { get { return Read(); } }       

        public FileIO(string path)
        {   
            _filePath = path;           
        }

        private List<string> Read()
        {
            CheckIfFileExist(_filePath);           

            List <string> lines = new List<string> ();
            try
            {
                if (File.Exists(_filePath))
                {
                    string line;
                    using (StreamReader reader = new StreamReader(_filePath))
                    {
                        while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                        {
                            lines.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = string.Format("{0}: An error happened while reading input file. {1}", this.GetType().Name, ex.Message);
                throw new ArgumentException(msg);
            }          
           
           return lines;
        }

        public void Write(string output)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(_filePath))
                {
                    writer.WriteLine(output);
                } 
            }
            catch (Exception ex)
            {
                var msg = string.Format("{0}: An error happened while writing in output file. {1}", this.GetType().Name, ex.Message);
                throw new ArgumentException(msg);
            }         
        }

        private void CheckIfFileExist(string path)
        {
            if (!File.Exists(path))
            {
                var msg = string.Format("{0}: Input file does not exist.", this.GetType().Name);               
                throw new ArgumentException(msg);
            }
        }
    }
}
