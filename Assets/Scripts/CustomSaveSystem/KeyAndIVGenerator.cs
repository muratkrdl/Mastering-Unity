using System;
using System.Security.Cryptography;
using UnityEngine;

namespace CustomSaveSystem
{
    public class KeyAndIVGenerator : MonoBehaviour
    {
        public static void GenerateKeyAndIV()
        {
            using Aes aes = Aes.Create();
            aes.GenerateKey();
            aes.GenerateIV();

            string base64Key = Convert.ToBase64String(aes.Key);
            string base64IV = Convert.ToBase64String(aes.IV);
                
            Debug.Log("Generated Key: " + base64Key);
            Debug.Log("Generated IV: " + base64IV);
        }
        
        private void Start()
        {
            GenerateKeyAndIV();
        }

    }
}