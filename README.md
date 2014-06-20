**The Stomping Launcher** is a tool for the dinosaur survival game [The Stomping Land](http://www.thestompingland.com/) with the aim of making joining and hosting servers easier for those not familiar with command line parameters. It as well provides functionality for editing solo and server save files.

# Download: 

Current version (v0.3.2): https://github.com/chrmoritz/StompingLauncher/releases (57kb)

# Features:

### 1. Join Server by IP
* join every community/private server with only knowing their ip address or dns name/url
  * even if the server isn't listed in the server list
* manage a history/server list of your favorite community/private servers with the ability to:
  * set a description for every server
  * reorder and remove server from the list
  * connect to any server from your history
  * and of course add new server to your server list

![The Stomping Launcher join server tab](https://cloud.githubusercontent.com/assets/1686759/3336080/fa561e72-f822-11e3-9239-2ed76033a290.png)

### 2. Host your Own Server
* easily change your server configuration by (un)checking checkboxes:
  * enable/disable friendly fire, show all player names and remove dinosaurs
* simply edit host options like:
  * hostname, port, public (steam) visibility, steam query port and choose a custom configuration directory
  * change slots / max players counts
* ability to auto-join your server on startup (if you host it on a local PC)
* support for multiple server profiles (save and load your server configurations)
* Note: if you want your server be public available make sure you forward the port, port+1 and the steamQueryPort (all UDP) and have a steam client running on your computer (needed for server list visibility)

![The Stomping Launcher host server tab](https://cloud.githubusercontent.com/assets/1686759/3336083/fa8baa38-f822-11e3-9ba7-439d2395b567.png)

### 3. Savefile editor (Solo and Server)
* easily edit your solo / server savefiles and change your / your players:
  * location: teleport to your friends or to some waypoints
  * expertise (start with 200+), hunger, thirst (disable hunger completely)
  * herbs, arrows, robe (more than in game limits possible => nearly unlimited)
  * weapons equipped in each slot (multiple shields possible)
* select some predefined waypoint for teleportation or create your own waypoints in the waypoint manager
  * ships with predefined waypoints: waterfall cave, big water cave entrance/exit, vulcano (top and cave entrance), southern lake, western river mouth
  * add any of your / your players position as a custom waypoint for later use
* copy the values of one player to another (useful for teleportation or fast editing)
* auto start solo game after applying your changes

![The Stomping Launcher solo savefile editir](https://cloud.githubusercontent.com/assets/1686759/3336082/fa8b55d8-f822-11e3-96c2-3e68bac35306.png)
![The Stomping Launcher server savefile editor](https://cloud.githubusercontent.com/assets/1686759/3336084/fa8c13ec-f822-11e3-87a1-3add20b14b5a.png)
![The Stomping Launcher waypoint manager](https://cloud.githubusercontent.com/assets/1686759/3336085/fa8c2ddc-f822-11e3-9ce9-0f679d4bd2b5.png)

### 4. Other Features
* open source (under [GPL v3 license](LICENCE.txt))
  * don't hesitate to make a pull request and contribute code ;)
  * please report bugs in the [Issue Tracker](https://github.com/chrmoritz/StompingLauncher/issues)
* German translation
  * contribution of other translation are always welcome 
