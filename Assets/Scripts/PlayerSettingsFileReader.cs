using UnityEngine;
using System;
using System.Collections;
using System.Text;
using System.IO;

public class PlayerSettingsFileReader : MonoBehaviour
{
    private bool controller;

    public bool Load(string fileName)
    {
        // Handle any problems that might arise when reading the text
        try
        {
            string line;
            // Create a new StreamReader, tell it which file to read and what encoding the file
            // was saved as
            StreamReader theReader = new StreamReader(fileName, Encoding.Default);
            // Immediately clean up the reader after this block of code is done.
            // You generally use the "using" statement for potentially memory-intensive objects
            // instead of relying on garbage collection.
            // (Do not confuse this with the using directive for namespace at the 
            // beginning of a class!)
            using (theReader)
            {
                // While there's lines left in the text file, do this:
                do
                {
                    line = theReader.ReadLine();

                    if (line != null)
                    {
                        readSettingLine(line);
                    }
                }
                while (line != null);
                // Done reading, close the reader and return true to broadcast success    
                theReader.Close();
                return true;
            }
        }
        // If anything broke in the try block, we throw an exception with information
        // on what didn't work
        catch (Exception e)
        {
            Debug.Log("{0}\n" + e.Message);
            return false;
        }
    }

    private void readSettingLine(String line) {
        if (line.Contains("ControllerEnabled"))
        {
            switch(line.Contains("True"))
            {
                case false:
                    controller = false;
                    break;
                case true:
                    controller = true;
                    break;
            }
        }     
    }

    private bool replaceSettingLine(String fileName, String[] lines, bool controllerEnabled)
    {
        for (int i = 0; i < lines.Length; i++) {
            if (lines[i].Contains("ControllerEnabled"))
            {
                lines[i] = "ControllerEnabled = " + controllerEnabled.ToString();
                File.WriteAllLines(fileName, lines);
                return true;
            }  
        }

        return false;
    }

    public bool getController()
    {
        return controller;
    }

    public bool setController(String fileName, bool controllerEnabled)
    {
        try
        {
            string[] lines = File.ReadAllLines(fileName);

            if (lines.Length != 0)
            {
               if (replaceSettingLine(fileName, lines, controllerEnabled))
               {
                    controller = controllerEnabled;
                    return true;
               }
            }
        }
        catch (Exception e)
        {
            Debug.Log("{0}\n" + e.Message);
        }
        return false;
    }
}
