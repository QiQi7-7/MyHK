An auxiliary mod for Hollow Knight, including three modules: BetterLogic, ExtraFeatures, and BugFixes. This can significantly optimize the gaming experience.


#  Instructions

- The dependencies of this mod are Satchel and HKTool, with Satchel version not lower than 0.8.12 and HKTool version not lower than 2.2.0.0.
- All of the following features are configurable in-game. If you are unclear about the relevant functions, it is recommended to keep the default settings.
- Some bugs have been fixed in GodSeekerPlus, so the mod does not fix them to avoid conflicts.
- When using this mod, if you encounter bugs caused by this mod or other bugs that you want to fix, please give me feedback. Bilibili：是柒不是七233, Discord：QiQi7, QQ group：599201137.



#  Features Introduction

##  1.BetterLogic

**The content related to this module is not a malicious bug, but it reflects the design shortcomings. All are on by default.**  

###  Feature list

- **HealthManagerFix**  
  - Description：Fixed damage loss due to frame rate. The invincibility time of enemies after being hit is now always 0.2s, regardless of frame rate.
  - Additional Notes：Turning on this feature will reduce the duration of Descending Dark's third stage by 0.02s to avoid one more damage. It is highly recommended to turn it on.

- **AbyssalShriekOptimization**  
  - Description：The direction of the Abyssal Shriek does not change with the change in the direction of the little knight.

- **HowlingWraithsOptimization**  
  - Description：Optimize the knockback mechanism of the Howling Wraiths to function like the Abyssal Shriek (repulsion to the left and attraction to the right) or to always knock back.

- **DoubleJumpOptimization**  
  - Description：You can use double jump immediately after attacking.

- **WarpOptimization**  
  - Description：This will cause some bosses to stop recoiling after teleporting, including Gorb, Soul Warrior, Elder Hu, and No Eyes.

- **DetectionOptimization**  
  - Description：Added a detection mechanism to some bosses to prevent certain objects from spawning directly on the player, including Hornet Sentinel's Spikes and the Radiance's Orbs.

- **HiveKnightOptimization**  
  - Description：After the death of the Hive Knight, all the Hivelings die。

- **SlyOptimization**  
  - Description：Adjusted Sly's Great Slash hitbox to make it more in line with the texture。



##  2.ExtraFeatures

**This module provides some Extra Features that can be used to assist in practice or actual combat. All are off by default.**  

###  Feature list

- **RemoveFreezeMoment**  
  - Description：Removed all freeze moment except for the player's injury.

- **ShowStunInfo**  
  - Description：Show stun hit max, stun combo, combo time.

- **ShowDestination**  
  - Description：Displays the destinations where all Dream Warriors move except Marmu.

- **TwoHitKills**  
  - Description：If an enemy cannot be killed with a single attack, its HP will be reduced to 1, which can be used for testing. This eliminates the need to use debug to adjust damage frequently, and avoids the problems that can be caused by using kill all.

- **RemoveForeground**  
  - Description：Removed part of the foreground in the Collector's Scene.

-------------------------------------------------------------------------------

##  3.BugFixes

**The content related to this module is a malicious bug, which reflects a serious design mistake and may significantly affect the gaming experience. All are on by default.**  

###  Feature list

- **CollisionFix**  
  - Description：Fixed several collision-related bugs (usually manifested as twitching and instant attack), such as Gruz Mother stucks in the corner, Collector grabs on the ground, Watcher Knight rolls instantly, etc.
  - Additional Notes：This bug is the most significant bug that affects the gaming experience, and it is an extremely serious design error. Fixes for some other bugs rely on this feature. It is highly recommended to turn it on.

- **MultiHitFix**  
  - Description：Fixed the bug where consecutive injuries caused invincibility time to be lost.

- **RoarFix**  
  - Description：It is now safe to skip Roar by opening the inventory. Collectors will cancel the roar when stagger.

