using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program
{
    void Divide(int num1, int num2)
    {
        int smallNum;
        int bigNum;
        string numbers;

        if (num1 >= num2)   //küçük sayıyı bulup smallNum değişkenine atar
        {
            smallNum = num2;
            bigNum = num1;
        }
        else
        {
            smallNum = num1;
            bigNum = num2;
        }


        for (int i = 1; i <= 10; i++) //girilen 2 sayı arasındaki tüm sayıları , 1 den 10 a kadar olan tüm sayılara böler (1e bölüm , 2ye bölüm ... smallNum a bölüm)
        {
            numbers = $"Numbers / {i} :";

            for (int j = smallNum; j <= bigNum; j++)//girilen 2 sayı arasındaki tüm sayıları gezer
            {
                if (j % i == 0)
                    numbers += " " + j.ToString();
            }
            print(numbers);//sonucu console yazdırır
        }
    }


    void Start()
    {
        Divide(10, 55);
    }
}

