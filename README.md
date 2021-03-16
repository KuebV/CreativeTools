# CreativeTools
Group of commands for Moderators and Admins alike.

## Utlity Commands
- Jail 
- Freeze
- Position
- Noclip

## Fun Commands
- Gravity
- Speed
- Jump Height
- Nicknames

## Command Info & Usage :
### Some of these commands are used in the Admin Panel, and some are in the textbox. 

### Jail Command (Admin Panel)

Jail is almost exactly how it works as in SCP:SL. It will teleport the target to the tower on surface.

The only changes are that the command sender also gets sent, and there must be a reason for sending a player to jail

Usage:
```jail (player name) (reason)```

Example:
```jail KuebV Hacking```

When typing the players name, only part of it has to be entered. As an example with my name KuebV

```jail kue Hacking```

### Freeze Command (Admin Panel)

Freeze is used as an alternative to Jail when Jail doesn't function correctly

Freeze does exactly what it says, it will freeze the player in place making them unable to move

Usage :
```freeze (player name) (reason)```

Example :
```freeze kueb Mic-Spam```

### Noclip Command (Text Chat)
If you have browsed through the Admin Panel previously, you know that there is already a noclip feature.

I found that to be slow and clunky.

Usage:
```/noclip (player name)``` **or** ```/noclip```

Example:
```/noclip kueb``` **or** ```/noclip```

The difference between selecting a user and not, is yourself. By just doing /noclip, it will select you rather than a different person


### Speed Command (Text Chat)
Ever wanted to speedrun?

Usage :
```/speed (walking/sprinting/crouching) (player name) (value)```

Example :
```/speed walking KuebV 5``` **or** ```/speed walking all 5```

That is correct, you can use `all` as a variable. Note, this has proved to be buggy. Use singlular players for better stability

### Gravity Command (Text Chat)
I couldn't think of any clever introductions

Usage:
```/gravity (get/reset/value)```

Example:
```/gravity -10``` **or** ```/gravity reset``` **or** ```/gravity get```

If you do `/gravity get` when you spawn. You'll see the default gravity is -19.62. I have no clue why. But it works


### Jump Height (Text Chat)
Jump, but higher

Usage :
```/jumpheight (value / reset)```

Example :
```/jumpheight 3``` **or** ```/jumpheight reset```

### Nicknames (Text Chat)
Rename someone or everyone

Usage :
```/nickname (player name / all) (name)```

Example :
```/nickname all Dr.Bright``` 

**There is no current way of changing nicknames back**

### Position (Text Chat)
Return the current coordinate position

Usage :
```/position```

Useful for Debugging Purposes

## Permissions

CreativeTools uses its own permissions.
- ct.gravity (is allowed to change gravity)
- ct.jail (allowed to jail)
- ct.freeze (allowed to freeze)
- ct.jump (allowed to change jump height)
- ct.nickname (allowed to change nicknames)
- ct.speed (allowed to use the speed command)
(Noclip doesn't have its own permission. It uses the default admin.noclip permission

## Q/A
- Why does Jail teleport me to nowhere?
**It's how SCPET does Seeding, unfortuantly I cannot fix this. If this happens, use freeze**

- Why are errors appearing in the console when running commands such as speed or nickname
**UnityObjects getting destroyed, this will be fixed in the near future**