- **StuckFix**  
  - Description：When the hitbox of some bosses overlaps with the terrain, it will pan the boss to prevent it from getting stuck outside the combat area, including Hornet Sentinel and Dung Defender.

- **StaggerFix**  
  - Description：Fixed some bosses's staggering-related bugs, including sliding while staggering (Broken Vessel, Sheo, Lost Kin), ending staggering early (Sheo, Sly), could not stagger Dung Defender normally after entering P2, staggering Pure Vessel while in the air retains its speed at that time, Pure Vessel may focus immediately after straggering.

- **AnimationFix**  
  - Description：Fixed a number of animations that caused stuck, such as using Descending Dark to fly after using the inventory to skip the roar, killing Soul Master while getting injured would cause the battle to not end, etc.
  - Additional Notes：It is a serious design mistake. It is recommended to turn it on (after it is turned off, you need to re-enter the archive to take effect).

- **RandomSelectionFix**  
  - Description：Fixed a bug where the boss would make abnormal moves during long battles, such as the Collector summoning three aspid in a row and the Radiance using Sword Wall continuously in P2.
  - Additional Notes：This is a serious design mistake, but it has little impact on the gaming experience. It is recommended to turn it on.

- **ItemRecyclingFix**  
  - Description：Fixed a bug where some objects could not be recycled correctly when switching scenes, such as Radiance's swords.
  - Additional Notes：This is a serious design mistake, but it has little impact on the gaming experience. It is recommended to turn it on.

- **InvincibleFix**  
  - Description：Fixed a bug where certain actions could keep the knight invincible.

- **FalseKnightFix**  
  - Description：Fixed known bugs of the False Knight, including shockwave getting bigger.

- **MassiveMossChargerFix**  
  - Description：Fixed known bugs of the Massive Moss Charger, including End charging early.

- **HornetProtectorFix**  
  - Description：Fixed known bugs of the Hornet Protector, including air dash at low altitudes.

- **DungDefenderFix**  
  - Description：Fixed known bugs of the Dung Defender, including slight deviation after landing, Special bursts are retained that should only be used at the beginning of P2.

- **双师傅修复**  
  - Description：Fixed known bugs of the Hornet Protector, including 奥罗冲刺斩会与各种攻击拼刀、马托在奥罗冲刺斩时不格挡、在另一位师傅仍在攻击时就释放剑技（逻辑之外的剑技）、p2剑技完全消失。

- **波波修复**  
  - Description：Fixed known bugs of the Hornet Protector, including 灵车漂移。

- **三螳螂修复**  
  - Description：Fixed known bugs of the Hornet Protector, including 螳螂领主左横冲刷脸、战斗姐妹p2结束后（进入两只螳螂的阶段）可能立刻进行攻击。

- **马尔穆修复**  
  - Description：Fixed known bugs of the Hornet Protector, including 急停霸体和反弹霸体。

- **虫母修复**  
  - Description：Fixed known bugs of the Hornet Protector, including 死亡后小吸虫不消失。

- **收藏家修复**  
  - Description：Fixed known bugs of the Hornet Protector, including 滚滚量子纠缠、蚊子霸体、蚊子虚空碰撞箱。

- **有翼诺斯克修复**  
  - Description：Fixed known bugs of the Hornet Protector, including 倒车。

- **二见修复**  
  - Description：Fixed known bugs of the Hornet Protector, including 低空斜冲、斜冲卡墙、无前摇冲刺。

- **白芬达修复**  
  - Description：Fixed known bugs of the Hornet Protector, including 落地后水平位移。

- **前辈修复**  
  - Description：Fixed known bugs of the Hornet Protector, including 免疫吸虫、地刺残留。

- **辐光修复**  
   Description：Fixed known bugs of the Hornet Protector, including 光球残留碰撞箱、自缚、剑雨残留、p4光球残留。

-------------------------------------------------------------------------------

