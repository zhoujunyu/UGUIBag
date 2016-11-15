using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EquitBag.Items;
using EquitBag.Base;
using System.IO;
using UnityEngine.UI;
using System;


namespace Equitbag.Manager
{

    public class KnapsackManager : MonoBehaviour
    {

        GameObject item;
        public GameObject[] UCells; //包裹格子
        public  Dictionary<int, BaseItem> ItemDictionary = new Dictionary<int, BaseItem>();
        public bool find = false;
        

        void Start()
        {
            string FileAddress = System.IO.Path.Combine(Application.streamingAssetsPath + "/", "EnquitmentConfig.txt");

            
            DataInit(FileAddress);

            for (int i = 0; i < ItemDictionary.Count; i++)
            {
                Debug.Log(" " + ItemDictionary[i].getMessage());
            }
        }

        public void DataInit(string address)
        {
            if (!File.Exists(address))
            {
                EquitmentConfig.Instance().Initial();
            }
            if (File.Exists(address))
            {
                File.Delete(address);
                EquitmentConfig.Instance().Initial();
                StreamReader sr = new StreamReader(address,System.Text.Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Debug.Log(line);
                    string[] sArray = line.Split(' ');

                    try
                    {
                        switch (sArray[1])
                        {
                            case "Weapons":
                                {
                                    ItemDictionary.Add(Convert.ToInt32(sArray[0]), new Weapons(Convert.ToInt32(sArray[0]), sArray[1], sArray[2], sArray[3], Convert.ToInt32(sArray[4]), Convert.ToInt32(sArray[5]), sArray[6], Convert.ToInt32(sArray[7])));
                                    break;
                                }

                            case "Armors":
                                {
                                    ItemDictionary.Add(Convert.ToInt32(sArray[0]), new Armors(Convert.ToInt32(sArray[0]), sArray[1], sArray[2], sArray[3], Convert.ToInt32(sArray[0]), Convert.ToInt32(sArray[0]), sArray[6], Convert.ToInt32(sArray[0])));
                                    break;
                                }
                            case "Consumables":
                                {
                                    break;
                                }
                            default:
                                break;


                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e);
                    }
                }
                sr.Close();
            }
        }


        void Update()
        {

            if (Input.GetKeyDown(KeyCode.X))
            {
                
               
                int index = UnityEngine.Random.Range(0,ItemDictionary.Count);
                Debug.Log("------" + index);
                Pickup(ItemDictionary[index]);
            }
        }

        public void Pickup(BaseItem ba)

        {
            find = false;
   

            for (int i = 0; i <UCells.Length;i++)
            {
                if (UCells[i].transform.childCount > 0)
                {
                    if (ba.Name == UCells[i].transform.GetChild(0).GetComponent<Image>().overrideSprite.name)
                    {
                        string index = UCells[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
                        UCells[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = (int.Parse(index) + 1).ToString();
                        find = true;
                        break;
                    }
                }
            }
            if (!find)
            {
                for (int i = 0; i < UCells.Length; i++)
                {
                    if (UCells[i].transform.childCount == 0)
                    {
                        item = (GameObject)Instantiate(Resources.Load("Prefabs/UItem"), transform.position, transform.rotation);
                        Image image = item.GetComponent<Image>();
                        image.sprite = (Sprite)Resources.Load(ba.Icon, typeof(Sprite));
                        item.transform.SetParent(UCells[i].transform);
                        item.transform.localScale = Vector3.one;
                        item.transform.localPosition = new Vector3(0,4,0);
                        break;
                    }
                }
            }
        }
    }

}
