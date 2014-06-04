**The Stomping Launcher** is a tool for the dinosaur survival game [The Stomping Land](http://www.thestompingland.com/) with the aim of making joining and hosting servers easier for those not familiar with command line parameters.

# Download: 

Current version (v0.1.1): https://github.com/chrmoritz/StompingLauncher/releases

# Features:

### 1. Join Server by IP
* join every community/private server with only knowing their ip address
  * even if the server isn't listed in the server list
* manage a history/server list of your favorite community/private servers with the ability to:
  * reorder and remove server from the list
  * connect to any server from your history
  * and of course add new server to your server list

![](https://github.com/chrmoritz/StompingLauncher/releases/download/0.1/sll2.png)


### 2. Host your Own Server
* easily change your server configuration by (un)checking checkboxes:
  * enable/disable friendly fire, show all player names and remove dinosaur
* simply edit host options like:
  * hostname, port, public (steam) visibility, steam query port and choose a custom configuration directory
* ability to auto-join your server on startup (if you host it on a local pc)
* support for multiple server profiles (save and load your server options)
* Note: if you want your server be public available make sure you forward the port and steamQueryPort and have a steam client running on your computer (needed for serverlist visibility)

![](https://github.com/chrmoritz/StompingLauncher/releases/download/0.1/sll1.png)

### 3. Start serverbased Singleplayer
* instead of playing in build-in solo modus play a serverbased singleplayer game with following advantages
  * working expertise and weapons saving
    * continue where you left the last time (Note: atm similar to current multiplayer games base and dinosaur saving isn't working)
  * ability to edit your server saves
    * you can cheat as many expertise/herbs/weapons as you want by editing UDK_TheStompingLand_Server.ini

### 4. Other Features
* open source (under [GPL v3 license](LICENCE.txt))
  * don't hesitate to make a pull request and contribute code ;)
  * please report bugs in the [Issue Tracker](https://github.com/chrmoritz/StompingLauncher/issues)
* German translation
  * contribution of other translation are welcome 
