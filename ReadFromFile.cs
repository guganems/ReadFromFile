using System;
using System.Collections.Generic;

public class ReadFromFile
{

    static void Main()
    {
        int junkWord = 0;
        string[] words;
        int i = 0;
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\nemst\Desktop\guga.txt");
        foreach(string line in lines)
        {
            words= line.Split(' ');
            foreach(string word in words)
            {
                i++;
            }
        }
        string[] complete = new string[i];
        i = 0;
        foreach (string line in lines)
        {
            words = line.Split(' ');
            foreach (string word in words)
            {
                complete[i] = word;
                i++;
            }
        }
        int completeLength = complete.Length;
        List<String> result = new List<string>(); //საბოლოო მასივი
        int notAWord = 0;
        int isINT = 0;
        //ცარიელი ხაზების მოშორება
        for(int k=0; k<completeLength; k++)
        {
            int wordLengthInThisScope = complete[k].Length;
            if (wordLengthInThisScope == 0)
            {
                junkWord++;
                continue;
            }
            else
            {
                complete[k - junkWord] = complete[k];
            }
        }
        //ზედმეტი ასო-ნიშნების მოშორება
        for(int k=0; k<completeLength-junkWord; k++)
        {
            int eachWordLength = complete[k].Length;
            String tempWord = "";
            for(int l=0; l<eachWordLength; l++)
            {
                if (complete[k][l] == ',' || complete[k][l] == '.' || complete[k][l] == '-' || complete[k][l] == '_'
                    || complete[k][l] == '?' || complete[k][l] == '!' || complete[k][l] == '*'
                    || complete[k][l] == '0' || complete[k][l] == '1' || complete[k][l] == '2' || complete[k][l] == '3'
                    || complete[k][l] == '4' || complete[k][l] == '5' || complete[k][l] == '6' || complete[k][l] == '7'
                    || complete[k][l]=='8' || complete[k][l]=='9' || complete[k][l]=='„' || complete[k][l]=='“'
                    || complete[k][l]==';' || complete[k][l]==':' || complete[k][l]=='\t' || complete[k][l]=='\n'
                    || complete[k][l] == '\"' || complete[k][l] == '#')
                {
                    continue;
                }
                else
                {
                    tempWord += complete[k][l];
                }
            }
            result.Add(tempWord);
            tempWord = "";
        }
        //გამეორებული სიტყვების წაშლა
        //ERROR!!!
        result.Sort();
        int oddWord = 0;
        for (int k = 0; k < result.Count-1; k++)
        {
            if (result[k] == result[k + 1])
            {
                //result.ForEach(Console.WriteLine);
                oddWord++;
                result.RemoveAt(k);
            }
        }
        //სიგრძეების გამოთვლა
        completeLength = result.Count;
        int[] length = new int[completeLength];
        Console.WriteLine(result.Count);
        for(int k=0; k<result.Count; k++)
        {
            if (result[k].Length <= 0)
            {
                result.RemoveAt(k);
                continue;
            }
            else
            {
                length[k] = result[k].Length;
            }
        }
        completeLength = result.Count;
        //ხმოვნებისა და თანხმოვნების განცალკევება
        string[] vowels = new string[completeLength - junkWord];
        string[] consonants = new string[completeLength - junkWord];
        for(int k=0; k<completeLength-junkWord; k++)
        {
            vowels[k] = ""; consonants[k] = "";
            int eachWordLength = result[k].Length;
            for(int l=0; l<eachWordLength; l++)
            {
                if (result[k][l] == 'ა' || result[k][l] == 'ე' || result[k][l] == 'ი' || result[k][l] == 'ო' ||
                    result[k][l] == 'უ' || result[k][l] == 'a' || result[k][l] == 'e' || result[k][l]=='i'
                    || result[k][l]=='o' || result[k][l]=='u')
                {
                    vowels[k] += result[k][l];
                }
                else
                {
                    consonants[k] += result[k][l];
                }
            }
        }
        //საბოლოო სახით PRE!!!
        for (int k=0; k<completeLength-(junkWord); k++)
        {
            result[k] = result[k] + "\t" + vowels[k] + "\t" + consonants[k] + "\t" + length[k];
        }
        System.IO.File.WriteAllLines(@"C:\Users\nemst\Desktop\guga1.txt", complete);
        System.Console.WriteLine("Contents of WriteLines2.txt = ");
        Console.ReadKey();
    }
}
//LOAD DATA LOCAL INFILE 'c:/Users/GugaNemsitsveridze/Desktop/guga1.txt' INTO TABLE words COLUMNS TERMINATED BY '\t';