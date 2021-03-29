using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p1 = new Program();

            //get all keys  in dictionary
            var allKeys = p1.GetDictionaryKeys();
            Console.WriteLine("Keys:");
            foreach (var key in allKeys)
            {
                //Console.WriteLine(string.Join(",", allKeys.Keys));
                Console.WriteLine(key.Key);
            }


            //Get all values from a dictionary
            List<string> allValues = p1.GetAllValues(allKeys);            
            Console.WriteLine("All members......" + string.Join(", ", allValues));


            //Get all Keys and values
            Dictionary<string, List<string>> allMembers = p1.GetAllKeysAndValues(allKeys);
            Console.WriteLine("----------------------");
            Console.WriteLine("Keys & Values");
            Console.WriteLine("----------------------");
            foreach (var kvp in allMembers)
            {
                Console.WriteLine(kvp.Key + " => [" + string.Join(", ", kvp.Value) + "]");
            }

            //get values for a specified key
            string inputKey = "fruits";
            var valuesforKey = p1.GetstringvaluesforKey(allKeys, inputKey);
            if (valuesforKey.Count != 0)
            {
                foreach (var val in valuesforKey)
                {
                    Console.WriteLine(inputKey + " =>" + string.Join(",", val));
                }
            }
            else
            {
                Console.WriteLine(inputKey + " key does not exists");
            }

            //add value to existing key   
            string inputValue = "cherry";
            List<string> listVal = p1.AddvaluetoKey(allKeys, inputKey, inputValue);

            foreach (var item in listVal)
            {
                Console.WriteLine(string.Join(",", item));
            }

            //check whether key exists in a dictinary or not            
            if (p1.CheckKey(allKeys, inputKey))
                Console.WriteLine("key Exists");
            else
                Console.WriteLine("key does not Exists");

            //check value exists for a key or not
            if (p1.CheckValueExistsforKey(allKeys, inputKey, inputValue))
                Console.WriteLine("Value Exists");
            else
                Console.WriteLine("Value does not Exists");
           

            //remove a value from a key

            List<string> listVal1 = p1.RemovevalByKey(allKeys, inputKey, inputValue);
            foreach (var item in listVal1)
            {
                Console.WriteLine(string.Join(",", item));
            }

            //Remove all from dictionary
            //p1.RemoveAll(allKeys);




        }

        //private Dictionary<string, List<string>> GetDictionaryKeys()
        //{
        //    Dictionary<string, List<string>> dic1 = new Dictionary<string, List<string>>();
        //    dic1.Add("foo", new List<string> { "foo bar1" });
        //    dic1.Add("baz", new List<string> { "baz bang1", "baz bang2" });

        //    return dic1;
        //}

        private Dictionary<string, List<string>> GetDictionaryKeys()
        {
            Dictionary<string, List<string>> dic1 = new Dictionary<string, List<string>>();
            dic1.Add("fruits", new List<string> { "apple,banana,berries,grapes,tomato,banana" });
            dic1.Add("vegetables", new List<string> { "carrot,beetroot,celery,tomato" });
            

            return dic1;
        }

        //return collection of string for a given key
        private List<string> GetstringvaluesforKey(Dictionary<string, List<string>> dict, string key)
        {
            List<string> result = new List<string>();
            bool exists;

            //if key contains only then inside code of if block is executed
            if (dict.ContainsKey(key))
            {
                exists = dict.TryGetValue(key, out result);
            }
            return result;
        }

        private List<string> AddvaluetoKey(IDictionary<string, List<string>> dict, string key, string val)
        {
            List<string> lstValues = new List<string>();
            if (dict.ContainsKey(key))
            {               

                dict.TryGetValue(key, out lstValues);
                if (lstValues.Contains(val))
                {
                    Console.WriteLine(val + "already exists in given key");
                }
                else
                {
                    lstValues.Add(val);
                    
                }
                

            }
            else
            {
                Console.WriteLine("Key does not exists");
            }
            return lstValues;

        }

        //remove value from dictionary by Key
        private List<string> RemovevalByKey(Dictionary<string, List<string>> dict, string key, string val)
        {
            List<string> result = new List<string>();
            if (dict.ContainsKey(key))
            {
                bool exists = dict.TryGetValue(key, out result);
            }

            if (result.Count != 0)
            {
                if (result.Contains(val))
                {
                    result.Remove(val);

                    //if value is the last value for that key in dictionary then removing that key from dic
                    if (result.Count == 0)
                    {
                        dict.Remove(key);
                    }
                }

                else
                {
                    Console.WriteLine(val + "does not exits for the key " + key);
                }
            }
            else
            {
                Console.WriteLine("No Key found");
            }
            return result;


        }


        //Method to remove all keys and values in dictionary
        private void RemoveAll(Dictionary<string, List<string>> dict)
        {
            dict.Clear();
            Console.WriteLine(dict.Count);
        }

        //method to return a key exists or not

        private bool CheckKey(Dictionary<string, List<string>> dict, string key)
        {

            bool isExists = dict.ContainsKey(key);
            return isExists;
        }

        //method to return a value exists in a key or not

        private bool CheckValueExistsforKey(Dictionary<string, List<string>> dict, string key, string value)
        {
            bool isKeyExists = dict.ContainsKey(key);
            bool isValExists = false;

            if (isKeyExists)
            {
                //isValExists = dict.Contains(KeyValuePair<key, value>);
                dict.TryGetValue(key, out List<string> value1);
                isValExists = value1.Contains(value);
            }
            return isValExists;
        }

        //return all values in dictionary
        private List<string> GetAllValues(Dictionary<string, List<string>> dict)
        {
            //List<string> result = new List<string>();
            
            var allValues = dict.SelectMany(d => d.Value).ToList();           
           
            return allValues;
        }

        //Get all Keys and values
        private Dictionary<string, List<string>> GetAllKeysAndValues(Dictionary<string, List<string>> dict)
        {
            return dict;
        }


    }
}
