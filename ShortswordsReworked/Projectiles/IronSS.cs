using Microsoft.Xna.Framework;
using System;
using System.Drawing.Printing;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace CSSRework.Projectiles
{
    public class IronSS: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.aiStyle = 0;
            projectile.penetrate = 1;
            projectile.scale = 1f;
            projectile.alpha = 0;

            projectile.friendly = true;
            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.tileCollide = false;
            projectile.melee = true;
            

        }

        public float movementFactor
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }

        public override void AI()
        {
            Player projOwner = Main.player[projectile.owner];

            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;


            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width/2 );//16 + (float)Math.Cos(projOwner.direction)*16;
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height/2);//16 - (float)Math.Sin(projOwner.direction)*16;

            if (!projOwner.frozen)
            {
                if(movementFactor == 0f)
                {
                    movementFactor = 7f;
                    projectile.netUpdate = true;
                }

                //projectile.position.X += (float)Math.Cos(projectile.direction) * projectile.velocity.X * movementFactor;
                //projectile.position.Y += (float)Math.Sin(projectile.direction) * projectile.velocity.Y * movementFactor;

                //if(projOwner.itemAnimation < projOwner.itemAnimationMax / 2)
                //{
                //    movementFactor = -6f;
                //}
                float angle=0;
                if (projectile.velocity.X < 0) 
                {
                    angle = (float)Math.PI + (float)Math.Atan(projectile.velocity.Y/projectile.velocity.X);
                }
                else
                {
                    if (projectile.velocity.Y < 0)
                    {
                        angle = (float)Math.PI*2 + (float)Math.Atan(projectile.velocity.Y / projectile.velocity.X);
                    }
                    else
                    {
                        angle = (float)Math.Atan(projectile.velocity.Y / projectile.velocity.X);
                    }
                }
                if(angle <0)
                {
                    angle =(float) Math.PI + angle;
                }
                if (projOwner.direction == 1)
                {
                    if (angle >= Math.PI || angle <= Math.PI * 2)
                    {
                        projectile.position.X += (float)Math.Cos(projectile.direction) * projectile.velocity.X * movementFactor;
                        projectile.position.Y += (float)Math.Sin(projectile.direction) * projectile.velocity.Y * movementFactor;
                    }
                    else
                    {
                        projectile.position.X += (float)Math.Cos(projectile.direction) * projectile.velocity.X * movementFactor;
                        projectile.position.Y -= (float)Math.Sin(projectile.direction) * projectile.velocity.Y * movementFactor;
                    }
                }
                else
                {
                    if (angle >= Math.PI || angle <= Math.PI * 2)
                    {
                        projectile.position.X += (float)Math.Cos(projectile.direction) * projectile.velocity.X * movementFactor;
                        projectile.position.Y -= (float)Math.Sin(projectile.direction) * projectile.velocity.Y * movementFactor;
                    }
                    else
                    {
                        projectile.position.X += (float)Math.Cos(projectile.direction) * projectile.velocity.X * movementFactor;
                        projectile.position.Y += (float)Math.Sin(projectile.direction) * projectile.velocity.Y * movementFactor;
                    }
                }
                projOwner.direction = projectile.direction;
                if (projOwner.itemAnimation <= 0)
                {
                    projectile.Kill();
                }
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
                //if(projectile.spriteDirection == -1)
                //{
                //    projectile.rotation -= MathHelper.ToRadians(90f);
                //}
            }
        }
        
    }


    


}