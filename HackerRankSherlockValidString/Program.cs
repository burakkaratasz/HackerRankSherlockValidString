using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'isValid' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string isValid(string s)
    {
        Dictionary<char, int> charCounts = new Dictionary<char, int>(); //dictionary olustur
        
        foreach (char c in s) //harf sayilarini hesapla
        {
            if (charCounts.ContainsKey(c)) //karakter varsa bir arttir
            {
                charCounts[c]++;
            }
            else
            {
                charCounts[c] = 1;
            }
        }

        int[] counts = charCounts.Values.ToArray(); //harf adetlerini diziye at
        
        bool esitMi = true; //harfler esit mi kontrol et
        for (int i = 1; i < counts.Length; i++)
        {
            if (counts[i] != counts[0])
            {
                esitMi = false;
                break;
            }
        }
        
        if (esitMi)
        {
            return "YES";
        }
        
        else
        {
            for (int i = 0; i < counts.Length; i++) //her elemani bir azalt esitlik kontrol et
            {
                counts[i]--;
                bool azalanEsitMi = true;
                for (int j = 0; j < counts.Length; j++)
                {
                    if (counts[j] != counts[0])
                    {
                        azalanEsitMi = false;
                        break;
                    }
                }
                counts[i]++; //azalttigin elemani tekrar arttir                
                if (azalanEsitMi)
                {
                    return "YES";
                }
                                                            
            }           
        }              
        return "NO";                
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.isValid(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
