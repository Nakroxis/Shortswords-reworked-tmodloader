﻿using Terraria;
using Terraria.Localization;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using System.Linq;
using CSSRework;
namespace CSSRework
{
    public class IronShortsword : GlobalItem
    {
       /* public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
           if(item.type == ItemID.CopperShortsword)
            {
                tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.mod == "Terraria");
                if(line != null)
                {
                    line.text = "New and improved!";
                }
                
            }
            
        }*/

        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.IronShortsword)
            {
                item.damage = 8;
                item.crit = 4;
                item.useTime = 12;
                item.autoReuse = false;
                item.melee = true;
                item.noMelee = true;
                item.useStyle = ItemUseStyleID.HoldingOut;
                item.noUseGraphic = true;
                item.shoot = ProjectileType<Projectiles.IronSS>();
                item.shootSpeed = 3f;
                item.useAnimation = 12;
            }
        }
    }

}


