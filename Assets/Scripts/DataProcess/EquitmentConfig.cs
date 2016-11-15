using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EquitBag.Items;
using EquitBag.Base;
using System.IO;
using System;

public class EquitmentConfig  {
    private static EquitmentConfig instance = null;
    private string FileAddress = System.IO.Path.Combine(Application.streamingAssetsPath + "/", "EnquitmentConfig.txt");
    private List<BaseItem> equitMentSetting;

    private EquitmentConfig(BaseItem[] item)
    {
        this.equitMentSetting = new List<BaseItem>();
        this.equitMentSetting.AddRange(item);
    }

    public static EquitmentConfig Instance()
    {
       
            if (instance == null)
            {
                
                BaseItem[] itemList = new BaseItem[]{new Weapons(0, "Weapons","Entropy", "ceshiceshi", 20, 10, "Pictures/Entropy", 30),
                new Weapons(1, "Weapons","Guinsoo_Rageblade", "ceshiceshi", 20, 10, "Pictures/Guinsoo_Rageblade", 30),
                new Weapons(2,"Weapons", "Infinity_Edge", "ceshiceshi", 20, 10, "Pictures/Infinity_Edge", 30),
                new Weapons(3,"Weapons", "Rod_Of_Ages", "ceshiceshi", 20, 10, "Pictures/Rod_Of_Ages", 30),
                new Weapons(4,"Weapons", "Rylai_Crystal_Scepter", "ceshiceshi", 20, 10, "Pictures/Rylai_Crystal_Scepter", 30),
                new Weapons(5, "Weapons","Sheen", "ceshiceshi", 20, 10, "Pictures/Sheen", 30),
                new Weapons(6, "Weapons","Trinity_Force", "ceshiceshi", 20, 10, "Pictures/Trinity_Force", 30),
                new Armors(7, "Armors","Frozen_Heart", "ceshiceshi", 20, 10, "Pictures/Frozen_Heart", 30),
                 new Armors(8, "Armors","Guardian_Angle", "ceshiceshi", 20, 10, "Pictures/Guardian_Angle", 30),
                 new Armors(9, "Armors","Spirit_Visage", "ceshiceshi", 20, 10, "Pictures/Spirit_Visage", 30),
                 new Armors(10, "Armors","Boots_of_Mobility", "ceshiceshi", 20, 10, "Pictures/Boots_of_Mobility", 30),
                 new Armors(11, "Armors","Boots_of_Swiftness", "ceshiceshi", 20, 10, "Pictures/Boots_of_Swiftness", 30)

                };
                 instance = new EquitmentConfig(itemList);
         
            };

            return instance;
      

            
        }

    public void Initial()
    {
        if (equitMentSetting != null)
        {
            FileStream fs = new FileStream(FileAddress,FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < equitMentSetting.Count; i++)
            {
                if (i != 0)
                {
                    sw.Write(Environment.NewLine);
                }
                sw.Write(equitMentSetting[i].getMessage());
            }
          
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
        
 }

