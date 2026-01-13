An assisting mod for HK featuring logic optimization, auxiliary functionality, bug fixes. This can improve the gaming experience significantly.



#  Instruction
- MOD dependency: Satchel (0.8.12 or later), HKTool (2.2.0.0 or later).
- All following functions can be configured in-game. If not sure about their function, it's suggested to keep them default.
- Some bugs that GodSeekerPlus fixes are not fixed in this mod to avoid conflicts.
- If you encounter any bug this mod causes or bugs you want this mod to fix while using this, feel free to report them. Contact: Discord: QiQi7; Bilibili: 是柒不是七233; QQ group: 599201137.



#  Introduction

##  1. Logic Optimization

**These are non-major glitches indicating design deficiency. All are enabled by default.** 

###  Feature List

- **Hitting Optimizations**
    - Description: Fixes missing hits caused by frame rate. Now enemies have a fixed 0.2s immune frame independent of frame rate.
    - Additional Note: Enabling this will also reduce the second burst of DDark by 0.2s to avoid it dealing multiple hits. After configuring this function, reload your save.

- **Abyss Shriek Optimization**
    - Description: Optimizes the knockback of Abyss Shriek so that it won't be affected by the change in player orientation for the duration.
    - Additional Note: After configuring this function, reload your save.

- **Howling Wraiths Optimization**
    - Description: Optimizes the knockback of Howling Wraiths so that it follows Abyss Shriek (Type1, LS pushes enemies and RS pulls enemies), or pushes enemies backwards no matter how (Type2).
    - Additional Note: After configuring this function, reload your save.

- **Double Jump Optimization**
    - Description: You can now instantly double jump upon a nail attack.

- **Teleport Optimization**
    - Description: Stop bosses from being knocked back upon teleport, including Gorb, Elder Hu, Soul Warrior, and No Eyes.

- **Detection Optimization**
    - Description: Add player detection for some boss attacks, including Hornet 2's spiked balls and Radiance's Orb.

- **Hive Knight Optimization**
    - Description: Kills all Hivelings upon Hive Knight's death.

- **Sly Optimization**
    - Description: Adjusts the Great Slash hitbox to better match the sprites.



##  2. Auxiliary Functionality

**These provide additional functions beneficial to practice and battles. All disabled by default.**

###  Feature List

- **Freezes Removal**
    - Description: Removes all freeze frames except those caused by the player getting hit.

- **Show Stagger Info**
    - Description: Shows cumulative stagger counter, combo stagger counter, and combo timer.

- **Show Moving Target**
    - Description: Shows all Dream Warriors' targets they're moving to, except Marmu.

- **Show Chasing Path**
    - Description: Show part of the chasing path aimed at the player, including Galien's scythe, Ooma's core, Marmu, Radiance's orbs.

- **2-Hit Kill**
    - Description: Kill enemies if able, otherwise set their health point to 1. Test friendly, avoiding Debug or Kill All issues.

- **Foreground Removal**
    - Description: Removes some foreground items in The Collector battleground.

- **Background Adjustment**
    - Description: Adjusts some background items in The Absolute Radiance battleground.



##  3. Bug Fixes

**These are major glitches reflecting serious design deficiencies. They may significantly affect the gaming experience. All are enabled by default.**

###  Feature List

- **Collision Fix**
    - Description: Fixes several bugs relevant to collision (usually presents as stuck behavior or no pre-cast anim), examples: Gruz Mother stucks on the wall; The Collector grabs without leaping ("sticky feet"); Watcher Knight bouncing rolls without curling into a ball.
    - Additional Note: This has the most significant impact on common gameplay and is an extremely serious design deficiency. Some of the bug fixes below also use this as a dependency. Very suggested to keep this enabled.

- **Multiple Hits Fix**
    - Description: Fixes the bug where multiple hits taken by the player in a short period cause immune frame losses.

- **Battlecry Fix**
    - Description: Saver inv menu battlecry cancel. The Collector will stop battlecry upon staggering.

- **Wall Collision Fix**
    - Description: When some bosses have their hitboxes collide with the battleground, this will move them to prevent them from being stuck outside (including Hornet 2 and Dung Defender).

- **Staggering Fix**
    - Description: Fixes some staggering-related bugs, including staggering slide (Broken Vessel, Sheo, and Lost Kin), instant exiting staggering (Sheo and Sly), Dung Defender's abnormal combo staggering loss, Pure Vessel's abnormal speed retaining when staggered in the air, and focusing during staggering.

- **Anim Fix**
    - Description: Fixes several stuck bugs caused by anim, such as floating after battlecry cancelling, Soul Master's stuck second phase.
    - Additional Note: After configuring this function, reload your save.

- **RNG Fix**
    - Description: Fixes the bug where bosses perform their attack abnormally in long fights, such as The Collector dropping 3 Aspids and Abs Radiance continuously summoning sword wall in plats phase.

- **Item Recycle Fix**
    - Description: Fixes the bug where some items aren't recycled successfully upon transition, such as Radiance's remaining sword burst.

- **Immune Fix**
    - Description: Fixes the bug where the player gets permanently immune by performing some certain moves.
    - Additional Note: After configuring this function, reload your save.

- **False Knight Fix**
    - Description: Fixes known bugs of False Knight, including abnormal shockwave scale.

- **Massive Moss Charger Fix**
    - Description: Fixes known bugs of Massive Moss Charger, including halfway burrowing.

- **Hornet 1 Fix**
    - Description: Fixes known bugs of Hornet 1, including low-altitude aerial lunge.

- **Dung Defender Fix**
    - Description: Fixes known bugs of Dung Defender, including horizontal movement after landing, and special diving retention in the second phase.

- **Nailmaster Brothers Fix**
    - Description: Fixes known bugs of Nailmaster Brothers, including Oro's Dash Slash parrying with various attacks, Mato not performing barricade when Oro Dash Slashes, unexpected nail art uses while another brother is attacking, and disappearing nail art in phase 2.

- **Oblobbles Fix**
    - Description: Fixes known bugs of Oblobbles, including unexpected movement when firing.

- **Mantis Lord Fix**
    - Description: Fixes known bugs of Mantis Lord, including left-dash mantis spawning despite the player's location (Mantis Lords) and instant attack upon one of the three defeated (Sisters of Battle).

- **Marmu Fix**
    - Description: Fixes known bugs of Marmu, including the knockback resistance while stopping suddenly and bouncing.

- **Flukemarm Fix**
    - Description: Fixes known bugs of Flukemarm, including Flukefeys not disappearing upon Flukemarm's death.

- **Collector Fix**
    - Description: Fixes known bugs of The Collector, including tangled Sharp Baldurs, the knockback resistance and the abnormal hitbox of Armored Squids.

- **Winged Nosk Fix**
    - Description: Fixes known bugs of Winged Nosk, including reverse swoop.

- **Hornet 2 Fix**
    - Description: Fixes known bugs of Hornet 2, including low-altitude aerial lunge, aerial lunge stuck on walls, and instant lunge.

- **White Defender Fix**
    - Description: Fixes known bugs of White Defender, including horizontal movement after landing.

- **Pure Vessel Fix**
    - Description: Fixes known bugs of Pure Vessel, including Flukenest immune and pillars remaining.

- **Radiance Fix**
    - Description: Fixes known bugs of Radiance, including remaining hitboxes of orbs, stuck behavior in plats phase, remaining sword rain, and remaining orb in final phase.


