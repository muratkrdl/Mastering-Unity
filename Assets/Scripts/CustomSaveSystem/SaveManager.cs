using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEngine;

namespace CustomSaveSystem
{
    public class SaveManager : MonoBehaviour
    {
        private const string SaveFileName = "saveData1.dat";
        private const string CloudSaveFileName = "cloudSaveData.dat";

        private static byte[] key = Convert.FromBase64String("kwAXmhR48HenPp04YXrKSNfRcFSiaQx35BlHnI7kzK0=");
        private static byte[] iv = Convert.FromBase64String("GcVb7iqWex9uza+Fcb3BCQ==");

        public static void SaveData(string key, string data)
        {
            string filePath = Path.Combine(Application.persistentDataPath, SaveFileName);
            Dictionary<string, string> savedData = LoadSavedData();
            savedData[key] = data;
            string jsonData = JsonConvert.SerializeObject(savedData);
            byte[] encryptedData = EncryptData(jsonData);
            
            using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            fileStream.Write(encryptedData, 0, encryptedData.Length);
        }
        
        public static string LoadData(string key)
        {
            string filePath = Path.Combine(Application.persistentDataPath, SaveFileName);
            Dictionary<string, string> savedData = LoadSavedData();
            if (savedData.TryGetValue(key, out var data))
            {
                return data;
            }

            Debug.LogWarning("No save data found for key: " + key);
            return null;
        }

        private static Dictionary<string, string> LoadSavedData()
        {
            string filePath = Path.Combine(Application.persistentDataPath,SaveFileName);
            if (File.Exists(filePath))
            {
                byte[] encryptedData = File.ReadAllBytes(filePath);
                string jsonData = DecryptData(encryptedData);
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            }
            else
            {
                Debug.LogWarning("No save data found.");
                return new Dictionary<string, string>();
            }
        }
        
        public static void DeleteSaveData()
        {
            string filePath = Path.Combine(Application.persistentDataPath, SaveFileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Debug.Log("Save data deleted.");
            }
            else
            {
                Debug.LogWarning("No save data found to delete.");
            }
        }
        
        private static byte[] EncryptData(string data)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = key;
            aesAlg.IV = iv;
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msEncrypt = new MemoryStream();
            using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(data);
            }
            return msEncrypt.ToArray();
        }
        
        private static string DecryptData(byte[] encryptedData)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = key;
            aesAlg.IV = iv;
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            
            using MemoryStream msDecrypt = new MemoryStream(encryptedData);
            using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new StreamReader(csDecrypt);
            return srDecrypt.ReadToEnd();
        }
        
    }
}