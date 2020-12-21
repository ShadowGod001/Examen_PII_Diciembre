using System;
using System.Collections.Generic;
using System.IO;
using Library.Encounters;
using Library.Scenarios;

namespace Library.Files
{
    public class FileReader
    {   
        private TypeHandler chainStarterHandler;
        
        /// <summary>
        /// Necesita el primer TypeHandler dentro de una cadena de estos.
        /// </summary>
        /// <param name="chainStarterHandler"></param>
        public FileReader (TypeHandler chainStarterHandler)
        {
            this.chainStarterHandler = chainStarterHandler;
        }

        public Scenario Read(string path)
        {   
            List<Encounter> encounterList = new List<Encounter>();
            HandlerRequest handlerRequest = new HandlerRequest();

            String[] lines = File.ReadAllLines(@path);

            if (lines.Length == 0)
            {
                throw new InvalidFileFormatException("Archivo vacio");
            }
            
            foreach (string line in lines)
            {
                string cleanLine = line.Replace("\n", "");

                switch (cleanLine)
                {
                    case "[Character]":
                    case "[Items]":
                    case "[Encounter]":
                        continue;
                    case "[NewGroup]":
                    {
                        if (handlerRequest.Encounter != null)
                        {
                            encounterList.Add(handlerRequest.Encounter);
                        }
                        handlerRequest = new HandlerRequest();
                        continue;
                    }
                }

                handlerRequest.Line = cleanLine;
                var updatedRequest = chainStarterHandler.Handle(handlerRequest);
                handlerRequest = updatedRequest ?? throw new InvalidFileFormatException($"Puede que falte un handler para este tipo de solicitud:\n{handlerRequest.Line}");
            }
            
            encounterList.Add(handlerRequest.Encounter);
            if (encounterList.Count == 0)
            {
                throw new InvalidFileFormatException("No se creo ningun encuentro");
            }

            Scenario scenario = new Scenario(encounterList);
            return scenario;
        }

    }

   
}