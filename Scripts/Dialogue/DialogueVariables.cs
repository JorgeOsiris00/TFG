using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;

public class DialogueVariables
{
    // Story son los archivos Ink, es decir, los dialogos

    // el diccionario almacena el estado de las variables globales
    public  Dictionary<string, Ink.Runtime.Object> variables { get; private set; }


    /* ERROR a tratar en el futuro
     * Debido a que Global.ink no se compila de manera normal,esta funcion se encarga de hacer lo
     * Hay que mirar como solucionar esto.
    */
    public DialogueVariables(string globalsFilePath)
    {
        // compilar la story:
        //  lee el archivo como cadena de String y lo compila
        string inkFileContens = File.ReadAllText(globalsFilePath);
        Ink.Compiler compiler = new Ink.Compiler(inkFileContens);
        Story globalsVariablesStory = compiler.Compile();

        // iniciar el diccionario
        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach(string name in globalsVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalsVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Iniciada la variable de Global Dialogue: " + name + " = " + value);

        }


    }

    public void StartListening(Story story)
    {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }



 
    private void VariableChanged(string name , Ink.Runtime.Object value)
    {
        // Carga solo las variablesque han sido iniciadas em Globals.ink
        if (variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
        }

    }

    private void VariablesToStory( Story story)
    {
        foreach(KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }

    }



}
