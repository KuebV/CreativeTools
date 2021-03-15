# CreativeTools
Group of commands for Moderators and Admins alike.

## Utlity Commands
- Jail / Freeze
- Noclip

## Fun Commands
- Gravity
- Speed


## Command Info & Usage :
## IMPORTANT : COMMANDS ARE RUN IN THE CHAT BOX. NOT ADMIN PANEL

### Jail Command

Jail is not how it usually works as in a game such as SCP:SL

Rather, it will freeze the player in their current location. And the Staff Member will teleport to them

Usage:
```/jail (player name) (reason)```

Example:
```/jail KuebV Hacking```

When typing the players name, only part of it has to be entered. As an example with my name KuebV

```/jail kue Hacking```

### Noclip Command
If you have browsed through the Admin Panel previously, you know that there is already a noclip feature.

I found that to be slow and clunky.

Usage:
```/noclip (player name)``` **or** ```/noclip```

Example:
```/noclip kueb``` **or** ```/noclip```

The difference between selecting a user and not, is yourself. By just doing /noclip, it will select you rather than a different person


### Speed Command
Ever wanted to speedrun?

Usage :
```/speed (walking/sprinting/crouching) (player name) (value)```

Example :
```/speed walking KuebV 5``` **or** ```/speed walking all 5```

That is correct, you can use `all` as a variable. Note, this has proved to be buggy. Use singlular players for better stability

### Gravity Command
I couldn't think of any clever introductions

Usage:
```/gravity (get/reset/value)```

Example:
```/gravity -10``` **or** ```/gravity reset``` **or** ```/gravity get```

If you do `/gravity get` when you spawn. You'll see the default gravity is -19.62. I have no clue why. But it works


## Permissions

CreativeTools uses its own permissions.
- ct.gravity (is allowed to change gravity)
- ct.jail (allowed to jail. Also need admin.teleport to work)
- ct.speed (allowed to use the speed command)
- 
(Noclip doesn't have its own permission. It uses the default admin.noclip permission

